using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net.Sockets;

namespace SpaceRpgServer.Services
{
    class RegisterRequest : ServiceProvider
    {
        public void Execute(TcpClient client, XmlNode node)
        {
            String user = node.Attributes["username"].Value;
            String mail = node.Attributes["email"].Value;
            String pass = (new Random(4325)).Next().ToString();

            try
            {
                StateDataBase.Instance.RegisterUser(user, mail, pass);
                Mailer.Instance.SendRegisterMail(mail, user, pass);
            }
            catch (GameException ge)
            {
                XmlDocument doc = new XmlDocument();
                XmlNode msgNode = doc.CreateElement("RegisterRequestError");
                XmlAttribute desc = doc.CreateAttribute("description");
                desc.Value = ge.Message;
                msgNode.Attributes.Append(desc);

                Sender.Instance.Send(client, msgNode);
            }
        }
    }
}
