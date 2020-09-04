using Serverspace.OpenApi.Models;
using System.Threading.Tasks;

namespace Serverspace.OpenApi.Network
{
    public interface IClient
    {
        Task<ApiResponse<TOut>> SendGetRequestAsync<TOut>(string relativeUri);
        Task<ApiResponse<TOut>> SendPostRequestAsync<TIn, TOut>(string relativeUri, TIn body);
        Task<ApiResponse<TOut>> SendPostRequestAsync<TOut>(string relativeUri);
        Task<ApiResponse<TOut>> SendPutRequestAsync<TIn, TOut>(string relativeUri, TIn body);
        Task SendDeleteRequestAsync(string relativeUri);
    }
}