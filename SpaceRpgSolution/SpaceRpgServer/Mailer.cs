using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace SpaceRpgServer
{
    class Mailer
    {
        private SmtpClient client;

        public static Mailer Instance = new Mailer();

        public Mailer()
        {
            client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            client.Credentials = new MailCredentialsByHost();
        }

        public void SendRegisterMail(string to, string user, string pass)
        {
            MailMessage msg = new MailMessage("riseven@gmail.com", to);
            msg.Subject = "Welcome to Space RPG";
            msg.Body =  "Welcome to Space RPG!" + Environment.NewLine;
            msg.Body += "Your username is: " + user + Environment.NewLine;
            msg.Body += "Your password is: " + pass;

            try
            {
                client.SendAsync(msg, null);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
