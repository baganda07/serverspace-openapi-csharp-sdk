using Newtonsoft.Json;
using Serverspace.OpenApi.Exceptions;
using Serverspace.OpenApi.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Serverspace.OpenApi.Network
{
    public abstract class BaseClient<TContext> : IClient
        where TContext:BaseContext
    {
        private readonly Uri _uri;
        private readonly HttpClient _httpClient;

        public abstract TContext Context { get; }

        public BaseClient(Uri uri, string token, HttpClient httpClient)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token));
            }
            _uri = uri ?? throw new ArgumentNullException(nameof(uri));
            
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.DefaultRequestHeaders.Add("X-API-KEY", token);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "serverspace-openapi-csharp-sdk");
        }

        public async Task<ApiResponse<TOut>> SendGetRequestAsync<TOut>(string relativeUri)
        {
            var uri = new Uri(_uri, relativeUri);
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            return await HandleResponseAsync<TOut>(response).ConfigureAwait(false);
        }

        public async Task<ApiResponse<TOut>> SendPostRequestAsync<TIn, TOut>(string relativeUri, TIn body)
        {
            var uri = new Uri(_uri, relativeUri);
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            if (body != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8);

            var responce = await _httpClient.SendAsync(request).ConfigureAwait(false);
            return await HandleResponseAsync<TOut>(responce).ConfigureAwait(false);
        }

        public async Task<ApiResponse<TOut>> SendPostRequestAsync<TOut>(string relativeUri)
        {
            var uri = new Uri(_uri, relativeUri);
            var request = new HttpRequestMessage(HttpMethod.Post, uri);

            var responce = await _httpClient.SendAsync(request).ConfigureAwait(false);
            return await HandleResponseAsync<TOut>(responce).ConfigureAwait(false);
        }

        public async Task<ApiResponse<TOut>> SendPutRequestAsync<TIn, TOut>(string relativeUri, TIn body)
        {
            var uri = new Uri(_uri, relativeUri);
            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            if (body != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8);

            var responce = await _httpClient.SendAsync(request).ConfigureAwait(false);
            return await HandleResponseAsync<TOut>(responce).ConfigureAwait(false);
        }

        public async Task SendDeleteRequestAsync(string relativeUri)
        {
            var uri = new Uri(_uri, relativeUri);
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            await HandleResponseAsync<ApiResponse<object>>(response).ConfigureAwait(false);
        }

        private static async Task<ApiResponse<TOut>> HandleResponseAsync<TOut>(HttpResponseMessage response)
        {
            try
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        {
                            var content = string.Empty;
                            if (response.Content != null)
                            {
                                content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            }
                            return new ApiResponse<TOut>(JsonConvert.DeserializeObject<TOut>(content));
                        }
                    case HttpStatusCode.Unauthorized:
                        throw new ApiException("You are not authorized.", HttpStatusCode.Unauthorized);
                    case HttpStatusCode.Forbidden:
                        throw new ApiException("You haven't access to this resource.", HttpStatusCode.Forbidden);
                    case HttpStatusCode.NotFound:
                        throw new ApiException("Resource not found.", HttpStatusCode.NotFound);
                        
                        // TODO: fix it after read documentations about BadRequest format
                    case HttpStatusCode.BadRequest:
                        throw new ApiException("The server can't process the request due to an client error.", HttpStatusCode.BadRequest);

                    default:
                        {
                            throw new ApiException("The server return unexpected http responce status", response.StatusCode);
                        }
                }
            }
            catch (Exception)
            {
                // TODO: throw ApiException and need to warp exceptions to custom exception with request data
                throw;
            }
        }


    }
}