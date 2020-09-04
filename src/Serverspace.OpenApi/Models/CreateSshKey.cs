using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class CreateSshKey
    {
        public string Name { get; }

        [JsonProperty("public_key")]
        public string PublicKey { get; }

        public CreateSshKey(string name, string publicKey)
        {
            Name = name;
            PublicKey = publicKey;
        }
    }
}
