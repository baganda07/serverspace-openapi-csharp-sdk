using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serverspace.OpenApiTests.Mock
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private string _fileName { get; }
        private HttpStatusCode _httpStatusCode { get; }
        public MockHttpMessageHandler(string fileName, HttpStatusCode httpStatusCode)
        {
            _fileName = fileName;
            _httpStatusCode = httpStatusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responce = new HttpResponseMessage(_httpStatusCode);

            if (_httpStatusCode == HttpStatusCode.OK)
                responce.Content = new StringContent(ResponceFile.GetFile(_fileName));

            return Task.FromResult(responce);
        }
    }
}
