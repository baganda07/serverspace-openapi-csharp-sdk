using NUnit.Framework;
using Serverspace.OpenApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Serverspace.OpenApiTests
{
    public class BaseClientTests
    {
        [Test]
        public void Handle_Unauthorized_Test()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler(string.Empty, HttpStatusCode.Unauthorized));
            var client = new FakeClient(httpClient);
            Assert.ThrowsAsync<ApiException>(() => client.SendGetRequestAsync<object>(@"\foo"));
        }

        [Test]
        public void Handle_Forbidden_Test()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler(string.Empty, HttpStatusCode.Forbidden));
            var client = new FakeClient(httpClient);
            Assert.ThrowsAsync<ApiException>(() => client.SendGetRequestAsync<object>(@"\foo"));
        }

        [Test]
        public void Handle_NotFound_Test()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler(string.Empty, HttpStatusCode.NotFound));
            var client = new FakeClient(httpClient);
            Assert.ThrowsAsync<ApiException>(() => client.SendGetRequestAsync<object>(@"\foo"));
        }

        [Test]
        public void Handle_BadRequest_Test()
        {
            var httpClient = new HttpClient(new Mock.MockHttpMessageHandler(string.Empty, HttpStatusCode.BadRequest));
            var client = new FakeClient(httpClient);
            Assert.ThrowsAsync<ApiException>(() => client.SendGetRequestAsync<object>(@"\foo"));
        }


    }
}
