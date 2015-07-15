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
        List<WMPLib.WindowsMediaPlayer> MusicToTable = new List<WMPLib.WindowsMediaPlayer>();
        int amount, counter = 0; // counts the number of times 'AddMusicInTable' was called. Useful for adding music to table.
        int songPlayed = -1; //index of the last song palyed
        Boolean isPlaying = false;
        Boolean viaWifi = false;
        Boolean loopMusic = false;
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
            AddMusicBotton.Location = new Point(50, panel1OriginalHeight + 50);
            checkWifi.Location = new Point(50, AddMusicBotton.Location.Y + AddMusicBotton.Height + 10);
            BackwardButton.Location = new Point(40, 70 - BackwardButton.Height / 2);
            PlayButton.Location = new Point(BackwardButton.Location.X + BackwardButton.Width + 40, 70 - PlayButton.Height / 2);
            ForwardButton.Location = new Point(PlayButton.Location.X + PlayButton.Width + 40, 70 - ForwardButton.Height / 2);
            Form1_Resize(sender, e);

            Console.WriteLine("Form1 loaded");
            
        }


        private void Form1_Resize(object sender, EventArgs e) //happends when the main form is resized
        {
            panel1.Width = this.Width;
            panel2.Width = this.Width;

            
            WhatDoToday.Location = new Point( this.Width - WhatDoToday.Width - 30, 30);
            StrokeOval.Location = new Point(this.Width / 2 - (WhatDoToday.Location.X - this.Width / 2), 80);
            StrokeOval.Width = 2 * WhatDoToday.Location.X - this.Width - 30;
            LeftMenu.Location = new Point(0, panel2.Location.Y + 10);
            songGrid.Location = new Point(LeftMenu.Width, panel2.Location.Y + panel2.Height);
            songGrid.Height = this.Height - panel2.Height - panel2.Location.Y - 50;
            songGrid.Width = this.Width - LeftMenu.Width - 20;
            

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
                songGrid.Location = new Point(LeftMenu.Width, panel2.Location.Y + panel2.Height);
                songGrid.Height = this.Height - panel2.Height - panel2.Location.Y - 50;
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
                     if(SongsPaths.IndexOf(file) == -1)
                        SongsPaths.Add(file);
                     
                 }
                
                LoadMusicInTable(SongsPaths);

            }

        }

         private void LoadMusicInTable(List<string> songs)
        {
            if (songPlayed != -1)
                MusicToTable[songPlayed].controls.stop();
            MusicToTable.Clear();
            amount = songs.Count;

            int numberOfRows = songGrid.Rows.Count;
            for (int j = 0; j < numberOfRows; j++)
            {
                songGrid.Rows.Remove(songGrid.Rows[0]);
            }

            for (int i = 0; i < songs.Count; i++)
            {
                WMPLib.WindowsMediaPlayer song = new WMPLib.WindowsMediaPlayer();
                MusicToTable.Add(song);
                MusicToTable[i].URL = songs[i];
                MusicToTable[i].settings.mute = true;
                MusicToTable[i].PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(AddMusicInTable);
            }
            

        }

         private void AddMusicInTable(int NewState)
         {
             counter++;

             if (counter == amount)
             {
                 for (int i = 0; i < MusicToTable.Count; i++)
                 {
                     MusicToTable[i].PlayStateChange -= new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(AddMusicInTable);
                     MusicToTable[i].settings.mute = false;
                     MusicToTable[i].controls.stop();
                     string[] rowDG = new string[] { MusicToTable[i].currentMedia.getItemInfo("Title"), MusicToTable[i].currentMedia.durationString, MusicToTable[i].currentMedia.getItemInfo("Artist"), MusicToTable[i].currentMedia.getItemInfo("Album"), MusicToTable[i].currentMedia.getItemInfo("Genre") };
                     songGrid.Rows.Add(rowDG);

                 }
                 counter = 0;
             }
         }

         protected override CreateParams CreateParams //remove flickering
         {
             get
             {
                 CreateParams cp = base.CreateParams;
                 cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                 return cp;
             }
         }
         
         private void playStopMusic(object sender, EventArgs e)
         {
             if (songGrid.Rows.Count > 0)
             {
                 if (sender.ToString() == "System.Windows.Forms.DataGridView" && !viaWifi)
                 {
                     if (songPlayed != -1)
                     {
                         MusicToTable[songPlayed].settings.setMode("loop", false);
                         MusicToTable[songPlayed].controls.stop();
                     }

                     for (int i = 0; i < MusicToTable.Count; i++)
                     {
                         if (songGrid.Rows[songGrid.CurrentCell.RowIndex].Cells[0].FormattedValue.ToString() == MusicToTable[i].currentMedia.getItemInfo("Title"))
                         {
                             Console.WriteLine("Se potrivesc");
                             songPlayed = i;
                             MusicToTable[songPlayed].controls.play();
                             MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
                             break;
                         }
                     }
                     isPlaying = true;
                 }
                 else if (!viaWifi)
                 {
                     if (isPlaying)
                     {
                         MusicToTable[songPlayed].controls.pause();
                         isPlaying = false;
                     }
                     else if (songPlayed == -1)
                     {
                         MusicToTable[0].controls.play();
                         MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
                         songPlayed = 0;
                         isPlaying = true;
                     }
                     else
                     {
                         MusicToTable[songPlayed].controls.play();
                         MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
                         isPlaying = true;
                     }
                 }
                 if(isPlaying)
                     PlayButton.BackgroundImage = Pimung.Properties.Resources.PauseBotton;
                 else
                     PlayButton.BackgroundImage = Pimung.Properties.Resources.playButton2;
             }
             
             

         }

         private void checkWifi_CheckStateChanged(object sender, EventArgs e)
         {
             viaWifi = !viaWifi;
         }

         
         private void ReplayButton_Click(object sender, EventArgs e)
         {
             loopMusic = !loopMusic;
             if (loopMusic)
                 ReplayButton.BackColor = System.Drawing.Color.Gainsboro;
             else
                 ReplayButton.BackColor = System.Drawing.Color.WhiteSmoke;
             if (songPlayed != -1)
                MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
         }

       //private void player_PlayStateChange(int NewState)
       //{
       //    for (int i = 0; i < song.Count; i++)
       //    {
       //        Console.WriteLine(song[i].currentMedia.duration);
       //        Console.WriteLine(song[i].currentMedia.getItemInfo("Album"));
       //        song[i].PlayStateChange -= new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(player_PlayStateChange);
       //        if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsPlaying)
       //        {
       //            //Console.WriteLine(WMPLi);

       //        }
       //    }
       // }
        //Console.WriteLine((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsPlaying);
        //for (int i = 0; i < songs.count; i++)
        //{
        //    // wmplib.windowsmediaplayer song = new wmplib.windowsmediaplayer();
        //    //boolean  b = song.playstate;
        //    //song[i].playstatechange += new wmplib._wmpocxevents_playstatechangeeventhandler(player_playstatechange);
        //    song[i].url = songs[i];
        //    song[i].controls.play();
        //    console.writeline(song[i].currentmedia.duration);
        //    console.writeline(songs[i]);
        //   // song[i].settings.mute = true;
        //    wmplib.iwmpmedia3 media;
        //    //media = Item;

        //}
     //   WMPLib.WindowsMediaPlayer a = new WMPLib.WindowsMediaPlayer();
     //                a.URL = file;
      //               a.controls.play();
        //Label l = new Label();
        // l.Text = "asdf";
        //LinesTable.Controls.Add(l, 1, 0);


    }
}
