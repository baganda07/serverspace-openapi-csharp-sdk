using Newtonsoft.Json;
using System.Collections.Generic;

namespace Serverspace.OpenApi.Models
{
    public class CreateVstackVm
    {
        [JsonProperty("configuration_id")]
        public int ConfigurationId { get; }

        [JsonProperty("image_id")]
        public int ImageId { get; }

        public string Name { get; }

        [JsonProperty("ssh_key_ids")]
        public ICollection<int> SshKeyIds { get; }

        public CreateVstackVm(int configurationId, int imageId, string name, ICollection<int> sshKeyIds)
        {
            ConfigurationId = configurationId;
            ImageId = imageId;
            Name = name;
            SshKeyIds = sshKeyIds;
        }
    }
}
