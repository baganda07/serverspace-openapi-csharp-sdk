using Serverspace.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Serverspace.OpenApi.Network
{
    public class ContextBetta : BaseContext
    {
        #region endpoints

        private static string EndpointProjectDetailing = "/api/v1/projects/self";

        private static string EndpointSshKeys = "api/v1/ssh-keys";
        private static string EndpointSshKey = "api/v1/ssh-keys/{0}";

        private static string EndpointVstackTask = "api/v1/vstack/tasks/{0}";

        private static string EndpointVstackLocations = "api/v1/vstack/locations";

        private static string EndpointVstackConfigurations = "api/v1/vstack/configurations";

        private static string EndpointVstackImages = "api/v1/vstack/images";

        private static string EndpointVstackVms = "api/v1/vstack/vms";
        private static string EndpointVstackVm = "api/v1/vstack/vms/{0}";

        private static string EndpointVstackVmPowerOn = "api/v1/vstack/vms/{0}/power/on";
        private static string EndpointVstackVmPowerOff = "api/v1/vstack/vms/{0}/power/off";
        private static string EndpointVstackVmShutdown = "api/v1/vstack/vms/{0}/power/shutdown";
        private static string EndpointVstackVmReboot = "api/v1/vstack/vms/{0}/power/reboot";
        private static string EndpointVstackVmReset = "api/v1/vstack/vms/{0}/power/reset";

        private static string EndpointVstackVmDisks = "api/v1/vstack/vms/{0}/disks";
        private static string EndpointVstackVmDisk = "api/v1/vstack/vms/{0}/disks/{1}";
        
        private static string EndpointVstackVmNics = "api/v1/vstack/vms/{0}/nics";
        private static string EndpointVstackVmNic = "api/v1/vstack/vms/{0}/nics/{1}";

        private static string EndpointVstackIsolatedNetworks = "api/v1/vstack/networks/private";
        private static string EndpointVstackIsolatedNetwork = "api/v1/vstack/networks/private/{0}";

        #endregion

        public ContextBetta(IClient client) : base(client) {}


        public async Task<ProjectDetailing> GetProjectDetailingAsync()
        {
            var responce = await Client.SendGetRequestAsync<ProjectDetailing>(EndpointProjectDetailing).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<ICollection<SshKey>> GetSshKeys()
        {
            var responce = await Client.SendGetRequestAsync<ICollection<SshKey>>(EndpointSshKeys).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<SshKey> CreateSshKey(CreateSshKey createSshKey)
        {
            var responce = await Client.SendPostRequestAsync<CreateSshKey, SshKey>(EndpointSshKeys, createSshKey).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<SshKey> GetSshKey(int id)
        {
            var endpoint = string.Format(EndpointSshKey, id);
            var responce = await Client.SendGetRequestAsync<SshKey>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task DeleteSshKey(int id)
        {
            var endpoint = string.Format(EndpointSshKey, id);
            await Client.SendDeleteRequestAsync(endpoint).ConfigureAwait(false);
        }

        public async Task<VstackTask> GetVstackTask(int id)
        {
            var endpoint = string.Format(EndpointVstackTask, id);
            var responce = await Client.SendGetRequestAsync<VstackTask>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<ICollection<VstackLocation>> GetVstackLocations()
        {
            var responce = await Client.SendGetRequestAsync<ICollection<VstackLocation>>(EndpointVstackLocations).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<ICollection<VstackConfiguration>> GetVstackConfigurations()
        {
            var responce = await Client.SendGetRequestAsync<ICollection<VstackConfiguration>>(EndpointVstackConfigurations).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<ICollection<VstackImage>> GetVstackImages()
        {
            var responce = await Client.SendGetRequestAsync<ICollection<VstackImage>>(EndpointVstackImages).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<ICollection<VstackVm>> GetVstackVms()
        {
            var responce = await Client.SendGetRequestAsync<ICollection<VstackVm>>(EndpointVstackVms).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackTaskResult> CreateVstackVm(CreateVstackVm createVstackVm)
        {
            var responce = await Client.SendPostRequestAsync<CreateVstackVm, VstackTaskResult>(EndpointVstackVms, createVstackVm).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackVm> GetVstackVm(int id)
        {
            var endpoint = string.Format(EndpointVstackVm, id);
            var responce = await Client.SendGetRequestAsync<VstackVm>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackTaskResult> EditVstackVm(int id, EditVstackVm editVstackVm)
        {
            var endpoint = string.Format(EndpointVstackVm, id);
            var responce = await Client.SendPutRequestAsync<EditVstackVm, VstackTaskResult>(endpoint, editVstackVm).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task DeleteVstackVm(int id)
        {
            var endpoint = string.Format(EndpointVstackVm, id);
            await Client.SendDeleteRequestAsync(endpoint).ConfigureAwait(false);
        }

        public async Task<VstackTaskResult> PowerOnVstackVm(int id)
        {
            var endpoint = string.Format(EndpointVstackVmPowerOn, id);
            var responce = await Client.SendPostRequestAsync<VstackTaskResult>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackTaskResult> ShutdownVstackVm(int id)
        {
            var endpoint = string.Format(EndpointVstackVmPowerOff, id);
            var responce = await Client.SendPostRequestAsync<VstackTaskResult>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackTaskResult> ShutdownViaOsVstackVm(int id)
        {
            var endpoint = string.Format(EndpointVstackVmShutdown, id);
            var responce = await Client.SendPostRequestAsync<VstackTaskResult>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackTaskResult> RebootVstackVm(int id)
        {
            var endpoint = string.Format(EndpointVstackVmReboot, id);
            var responce = await Client.SendPostRequestAsync<VstackTaskResult>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackTaskResult> ResetVstackVm(int id)
        {
            var endpoint = string.Format(EndpointVstackVmReset, id);
            var responce = await Client.SendPostRequestAsync<VstackTaskResult>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<ICollection<VstackVmDisk>> GetVstackVmDisks(int vmId)
        {
            var endpoint = string.Format(EndpointVstackVmDisks, vmId);
            var responce = await Client.SendPostRequestAsync<ICollection<VstackVmDisk>>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackTaskResult> CreateVstackVmDisk(int vmId, CreateVstackVmDisk createVstackDiskVm)
        {
            var endpoint = string.Format(EndpointVstackVmDisks, vmId);
            var responce = await Client.SendPostRequestAsync<CreateVstackVmDisk, VstackTaskResult>(endpoint, createVstackDiskVm).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackVmDisk> GetVstackVmDisk(int vmId, int diskId)
        {
            var endpoint = string.Format(EndpointVstackVmDisk, vmId, diskId);
            var responce = await Client.SendPostRequestAsync<VstackVmDisk>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackTaskResult> EditVstackVmDisk(int vmId, int diskId, EditVstackVmDisk editVstackVmDisk)
        {
            var endpoint = string.Format(EndpointVstackVmDisk, vmId, diskId);
            var responce = await Client.SendPutRequestAsync<EditVstackVmDisk, VstackTaskResult>(endpoint, editVstackVmDisk).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task DeleteVstackVmDisk(int vmId, int diskId)
        {
            var endpoint = string.Format(EndpointVstackVmDisk, vmId, diskId);
            await Client.SendDeleteRequestAsync(endpoint).ConfigureAwait(false);
        }

        public async Task<ICollection<VstackVmNic>> GetVstackVmNics(int vmId)
        {
            var endpoint = string.Format(EndpointVstackVmNics, vmId);
            var responce = await Client.SendPostRequestAsync<ICollection<VstackVmNic>>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackTaskResult> CreateVstackVmNic(int vmId, CreateVstackVmNic createVstackVmNic)
        {
            var endpoint = string.Format(EndpointVstackVmNics, vmId);
            var responce = await Client.SendPostRequestAsync<CreateVstackVmNic, VstackTaskResult>(endpoint, createVstackVmNic).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackVmNic> GetVstackVmNic(int vmId, int nicId)
        {
            var endpoint = string.Format(EndpointVstackVmNic, vmId, nicId);
            var responce = await Client.SendPostRequestAsync<VstackVmNic>(endpoint).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task DeleteVstackVmNic(int vmId, int nicId)
        {
            var endpoint = string.Format(EndpointVstackVmNic, vmId, nicId);
            await Client.SendDeleteRequestAsync(endpoint).ConfigureAwait(false);
        }

        public async Task<ICollection<VstackIsolatedNetwork>> GetVstackIsolatedNetworks()
        {
            var responce = await Client.SendPostRequestAsync<ICollection<VstackIsolatedNetwork>>(EndpointVstackIsolatedNetworks).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackTaskResult> CreateVstackIsolatedNetwork(CreateVstackIsolatedNetwork createVstackIsolatedNetwork)
        {
            var responce = await Client.SendPostRequestAsync<CreateVstackIsolatedNetwork, VstackTaskResult>(EndpointVstackIsolatedNetworks, createVstackIsolatedNetwork).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<VstackIsolatedNetwork> GetVstackIsolatedNetwork(int id)
        {
            var endpoint = string.Format(EndpointVstackIsolatedNetwork, id);
            var responce = await Client.SendPostRequestAsync<VstackIsolatedNetwork>(endpoint).ConfigureAwait(false);
            return responce?.Data;

        }

        public async Task<VstackIsolatedNetwork> EditVstackIsolatedNetwork(int id, EditVstackIsolatedNetwork editVstackIsolatedNetwork)
        {
            var endpoint = string.Format(EndpointVstackIsolatedNetwork, id);
            var responce = await Client.SendPutRequestAsync<EditVstackIsolatedNetwork, VstackIsolatedNetwork>(endpoint, editVstackIsolatedNetwork).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task DeleteVstackIsolatedNetwork(int id)
        {
            var endpoint = string.Format(EndpointVstackIsolatedNetwork, id);
            await Client.SendDeleteRequestAsync(endpoint).ConfigureAwait(false);
        }
    }
}