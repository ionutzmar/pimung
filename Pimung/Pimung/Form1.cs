using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using WMPLib;


namespace Pimung
{
    public partial class ChooseMusic : Form
    {

        Boolean startDragging;
        int panel1OriginalHeight;
        List<string> SongsPaths = new List<string>();


        public ChooseMusic()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e) //Set up a few components after the app has loaded
        {
            panel2.Height = 10;
            panel2.Location = new Point(0, panel1.Height + panel1.Location.Y);
            panel1OriginalHeight = panel1.Height;
            StrokeOval.Height = 10;
            Form1_Resize(sender, e);
            for (int rowNum = 2; rowNum < 10; rowNum++)
            {
                TableRow tempRow = new TableRow();
                for (int cellNum = 0; cellNum < 3; cellNum++)
                {
                    TableCell tempCell = new TableCell();
                    tempCell.Text =
                        String.Format("({0},{1})", rowNum, cellNum);
                    tempRow.Cells.Add(tempCell);
                }
                Table1.Rows.Add(tempRow);
            }
        }


        private void Form1_Resize(object sender, EventArgs e) //happends when the main form is resized
        {
            panel1.Width = this.Width;
            panel2.Width = this.Width;

            AddMusicBotton.Location = new Point(50, panel1OriginalHeight + 50);
            WhatDoToday.Location = new Point( this.Width - WhatDoToday.Width - 30, 30);
            StrokeOval.Location = new Point(this.Width / 2 - (WhatDoToday.Location.X - this.Width / 2), 80);
            StrokeOval.Width = 2 * WhatDoToday.Location.X - this.Width - 30;
            BackwardButton.Location = new Point(40, 70 - BackwardButton.Height / 2);
            PlayButton.Location = new Point(BackwardButton.Location.X + BackwardButton.Width + 30, 70 - PlayButton.Height / 2);
            ForwardButton.Location = new Point(PlayButton.Location.X + PlayButton.Width + 30, 70 - ForwardButton.Height / 2);
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
            if (startDragging && (MousePosition.Y - this.Top > panel1OriginalHeight + 35))
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

        private void AddMusicBotton_Click(object sender, EventArgs e)
        {
            if (BrowseMusic.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                 foreach (string file in BrowseMusic.FileNames)
                 {
                     SongsPaths.Add(file);
                     
                 }
                 foreach (string file in SongsPaths)
                 Console.WriteLine(file);
            }

        }


     //   WMPLib.WindowsMediaPlayer a = new WMPLib.WindowsMediaPlayer();
     //                a.URL = file;
      //               a.controls.play();



    }
}
