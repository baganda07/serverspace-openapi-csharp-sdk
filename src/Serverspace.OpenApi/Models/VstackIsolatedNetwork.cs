using Newtonsoft.Json;
using System;

namespace Serverspace.OpenApi.Models
{
    public class VstackIsolatedNetwork
    {
        public int Id { get; }

        [JsonProperty("location_id")]
        public int LocationId { get; }

        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("description")]
        public string Description { get; }

        [JsonProperty("pool")]
        public string IpV4Pool { get; }

        [JsonProperty("bandwidth_mb")]
        public int BandwidthMb { get; }

        [JsonProperty("used_addresses")]
        public int AddressesReserved { get; }

        [JsonProperty("state")]
        public string State { get; }

        [JsonProperty("created_at")]
        public DateTime Created { get; }

        public VstackIsolatedNetwork(int id, int locationId, string name, string description, string ipV4Pool, int bandwidthMb, int addressesReserved, string state, DateTime created)
        {
            Id = id;
            LocationId = locationId;
            Name = name;
            Description = description;
            IpV4Pool = ipV4Pool;
            BandwidthMb = bandwidthMb;
            AddressesReserved = addressesReserved;
            State = state;
            Created = created;
        }

    }
}
