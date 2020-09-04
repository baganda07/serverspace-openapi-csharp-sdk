using NUnit.Framework;
using Serverspace.OpenApi.Models;
using Serverspace.OpenApi.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Serverspace.OpenApiTests
{
    public class ContextBettaTests
    {
        [Test]
        public async Task Get_ProjectDetailing_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("Projects.Detailing.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;


            var actual = new ProjectDetailing(123, 10000);

            var expected = await _context.GetProjectDetailingAsync();

            Assert.AreEqual(expected.Balance, actual.Balance);
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [Test]
        public async Task Get_SshKeys_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("SshKeys.List.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;


            var actual = new List<SshKey>(2)
            {
                new SshKey(1,"Test Ssh-Key 1","---- BEGIN SSH2 PUBLIC KEY ----\r\nComment: \"rsa-key-20190927\"\r\nAAAAB3NzaC1yc2EAAAABJQAAAQEAkEWseYLYVW4wpdNwWNXtoz84r5sYZ2FBXJ5M\r\nsfibRpJ47o/2z6VcdYnbhhJ/J2dE9AlDCGgleXilnxc9UKRgWXi3NHMmDNFi1kR5\r\nJ6xcY3Tv0ly6w0if+QMJULnoixgPulg93JanVxCvAFy4sE8kwQqTQrYio3UJbiQ5\r\nlX0kEkaWMDM/p8Z97d5izVN+PoMjW0bZdK17VAS90cf+FKFL6cs5VKrY/d7OMfxi\r\nqNeEs+vzYPK2VT4aiLLzryTIiDgG9CjsPtRoMxSihw5tdIw3mhsFdZkKdaJDfank\r\noQ3Y6P4XFPbzwOfDLwIRkDd7Gbh7jRp+4SeVVsBP9AbBR/kv3w==\r\n---- END SSH2 PUBLIC KEY ----"),
                new SshKey(2,"Test Ssh-Key 2", "ssh-rsa AAAAB3NzaC1yc2EAAAABJQAAAQEA4pO1k8IU4JYNASJEGWR/3ECARddXiKLePNN8hIGaqT2grSpFIRULrRhL4qFIQOUB5m9qy0ZjazHoBUzaK/m+nrmkfamF90sKMN5KHRCUMbBOixS0Uc5r/HK7SDDnozjNSFDWscfpMuZfzSXQ512HRZ0ZN+fmXl9Ku87SE9fhrir7injfTVvF/VYfz9W1CvIwN8D6iTBo2zpI1xVfX1tuL2akME4ZBvH9+xVV7Ejw4ad6e/Z1p8g/pYzcmoMvng8qhrBMQaNSq1fTHN+YrJmr86k0pFpKbbSEksOLmV2piTBxqWqR00faRFgvG7HJDtoVAKSdpREUyDvDYeyUGyJwJw== rsa-key-20200730"),

            };

            var expected = await _context.GetSshKeys();

            Assert.AreEqual(expected.Count, actual.Count);

            foreach(var actualKey in actual)
            {
                var expectedKey = expected.Single(x => x.Id == actualKey.Id);
                Assert.AreEqual(actualKey.Name, expectedKey.Name);
                Assert.AreEqual(actualKey.PublicKey, expectedKey.PublicKey);

            }
        }

        [Test]
        public async Task Create_SshKeys_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("SshKey,Create.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var createdSshKey = new SshKey(
                999,
                "Test Ssh-Key",
                "---- BEGIN SSH2 PUBLIC KEY ----\r\nComment: \"rsa-key-20190927\"\r\nAAAAB3NzaC1yc2EAAAABJQAAAQEAkEWseYLYVW4wpdNwWNXtoz84r5sYZ2FBXJ5M\r\nsfibRpJ47o/2z6VcdYnbhhJ/J2dE9AlDCGgleXilnxc9UKRgWXi3NHMmDNFi1kR5\r\nJ6xcY3Tv0ly6w0if+QMJULnoixgPulg93JanVxCvAFy4sE8kwQqTQrYio3UJbiQ5\r\nlX0kEkaWMDM/p8Z97d5izVN+PoMjW0bZdK17VAS90cf+FKFL6cs5VKrY/d7OMfxi\r\nqNeEs+vzYPK2VT4aiLLzryTIiDgG9CjsPtRoMxSihw5tdIw3mhsFdZkKdaJDfank\r\noQ3Y6P4XFPbzwOfDLwIRkDd7Gbh7jRp+4SeVVsBP9AbBR/kv3w==\r\n---- END SSH2 PUBLIC KEY ----");



            var expected = await _context.CreateSshKey(new CreateSshKey(createdSshKey.Name, createdSshKey.PublicKey));

            Assert.AreEqual(expected.Id, expected.Id);
            Assert.AreEqual(expected.Name, expected.Name);
            Assert.AreEqual(expected.PublicKey, expected.PublicKey);
        }

        [Test]
        public async Task Get_SshKey_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("SshKey.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new SshKey(
                5,
                "Test Ssh-Key",
                "---- BEGIN SSH2 PUBLIC KEY ----\r\nComment: \"rsa-key-20190927\"\r\nAAAAB3NzaC1yc2EAAAABJQAAAQEAkEWseYLYVW4wpdNwWNXtoz84r5sYZ2FBXJ5M\r\nsfibRpJ47o/2z6VcdYnbhhJ/J2dE9AlDCGgleXilnxc9UKRgWXi3NHMmDNFi1kR5\r\nJ6xcY3Tv0ly6w0if+QMJULnoixgPulg93JanVxCvAFy4sE8kwQqTQrYio3UJbiQ5\r\nlX0kEkaWMDM/p8Z97d5izVN+PoMjW0bZdK17VAS90cf+FKFL6cs5VKrY/d7OMfxi\r\nqNeEs+vzYPK2VT4aiLLzryTIiDgG9CjsPtRoMxSihw5tdIw3mhsFdZkKdaJDfank\r\noQ3Y6P4XFPbzwOfDLwIRkDd7Gbh7jRp+4SeVVsBP9AbBR/kv3w==\r\n---- END SSH2 PUBLIC KEY ----");

            var expected = await _context.GetSshKey(actual.Id);

            Assert.AreEqual(expected.Id, expected.Id);
            Assert.AreEqual(expected.Name, expected.Name);
            Assert.AreEqual(expected.PublicKey, expected.PublicKey);
        }

        [Test]
        public async Task Get_Vstack_Task_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("Task.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTask(
                1234567,
                1,
                2,
                1467,
                3,
                4,
                DateTime.Parse("2020-08-07T07:56:55.416Z"),
                DateTime.Parse("2020-08-07T07:59:55.416Z"),
                true);

            var expected = await _context.GetVstackTask(actual.Id);

            Assert.AreEqual(expected.Id, expected.Id);
            Assert.AreEqual(expected.LocationId, expected.LocationId);
            Assert.AreEqual(expected.VmId, expected.VmId);
            Assert.AreEqual(expected.DiskId, expected.DiskId);
            Assert.AreEqual(expected.NetworkId, expected.NetworkId);
            Assert.AreEqual(expected.NicId, expected.NicId);
            Assert.AreEqual(expected.Created, expected.Created);
            Assert.AreEqual(expected.Complted, expected.Complted);
            Assert.AreEqual(expected.IsCompleted, expected.IsCompleted);
        }

        [Test]
        public async Task Get_Vstack_Locations_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackLocations.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new List<VstackLocation>()
            {
                new VstackLocation(5,"AM2",10240,1024000),
                new VstackLocation(6,"NJ3",1024000,2048000),
            };

            var expected = await _context.GetVstackLocations();

            Assert.AreEqual(expected.Count, actual.Count);

            foreach (var actualKey in actual)
            {
                var expectedKey = expected.Single(x => x.Id == actualKey.Id);

                Assert.AreEqual(actualKey.TechTitle, expectedKey.TechTitle);
                Assert.AreEqual(actualKey.MinDiskSizeMb, expectedKey.MinDiskSizeMb);
                Assert.AreEqual(actualKey.MaxDiskSizeMb, expectedKey.MaxDiskSizeMb);
            }
        }

        [Test]
        public async Task Get_Vstack_Configurations_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackConfigurations.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new List<VstackConfiguration>()
            {
                new VstackConfiguration(1,5,"CentOS",5,1,1024,5120,1024),
                new VstackConfiguration(2,6,"Ubuntu",10,2,10240,61440,20480),
            };

            var expected = await _context.GetVstackConfigurations();

            Assert.AreEqual(expected.Count, actual.Count);

            foreach (var actualKey in actual)
            {
                var expectedKey = expected.Single(x => x.Id == actualKey.Id);

                Assert.AreEqual(actualKey.LocationId, expectedKey.LocationId);
                Assert.AreEqual(actualKey.Cpu, expectedKey.Cpu);
                Assert.AreEqual(actualKey.RamMb, expectedKey.RamMb);
                Assert.AreEqual(actualKey.HddMb, expectedKey.HddMb);
                Assert.AreEqual(actualKey.FreeOutTrafficMb, expectedKey.FreeOutTrafficMb);
                Assert.AreEqual(actualKey.Price, expectedKey.Price);
                Assert.AreEqual(actualKey.OsFamily, expectedKey.OsFamily);
            }
        }

        [Test]
        public async Task Get_Vstack_Images_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackImages.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new List<VstackImage>()
            {
                new VstackImage(1,1,"Ubuntu","16.0","X64",true),
                new VstackImage(2,3,"CentOs","18.0","X64",false),
            };

            var expected = await _context.GetVstackImages();

            Assert.AreEqual(expected.Count, actual.Count);

            foreach (var actualKey in actual)
            {
                var expectedKey = expected.Single(x => x.Id == actualKey.Id);

                Assert.AreEqual(actualKey.Name, expectedKey.Name);
                Assert.AreEqual(actualKey.LocationId, expectedKey.LocationId);
                Assert.AreEqual(actualKey.Version, expectedKey.Version);
                Assert.AreEqual(actualKey.Architecture, expectedKey.Architecture);
                Assert.AreEqual(actualKey.AllowSshKeys, expectedKey.AllowSshKeys);
            }
        }

        [Test]
        public async Task Get_Vstack_Vms_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVms.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new List<VstackVm>()
            {
                new VstackVm(9384,1,1,3,"Server 1",true,"188.227.59.91","root","asdsadasd",new List<int>(){12, 5},"Active",DateTime.Parse("2020-08-07T12:29:37.311Z").ToUniversalTime()),
                new VstackVm(9385,6,2,5,"Server 2",false,"188.227.59.92","admin","12334sad",null,"New",DateTime.Parse("2020-08-07T14:35:38.311Z").ToUniversalTime()),
            };

            var expected = await _context.GetVstackVms();

            Assert.AreEqual(expected.Count, actual.Count);

            foreach (var actualVm in actual)
            {
                var expectedVm = expected.Single(x => x.Id == actualVm.Id);

                Assert.AreEqual(actualVm.LocationId, expectedVm.LocationId);
                Assert.AreEqual(actualVm.ConfigurationId, expectedVm.ConfigurationId);
                Assert.AreEqual(actualVm.ImageId, expectedVm.ImageId);
                Assert.AreEqual(actualVm.Name, expectedVm.Name);
                Assert.AreEqual(actualVm.Ip, expectedVm.Ip);
                Assert.AreEqual(actualVm.Login, expectedVm.Login);
                Assert.AreEqual(actualVm.Password, expectedVm.Password);
                Assert.AreEqual(actualVm.State, expectedVm.State);
                Assert.AreEqual(actualVm.Created, expectedVm.Created);
                Assert.AreEqual(actualVm.IsPowerOn, expectedVm.IsPowerOn);

                
                Assert.AreEqual(expectedVm.SshKeyIds!= null, actualVm.SshKeyIds!= null);

                if (expectedVm.SshKeyIds != null)
                {
                    // map to list for sort
                    var expectedSshKeys = expectedVm.SshKeyIds.ToList();
                    var actualSshKeys = actualVm.SshKeyIds.ToList();

                    // need to sort for assert
                    expectedSshKeys.Sort();
                    actualSshKeys.Sort();

                    Assert.AreEqual(expectedSshKeys, actualSshKeys);
                }

            }
        }

        [Test]
        public async Task Create_Vstack_Vm_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Create.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTaskResult(593208);
            
            var createVstackVm = new CreateVstackVm(1, 1, "test", null);
            var expected = await _context.CreateVstackVm(createVstackVm);

            Assert.AreEqual(expected.TaskId, actual.TaskId);
        }

        [Test]
        public async Task Get_Vstack_Vm_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackVm(9384, 1, 1, 3, "Server 1", true, "188.227.59.91", "root", "asdsadasd", new List<int>() { 12, 5 }, "Active", DateTime.Parse("2020-08-07T12:29:37.311Z").ToUniversalTime());

            var expected = await _context.GetVstackVm(actual.Id);

            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.LocationId, expected.LocationId);
            Assert.AreEqual(actual.ConfigurationId, expected.ConfigurationId);
            Assert.AreEqual(actual.ImageId, expected.ImageId);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Ip, expected.Ip);
            Assert.AreEqual(actual.Login, expected.Login);
            Assert.AreEqual(actual.Password, expected.Password);
            Assert.AreEqual(actual.State, expected.State);
            Assert.AreEqual(actual.Created, expected.Created);
            Assert.AreEqual(actual.IsPowerOn, expected.IsPowerOn);
            
            Assert.AreEqual(expected.SshKeyIds != null, actual.SshKeyIds != null);
            if (expected.SshKeyIds != null)
            {
                // map to list for sort
                var expectedSshKeys = expected.SshKeyIds.ToList();
                var actualSshKeys = actual.SshKeyIds.ToList();

                // need to sort for assert
                expectedSshKeys.Sort();
                actualSshKeys.Sort();

                Assert.AreEqual(expectedSshKeys, actualSshKeys);
            }
        }

        [Test]
        public async Task Edit_Vstack_Vm_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Edit.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTaskResult(593208);

            var expected = await _context.EditVstackVm(1, new EditVstackVm(1));

            Assert.AreEqual(actual.TaskId, expected.TaskId);
        }

        [Test]
        public async Task Action_Vstack_Vm_PowerOn_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Action.PowerOn.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTaskResult(22522525);

            var expected = await _context.PowerOnVstackVm(1);

            Assert.AreEqual(actual.TaskId, expected.TaskId);
        }

        [Test]
        public async Task Action_Vstack_Vm_Shutdown_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Action.Shutdown.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTaskResult(112581);

            var expected = await _context.ShutdownVstackVm(1);

            Assert.AreEqual(actual.TaskId, expected.TaskId);
        }

        [Test]
        public async Task Action_Vstack_Vm_Shutdown_Via_Os_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Action.ShutdownViaOs.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTaskResult(779118);

            var expected = await _context.ShutdownViaOsVstackVm(1);

            Assert.AreEqual(actual.TaskId, expected.TaskId);
        }

        [Test]
        public async Task Action_Vstack_Vm_Reboot_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Action.Reboot.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTaskResult(155);

            var expected = await _context.RebootVstackVm(1);

            Assert.AreEqual(actual.TaskId, expected.TaskId);
        }

        [Test]
        public async Task Action_Vstack_Vm_Reset_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Action.Reset.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTaskResult(98823142);

            var expected = await _context.ResetVstackVm(1);

            Assert.AreEqual(actual.TaskId, expected.TaskId);
        }

        [Test]
        public async Task Get_Vstack_Vm_Disks_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Disks.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;


            var actual = new List<VstackVmDisk>(2)
            {
                new VstackVmDisk(1,12345,1,"Disk 1",10240,DateTime.Parse("2020-08-07T08:36:03.975Z").ToUniversalTime()),
                new VstackVmDisk(2,12345,1,"Disk 2",51200,DateTime.Parse("2020-08-08T10:47:04.215Z").ToUniversalTime()),

            };

            var expected = await _context.GetVstackVmDisks(1);

            Assert.AreEqual(expected.Count, actual.Count);

            foreach (var actualKey in actual)
            {
                var expectedKey = expected.Single(x => x.Id == actualKey.Id);
                Assert.AreEqual(actualKey.LocaionId, expectedKey.LocaionId);
                Assert.AreEqual(actualKey.Name, expectedKey.Name);
                Assert.AreEqual(actualKey.VmId, expectedKey.VmId);
                Assert.AreEqual(actualKey.SizeMb, expectedKey.SizeMb);
                Assert.AreEqual(actualKey.Created, expectedKey.Created);

            }
        }

        [Test]
        public async Task Create_Vstack_Vm_Disk_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Disk.Create.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTaskResult(593208);

            var createVstackDiskVm = new CreateVstackVmDisk("test",1024);
            var expected = await _context.CreateVstackVmDisk(1, createVstackDiskVm);

            Assert.AreEqual(expected.TaskId, actual.TaskId);
        }

        [Test]
        public async Task Get_Vstack_Vm_Disk_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Disk.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackVmDisk(1, 12345, 1, "Disk 1", 10240, DateTime.Parse("2020-08-07T08:36:03.975Z").ToUniversalTime());

            var expected = await _context.GetVstackVmDisk(1, 1);

            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.LocaionId, expected.LocaionId);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.VmId, expected.VmId);
            Assert.AreEqual(actual.SizeMb, expected.SizeMb);
            Assert.AreEqual(actual.Created, expected.Created);
        }

        [Test]
        public async Task Edit_Vstack_Vm_Disk_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Disk.Edit.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTaskResult(593208);

            var expected = await _context.EditVstackVmDisk(1,1, new EditVstackVmDisk(1024));

            Assert.AreEqual(actual.TaskId, expected.TaskId);
        }

        [Test]
        public async Task Get_Vstack_Vm_Nics_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Nics.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;


            var actual = new List<VstackVmNic>(2)
            {
                new VstackVmNic(12,1,321,31,"ca:06:85:8a:58:5f","188.227.50.41"),
                new VstackVmNic(2,1,321,1,"ca:06:5d:07:84:4e","10.0.0.1"),

            };

            var expected = await _context.GetVstackVmNics(1);

            Assert.AreEqual(expected.Count, actual.Count);

            foreach (var actualKey in actual)
            {
                var expectedKey = expected.Single(x => x.Id == actualKey.Id);
                Assert.AreEqual(actualKey.VmId, expectedKey.VmId);
                Assert.AreEqual(actualKey.LocationId, expectedKey.LocationId);
                Assert.AreEqual(actualKey.NetworkId, expectedKey.NetworkId);
                Assert.AreEqual(actualKey.Mac, expectedKey.Mac);
                Assert.AreEqual(actualKey.IpV4, expectedKey.IpV4);
            }
        }

        [Test]
        public async Task Create_Vstack_Vm_Nic_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Nic.Create.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTaskResult(593208);

            var createVstackVmNic = new CreateVstackVmNic(1);
            var expected = await _context.CreateVstackVmNic(1, createVstackVmNic);

            Assert.AreEqual(expected.TaskId, actual.TaskId);
        }

        [Test]
        public async Task Get_Vstack_Vm_Nic_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackVm.Nic.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackVmNic(2,1,321,1, "ca:06:5d:07:84:4e", "10.0.0.1");

            var expected = await _context.GetVstackVmNic(1, 1);

            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.VmId, expected.VmId);
            Assert.AreEqual(actual.LocationId, expected.LocationId);
            Assert.AreEqual(actual.NetworkId, expected.NetworkId);
            Assert.AreEqual(actual.Mac, expected.Mac);
            Assert.AreEqual(actual.IpV4, expected.IpV4);
        }

        [Test]
        public async Task Get_Vstack_IsolatedNetworks_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackIsolatedNetworks.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;


            var actual = new List<VstackIsolatedNetwork>(2)
            {
                new VstackIsolatedNetwork(1,1,"Private Network 1","Description of Private Network 1","10.0.0.0",100,1, "Active",DateTime.Parse("2020-08-07T11:56:41.004Z").ToUniversalTime()),
                new VstackIsolatedNetwork(2,1,"Private Network 2","Description of Private Network 2","192.168.0.0",100,1, "Active",DateTime.Parse("2020-08-07T12:31:49.094Z").ToUniversalTime()),

            };

            var expected = await _context.GetVstackIsolatedNetworks();

            Assert.AreEqual(expected.Count, actual.Count);

            foreach (var actualKey in actual)
            {
                var expectedKey = expected.Single(x => x.Id == actualKey.Id);
                Assert.AreEqual(actualKey.LocationId, expectedKey.LocationId);
                Assert.AreEqual(actualKey.Name, expectedKey.Name);
                Assert.AreEqual(actualKey.Description, expectedKey.Description);
                Assert.AreEqual(actualKey.IpV4Pool, expectedKey.IpV4Pool);
                Assert.AreEqual(actualKey.BandwidthMb, expectedKey.BandwidthMb);
                Assert.AreEqual(actualKey.AddressesReserved, expectedKey.AddressesReserved);
                Assert.AreEqual(actualKey.State, expectedKey.State);
                Assert.AreEqual(actualKey.Created, expectedKey.Created);
            }
        }

        [Test]
        public async Task Create_Vstack_IsolatedNetwork_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackIsolatedNetwork.Create.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;

            var actual = new VstackTaskResult(593208);

            var createVstackIsolatedNetwork = new CreateVstackIsolatedNetwork(1, "1", "1", "1", "1");
            var expected = await _context.CreateVstackIsolatedNetwork(createVstackIsolatedNetwork);

            Assert.AreEqual(expected.TaskId, actual.TaskId);
        }

        [Test]
        public async Task Get_Vstack_IsolatedNetwork_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackIsolatedNetwork.Get.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;


            var actual = new VstackIsolatedNetwork(1, 1, "Private Network 1", "Description of Private Network 1", "10.0.0.0", 100, 1, "Active", DateTime.Parse("2020-08-07T11:56:41.004Z").ToUniversalTime());

            var expected = await _context.GetVstackIsolatedNetwork(1);

            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.LocationId, expected.LocationId);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Description, expected.Description);
            Assert.AreEqual(actual.IpV4Pool, expected.IpV4Pool);
            Assert.AreEqual(actual.BandwidthMb, expected.BandwidthMb);
            Assert.AreEqual(actual.AddressesReserved, expected.AddressesReserved);
            Assert.AreEqual(actual.State, expected.State);
            Assert.AreEqual(actual.Created, expected.Created);
        }

        [Test]
        public async Task Edit_Vstack_IsolatedNetwork_Success()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("VstackIsolatedNetwork.Edit.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;


            var actual = new VstackIsolatedNetwork(1, 1, "Private Network 1", "Description of Private Network 1", "10.0.0.0", 100, 1, "Active", DateTime.Parse("2020-08-07T11:56:41.004Z").ToUniversalTime());

            EditVstackIsolatedNetwork editVstackIsolatedNetwork = new EditVstackIsolatedNetwork("", "");
            var expected = await _context.EditVstackIsolatedNetwork(1, editVstackIsolatedNetwork);

            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.LocationId, expected.LocationId);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Description, expected.Description);
            Assert.AreEqual(actual.IpV4Pool, expected.IpV4Pool);
            Assert.AreEqual(actual.BandwidthMb, expected.BandwidthMb);
            Assert.AreEqual(actual.AddressesReserved, expected.AddressesReserved);
            Assert.AreEqual(actual.State, expected.State);
            Assert.AreEqual(actual.Created, expected.Created);
        }

    }
}

