using Serverspace.OpenApi.Models;
using System.Threading.Tasks;

namespace Serverspace.OpenApi.Network
{
    public interface IClient
    {
        Task<ApiResponse<TPayload>> SendGetRequestAsync<TPayload>(string relativeUri);
        Task<ApiResponse<TOut>> SendPostRequestAsync<TIn, TOut>(string relativeUri, TIn body);
        Task<ApiResponse<TOut>> SendPutRequestAsync<TIn, TOut>(string relativeUri, TIn body);
        Task<ApiResponse<TOut>> SendDeleteRequestAsync<TIn, TOut>(string relativeUri);
    }
}