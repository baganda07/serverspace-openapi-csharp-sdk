using Newtonsoft.Json;
using System;

namespace Serverspace.OpenApi.Models
{
    public class VstackTask
    {
        public string Id { get; }

        [JsonProperty("location_id")]
        public int LocationId { get; }

        [JsonProperty("network_id")]
        public int NetworkId { get; }

        [JsonProperty("vm_id")]
        public string VmId { get; }

        [JsonProperty("disk_id")]
        public int DiskId { get; }

        [JsonProperty("nic_id")]
        public int NicId { get; }

        [JsonProperty("created_at")]
        public DateTime Created { get; }

        [JsonProperty("completed_at")]
        public DateTime Complted { get; }

        [JsonProperty("is_completed")]
        public bool IsCompleted { get; }


        public VstackTask(string id, int locationId, int networkId, string vmId, int diskId, int nicId, DateTime created, DateTime complted, bool isCompleted)
        {
            Id = id;
            LocationId = locationId;
            NetworkId = networkId;
            VmId = vmId;
            DiskId = diskId;
            NicId = nicId;
            Created = created;
            Complted = complted;
            IsCompleted = isCompleted;
        }

    }
}
