using Newtonsoft.Json;

namespace Serverspace.OpenApi.Models
{
    public class ApiResponse<TData>
    {
        public TData Data { get; }

        [JsonConstructor]
        public ApiResponse(TData data)
        {
            Data = data;
        }
    }
}