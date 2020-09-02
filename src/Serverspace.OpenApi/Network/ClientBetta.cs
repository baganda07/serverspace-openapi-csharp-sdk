using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Serverspace.OpenApi.Network
{
    public class ClientBetta : BaseClient<ContextBetta>
    {
        public ClientBetta(Uri uri, string token, HttpClient httpClient) : base(uri, token, httpClient)
        {
        }

        public override ContextBetta Context => new ContextBetta(this);

    }
}
