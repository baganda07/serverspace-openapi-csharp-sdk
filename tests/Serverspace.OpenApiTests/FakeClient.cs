using Serverspace.OpenApi.Network;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Serverspace.OpenApiTests
{
    public class FakeClient : BaseClient<ContextBetta>
    {
        public FakeClient(HttpClient httpClient) : base(new Uri("https://127.0.0.1"), "XXX", httpClient)
        {
        }

        public override ContextBetta Context => new ContextBetta(this);
    }
}
