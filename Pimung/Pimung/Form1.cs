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
        List<int> indices = new List<int>();
        List<int> reverseIndices = new List<int>();
        List<string> items = new List<string>();
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
        BackgroundWorker bwMusic2 = new BackgroundWorker();
        internal BackgroundWorker bwServer = new BackgroundWorker();
        internal Boolean connectedToServer = false;
        TcpClient client;
        string lastIp = "";

        string[] quotesArray = {"Arguing with a fool only proves that there are two...", "The key to success is not through achievement, but through enthusiasm.  Malcolm Forbes", "All you need in this life is ignorance and confidence, and then success is sure.  Mark Twain", "Age is of no importance unless you're a cheese.  Billie Burke", "The best way to cheer yourself up is to try to cheer somebody else up. Mark Twain", "The elevator to success is out of order. You'll have to use the stairs: one step at a time.  Joe Girard", "I always wanted to be somebody, but now I realize I should have been more specific.  Lily Tomlin", "If you think you are too small to be effective, you have never been in the dark with a mosquito.  Betty Reese", "Hope is the dream of a waking man.  Aristotle", "He who knows others is wise. He who knows himself is enlightened.  Lao Tzu", "When you do not know what you are doing and what you are doing is the best  that is inspiration.  Robert Bresson", "It is not the answer that enlightens, but the question.  Eugene Ionesco Decouvertes", "It takes less time to do things right than to explain why you did it wrong.  Henry Wadsworth Longfellow", "Opportunity is missed by most people because it is dressed in overalls and looks like work.  Thomas Eddison", "Great spirits have always encountered violent opposition from mediocre minds.  Albert Einstein", "People say nothing is impossible, but I do nothing every day.  A.A. Milne", "Failure is the condiment that gives success its flavor.  Truman Capote", "People often say that motivation doesn't last. Well, neither does bathing; that's why we recommend it daily.  Zig Ziglar", "Life is like photography. You need the negatives to develop.  Unknown", "It is amazing what you can accomplish if you do not care who gets the credit.  Harry S. Truman", "Seven days without laughter make one weak.  Joel Goodman", "Vision without action is daydream. Action without vision is nightmare.  Japanese proverb", "Good habits are as addictive as bad habits, and a lot more rewarding.", "Sunglasses: allowing you stare at people without getting caught. It's like Facebook in real life.", "No matter how you feel, get up, dress up, show up, and never give up!", "A good laugh and a long sleep are the two best cures for anything.", "Sometimes the wrong choices bring us to the right places.", "Change your thoughts and you change your world." };
        public Form1()
        {
            InitializeComponent();
        }

        private void play_wireless(string path)
        {
            if (bwMusic.IsBusy)
            {
                bwMusic.CancelAsync();
                Console.WriteLine("Cancel async");
                bwMusic2.RunWorkerAsync(path);
            }
            else
            {
                if (bwMusic2.IsBusy)
                {
                    bwMusic2.CancelAsync();
                    Console.WriteLine("O intrat");
                }
                bwMusic.RunWorkerAsync(path);
                return;
            }
       

        }

        void bwMusic_DoWork(object sender, DoWorkEventArgs e) //bwMusic
        {
            try
            {
                if (MusicToTable[songPlayed].currentMedia.getItemInfo("FileType") == "mp3")
                {
                    pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader((string)e.Argument));
                }
                else
                {
                    e.Cancel = true;
                    object obj = new object();
                    EventArgs evt = new EventArgs();
                    playStopMusic(obj, evt);
                    MessageBox.Show("I can not send wav files to server. Please try mp3 files.");
                    return;
                }
                int oneSec = 1204 * 4;  //1204 samples * 2 channels * 2 bytes each
                byte[] buffer = new byte[oneSec];
                int ret = 0;

                do
                {
                    if (bwMusic.CancellationPending)
                    {
                        pcm.Dispose();
                        e.Cancel = true;
                        Console.WriteLine("Has returned1");
                        return;
                    }
                    if (pcm != null)
                        ret = pcm.Read(buffer, 0, oneSec);
                    if (ns !=null)
                     ns.Write(buffer, 0, oneSec);
                } while (ret >= 0);
                pcm.Dispose();
                
                
            }
            catch
            {
                MessageBox.Show("Something went wrong with the server");
                connectedToServer = false;
            }
        }

        void bwMusic2_DoWork(object sender, DoWorkEventArgs e) //bwMusic2
        {
            try
            {
                if (MusicToTable[songPlayed].currentMedia.getItemInfo("FileType") == "mp3")
                    pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader((string)e.Argument));
                else
                {
                    e.Cancel = true;
                    object obj = new object();
                    EventArgs evt = new EventArgs();
                    playStopMusic(obj, evt);
                    MessageBox.Show("I can not send wav files to server. Please try mp3 files.");
                    return;
                }
                int oneSec = 1204 * 4;
                byte[] buffer = new byte[oneSec];
                int ret = 0;

                do
                {
                    if (bwMusic2.CancellationPending)
                    {
                        pcm.Dispose();
                        e.Cancel = true;
                        Console.WriteLine("Has returned2");
                        return;
                    }
                    ret = pcm.Read(buffer, 0, oneSec);
                    ns.Write(buffer, 0, oneSec);
                } while (ret != -1);
                pcm.Dispose();


            }
            catch
            {
                MessageBox.Show("Something went wrong");
                connectedToServer = false;
            }
        }

        void bwServer_DoWork(object sender, DoWorkEventArgs e)  //bwserver
        {
            try
            {
                Console.WriteLine(lastIp != (string)e.Argument);
                Console.WriteLine(lastIp);
                Console.WriteLine((string)e.Argument);
                if (lastIp != (string)e.Argument)
                {
                    lastIp = (string)e.Argument;
                    client = new TcpClient(lastIp, 7654);
                    ns = client.GetStream();

                    Console.WriteLine(client.Client.LocalEndPoint.ToString());
                    Console.WriteLine("o intrat");
                }

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
            mainPurpose.Width = WhatDoToday.Width - 80;
            yourDP.Location = new Point(0, 10);
            addItemBox.Location = new Point(40, yourDP.Location.Y + yourDP.Height + 25);
            addItemButton.Location = new Point(addItemBox.Location.X + addItemBox.Width + 4, addItemBox.Location.Y);
            todoList.Location = new Point(addItemBox.Location.X, addItemBox.Location.Y + addItemBox.Height + 5);
            todoList.Width = addItemButton.Location.X + addItemButton.Width - addItemBox.Location.X;
            todoList.Height = this.Height - panel2.Height - panel2.Location.Y - 60 - todoList.Location.Y - deleteItems.Height;
            deleteItems.Width = addItemBox.Width + addItemButton.Width + 4;
            deleteItems.Location = new Point(addItemBox.Location.X, todoList.Location.Y + todoList.Height + 4);
            listsLayout.Visible = false;
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Enabled = true;
            aTimer.Interval = 200;
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Start();

            if(Pimung.Properties.Settings.Default.itemsSaved != null)
            {
                items = Pimung.Properties.Settings.Default.itemsSaved;
                for(int i = 0; i < Pimung.Properties.Settings.Default.itemsSaved.Count; i++)
                {
                    todoList.Items.Add(Pimung.Properties.Settings.Default.itemsSaved[i]);
                }
            }
            if (Pimung.Properties.Settings.Default.paths != null)
            {
                SongsPaths = Pimung.Properties.Settings.Default.paths;
                LoadMusicInTable(SongsPaths);
                Console.WriteLine(SongsPaths);
            }
            if (Pimung.Properties.Settings.Default.date == null || Pimung.Properties.Settings.Default.purpose == null || Pimung.Properties.Settings.Default.date != DateTime.Now.ToShortDateString())
            {
                WhatDoToday.Visible = true;
                today.Visible = false;
                mainPurpose.Visible = true;
                mainPurpose.Text = "";
                purposeAnswer.Visible = false;
                reType.Visible = false;
            }
            else
            {
                WhatDoToday.Visible = false;
                today.Visible = true;
                mainPurpose.Visible = false;
                purposeAnswer.Text = Pimung.Properties.Settings.Default.purpose;
                purposeAnswer.Visible = true;
                reType.Visible = true;
            }
            setComPorts();
            if(portFound)
                Console.WriteLine(currentPort.PortName);


            
            bwMusic.DoWork += bwMusic_DoWork;
            bwMusic.WorkerSupportsCancellation = true;
            bwMusic2.DoWork += bwMusic2_DoWork;
            bwMusic2.WorkerSupportsCancellation = true;
            bwServer.DoWork += bwServer_DoWork;
            bwServer.WorkerSupportsCancellation = true;

            Form1_Resize(sender, e);
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

            
            WhatDoToday.Location = new Point(this.Width - WhatDoToday.Width - 30, 40);
            today.Location = new Point(WhatDoToday.Location.X + (WhatDoToday.Width - today.Width) / 2, WhatDoToday.Location.Y);
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
            listsLayout.Location = new Point(LeftMenu.Width, LeftMenu.Location.Y);
            listsLayout.Width = this.Width - LeftMenu.Width;
            listsLayout.Height = this.Height - panel2.Height - panel2.Location.Y - 50;
            nowPlaying.Location = new Point(StrokeOval.Location.X + (StrokeOval.Width - nowPlaying.Width) / 2, elapsedTime.Location.Y - 35);
            songGrid.Location = new Point(LeftMenu.Width, panel2.Location.Y + panel2.Height);
            songGrid.Height = this.Height - panel2.Height - panel2.Location.Y - 50;
            songGrid.Width = this.Width - LeftMenu.Width - 20;
            todoList.Height = this.Height - panel2.Height - panel2.Location.Y - 60 - todoList.Location.Y - deleteItems.Height;
            deleteItems.Location = new Point(addItemBox.Location.X, todoList.Location.Y + todoList.Height + 4);
            ReplayButton.Location = new Point(StrokeOval.Location.X, StrokeOval.Location.Y + StrokeOval.Height + 20);
            ShuffleButton.Location = new Point(StrokeOval.Location.X + StrokeOval.Width - ShuffleButton.Width, StrokeOval.Location.Y + StrokeOval.Height + 20);
            mainPurpose.Location = new Point(WhatDoToday.Location.X + 40, WhatDoToday.Location.Y + 2 * WhatDoToday.Height - mainPurpose.Height);
            purposeAnswer.Location = new Point(WhatDoToday.Location.X + (WhatDoToday.Width - purposeAnswer.Width) / 2, mainPurpose.Location.Y);
            reType.Location = new Point(purposeAnswer.Location.X + purposeAnswer.Width + 5, purposeAnswer.Location.Y + purposeAnswer.Height / 2);
            needMot.Location = new Point(( listsLayout.Width - addItemButton.Location.X - addItemButton.Width - needMot.Width) / 2 + addItemButton.Location.X + addItemButton.Width, 100);
            pressMe.Location = new Point((listsLayout.Width - addItemButton.Location.X - addItemButton.Width - pressMe.Width) / 2 + addItemButton.Location.X + addItemButton.Width, needMot.Location.Y + needMot.Height + 20);
            quoteContainer.Location = new Point(addItemButton.Location.X + addItemButton.Width + 50, pressMe.Location.Y + 60);
            quoteContainer.Width = listsLayout.Width - quoteContainer.Location.X - 10;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (reType.Visible == false)
                e.Graphics.DrawLine(new Pen(Color.FromArgb(255, 38, 126, 200), 1), WhatDoToday.Location.X + 40, WhatDoToday.Location.Y + 2 * WhatDoToday.Height, WhatDoToday.Location.X + WhatDoToday.Width - 40, WhatDoToday.Location.Y + 2 * WhatDoToday.Height);
            
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
            if (startDragging && (MousePosition.Y - this.Top > panel1OriginalHeight + 35) && MousePosition.Y - this.Top <= 305)
            {
                panel1.Height = MousePosition.Y - this.Top - 35;
                panel2.Location = new Point(0, panel1.Height + panel1.Location.Y);
                LeftMenu.Location = new Point(0, panel2.Location.Y + 10);
                listsLayout.Location = new Point(LeftMenu.Width, LeftMenu.Location.Y);
                songGrid.Location = new Point(LeftMenu.Width, panel2.Location.Y + panel2.Height);
                songGrid.Height = this.Height - panel2.Height - panel2.Location.Y - 50;
            }
            else if (startDragging && MousePosition.Y - this.Top > 305)
            {
                panel1.Height = 305 - 35;
                panel2.Location = new Point(0, panel1.Height + panel1.Location.Y);
                LeftMenu.Location = new Point(0, panel2.Location.Y + 10);
                listsLayout.Location = new Point(LeftMenu.Width, LeftMenu.Location.Y);
                songGrid.Location = new Point(LeftMenu.Width, panel2.Location.Y + panel2.Height);
                songGrid.Height = this.Height - panel2.Height - panel2.Location.Y - 50;
            }

            else if(startDragging)
            {
                panel1.Height = panel1OriginalHeight;
                panel2.Location = new Point(0, panel1.Height + panel1.Location.Y);
                LeftMenu.Location = new Point(0, panel2.Location.Y + 10);
                listsLayout.Location = new Point(LeftMenu.Width, LeftMenu.Location.Y);
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
            try
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
            catch (Exception ext)
            {
                MessageBox.Show("Something went wrong :( Are you sure that you haven't changed the files' path? The following exception occurred: " + ext);
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
             try
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
                                 MusicToTable[songPlayed].settings.mute = false;
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
                             if (connectedToServer)
                             {
                                 MusicToTable[songPlayed].controls.stop();
                                 if (bwMusic.IsBusy)
                                     bwMusic.CancelAsync();
                                 if (bwMusic2.IsBusy)
                                     bwMusic2.CancelAsync();
                             }
                             isPlaying = false;
                         }
                         else if (songPlayed == -1)
                         {
                             MusicToTable[0].controls.play();
                             MusicToTable[0].settings.mute = false;
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
                             MusicToTable[songPlayed].settings.mute = false;
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
                     if (isPlaying)
                         PlayButton.BackgroundImage = Pimung.Properties.Resources.PauseBotton;
                     else
                         PlayButton.BackgroundImage = Pimung.Properties.Resources.playButton2;
                 }
             }
             catch (Exception ext)
             {
                 MessageBox.Show("Something went wrong :( Are you sure that you haven't changed the files' path? The following exception occurred: " + ext);
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

             else if (!viaWifi && connectedToServer)
             {
                 if (bwMusic.IsBusy)
                     bwMusic.CancelAsync();
                 if (bwMusic2.IsBusy)
                     bwMusic2.CancelAsync();
                 connectedToServer = false;
                 object snd = new object();
                 EventArgs evt = new EventArgs();
                 Console.WriteLine("Play");
                 playStopMusic(snd, evt);
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

                 if (MusicToTable.Count == 1)
                     songPlayed = 0;
                 else if (!shuffleMusic)
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
                 }
                 else
                     songPlayed = random.Next(0, MusicToTable.Count);
             
             MusicToTable[songPlayed].controls.play();
             MusicToTable[songPlayed].settings.mute = false;
             MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
             if (connectedToServer)
             {
                 MusicToTable[songPlayed].settings.mute = true;
                 play_wireless(SongsPaths[songPlayed]);
             }
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
                 MusicToTable[songPlayed].settings.mute = false;
                 MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
                 if (connectedToServer)
                 {
                     MusicToTable[songPlayed].settings.mute = true;
                     play_wireless(SongsPaths[songPlayed]);
                 }
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
                     MusicToTable[songPlayed].settings.mute = false;
                     MusicToTable[songPlayed].PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
                     if (connectedToServer)
                     {
                         MusicToTable[songPlayed].settings.mute = true;
                         play_wireless(SongsPaths[songPlayed]);
                     }
                     MusicToTable[songPlayed].settings.setMode("loop", loopMusic);
                     totalTime.Text = MusicToTable[songPlayed].currentMedia.durationString;
                     nowPlaying.Text = "Now playing: " + MusicToTable[songPlayed].currentMedia.getItemInfo("Title");
                     nowPlaying.Location = new Point(StrokeOval.Location.X + (StrokeOval.Width - nowPlaying.Width) / 2, elapsedTime.Location.Y - 35);
                     aTimer.Enabled = true;
                     aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                 }
             }
         }

         private void playerButton_Click(object sender, EventArgs e)
         {
             songGrid.Visible = true;
             listsLayout.Visible = false;
             plannerButton.BackColor = System.Drawing.Color.WhiteSmoke;
             playerButton.BackColor = System.Drawing.Color.Gainsboro;
         }

         private void plannerButton_Click(object sender, EventArgs e)
         {
             songGrid.Visible = false;
             listsLayout.Visible = true;
             plannerButton.BackColor = System.Drawing.Color.Gainsboro;
             playerButton.BackColor = System.Drawing.Color.WhiteSmoke;

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
                     try
                     {
                         currentPort.Close();
                     }
                     catch { }
                     readFromArduino.CheckState = System.Windows.Forms.CheckState.Unchecked;
                     MessageBox.Show("Could not connect to arduino");
                 }
             }
             else
             {
                 if (currentPort != null)
                 {
                     if (currentPort.IsOpen)
                     {
                         try
                         {
                             currentPort.Close();
                         }
                         catch { }
                         readFromArduino.CheckState = System.Windows.Forms.CheckState.Unchecked;
                         portFound = false;
                     }
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

        private void mainPurpose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("Enter");
                e.Handled = true;
                e.SuppressKeyPress = true;
                purposeAnswer.Visible = true;
                mainPurpose.Visible = false;
                reType.Visible = true;
                WhatDoToday.Visible = false;
                today.Visible = true;
                purposeAnswer.Text = mainPurpose.Text + "!";
                purposeAnswer.Location = new Point(WhatDoToday.Location.X + (WhatDoToday.Width - purposeAnswer.Width) / 2, mainPurpose.Location.Y);
                reType.Location = new Point(purposeAnswer.Location.X + purposeAnswer.Width + 5, purposeAnswer.Location.Y + purposeAnswer.Height / 2);
                Pimung.Properties.Settings.Default.purpose = purposeAnswer.Text;
                Pimung.Properties.Settings.Default.date = DateTime.Now.ToShortDateString();
                Pimung.Properties.Settings.Default.Save();
                panel1.Refresh();
                

            }
        }

        private void reType_Click(object sender, EventArgs e)
        {
            Pimung.Properties.Settings.Default.date = "28.02.1989";
            Pimung.Properties.Settings.Default.Save();
            reType.Visible = false;
            mainPurpose.Visible = true;
            mainPurpose.Text = "";
            purposeAnswer.Visible = false;
            WhatDoToday.Visible = true;
            today.Visible = false;
            panel1.Refresh();
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            items.Add(addItemBox.Text);
            todoList.Items.Add(addItemBox.Text);
            addItemBox.Text = "";
        }

        private void addItemBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                object obj = new Object();
                EventArgs evt = new EventArgs();
                addItemButton_Click(obj, evt);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void deleteItems_Click(object sender, EventArgs e)
        {
            indices.Clear();
            reverseIndices.Clear();
            foreach (int indexChecked in todoList.CheckedIndices)
            {
                indices.Add(indexChecked);
                Console.WriteLine("index checked: " + indexChecked);
            }

            descendingOrdering(indices);
            foreach (int indexChecked in reverseIndices)
            {
                todoList.Items.RemoveAt(indexChecked);
                items.RemoveAt(indexChecked);
            }
        }

        private void descendingOrdering(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                reverseIndices.Add(list[list.Count - i - 1]);
            }
        }

        private void pressMe_Click(object sender, EventArgs e)
        {


            actualQuote.Text = quotesArray[random.Next(0, quotesArray.Length)];

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pcm != null)
                pcm.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (portFound)
            {
                try
                {
                    currentPort.Close();
                }
                catch { }
            }
            Pimung.Properties.Settings.Default.paths = SongsPaths;
            Pimung.Properties.Settings.Default.itemsSaved = items;
            Pimung.Properties.Settings.Default.Save();
        }
    }
}
