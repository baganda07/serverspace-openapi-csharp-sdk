using Serverspace.OpenApi.Network;
using System;
using System.Net.Http;

namespace Serverspace.OpenApi
{
    public class ClientFactory
    {
        /// <summary>
        /// Create class for connect to serverspace open api
        /// </summary>
        /// <param name="absoluteBaseUrl"> base url for connect, like https://api.serverspace.io/ </param>
        /// <param name="token">authentication token</param>
        /// <returns>client for serverspace open api</returns>
        public static ClientBetta GetClientBetta(string absoluteBaseUrl, string token)
        {
            if (string.IsNullOrEmpty(absoluteBaseUrl))
            {
                throw new ArgumentNullException(nameof(absoluteBaseUrl));
            }

            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (Uri.TryCreate(absoluteBaseUrl, UriKind.Absolute, out Uri uri) == false)
            {
                throw new ArgumentException("can't parse to Uri", nameof(absoluteBaseUrl));
            }

            return new ClientBetta(uri, token, new HttpClient());
        }
    }
}
