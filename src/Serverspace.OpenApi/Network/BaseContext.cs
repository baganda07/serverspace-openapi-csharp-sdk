using System;
using System.Collections.Generic;
using System.Text;

namespace Serverspace.OpenApi.Network
{
    public abstract class BaseContext
    {
        protected IClient Client;

        protected BaseContext(IClient client)
        {
            Client = client;
        }
    }
}
