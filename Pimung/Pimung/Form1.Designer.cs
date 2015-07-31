namespace Pimung
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.today = new System.Windows.Forms.Label();
            this.reType = new System.Windows.Forms.Label();
            this.purposeAnswer = new System.Windows.Forms.Label();
            this.mainPurpose = new System.Windows.Forms.TextBox();
            this.removeMusicButton = new System.Windows.Forms.Label();
            this.nowPlaying = new System.Windows.Forms.Label();
            this.elapsedTime = new System.Windows.Forms.Label();
            this.totalTime = new System.Windows.Forms.Label();
            this.readFromArduino = new System.Windows.Forms.CheckBox();
            this.checkWifi = new System.Windows.Forms.CheckBox();
            this.AddMusicBotton = new System.Windows.Forms.Label();
            this.fullOval = new System.Windows.Forms.PictureBox();
            this.StrokeOval = new System.Windows.Forms.PictureBox();
            this.ReplayButton = new System.Windows.Forms.PictureBox();
            this.ShuffleButton = new System.Windows.Forms.PictureBox();
            this.WhatDoToday = new System.Windows.Forms.Label();
            this.BackwardButton = new System.Windows.Forms.PictureBox();
            this.ForwardButton = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LeftMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.playerButton = new System.Windows.Forms.Button();
            this.plannerButton = new System.Windows.Forms.Button();
            this.BrowseMusic = new System.Windows.Forms.OpenFileDialog();
            this.songGrid = new System.Windows.Forms.DataGridView();
            this.songName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songAlbum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yourDP = new System.Windows.Forms.Label();
            this.listsLayout = new System.Windows.Forms.Panel();
            this.quoteContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.actualQuote = new System.Windows.Forms.Label();
            this.needMot = new System.Windows.Forms.Label();
            this.deleteItems = new System.Windows.Forms.Button();
            this.todoList = new System.Windows.Forms.CheckedListBox();
            this.pressMe = new System.Windows.Forms.Button();
            this.addItemButton = new System.Windows.Forms.Button();
            this.addItemBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullOval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrokeOval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShuffleButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackwardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).BeginInit();
            this.LeftMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songGrid)).BeginInit();
            this.listsLayout.SuspendLayout();
            this.quoteContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.today);
            this.panel1.Controls.Add(this.reType);
            this.panel1.Controls.Add(this.purposeAnswer);
            this.panel1.Controls.Add(this.mainPurpose);
            this.panel1.Controls.Add(this.removeMusicButton);
            this.panel1.Controls.Add(this.nowPlaying);
            this.panel1.Controls.Add(this.elapsedTime);
            this.panel1.Controls.Add(this.totalTime);
            this.panel1.Controls.Add(this.readFromArduino);
            this.panel1.Controls.Add(this.checkWifi);
            this.panel1.Controls.Add(this.AddMusicBotton);
            this.panel1.Controls.Add(this.fullOval);
            this.panel1.Controls.Add(this.StrokeOval);
            this.panel1.Controls.Add(this.ReplayButton);
            this.panel1.Controls.Add(this.ShuffleButton);
            this.panel1.Controls.Add(this.WhatDoToday);
            this.panel1.Controls.Add(this.BackwardButton);
            this.panel1.Controls.Add(this.ForwardButton);
            this.panel1.Controls.Add(this.PlayButton);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 145);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // today
            // 
            this.today.AutoSize = true;
            this.today.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.today.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.today.Location = new System.Drawing.Point(817, 20);
            this.today.Name = "today";
            this.today.Size = new System.Drawing.Size(83, 33);
            this.today.TabIndex = 14;
            this.today.Text = "Today,";
            // 
            // reType
            // 
            this.reType.AutoSize = true;
            this.reType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reType.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reType.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.reType.Location = new System.Drawing.Point(940, 66);
            this.reType.Name = "reType";
            this.reType.Size = new System.Drawing.Size(12, 13);
            this.reType.TabIndex = 13;
            this.reType.Text = "x";
            this.reType.Click += new System.EventHandler(this.reType_Click);
            // 
            // purposeAnswer
            // 
            this.purposeAnswer.AutoSize = true;
            this.purposeAnswer.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.purposeAnswer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.purposeAnswer.Location = new System.Drawing.Point(849, 37);
            this.purposeAnswer.Name = "purposeAnswer";
            this.purposeAnswer.Size = new System.Drawing.Size(74, 29);
            this.purposeAnswer.TabIndex = 12;
            this.purposeAnswer.Text = "label1";
            // 
            // mainPurpose
            // 
            this.mainPurpose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPurpose.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainPurpose.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mainPurpose.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.mainPurpose.Location = new System.Drawing.Point(779, 66);
            this.mainPurpose.MaxLength = 23;
            this.mainPurpose.Name = "mainPurpose";
            this.mainPurpose.Size = new System.Drawing.Size(115, 30);
            this.mainPurpose.TabIndex = 11;
            this.mainPurpose.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mainPurpose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainPurpose_KeyDown);
            // 
            // removeMusicButton
            // 
            this.removeMusicButton.AutoSize = true;
            this.removeMusicButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeMusicButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeMusicButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.removeMusicButton.Location = new System.Drawing.Point(174, 73);
            this.removeMusicButton.Name = "removeMusicButton";
            this.removeMusicButton.Size = new System.Drawing.Size(283, 26);
            this.removeMusicButton.TabIndex = 6;
            this.removeMusicButton.Text = "Remove music from your player";
            this.removeMusicButton.Click += new System.EventHandler(this.removeMusicButton_Click);
            // 
            // nowPlaying
            // 
            this.nowPlaying.AutoSize = true;
            this.nowPlaying.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nowPlaying.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.nowPlaying.Location = new System.Drawing.Point(310, 27);
            this.nowPlaying.Name = "nowPlaying";
            this.nowPlaying.Size = new System.Drawing.Size(0, 26);
            this.nowPlaying.TabIndex = 10;
            // 
            // elapsedTime
            // 
            this.elapsedTime.AutoSize = true;
            this.elapsedTime.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.elapsedTime.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.elapsedTime.Location = new System.Drawing.Point(423, 100);
            this.elapsedTime.Name = "elapsedTime";
            this.elapsedTime.Size = new System.Drawing.Size(34, 13);
            this.elapsedTime.TabIndex = 9;
            this.elapsedTime.Text = "00:00";
            // 
            // totalTime
            // 
            this.totalTime.AutoSize = true;
            this.totalTime.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.totalTime.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.totalTime.Location = new System.Drawing.Point(776, 94);
            this.totalTime.Name = "totalTime";
            this.totalTime.Size = new System.Drawing.Size(34, 13);
            this.totalTime.TabIndex = 8;
            this.totalTime.Text = "00:00";
            // 
            // readFromArduino
            // 
            this.readFromArduino.AutoSize = true;
            this.readFromArduino.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.readFromArduino.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.readFromArduino.Location = new System.Drawing.Point(496, 83);
            this.readFromArduino.Name = "readFromArduino";
            this.readFromArduino.Size = new System.Drawing.Size(152, 30);
            this.readFromArduino.TabIndex = 7;
            this.readFromArduino.Text = "Enable knocks";
            this.readFromArduino.UseVisualStyleBackColor = true;
            this.readFromArduino.CheckedChanged += new System.EventHandler(this.readFromArduino_CheckedChanged);
            // 
            // checkWifi
            // 
            this.checkWifi.AutoSize = true;
            this.checkWifi.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkWifi.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkWifi.Location = new System.Drawing.Point(423, 63);
            this.checkWifi.Name = "checkWifi";
            this.checkWifi.Size = new System.Drawing.Size(201, 30);
            this.checkWifi.TabIndex = 7;
            this.checkWifi.Text = "Send music via WiFi";
            this.checkWifi.UseVisualStyleBackColor = true;
            this.checkWifi.CheckStateChanged += new System.EventHandler(this.checkWifi_CheckStateChanged);
            // 
            // AddMusicBotton
            // 
            this.AddMusicBotton.AutoSize = true;
            this.AddMusicBotton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddMusicBotton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddMusicBotton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AddMusicBotton.Location = new System.Drawing.Point(91, 112);
            this.AddMusicBotton.Name = "AddMusicBotton";
            this.AddMusicBotton.Size = new System.Drawing.Size(224, 26);
            this.AddMusicBotton.TabIndex = 6;
            this.AddMusicBotton.Text = "Add music in your player";
            this.AddMusicBotton.Click += new System.EventHandler(this.AddMusicBotton_Click);
            // 
            // fullOval
            // 
            this.fullOval.BackgroundImage = global::Pimung.Properties.Resources.FullOval;
            this.fullOval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fullOval.Location = new System.Drawing.Point(411, 110);
            this.fullOval.Name = "fullOval";
            this.fullOval.Size = new System.Drawing.Size(371, 19);
            this.fullOval.TabIndex = 5;
            this.fullOval.TabStop = false;
            // 
            // StrokeOval
            // 
            this.StrokeOval.BackgroundImage = global::Pimung.Properties.Resources.StrokeOval;
            this.StrokeOval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StrokeOval.Location = new System.Drawing.Point(426, 119);
            this.StrokeOval.Name = "StrokeOval";
            this.StrokeOval.Size = new System.Drawing.Size(371, 19);
            this.StrokeOval.TabIndex = 5;
            this.StrokeOval.TabStop = false;
            // 
            // ReplayButton
            // 
            this.ReplayButton.BackgroundImage = global::Pimung.Properties.Resources.Replay;
            this.ReplayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReplayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReplayButton.Location = new System.Drawing.Point(720, 73);
            this.ReplayButton.Name = "ReplayButton";
            this.ReplayButton.Size = new System.Drawing.Size(32, 20);
            this.ReplayButton.TabIndex = 4;
            this.ReplayButton.TabStop = false;
            this.ReplayButton.Click += new System.EventHandler(this.ReplayButton_Click);
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.BackgroundImage = global::Pimung.Properties.Resources.Shuffle;
            this.ShuffleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ShuffleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShuffleButton.Location = new System.Drawing.Point(385, 56);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(32, 20);
            this.ShuffleButton.TabIndex = 4;
            this.ShuffleButton.TabStop = false;
            this.ShuffleButton.Click += new System.EventHandler(this.ShuffleButton_Click);
            // 
            // WhatDoToday
            // 
            this.WhatDoToday.AutoSize = true;
            this.WhatDoToday.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WhatDoToday.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.WhatDoToday.Location = new System.Drawing.Point(463, 20);
            this.WhatDoToday.Name = "WhatDoToday";
            this.WhatDoToday.Size = new System.Drawing.Size(348, 33);
            this.WhatDoToday.TabIndex = 3;
            this.WhatDoToday.Text = "What do you wanna do today?";
            // 
            // BackwardButton
            // 
            this.BackwardButton.BackgroundImage = global::Pimung.Properties.Resources.BackwardButton1;
            this.BackwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackwardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackwardButton.Location = new System.Drawing.Point(96, 56);
            this.BackwardButton.Name = "BackwardButton";
            this.BackwardButton.Size = new System.Drawing.Size(48, 30);
            this.BackwardButton.TabIndex = 2;
            this.BackwardButton.TabStop = false;
            this.BackwardButton.Click += new System.EventHandler(this.BackwardButton_Click);
            // 
            // ForwardButton
            // 
            this.ForwardButton.BackgroundImage = global::Pimung.Properties.Resources.ForwardButton1;
            this.ForwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ForwardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForwardButton.Location = new System.Drawing.Point(288, 56);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(48, 30);
            this.ForwardButton.TabIndex = 1;
            this.ForwardButton.TabStop = false;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackgroundImage = global::Pimung.Properties.Resources.playButton2;
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayButton.Location = new System.Drawing.Point(195, 43);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(40, 50);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.TabStop = false;
            this.PlayButton.Click += new System.EventHandler(this.playStopMusic);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 15);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // LeftMenu
            // 
            this.LeftMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftMenu.Controls.Add(this.playerButton);
            this.LeftMenu.Controls.Add(this.plannerButton);
            this.LeftMenu.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.LeftMenu.Location = new System.Drawing.Point(4, 183);
            this.LeftMenu.Name = "LeftMenu";
            this.LeftMenu.Size = new System.Drawing.Size(156, 396);
            this.LeftMenu.TabIndex = 3;
            // 
            // playerButton
            // 
            this.playerButton.BackColor = System.Drawing.Color.Gainsboro;
            this.playerButton.FlatAppearance.BorderSize = 0;
            this.playerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerButton.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.playerButton.Location = new System.Drawing.Point(3, 3);
            this.playerButton.Name = "playerButton";
            this.playerButton.Size = new System.Drawing.Size(153, 49);
            this.playerButton.TabIndex = 0;
            this.playerButton.Text = "Player";
            this.playerButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playerButton.UseMnemonic = false;
            this.playerButton.UseVisualStyleBackColor = false;
            this.playerButton.Click += new System.EventHandler(this.playerButton_Click);
            // 
            // plannerButton
            // 
            this.plannerButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.plannerButton.FlatAppearance.BorderSize = 0;
            this.plannerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plannerButton.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.plannerButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.plannerButton.Location = new System.Drawing.Point(3, 58);
            this.plannerButton.Name = "plannerButton";
            this.plannerButton.Size = new System.Drawing.Size(153, 49);
            this.plannerButton.TabIndex = 0;
            this.plannerButton.Text = "Planner";
            this.plannerButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.plannerButton.UseMnemonic = false;
            this.plannerButton.UseVisualStyleBackColor = false;
            this.plannerButton.Click += new System.EventHandler(this.plannerButton_Click);
            // 
            // BrowseMusic
            // 
            this.BrowseMusic.Filter = "Music |*.mp3; *.wav";
            this.BrowseMusic.Multiselect = true;
            this.BrowseMusic.Title = "Choose Music";
            // 
            // songGrid
            // 
            this.songGrid.AllowUserToAddRows = false;
            this.songGrid.AllowUserToDeleteRows = false;
            this.songGrid.AllowUserToOrderColumns = true;
            this.songGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.songGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.songGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.songGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.songGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.songGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.songGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.songGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.songGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.songGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.songName,
            this.songDuration,
            this.songArtist,
            this.songAlbum,
            this.songGenre});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.songGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.songGrid.EnableHeadersVisualStyles = false;
            this.songGrid.GridColor = System.Drawing.Color.Gainsboro;
            this.songGrid.Location = new System.Drawing.Point(166, 186);
            this.songGrid.Name = "songGrid";
            this.songGrid.ReadOnly = true;
            this.songGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.songGrid.RowHeadersVisible = false;
            this.songGrid.Size = new System.Drawing.Size(652, 251);
            this.songGrid.TabIndex = 4;
            this.songGrid.DoubleClick += new System.EventHandler(this.playStopMusic);
            // 
            // songName
            // 
            this.songName.HeaderText = "Song";
            this.songName.Name = "songName";
            this.songName.ReadOnly = true;
            // 
            // songDuration
            // 
            this.songDuration.HeaderText = "Duration";
            this.songDuration.Name = "songDuration";
            this.songDuration.ReadOnly = true;
            // 
            // songArtist
            // 
            this.songArtist.HeaderText = "Artist";
            this.songArtist.Name = "songArtist";
            this.songArtist.ReadOnly = true;
            // 
            // songAlbum
            // 
            this.songAlbum.HeaderText = "Album";
            this.songAlbum.Name = "songAlbum";
            this.songAlbum.ReadOnly = true;
            // 
            // songGenre
            // 
            this.songGenre.HeaderText = "Genre";
            this.songGenre.Name = "songGenre";
            this.songGenre.ReadOnly = true;
            // 
            // yourDP
            // 
            this.yourDP.AutoSize = true;
            this.yourDP.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.yourDP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.yourDP.Location = new System.Drawing.Point(15, 1);
            this.yourDP.Name = "yourDP";
            this.yourDP.Size = new System.Drawing.Size(269, 36);
            this.yourDP.TabIndex = 0;
            this.yourDP.Text = "      Your daily planner";
            // 
            // listsLayout
            // 
            this.listsLayout.Controls.Add(this.quoteContainer);
            this.listsLayout.Controls.Add(this.needMot);
            this.listsLayout.Controls.Add(this.deleteItems);
            this.listsLayout.Controls.Add(this.todoList);
            this.listsLayout.Controls.Add(this.pressMe);
            this.listsLayout.Controls.Add(this.addItemButton);
            this.listsLayout.Controls.Add(this.addItemBox);
            this.listsLayout.Controls.Add(this.yourDP);
            this.listsLayout.Location = new System.Drawing.Point(173, 191);
            this.listsLayout.Name = "listsLayout";
            this.listsLayout.Size = new System.Drawing.Size(799, 408);
            this.listsLayout.TabIndex = 5;
            // 
            // quoteContainer
            // 
            this.quoteContainer.Controls.Add(this.actualQuote);
            this.quoteContainer.Location = new System.Drawing.Point(481, 238);
            this.quoteContainer.Name = "quoteContainer";
            this.quoteContainer.Size = new System.Drawing.Size(298, 586);
            this.quoteContainer.TabIndex = 6;
            // 
            // actualQuote
            // 
            this.actualQuote.AutoSize = true;
            this.actualQuote.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.actualQuote.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.actualQuote.Location = new System.Drawing.Point(3, 0);
            this.actualQuote.Name = "actualQuote";
            this.actualQuote.Size = new System.Drawing.Size(0, 29);
            this.actualQuote.TabIndex = 0;
            // 
            // needMot
            // 
            this.needMot.AutoSize = true;
            this.needMot.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.needMot.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.needMot.Location = new System.Drawing.Point(520, 50);
            this.needMot.Name = "needMot";
            this.needMot.Size = new System.Drawing.Size(276, 33);
            this.needMot.TabIndex = 5;
            this.needMot.Text = "Need some motivation?";
            // 
            // deleteItems
            // 
            this.deleteItems.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteItems.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.deleteItems.Location = new System.Drawing.Point(58, 298);
            this.deleteItems.Name = "deleteItems";
            this.deleteItems.Size = new System.Drawing.Size(320, 37);
            this.deleteItems.TabIndex = 4;
            this.deleteItems.Text = "Delete checked items";
            this.deleteItems.UseVisualStyleBackColor = false;
            this.deleteItems.Click += new System.EventHandler(this.deleteItems_Click);
            // 
            // todoList
            // 
            this.todoList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.todoList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.todoList.CheckOnClick = true;
            this.todoList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.todoList.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.todoList.FormattingEnabled = true;
            this.todoList.HorizontalScrollbar = true;
            this.todoList.Location = new System.Drawing.Point(58, 103);
            this.todoList.Name = "todoList";
            this.todoList.Size = new System.Drawing.Size(320, 168);
            this.todoList.TabIndex = 3;
            // 
            // pressMe
            // 
            this.pressMe.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pressMe.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pressMe.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.pressMe.Location = new System.Drawing.Point(594, 103);
            this.pressMe.Name = "pressMe";
            this.pressMe.Size = new System.Drawing.Size(101, 27);
            this.pressMe.TabIndex = 2;
            this.pressMe.Text = "Press me!!";
            this.pressMe.UseVisualStyleBackColor = false;
            this.pressMe.Click += new System.EventHandler(this.pressMe_Click);
            // 
            // addItemButton
            // 
            this.addItemButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.addItemButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addItemButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.addItemButton.Location = new System.Drawing.Point(302, 65);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(77, 27);
            this.addItemButton.TabIndex = 2;
            this.addItemButton.Text = "Add item";
            this.addItemButton.UseVisualStyleBackColor = false;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // addItemBox
            // 
            this.addItemBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addItemBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.addItemBox.Location = new System.Drawing.Point(58, 65);
            this.addItemBox.Name = "addItemBox";
            this.addItemBox.Size = new System.Drawing.Size(238, 27);
            this.addItemBox.TabIndex = 1;
            this.addItemBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addItemBox_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.listsLayout);
            this.Controls.Add(this.songGrid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LeftMenu);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(950, 500);
            this.Name = "Form1";
            this.Text = "Pimung";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullOval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrokeOval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShuffleButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackwardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).EndInit();
            this.LeftMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.songGrid)).EndInit();
            this.listsLayout.ResumeLayout(false);
            this.listsLayout.PerformLayout();
            this.quoteContainer.ResumeLayout(false);
            this.quoteContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PlayButton;
        private System.Windows.Forms.PictureBox ForwardButton;
        private System.Windows.Forms.PictureBox BackwardButton;
        private System.Windows.Forms.Label WhatDoToday;
        private System.Windows.Forms.FlowLayoutPanel LeftMenu;
        private System.Windows.Forms.Button plannerButton;
        private System.Windows.Forms.Button playerButton;
        private System.Windows.Forms.PictureBox ShuffleButton;
        private System.Windows.Forms.PictureBox ReplayButton;
        private System.Windows.Forms.PictureBox StrokeOval;
        private System.Windows.Forms.Label AddMusicBotton;
        private System.Windows.Forms.OpenFileDialog BrowseMusic;
        private System.Windows.Forms.DataGridView songGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn songName;
        private System.Windows.Forms.DataGridViewTextBoxColumn songDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn songArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn songAlbum;
        private System.Windows.Forms.DataGridViewTextBoxColumn songGenre;
        internal System.Windows.Forms.CheckBox checkWifi;
        private System.Windows.Forms.Label elapsedTime;
        private System.Windows.Forms.Label totalTime;
        private System.Windows.Forms.PictureBox fullOval;
        private System.Windows.Forms.Label nowPlaying;
        private System.Windows.Forms.Label removeMusicButton;
        internal System.Windows.Forms.CheckBox readFromArduino;
        private System.Windows.Forms.TextBox mainPurpose;
        private System.Windows.Forms.Label purposeAnswer;
        private System.Windows.Forms.Label reType;
        private System.Windows.Forms.Label today;
        private System.Windows.Forms.Label yourDP;
        private System.Windows.Forms.Panel listsLayout;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.TextBox addItemBox;
        private System.Windows.Forms.CheckedListBox todoList;
        private System.Windows.Forms.Button deleteItems;
        private System.Windows.Forms.Label needMot;
        private System.Windows.Forms.Button pressMe;
        private System.Windows.Forms.FlowLayoutPanel quoteContainer;
        private System.Windows.Forms.Label actualQuote;
    }
}

