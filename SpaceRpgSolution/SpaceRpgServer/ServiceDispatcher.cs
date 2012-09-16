using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net.Sockets;

namespace SpaceRpgServer
{
    class ServiceDispatcher
    {
        public static ServiceDispatcher Instance = new ServiceDispatcher();

        private Dictionary<String, ServiceProvider> services;

        private ServiceDispatcher() 
        {
            services = new Dictionary<string, ServiceProvider>();
        }

        public void AddService(String name, ServiceProvider provider)
        {
            services.Add(name, provider);
        }

        public void Dispatch(TcpClient client, XmlNode node)
        {
            if ( !services.ContainsKey(node.Name) )
            {
                System.Windows.Forms.MessageBox.Show("Protocolo incorrecto");
                return;
            }

            ServiceProvider prov = services[node.Name];
            prov.Execute(client, node);
        }
    }
}
