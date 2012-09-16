using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net.Sockets;

namespace SpaceRpgServer
{
    interface ServiceProvider
    {
        void Execute(TcpClient client, XmlNode node);
    }
}
