using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Serverspace.OpenApi.Models
{
    public class VstackVm
    {
        public string Id { get; }

        [JsonProperty("location_id")]
        public int LocationId { get; }

        [JsonProperty("configuration_id")]
        public int ConfigurationId { get; }

        [JsonProperty("image_id")]
        public string ImageId { get; }

        public string  Name { get; }

        [JsonProperty("is_power_on")]
        public bool IsPowerOn { get; }

        public string Ip { get; }

        public string Login { get; }

        public string Password { get; }

        [JsonProperty("ssh_key_ids")]
        public IReadOnlyCollection<int> SshKeyIds { get; }

        public string State { get; }

        [JsonProperty("created_at")]
        public DateTime Created { get; }

        public VstackVm(string id, int locationId, int configurationId, string imageId, string name, bool isPowerOn, string ip, string login, string password, IReadOnlyCollection<int> sshKeyIds, string state, DateTime created)
        {
            Id = id;
            LocationId = locationId;
            ConfigurationId = configurationId;
            ImageId = imageId;
            Name = name;
            IsPowerOn = isPowerOn;
            Ip = ip;
            Login = login;
            Password = password;
            SshKeyIds = sshKeyIds;
            State = state;
            Created = created;
        }
    }
}
