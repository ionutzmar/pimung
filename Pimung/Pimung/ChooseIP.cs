using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pimung
{
    public partial class ChooseIP : Form
    {
        private Form1 mainForm = null;
        public ChooseIP(Form callingForm)
        {
            mainForm = callingForm as Form1; 
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip = textBox1.Text;
            if (this.mainForm.viaWifi && !this.mainForm.bwServer.IsBusy)
                this.mainForm.bwServer.RunWorkerAsync(ip);
            textBox1.Visible = false;
            textIP.Text = "Wait to connect!";
            button1.Visible = false;
            button2.Visible = false;
            textIP.Location = new Point(this.Width / 2 - textIP.Width / 2, 20);
            Console.WriteLine("Trying to connect");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseIP_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mainForm.viaWifi = false;
            this.mainForm.checkWifi.CheckState = System.Windows.Forms.CheckState.Unchecked;
            if (this.mainForm.bwServer.IsBusy)
            {
                this.mainForm.bwServer.CancelAsync();
                while (this.mainForm.bwServer.IsBusy) { }
            }
            this.mainForm.checkWifi.Enabled = true;
            this.mainForm.ChooseIPFormIsOpen = false;
        }
    }
}
