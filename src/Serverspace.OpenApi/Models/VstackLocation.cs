using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class VstackLocation
    {
        public int Id { get; }

        [JsonProperty("tech_title")]
        public string TechTitle { get; }

        [JsonProperty("min_disk_size_mb")]
        public int MinDiskSizeMb { get; }

        [JsonProperty("max_disk_size_mb")]
        public int MaxDiskSizeMb { get; }

        public VstackLocation(int id, string techTitle, int minDiskSizeMb, int maxDiskSizeMb)
        {
            Id = id;
            TechTitle = techTitle;
            MinDiskSizeMb = minDiskSizeMb;
            MaxDiskSizeMb = maxDiskSizeMb;
        }

    }
}
