using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class EditVstackIsolatedNetwork
    {
        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("description")]
        public string Description { get; }
        
        public EditVstackIsolatedNetwork(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
