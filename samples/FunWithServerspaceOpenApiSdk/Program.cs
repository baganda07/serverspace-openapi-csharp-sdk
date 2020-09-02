using Serverspace.OpenApi;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithServerspaceOpenApiSdk
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = ClientFactory.GetClientBetta("https://api.serverspace.io/", "XXX");
            var accountInfo = await client.Context.GetProjectDetailingAsync();
            Console.WriteLine($"Hello id:{accountInfo.Id}, your balance:{accountInfo.Balance}");
            var sshKeys = (await client.Context.GetSshKeys()).ToList();
            Console.Write($"You have {sshKeys.Count} ssh-keys");
            if (sshKeys.Count > 0)
            {
                for(int i = 0; i< sshKeys.Count; i++)
                {
                    var sshKey = sshKeys[i];
                    // first record
                    if (i == 0)
                    {
                        Console.Write($": {sshKey.Name}");
                        continue;
                    }

                    Console.Write($", {sshKey.Name}");

                    //last record
                    if (i == sshKeys.Count - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
