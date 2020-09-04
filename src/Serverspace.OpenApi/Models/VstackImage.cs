using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class VstackImage
    {
        public int Id { get; }

        [JsonProperty("location_id")]
        public int LocationId { get; }

        [JsonProperty("type")]
        public string Name { get; }

        [JsonProperty("os_version")]
        public string Version { get; }

        [JsonProperty("architecture")]
        public string Architecture { get; }

        [JsonProperty("allow_ssh_keys")]
        public bool AllowSshKeys { get; }


        public VstackImage(int id, int locationId, string name, string version, string architecture, bool allowSshKeys)
        {
            Id = id;
            LocationId = locationId;
            Name = name;
            Version = version;
            Architecture = architecture;
            AllowSshKeys = allowSshKeys;
        }
    }
}
