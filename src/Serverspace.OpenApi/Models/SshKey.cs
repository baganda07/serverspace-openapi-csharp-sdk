using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class SshKey
    {
        public int Id { get; }

        public string Name { get; }

        [JsonProperty("public_key")]
        public string PublicKey { get; }

        public SshKey(int id, string name, string publicKey)
        {
            Id = id;
            Name = name;
            PublicKey = publicKey;
        }
    }
}
