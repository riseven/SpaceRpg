using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpaceRpgServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void botonTest_Click(object sender, EventArgs e)
        {
            //Mailer.Instance.R
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            // Preparamos los servicios
            ServiceDispatcher.Instance.AddService("RegisterRequest", new Services.RegisterRequest());

            Listener.Instance.Start();
        }

        private void timerListener_Tick(object sender, EventArgs e)
        {
            Listener.Instance.Update();
        }
    }
}