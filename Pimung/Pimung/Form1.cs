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
using System.Timers;
using System.Net;
using System.Net.Sockets;
using System.IO.Ports;
using System.Threading;
using NAudio;

namespace Pimung
{

   
    public partial class Form1 : Form
    {

        Boolean startDragging;
        int panel1OriginalHeight;
        internal List<string> SongsPaths = new List<string>();
        internal List<WMPLib.WindowsMediaPlayer> MusicToTable = new List<WMPLib.WindowsMediaPlayer>();
        int amount, counter = 0; // counts the number of times 'AddMusicInTable' was called. Useful for adding music to table.
        int songPlayed = -1; //index of the last song palyed
        Boolean isPlaying = false;
        internal Boolean viaWifi = false;
        Boolean loopMusic = false;
        Boolean shuffleMusic = false;
        internal Boolean ChooseIPFormIsOpen = false;
        internal Boolean rmMusicIsOpen = false;
        System.Timers.Timer aTimer = new System.Timers.Timer();
        System.Timers.Timer portTimer = new System.Timers.Timer();
        Random random = new Random();
        int randomSong;
        SerialPort currentPort;
        Boolean portFound;
        NetworkStream ns = null;
        NAudio.Wave.WaveStream pcm = null;
        BackgroundWorker bwMusic = new BackgroundWorker();
        internal BackgroundWorker bwServer = new BackgroundWorker();
        Boolean connectedToServer = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void play_wireless(string path)
        {
            if (bwMusic.IsBusy)
            {
                bwMusic.CancelAsync();
                while (bwMusic.IsBusy) { }
            }
            bwMusic.RunWorkerAsync(path);
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader((string)e.Argument));
                int oneSec = 1204 * 4;
                byte[] buffer = new byte[oneSec];
                int current = 0;
                int ret = 0;

                do
                {
                    ret = pcm.Read(buffer, 0, oneSec);
                    ns.Write(buffer, 0, oneSec);
                    current += oneSec;
                } while (ret != -1);
            }
            catch
            {
                MessageBox.Show("Something went wrong");
                connectedToServer = false;
            }
        }

        void bwMusic_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                TcpClient client = new TcpClient((string) e.Argument, 7777);
                ns = client.GetStream();
                Console.WriteLine("Connected to server");
                MessageBox.Show("Connected to server!");
                connectedToServer = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("could not connect to server");
                MessageBox.Show(ex.Message);
                connectedToServer = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e) //Set up a few components after the app has loaded
        {
            panel2.Height = 10;
            panel2.Location = new Point(0, panel1.Height + panel1.Location.Y);
            panel1OriginalHeight = panel1.Height;
            StrokeOval.Height = 10;
            fullOval.Height = 10;
            AddMusicBotton.Location = new Point(50, panel1OriginalHeight + 50);
            removeMusicButton.Location = new Point(AddMusicBotton.Location.X, AddMusicBotton.Location.Y + AddMusicBotton.Height + 10);
            checkWifi.Location = new Point(removeMusicButton.Location.X + removeMusicButton.Width + 20, AddMusicBotton.Location.Y);
            readFromArduino.Location = new Point(checkWifi.Location.X, removeMusicButton.Location.Y);
            BackwardButton.Location = new Point(40, 70 - BackwardButton.Height / 2);
            PlayButton.Location = new Point(BackwardButton.Location.X + BackwardButton.Width + 40, 70 - PlayButton.Height / 2);
            ForwardButton.Location = new Point(PlayButton.Location.X + PlayButton.Width + 40, 70 - ForwardButton.Height / 2);
            Form1_Resize(sender, e);
            listsLayout.Visible = false;
            songGrid.Visible = true;
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Enabled = true;
            aTimer.Interval = 200;
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Start();

            if (Pimung.Properties.Settings.Default.paths != null)
            {
                SongsPaths = Pimung.Properties.Settings.Default.paths;
                LoadMusicInTable(SongsPaths);
                Console.WriteLine(SongsPaths);
            }

            setComPorts();
            if(portFound)
                Console.WriteLine(currentPort.PortName);


            
            bwMusic.DoWork += bw_DoWork;
            bwMusic.WorkerSupportsCancellation = true;
            bwServer.DoWork += bwMusic_DoWork;
            bwServer.WorkerSupportsCancellation = true;


        }

        private void setComPorts()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                foreach(string port in ports)
                {
                    currentPort = new SerialPort(port, 9600);
                    if (detectArduino())
                    {
                        portFound = true;
                        break;
                    }
                    else
                        portFound = false;
                }

            }
            catch
            {
            }


        }

        Boolean detectArduino()
        {
            try
            {
                byte[] buffer = new byte[5];
                buffer[0] = Convert.ToByte(16);
                buffer[1] = Convert.ToByte(128);
                buffer[2] = Convert.ToByte(0);
                buffer[3] = Convert.ToByte(0);
                buffer[4] = Convert.ToByte(4);
                int returnAscii = 0;
                //char returnChar = (char)returnAscii;
                currentPort.Open();
                currentPort.Write(buffer, 0, 5);
                Thread.Sleep(1000);
                int count = currentPort.BytesToRead;
                string returnMessage = "";
                while(count > 0)
                {
                    returnAscii = currentPort.ReadByte();
                    returnMessage = returnMessage + Convert.ToChar(returnAscii);
                    count--;
                }
                currentPort.Close();
                if (returnMessage.Contains("Hello budie!"))
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }


        private void Form1_Resize(object sender, EventArgs e) //happends when the main form is resized
        {
            panel1.Width = this.Width;
            panel2.Width = this.Width;

            
            WhatDoToday.Location = new Point( this.Width - WhatDoToday.Width - 30, 30);
            StrokeOval.Location = new Point(this.Width / 2 - (WhatDoToday.Location.X - this.Width / 2), 80);
            StrokeOval.Width = 2 * WhatDoToday.Location.X - this.Width - 30;
            fullOval.Location = new Point(this.Width / 2 - (WhatDoToday.Location.X - this.Width / 2), 80);
            if (songPlayed != -1)
                fullOval.Width = Convert.ToInt32(StrokeOval.Width * MusicToTable[songPlayed].controls.currentPosition / MusicToTable[songPlayed].currentMedia.duration);
            else
                fullOval.Width = 0;
            elapsedTime.Location = new Point(StrokeOval.Location.X - elapsedTime.Width / 2, StrokeOval.Location.Y - elapsedTime.Height - 10);
            totalTime.Location = new Point(StrokeOval.Location.X + StrokeOval.Width - totalTime.Width / 2, elapsedTime.Location.Y);
            LeftMenu.Location = new Point(0, panel2.Location.Y + 10);
            nowPlaying.Location = new Point(StrokeOval.Location.X + (StrokeOval.Width - nowPlaying.Width) / 2, elapsedTime.Location.Y - 35);
            songGrid.Location = new Point(LeftMenu.Width, panel2.Location.Y + panel2.Height);
            songGrid.Height = this.Height - panel2.Height - panel2.Location.Y - 50;
            songGrid.Width = this.Width - LeftMenu.Width - 20;
            ReplayButton.Location = new Point(StrokeOval.Location.X, StrokeOval.Location.Y + StrokeOval.Height + 20);
            ShuffleButton.Location = new Point(StrokeOval.Location.X + StrokeOval.Width - ShuffleButton.Width, StrokeOval.Location.Y + StrokeOval.Height + 20);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(255, 38, 126, 200), 1), WhatDoToday.Location.X + 40, WhatDoToday.Location.Y + Convert.ToInt32(2.5 * WhatDoToday.Height), WhatDoToday.Location.X + WhatDoToday.Width - 40, WhatDoToday.Location.Y + Convert.ToInt32(2.5 * WhatDoToday.Height));
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
            else if(startDragging)
            {
                panel1.Height = panel1OriginalHeight;
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

        internal void LoadMusicInTable(List<string> songs)
        {
            isPlaying = false;
            PlayButton.BackgroundImage = Pimung.Properties.Resources.playButton2;
            nowPlaying.Text = "";
            elapsedTime.Text = "00:00";
            totalTime.Text = "00:00";
            fullOval.Width = 0;
            if (songPlayed != -1)
            {
                MusicToTable[songPlayed].PlayStateChange -= new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
                aTimer.Elapsed -= new ElapsedEventHandler(OnTimedEvent);
                MusicToTable[songPlayed].settings.setMode("loop", false);
                MusicToTable[songPlayed].controls.stop();
                songPlayed = -1;
            }
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
                 if (sender.ToString() == "System.Windows.Forms.DataGridView")
                 {
                     if (songPlayed != -1)
                     {
                         MusicToTable[songPlayed].settings.setMode("loop", false);
                         MusicToTable[songPlayed].PlayStateChange -= new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
                         aTimer.Elapsed -= new ElapsedEventHandler(OnTimedEvent);
                         MusicToTable[songPlayed].controls.stop();
                     }

                     for (int i = 0; i < MusicToTable.Count; i++)
                     {
                         if (songGrid.Rows[songGrid.CurrentCell.RowIndex].Cells[0].FormattedValue.ToString() == MusicToTable[i].currentMedia.getItemInfo("Title"))
                         {
                             songPlayed = i;
                             MusicToTable[songPlayed].controls.play();
                             MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
                             if (connectedToServer)
                             {
                                 MusicToTable[songPlayed].settings.mute = true;
                                 play_wireless(SongsPaths[i]);
                             }
                             break;
                         }
                     }
                     MusicToTable[songPlayed].PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
                     aTimer.Enabled = true;
                     aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                     totalTime.Text = MusicToTable[songPlayed].currentMedia.durationString;
                     nowPlaying.Text = "Now playing: " + MusicToTable[songPlayed].currentMedia.getItemInfo("Title");
                     nowPlaying.Location = new Point(StrokeOval.Location.X + (StrokeOval.Width - nowPlaying.Width) / 2, elapsedTime.Location.Y - 35);
                     isPlaying = true;
                 }
                 else
                 {
                     if (isPlaying)
                     {
                         MusicToTable[songPlayed].PlayStateChange -= new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
                         MusicToTable[songPlayed].controls.pause();
                         aTimer.Enabled = true;
                         aTimer.Elapsed -= new ElapsedEventHandler(OnTimedEvent);
                         //totalTime.Text = MusicToTable[songPlayed].currentMedia.durationString;
                         //nowPlaying.Text = "Now playing: " + MusicToTable[songPlayed].currentMedia.getItemInfo("Title");
                         if (connectedToServer)
                         {
                             MusicToTable[songPlayed].settings.mute = true;        ////////////////////////////////////////////////////////////////////STOP THE PLAYER/////////////
                             play_wireless(SongsPaths[songPlayed]);
                         }
                         isPlaying = false;
                     }
                     else if (songPlayed == -1)
                     {
                         MusicToTable[0].controls.play();
                         MusicToTable[0].PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
                         MusicToTable[0].settings.setMode("loop", loopMusic);
                         songPlayed = 0;
                         aTimer.Enabled = true;
                         aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                         totalTime.Text = MusicToTable[songPlayed].currentMedia.durationString;
                         nowPlaying.Text = "Now playing: " + MusicToTable[songPlayed].currentMedia.getItemInfo("Title");
                         nowPlaying.Location = new Point(StrokeOval.Location.X + (StrokeOval.Width - nowPlaying.Width) / 2, elapsedTime.Location.Y - 35);
                         if (connectedToServer)
                         {
                             MusicToTable[songPlayed].settings.mute = true;
                             play_wireless(SongsPaths[songPlayed]);
                         }
                         isPlaying = true;
                     }
                     else
                     {
                         MusicToTable[songPlayed].controls.play();
                         MusicToTable[songPlayed].PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
                         MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
                         aTimer.Enabled = true;
                         aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                         totalTime.Text = MusicToTable[songPlayed].currentMedia.durationString;
                         nowPlaying.Text = "Now playing: " + MusicToTable[songPlayed].currentMedia.getItemInfo("Title");
                         nowPlaying.Location = new Point(StrokeOval.Location.X + (StrokeOval.Width - nowPlaying.Width) / 2, elapsedTime.Location.Y - 35);
                         if (connectedToServer)
                         {
                             MusicToTable[songPlayed].settings.mute = true;
                             play_wireless(SongsPaths[songPlayed]);
                         }
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
             if (checkWifi.CheckState == System.Windows.Forms.CheckState.Checked)
                 viaWifi = true;
             else
                 viaWifi = false;
             if (viaWifi && !bwServer.IsBusy && !ChooseIPFormIsOpen)
             {
                 ChooseIP ChooseIPForm = new ChooseIP(this);
                 ChooseIPFormIsOpen = true;
                 ChooseIPForm.Show();
                 checkWifi.Enabled = false;
             }

             else
             {
                 //if (bwServer.IsBusy)
                 //{
                 //    bwServer.CancelAsync();
                 //    while (bwServer.IsBusy) { }
                 //}
             }
         }

         private void ReplayButton_Click(object sender, EventArgs e)
         {
             if (isPlaying)
             {
                 loopMusic = !loopMusic;
                 if (loopMusic)
                     ReplayButton.BackColor = System.Drawing.Color.Gainsboro;
                 else
                     ReplayButton.BackColor = System.Drawing.Color.WhiteSmoke;
                 if (songPlayed != -1)
                     MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
                 if (shuffleMusic && sender.Equals(ReplayButton))
                     ShuffleButton_Click(sender, e);
                 Console.WriteLine("sender: " + sender.Equals(ReplayButton));
                 Console.WriteLine("e: " + e);
             }
         }

         private void ShuffleButton_Click(object sender, EventArgs e)
         {
             if (isPlaying)
             {
                 shuffleMusic = !shuffleMusic;
                 if (shuffleMusic)
                     ShuffleButton.BackColor = System.Drawing.Color.Gainsboro;
                 else
                     ShuffleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                 if (loopMusic && sender.Equals(ShuffleButton))
                     ReplayButton_Click(sender, e);
             }
         }

         private  void OnTimedEvent(object e, ElapsedEventArgs args)
         {
             try
             {
                 if (elapsedTime.InvokeRequired)
                 {
                     elapsedTime.Invoke((Action)delegate { OnTimedEvent(e, args); });
                     return;
                 }

             }
             catch(Exception exc)
             {
                 Console.WriteLine("here1: " + exc);
                 this.Close();
             }
             try
             {
                 if (isPlaying)
                     elapsedTime.Text = MusicToTable[songPlayed].controls.currentPositionString;
                 else
                     elapsedTime.Text = "00:00";
                 fullOval.Width = Convert.ToInt32(StrokeOval.Width * MusicToTable[songPlayed].controls.currentPosition / MusicToTable[songPlayed].currentMedia.duration);
             }
             catch (System.OverflowException)
             {
                //fullOval.Width is not a number (NaN)
                // DO nothing
             }
             catch (System.ArgumentOutOfRangeException)
             {
                 //SongPlayed is greater than the MusicToTable size.
                 //This will be solved in LoadMusicInTable(songs)
             }
             catch (Exception exp)
             {
                 Console.WriteLine("here2: " + exp);
                 this.Close();
             }

             var timer = (System.Timers.Timer)e; // Get the timer that fired the event
             if (isPlaying)
                 timer.Start();
             else
                 timer.Stop();

         }

         private void ForwardButton_Click(object sender, EventArgs e)
         {
             if (isPlaying && (songPlayed != -1))
             {

                 MusicToTable[songPlayed].settings.setMode("loop", false);
                 MusicToTable[songPlayed].PlayStateChange -= new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
                 aTimer.Elapsed -= new ElapsedEventHandler(OnTimedEvent);
                 MusicToTable[songPlayed].controls.stop();

                for (int i = 0; i < MusicToTable.Count; i++)
                {

                     if (i == MusicToTable.Count - 1)
                     {
                         for (int k = 0; k < MusicToTable.Count; k++)
                         {
                             if (songGrid.Rows[0].Cells[0].FormattedValue.ToString() == MusicToTable[k].currentMedia.getItemInfo("Title"))
                             {
                                 songPlayed = k;
                                 break;
                             }
                        }
                        break;
                     }
                     if (songGrid.Rows[i].Cells[0].FormattedValue.ToString() == MusicToTable[songPlayed].currentMedia.getItemInfo("Title"))
                     {

                         for (int m = 0; m < MusicToTable.Count; m++)
                         {
                             if(songGrid.Rows[i + 1].Cells[0].FormattedValue.ToString() == MusicToTable[m].currentMedia.getItemInfo("Title"))
                             {
                                 songPlayed = m;
                                 break;
                             }
                         }
                        break;
                 }
             }
             
             MusicToTable[songPlayed].controls.play();
             MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
             totalTime.Text = MusicToTable[songPlayed].currentMedia.durationString;
             nowPlaying.Text = "Now playing: " + MusicToTable[songPlayed].currentMedia.getItemInfo("Title");
             nowPlaying.Location = new Point(StrokeOval.Location.X + (StrokeOval.Width - nowPlaying.Width) / 2, elapsedTime.Location.Y - 35);
             aTimer.Enabled = true;
             aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
             }
         }

         private void BackwardButton_Click(object sender, EventArgs e)
         {
             if (isPlaying && (songPlayed != -1))
             {
                 MusicToTable[songPlayed].settings.setMode("loop", false);
                 MusicToTable[songPlayed].PlayStateChange -= new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
                 aTimer.Elapsed -= new ElapsedEventHandler(OnTimedEvent);
                 MusicToTable[songPlayed].controls.stop();

                 for (int i = 0; i < MusicToTable.Count; i++)
                 {

                     if (songGrid.Rows[0].Cells[0].FormattedValue.ToString() == MusicToTable[songPlayed].currentMedia.getItemInfo("Title"))
                     {
                         for (int k = 0; k < MusicToTable.Count; k++)
                         {
                             if (songGrid.Rows[MusicToTable.Count - 1].Cells[0].FormattedValue.ToString() == MusicToTable[k].currentMedia.getItemInfo("Title"))
                             {
                                 songPlayed = k;
                                 break;
                             }
                         }
                         break;
                     }
                     if (songGrid.Rows[i].Cells[0].FormattedValue.ToString() == MusicToTable[songPlayed].currentMedia.getItemInfo("Title"))
                     {

                         for (int m = 0; m < MusicToTable.Count; m++)
                         {
                             if (songGrid.Rows[i - 1].Cells[0].FormattedValue.ToString() == MusicToTable[m].currentMedia.getItemInfo("Title"))
                             {
                                 songPlayed = m;
                                 break;
                             }
                         }
                         break;
                     }
                 }

                 MusicToTable[songPlayed].controls.play();
                 MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
                 totalTime.Text = MusicToTable[songPlayed].currentMedia.durationString;
                 nowPlaying.Text = "Now playing: " + MusicToTable[songPlayed].currentMedia.getItemInfo("Title");
                 nowPlaying.Location = new Point(StrokeOval.Location.X + (StrokeOval.Width - nowPlaying.Width) / 2, elapsedTime.Location.Y - 35);
                 aTimer.Enabled = true;
                 aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
             }
         }

         private void removeMusicButton_Click(object sender, EventArgs e)
         {
             if (!rmMusicIsOpen)
             {
                 RemoveMusicDialog rmMusic = new RemoveMusicDialog(this);
                 rmMusicIsOpen = true;
                 rmMusic.Show();
             }
         }
         private void OnPlayStateChange(int NewState)
         {
             if (NewState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
             {
                 if (MusicToTable.Count == 1)
                     MusicToTable[songPlayed].settings.setMode("loop", true);
                 else if (isPlaying && (songPlayed != -1) && !loopMusic)
                 {
                     MusicToTable[songPlayed].settings.setMode("loop", false);
                     MusicToTable[songPlayed].PlayStateChange -= new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
                     aTimer.Elapsed -= new ElapsedEventHandler(OnTimedEvent);
                     MusicToTable[songPlayed].controls.stop();

                     if (!shuffleMusic)
                     {
                         for (int i = 0; i < MusicToTable.Count; i++)
                         {

                             if (i == MusicToTable.Count - 1)
                             {
                                 for (int k = 0; k < MusicToTable.Count; k++)
                                 {
                                     if (songGrid.Rows[0].Cells[0].FormattedValue.ToString() == MusicToTable[k].currentMedia.getItemInfo("Title"))
                                     {
                                         songPlayed = k;
                                         break;
                                     }
                                 }
                                 break;
                             }
                             try
                             {
                                 if (songGrid.Rows[i].Cells[0].FormattedValue.ToString() == MusicToTable[songPlayed].currentMedia.getItemInfo("Title"))
                                 {

                                     for (int m = 0; m < MusicToTable.Count; m++)
                                     {
                                         if (songGrid.Rows[i + 1].Cells[0].FormattedValue.ToString() == MusicToTable[m].currentMedia.getItemInfo("Title"))
                                         {
                                             songPlayed = m;
                                             break;
                                         }
                                     }
                                     break;
                                 }
                             }
                             catch(Exception exp)
                             {
                                 Console.WriteLine(exp);
                                 this.Close();
                             }
                         }
                     }
                     else
                     {
                         do
                         {
                             randomSong = random.Next(0, MusicToTable.Count);
                         }
                         while (songPlayed == randomSong);
                         songPlayed = randomSong;
                     }
                     MusicToTable[songPlayed].controls.play();
                     MusicToTable[songPlayed].PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
                     MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
                     totalTime.Text = MusicToTable[songPlayed].currentMedia.durationString;
                     nowPlaying.Text = "Now playing: " + MusicToTable[songPlayed].currentMedia.getItemInfo("Title");
                     nowPlaying.Location = new Point(StrokeOval.Location.X + (StrokeOval.Width - nowPlaying.Width) / 2, elapsedTime.Location.Y - 35);
                     aTimer.Enabled = true;
                     aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                 }
             }
         }

         private void Form1_FormClosing(object sender, FormClosingEventArgs e)
         {
             Pimung.Properties.Settings.Default.paths = SongsPaths;
             Pimung.Properties.Settings.Default.Save();
         }

         private void button1_Click(object sender, EventArgs e)
         {
             songGrid.Visible = true;
             listsLayout.Visible = false;
         }

         private void plannerButton_Click(object sender, EventArgs e)
         {
             songGrid.Visible = false;
             listsLayout.Visible = true;
         }

         private void readFromArduino_CheckedChanged(object sender, EventArgs e)
         {
             if(readFromArduino.CheckState == System.Windows.Forms.CheckState.Checked)
             {
                 setComPorts();
                 if (portFound)
                 {
                     MessageBox.Show("Connected on " + currentPort.PortName);
                     Console.WriteLine(currentPort.PortName);
                     portTimer.Elapsed += new ElapsedEventHandler(readFromPort);
                     portTimer.Interval = 500;
                     portTimer.Enabled = true;
                     currentPort.Open();
                 }
                 else
                 {
                     currentPort.Close();
                     readFromArduino.CheckState = System.Windows.Forms.CheckState.Unchecked;
                     MessageBox.Show("Could not connect to arduino");
                 }
             }
             else
             {
                 if(currentPort.IsOpen)
                 {
                     currentPort.Close();
                     readFromArduino.CheckState = System.Windows.Forms.CheckState.Unchecked;
                     portFound = false;
                 }
             }
         }

        private  void readFromPort(object e, ElapsedEventArgs args)
        {
            if (currentPort.IsOpen)
            {
                if (currentPort.BytesToRead > 0)
                {
                    int btr = currentPort.ReadByte();
                    if (btr == 1)
                    {
                        object sender = new object();
                        EventArgs evt = new EventArgs();
                        Console.WriteLine("Play");
                        if (totalTime.InvokeRequired)
                            totalTime.Invoke((Action)delegate { playStopMusic(sender, evt); });
                    }
                    if (btr == 2)
                    {
                        object sender = new object();
                        EventArgs evt = new EventArgs();
                        Console.WriteLine("Forward");
                        if (totalTime.InvokeRequired)
                            totalTime.Invoke((Action)delegate { ForwardButton_Click(sender, evt); });
                    }
                    if (btr == 3)
                    {
                        object sender = new object();
                        EventArgs evt = new EventArgs();
                        Console.WriteLine("Backward");
                        if (totalTime.InvokeRequired)
                            totalTime.Invoke((Action)delegate { BackwardButton_Click(sender, evt); });
                    }
                }
            }
            else
            {
                readFromArduino.CheckState = System.Windows.Forms.CheckState.Unchecked;
                portFound = false;
                portTimer.Enabled = false;
                Console.WriteLine("Stop reading");

            }
        }
    }
}
