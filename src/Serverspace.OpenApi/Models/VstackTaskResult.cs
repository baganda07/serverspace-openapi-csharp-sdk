using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class VstackTaskResult
    {
        [JsonProperty("task_id")]
        public string TaskId { get; }

        public VstackTaskResult(string taskId)
        {
            TaskId = taskId;
        }
    }
}
