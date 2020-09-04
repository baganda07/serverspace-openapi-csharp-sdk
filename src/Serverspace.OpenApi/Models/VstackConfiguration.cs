using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class VstackConfiguration
    {
        public int Id { get; }

        [JsonProperty("vstack_location_id")]
        public int LocationId { get; }

        [JsonProperty("os_family_id")]
        public string OsFamily { get; }

        [JsonProperty("price")]
        public decimal Price { get; }

        [JsonProperty("cpu")]
        public int Cpu { get; }

        [JsonProperty("ram_mb")]
        public int RamMb { get; }

        [JsonProperty("hdd_mb")]
        public int HddMb { get; }

        [JsonProperty("free_out_traffic_gb")]
        public int FreeOutTrafficMb { get; }

        public VstackConfiguration(int id, int locationId, string osFamily, decimal price, int cpu, int ramMb, int hddMb, int freeOutTrafficMb)
        {
            Id = id;
            LocationId = locationId;
            OsFamily = osFamily;
            Price = price;
            Cpu = cpu;
            RamMb = ramMb;
            HddMb = hddMb;
            FreeOutTrafficMb = freeOutTrafficMb;
        }

    }
}
