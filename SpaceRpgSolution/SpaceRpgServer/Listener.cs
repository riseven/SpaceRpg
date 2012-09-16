using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SpaceRpgServer
{
    class Listener
    {
        public static Listener Instance = new Listener();

        private TcpListener listener;
        private List<TcpClient> clients;
        private Boolean started = false;

        private Listener()
        {
            clients = new List<TcpClient>();
        }

        public void Start()
        {
            if (started)
            {
                System.Windows.Forms.MessageBox.Show("Server Listener is already started!");
                return;
            }

            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 13557);
            listener.Start();
            started = true;
        }

        public void Update()
        {
            if (!started)
            {
                return;
            }

            // Aceptamos conexiones entrantes
            while (listener.Pending())
            {
                clients.Add(listener.AcceptTcpClient());
            }


            // Ahora leemos de los sockets
            foreach (TcpClient c in clients)
            {
                if (c.Available > 0)
                {
                    byte[] buffer = new byte[c.Available];
                    c.GetStream().Read(buffer, 0, c.Available);

                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    doc.LoadXml(System.Text.UTF8Encoding.GetEncoding(1250).GetString(buffer));
                    
                    ServiceDispatcher.Instance.Dispatch(c, doc.FirstChild);
                }
            }
        }
    }
}
