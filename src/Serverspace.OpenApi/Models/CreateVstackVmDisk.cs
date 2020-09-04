using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class CreateVstackVmDisk
    {
        public string Name { get; }

        [JsonProperty("size_mb")]
        public int SizeMb { get; }

        public CreateVstackVmDisk(string name, int sizeMb)
        {
            Name = name;
            SizeMb = sizeMb;
        }
    }
}
