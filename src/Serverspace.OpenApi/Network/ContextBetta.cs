using Serverspace.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Serverspace.OpenApi.Network
{
    public class ContextBetta : BaseContext
    {
        #region endpoints

        private static string EndpointProjectDetailing = "/api/v1/projects/self";

        private static string EndpointSshKeysList = "api/v1/ssh-keys";

        #endregion

        public ContextBetta(IClient client) : base(client) {}


        public async Task<ProjectDetailing> GetProjectDetailingAsync()
        {
            var responce = await Client.SendGetRequestAsync<ProjectDetailing>(EndpointProjectDetailing).ConfigureAwait(false);
            return responce?.Data;
        }

        public async Task<ICollection<SshKey>> GetSshKeys()
        {
            var responce = await Client.SendGetRequestAsync<ICollection<SshKey>>(EndpointSshKeysList).ConfigureAwait(false);
            return responce?.Data;
        }

    }
}