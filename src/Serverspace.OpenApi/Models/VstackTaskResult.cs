using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class VstackTaskResult
    {
        [JsonProperty("task_id")]
        public int TaskId { get; }

        public VstackTaskResult(int taskId)
        {
            TaskId = taskId;
        }
    }
}
