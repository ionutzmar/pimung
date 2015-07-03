﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Pimung
{
    public partial class Form1 : Form
    {

        Boolean startDragging;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
            panel2.Width = this.Width;
            panel2.Height = 10;
            panel2.Location = new Point(0 ,panel1.Height + panel1.Location.Y);

            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(0, this.Height),
            Color.FromArgb(255, 218, 227, 124),
            Color.FromArgb(255, 142, 247, 134));
            Pen pen = new Pen(linGrBrush);
            e.Graphics.FillRectangle(linGrBrush, 0, 0, this.Width, this.Height);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
            panel2.Width = this.Width;

            this.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Purple, 1), 20, 5, panel2.Width - 35, 5);
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            panel2.Invalidate();
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeNS;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            startDragging = true;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (startDragging)
            {
                panel1.Height = MousePosition.Y - this.Top - 35;
                panel2.Location = new Point(0, panel1.Height + panel1.Location.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            startDragging = false;
        }



    }
}
