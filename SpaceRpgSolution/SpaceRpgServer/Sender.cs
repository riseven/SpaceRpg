using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Xml;

namespace SpaceRpgServer
{
    class Sender
    {
        public static Sender Instance = new Sender();

        private UTF8Encoding encoding;

        private Sender()
        {
            encoding = new UTF8Encoding();
        }

        public void Send(TcpClient client, XmlNode node)
        {
            Send(client, node.OuterXml);
        }

        public void Send(TcpClient client, String text)
        {
            NetworkStream ns = client.GetStream();

            byte[] bytes = new byte[encoding.GetByteCount(text) + 1];
            encoding.GetBytes(text).CopyTo(bytes, 0);
            bytes[bytes.Length - 1] = 0;

            ns.BeginWrite(bytes, 0, bytes.Length, null, null);
        }
    }
}
