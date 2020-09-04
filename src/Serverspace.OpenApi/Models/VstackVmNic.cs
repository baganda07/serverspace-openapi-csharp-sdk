using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class VstackVmNic
    {
        public int Id { get; }

        [JsonProperty("location_id")]
        public int LocationId { get; }

        [JsonProperty("vm_id")]
        public int VmId { get; }

        [JsonProperty("network_id")]
        public int NetworkId { get; }

        [JsonProperty("mac")]
        public string Mac { get; }

        [JsonProperty("ip_address")]
        public string IpV4 { get; }

        public VstackVmNic(int id, int locationID, int vmID, int networkId, string mac, string ipV4)
        {
            Id = id;
            LocationId = locationID;
            VmId = vmID;
            NetworkId = networkId;
            Mac = mac;
            IpV4 = ipV4;
        }

    }
}
