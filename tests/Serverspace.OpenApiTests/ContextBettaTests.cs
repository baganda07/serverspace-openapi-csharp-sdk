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
        public async Task GetProjectDetailingAsync_Test()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler("Projects.Detailing.json", HttpStatusCode.OK));
            var _context = new FakeClient(httpClient).Context;


            var actual = new ProjectDetailing(123, 10000);

            var expected = await _context.GetProjectDetailingAsync();

            Assert.AreEqual(expected.Balance, actual.Balance);
            Assert.AreEqual(expected.Id, actual.Id);
        }


        [Test]
        public async Task GetSshKeys_Test()
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

    }
}
