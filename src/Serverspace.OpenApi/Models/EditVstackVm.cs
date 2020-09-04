using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class EditVstackVm
    {
        [JsonProperty("configuration_id")]
        public int ConfigurationId { get; }

        public EditVstackVm(int configurationId)
        {
            ConfigurationId = configurationId;
        }
    }
}
