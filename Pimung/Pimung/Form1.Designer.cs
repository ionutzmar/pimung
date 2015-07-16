namespace Pimung
{
    partial class ChooseMusic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseMusic));
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkWifi = new System.Windows.Forms.CheckBox();
            this.AddMusicBotton = new System.Windows.Forms.Label();
            this.WhatDoToday = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LeftMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.plannerButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PlaylistsText = new System.Windows.Forms.Button();
            this.BrowseMusic = new System.Windows.Forms.OpenFileDialog();
            this.songGrid = new System.Windows.Forms.DataGridView();
            this.songName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songAlbum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalTime = new System.Windows.Forms.Label();
            this.elapsedTime = new System.Windows.Forms.Label();
            this.fullOval = new System.Windows.Forms.PictureBox();
            this.StrokeOval = new System.Windows.Forms.PictureBox();
            this.ReplayButton = new System.Windows.Forms.PictureBox();
            this.ShuffleButton = new System.Windows.Forms.PictureBox();
            this.BackwardButton = new System.Windows.Forms.PictureBox();
            this.ForwardButton = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.PictureBox();
            this.nowPlaying = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.LeftMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullOval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrokeOval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShuffleButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackwardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.nowPlaying);
            this.panel1.Controls.Add(this.elapsedTime);
            this.panel1.Controls.Add(this.totalTime);
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
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 145);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.LeftMenu.Controls.Add(this.button1);
            this.LeftMenu.Controls.Add(this.plannerButton);
            this.LeftMenu.Controls.Add(this.panel3);
            this.LeftMenu.Controls.Add(this.PlaylistsText);
            this.LeftMenu.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.LeftMenu.Location = new System.Drawing.Point(4, 183);
            this.LeftMenu.Name = "LeftMenu";
            this.LeftMenu.Size = new System.Drawing.Size(156, 396);
            this.LeftMenu.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Player";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
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
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(3, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(153, 10);
            this.panel3.TabIndex = 1;
            // 
            // PlaylistsText
            // 
            this.PlaylistsText.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PlaylistsText.FlatAppearance.BorderSize = 0;
            this.PlaylistsText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlaylistsText.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PlaylistsText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PlaylistsText.Location = new System.Drawing.Point(3, 129);
            this.PlaylistsText.Name = "PlaylistsText";
            this.PlaylistsText.Size = new System.Drawing.Size(153, 49);
            this.PlaylistsText.TabIndex = 0;
            this.PlaylistsText.Text = "Playlists";
            this.PlaylistsText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PlaylistsText.UseMnemonic = false;
            this.PlaylistsText.UseVisualStyleBackColor = false;
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
            // fullOval
            // 
            this.fullOval.BackgroundImage = global::Pimung.Properties.Resources.FullOval;
            this.fullOval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fullOval.Location = new System.Drawing.Point(342, 12);
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
            this.ShuffleButton.Location = new System.Drawing.Point(385, 56);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(32, 20);
            this.ShuffleButton.TabIndex = 4;
            this.ShuffleButton.TabStop = false;
            // 
            // BackwardButton
            // 
            this.BackwardButton.BackgroundImage = global::Pimung.Properties.Resources.BackwardButton1;
            this.BackwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackwardButton.Location = new System.Drawing.Point(96, 56);
            this.BackwardButton.Name = "BackwardButton";
            this.BackwardButton.Size = new System.Drawing.Size(48, 30);
            this.BackwardButton.TabIndex = 2;
            this.BackwardButton.TabStop = false;
            // 
            // ForwardButton
            // 
            this.ForwardButton.BackgroundImage = global::Pimung.Properties.Resources.ForwardButton1;
            this.ForwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ForwardButton.Location = new System.Drawing.Point(288, 56);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(48, 30);
            this.ForwardButton.TabIndex = 1;
            this.ForwardButton.TabStop = false;
            // 
            // PlayButton
            // 
            this.PlayButton.BackgroundImage = global::Pimung.Properties.Resources.playButton2;
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PlayButton.Location = new System.Drawing.Point(195, 43);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(40, 50);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.TabStop = false;
            this.PlayButton.Click += new System.EventHandler(this.playStopMusic);
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
            // ChooseMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.songGrid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LeftMenu);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(950, 500);
            this.Name = "ChooseMusic";
            this.Text = "Pimung";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.LeftMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.songGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullOval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrokeOval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShuffleButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackwardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button PlaylistsText;
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
        private System.Windows.Forms.CheckBox checkWifi;
        private System.Windows.Forms.Label elapsedTime;
        private System.Windows.Forms.Label totalTime;
        private System.Windows.Forms.PictureBox fullOval;
        private System.Windows.Forms.Label nowPlaying;
    }
}

