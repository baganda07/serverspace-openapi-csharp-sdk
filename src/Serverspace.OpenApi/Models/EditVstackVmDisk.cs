using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class EditVstackVmDisk
    {
        [JsonProperty("size_mb")]
        public int SizeMb { get; }

        public EditVstackVmDisk(int sizeMb)
        {
            SizeMb = sizeMb;
        }
    }
}
