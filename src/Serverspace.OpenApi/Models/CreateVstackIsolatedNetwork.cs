using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class CreateVstackIsolatedNetwork
    {
        [JsonProperty("location_id")]
        public int LocationId { get; }

        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("description")]
        public string Description { get; }

        [JsonProperty("address")]
        public string IpV4Address { get; }

        [JsonProperty("mask")]
        public string IpV4Mask { get; }

        public CreateVstackIsolatedNetwork(int locationId, string name, string description, string ipV4Address, string ipV4Mask)
        {
            LocationId = locationId;
            Name = name;
            Description = description;
            IpV4Address = ipV4Address;
            IpV4Mask = ipV4Mask;
        }
    }
}
