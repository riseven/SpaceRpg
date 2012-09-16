using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace SpaceRpgServer
{
    public class MailCredentialsByHost : ICredentialsByHost
    {
        public MailCredentialsByHost()
        {
        }

        public NetworkCredential GetCredential(string host, int port, string aut)
        {
            return new NetworkCredential("riseven@gmail.com", "rsrei700tgi3");
        }
    }
}
