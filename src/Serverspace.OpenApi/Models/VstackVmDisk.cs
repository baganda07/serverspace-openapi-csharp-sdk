using Newtonsoft.Json;
using System;

namespace Serverspace.OpenApi.Models
{
    public class VstackVmDisk
    {
        public int Id { get; }

        [JsonProperty("vm_id")]
        public int VmId { get; }

        [JsonProperty("location_id")]
        public int LocaionId { get; }

        public string Name { get; }

        [JsonProperty("size_mb")]
        public int SizeMb { get; }

        [JsonProperty("created_at")]
        public DateTime Created { get; }

        public VstackVmDisk(int id, int vmId, int locaionId, string name, int sizeMb, DateTime created)
        {
            Id = id;
            VmId = vmId;
            LocaionId = locaionId;
            Name = name;
            SizeMb = sizeMb;
            Created = created;
        }



    }


}
