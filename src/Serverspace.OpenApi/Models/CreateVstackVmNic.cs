using Newtonsoft.Json;


namespace Serverspace.OpenApi.Models
{
    public class CreateVstackVmNic
    {
        [JsonProperty("network_id")]
        public int NetworkId { get; }

        public CreateVstackVmNic(int networkId)
        {
            NetworkId = networkId;
        }
    }
}
