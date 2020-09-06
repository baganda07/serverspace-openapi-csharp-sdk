using Serverspace.OpenApi;
using Serverspace.OpenApi.Exceptions;
using Serverspace.OpenApi.Models;
using Serverspace.OpenApi.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithServerspaceOpenApiSdk
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // need to delete
            SshKey createdSshKey = null;
            VstackIsolatedNetwork isolatedNetwork = null;
            VstackVm vm = null;

            Console.WriteLine("Enter api key");
            string apiKey = Console.ReadLine();

            var client = ClientFactory.GetClientBetta("https://api.serverspace.io/", apiKey);

            try
            {
                await ShowAccountInfo(client);
                await ShowSshKeys(client);
                createdSshKey = await CreateSshKey(client);
                await ShowSshKey(client, createdSshKey.Id);

                await ShowVms(client);
                vm = await CreateVm(client, createdSshKey);
                //await ShowVm(client, vm.Id);
                //await VmPowerOff(client, vm.Id);
                //await VmPowerOn(client, vm.Id);
                //await VmShutdown(client, vm.Id);
                //await VmPowerOn(client, vm.Id);
                //await VmReboot(client, vm.Id);
                //await VmRestart(client, vm.Id);
                //await VmChangeConfig(client, vm.Id);

                //await ShowDisks(client, vm.Id);
                //VstackVmDisk disk =  await AddDisk(client, vm.Id);
                //await ChangeDisk(client, vm.Id, disk);
                //await ShowDisks(client, vm.Id);
                //await DeleteDisk(client, vm.Id, disk.Id);





                //await ShowIsolatedNetworks(client);
                //isolatedNetwork = await CreateIsolatedNetworks(client);
                //await EditIsolatedNetwork(client, isolatedNetwork);
                //isolatedNetwork = await CreateIsolatedNetworks(client);

            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            try
            {
                await DeleteSshKeys(client, createdSshKey);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            try
            {
                await DeleteIsolatedNetwork(client, isolatedNetwork);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            try
            {
                await DeleteVm(client, vm);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

        }

        private static async Task DeleteVm(ClientBetta client, VstackVm vm)
        {
            if (vm == null)
                return;

            await client.Context.DeleteVstackVm(vm.Id);

            Console.WriteLine($"vm {vm.Name} - DELETED");
        }

        private static async Task<VstackVm> CreateVm(ClientBetta client, SshKey createdSshKey)
        {
            var locations = await client.Context.GetVstackLocations();
            var location = locations.First(x => x.TechTitle == "am2");

            var images = await client.Context.GetVstackImages();
            var image = images.First(x => x.LocationId == location.Id & x.Name == "Ubuntu");

            var configurations = await client.Context.GetVstackConfigurations();
            var configuration = configurations.Where(x => x.LocationId == image.LocationId && x.OsFamily == image.Name).OrderBy(x => x.Price).First();

            var jobResult = await client.Context.CreateVstackVm(new CreateVstackVm(
                configurationId: configuration.Id,
                imageId: image.Id,
                name: "created-from-api",
                new List<int>() { createdSshKey.Id }
                ));

            VstackTask job = null;
            Console.Write($"Job id {jobResult.TaskId} started: ");
            do
            {
                Console.Write(".");
                Thread.Sleep(new TimeSpan(0, 0, 1));

                job = await client.Context.GetVstackTask(jobResult.TaskId);
            } while (job.IsCompleted == false);

            Console.WriteLine();
            Console.WriteLine($"Job id {jobResult.TaskId} completed");

            var vm = await client.Context.GetVstackVm(job.VmId);


            Console.WriteLine($"vm name: {vm.Name} - CREATED");
            return vm;
        }

        private static async Task ShowVms(ClientBetta client)
        {
            var vms = (await client.Context.GetVstackVms()).ToList();
            Console.Write($"You have {vms.Count} vms");
            if (vms.Count > 0)
            {
                for (int i = 0; i < vms.Count; i++)
                {
                    var vm = vms[i];
                    // first record
                    if (i == 0)
                    {
                        Console.Write($": {vm.Name}");
                        continue;
                    }

                    Console.Write($", {vm.Name}");

                }
                Console.WriteLine();
            }
        }

        private static async Task DeleteIsolatedNetwork(ClientBetta client, VstackIsolatedNetwork isolatedNetwork)
        {
            if (isolatedNetwork == null)
                return;

            await client.Context.DeleteVstackIsolatedNetwork(isolatedNetwork.Id);

            Console.WriteLine($"network name: {isolatedNetwork.Name} - DELETED");
        }

        private static async Task EditIsolatedNetwork(ClientBetta client, VstackIsolatedNetwork isolatedNetwork)
        {
            Console.WriteLine($"Edit network {isolatedNetwork.Name}");
            await client.Context.EditVstackIsolatedNetwork(isolatedNetwork.Id,
                new EditVstackIsolatedNetwork(isolatedNetwork.Name + "(edited)", isolatedNetwork.Description + "(edited)"));
            Console.WriteLine($"Edit network {isolatedNetwork.Name} - COMPLETED");
        }

        private static async Task<VstackIsolatedNetwork> CreateIsolatedNetworks(ClientBetta client)
        {
            var locations = await client.Context.GetVstackLocations();
            var location = locations.First();

            var jobResult = await client.Context.CreateVstackIsolatedNetwork(new CreateVstackIsolatedNetwork(
                locationId: location.Id,
                name: "FromApi",
                description: "Nework created from api request",
                ipV4Address: "10.0.0.0",
                ipV4Mask: 32));

            VstackTask job = null;
            Console.Write($"Job id {jobResult.TaskId} started: ");
            do
            {
                Console.Write(".");
                Thread.Sleep(new TimeSpan(0, 0, 1));

                job = await client.Context.GetVstackTask(jobResult.TaskId);
            } while (job.IsCompleted == false);

            Console.WriteLine();
            Console.WriteLine($"Job id {jobResult.TaskId} completed");

            var network = await client.Context.GetVstackIsolatedNetwork(job.NetworkId);


            Console.WriteLine($"network name: {network.Name} - CREATED");
            return network;
        }

        private static async Task ShowIsolatedNetworks(ClientBetta client)
        {
            var networks = (await client.Context.GetVstackIsolatedNetworks()).ToList();
            Console.Write($"You have {networks.Count} isolated networks");
            if (networks.Count > 0)
            {
                for (int i = 0; i < networks.Count; i++)
                {
                    var network = networks[i];
                    // first record
                    if (i == 0)
                    {
                        Console.Write($": {network.Name}");
                        continue;
                    }

                    Console.Write($", {network.Name}");

                    //last record
                    if (i == networks.Count - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        private static async Task ShowSshKey(ClientBetta client, int keyId)
        {
            var key = await client.Context.GetSshKey(keyId);

            Console.WriteLine($"ssh key id: {key.Id} Name: {key.Name}");
        }

        private static void ShowException(Exception ex)
        {
            Console.WriteLine("EXCEPTION:");
            Console.WriteLine(ex.ToString());
        }

        private static async Task DeleteSshKeys(ClientBetta client, SshKey createdSshKey)
        {
            if (createdSshKey == null)
                return;

            await client.Context.DeleteSshKey(createdSshKey.Id);

            Console.WriteLine($"ssh key {createdSshKey.Name} - DELETED");
        }

        private static async Task<SshKey> CreateSshKey(ClientBetta client)
        {
            var key = await client.Context.CreateSshKey(new Serverspace.OpenApi.Models.CreateSshKey(
                "Created From Api",
                @"ecdsa-sha2-nistp256 AAAAE2VjZHNhLXNoYTItbmlzdHAyNTYAAAAIbmlzdHAyNTYAAABBBE6hH8ahRHd1gO9gLtFzpRLTS0+xtI7fBkJLtuDK1SOsW1IsgNKQjCSeHp7FjATdcBuykalX95DDPFCvyt34IIc= ecdsa-key-20200904"));

            Console.WriteLine($"ssh key {key.Name} - CREATED");
            return key;
        }

        private static async Task ShowSshKeys(ClientBetta client)
        {
            var sshKeys = (await client.Context.GetSshKeys()).ToList();
            Console.Write($"You have {sshKeys.Count} ssh-keys");
            if (sshKeys.Count > 0)
            {
                for (int i = 0; i < sshKeys.Count; i++)
                {
                    var sshKey = sshKeys[i];
                    // first record
                    if (i == 0)
                    {
                        Console.Write($": {sshKey.Name}");
                        continue;
                    }

                    Console.Write($", {sshKey.Name}");

                    //last record
                    if (i == sshKeys.Count - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        private static async Task ShowAccountInfo(ClientBetta client)
        {
            var accountInfo = await client.Context.GetProjectDetailingAsync();
            Console.WriteLine($"Hello id:{accountInfo.Id}, your balance:{accountInfo.Balance}");
        }
    }
}
