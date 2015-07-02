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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
            Console.WriteLine("Form1 loaded");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           e.Graphics.DrawLine(new Pen(Color.Black, 3), 30, panel1.Height, panel1.Width - 30, panel1.Height);
        }

        private void MouseEntered(object sender, EventArgs e)
        {
            if (Cursor.Position.X > 30 && Cursor.Position.X < panel1.Width - 30 &);
        }
    }
}
