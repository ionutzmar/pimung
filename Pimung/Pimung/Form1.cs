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


        private void Form1_Load(object sender, EventArgs e) //Set up a few components after the app has loaded
        {
            panel2.Height = 10;
            panel2.Location = new Point(0, panel1.Height + panel1.Location.Y);
            StrokeOval.Height = 10;
            Form1_Resize(sender, e);
            
        }


        private void Form1_Resize(object sender, EventArgs e) //happends when the main form is resized
        {
            panel1.Width = this.Width;
            panel2.Width = this.Width;

            
            WhatDoToday.Location = new Point( this.Width - WhatDoToday.Width - 30, 30);
            StrokeOval.Location = new Point(this.Width / 2 - (WhatDoToday.Location.X - this.Width / 2), 80);
            StrokeOval.Width = 2 * WhatDoToday.Location.X - this.Width - 30;
            BackwardButton.Location = new Point(30, 80 - BackwardButton.Height / 2);
            PlayButton.Location = new Point(BackwardButton.Location.X + BackwardButton.Width + 50, 80 - PlayButton.Height / 2);
            ForwardButton.Location = new Point(PlayButton.Location.X + PlayButton.Width + 50, 80 - ForwardButton.Height / 2);
            LeftMenu.Location = new Point(0, panel2.Location.Y + 10);
            LinesTable.Location = new Point(LeftMenu.Width, panel2.Location.Y);
            LinesTable.Height = this.Height - panel1.Height;

            ReplayButton.Location = new Point(StrokeOval.Location.X, StrokeOval.Location.Y + StrokeOval.Height + 20);
            ShuffleButton.Location = new Point(StrokeOval.Location.X + StrokeOval.Width - ShuffleButton.Width, StrokeOval.Location.Y + StrokeOval.Height + 20);

        }

        private void panel2_Paint(object sender, PaintEventArgs e) //Panel2 contains the line under the play, for/back wardButtons
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(255, 38, 126, 200), 1), 20, 5, panel2.Width - 35, 5);
            e.Dispose();
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            panel2.Invalidate(); //cause the panel2 to be repainted
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
                LeftMenu.Location = new Point(0, panel2.Location.Y + 10);
                LinesTable.Location = new Point(LeftMenu.Width, panel2.Location.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            startDragging = false;
        }


    }
}
