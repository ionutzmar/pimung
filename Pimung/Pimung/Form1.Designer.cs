﻿namespace Pimung
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddMusicBotton = new System.Windows.Forms.Label();
            this.StrokeOval = new System.Windows.Forms.PictureBox();
            this.ReplayButton = new System.Windows.Forms.PictureBox();
            this.ShuffleButton = new System.Windows.Forms.PictureBox();
            this.WhatDoToday = new System.Windows.Forms.Label();
            this.BackwardButton = new System.Windows.Forms.PictureBox();
            this.ForwardButton = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LinesTable = new System.Windows.Forms.TableLayoutPanel();
            this.SongLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LeftMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.plannerButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PlaylistsText = new System.Windows.Forms.Button();
            this.BrowseMusic = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StrokeOval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShuffleButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackwardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).BeginInit();
            this.LinesTable.SuspendLayout();
            this.LeftMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.AddMusicBotton);
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
            // 
            // AddMusicBotton
            // 
            this.AddMusicBotton.AutoSize = true;
            this.AddMusicBotton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddMusicBotton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddMusicBotton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AddMusicBotton.Location = new System.Drawing.Point(39, 112);
            this.AddMusicBotton.Name = "AddMusicBotton";
            this.AddMusicBotton.Size = new System.Drawing.Size(256, 29);
            this.AddMusicBotton.TabIndex = 6;
            this.AddMusicBotton.Text = "Add music in your player";
            this.AddMusicBotton.Click += new System.EventHandler(this.AddMusicBotton_Click);
            // 
            // StrokeOval
            // 
            this.StrokeOval.BackgroundImage = global::Pimung.Properties.Resources.StrokeOval;
            this.StrokeOval.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StrokeOval.Location = new System.Drawing.Point(440, 112);
            this.StrokeOval.Name = "StrokeOval";
            this.StrokeOval.Size = new System.Drawing.Size(371, 19);
            this.StrokeOval.TabIndex = 5;
            this.StrokeOval.TabStop = false;
            // 
            // ReplayButton
            // 
            this.ReplayButton.BackgroundImage = global::Pimung.Properties.Resources.Replay;
            this.ReplayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReplayButton.Location = new System.Drawing.Point(96, 112);
            this.ReplayButton.Name = "ReplayButton";
            this.ReplayButton.Size = new System.Drawing.Size(32, 20);
            this.ReplayButton.TabIndex = 4;
            this.ReplayButton.TabStop = false;
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.BackgroundImage = global::Pimung.Properties.Resources.Shuffle;
            this.ShuffleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ShuffleButton.Location = new System.Drawing.Point(304, 112);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(32, 20);
            this.ShuffleButton.TabIndex = 4;
            this.ShuffleButton.TabStop = false;
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
            // LinesTable
            // 
            this.LinesTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LinesTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.LinesTable.ColumnCount = 6;
            this.LinesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.48166F));
            this.LinesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.LinesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.LinesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.LinesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.LinesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.LinesTable.Controls.Add(this.SongLabel, 0, 0);
            this.LinesTable.Controls.Add(this.label1, 1, 0);
            this.LinesTable.Controls.Add(this.label2, 2, 0);
            this.LinesTable.Controls.Add(this.label3, 3, 0);
            this.LinesTable.Controls.Add(this.label4, 4, 0);
            this.LinesTable.Controls.Add(this.label5, 5, 0);
            this.LinesTable.Location = new System.Drawing.Point(195, 183);
            this.LinesTable.Name = "LinesTable";
            this.LinesTable.RowCount = 6;
            this.LinesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.661836F));
            this.LinesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.33817F));
            this.LinesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LinesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LinesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LinesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LinesTable.Size = new System.Drawing.Size(777, 359);
            this.LinesTable.TabIndex = 2;
            // 
            // SongLabel
            // 
            this.SongLabel.AutoSize = true;
            this.SongLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SongLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SongLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SongLabel.Location = new System.Drawing.Point(4, 1);
            this.SongLabel.Name = "SongLabel";
            this.SongLabel.Size = new System.Drawing.Size(99, 26);
            this.SongLabel.TabIndex = 0;
            this.SongLabel.Text = "Song";
            this.SongLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(110, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Duration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(226, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Artist";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(352, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Album";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(455, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Genre";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.plannerButton.BackColor = System.Drawing.Color.Gainsboro;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(553, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "Send via WiFi";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChooseMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LinesTable);
            this.Controls.Add(this.LeftMenu);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(950, 500);
            this.Name = "ChooseMusic";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StrokeOval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplayButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShuffleButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackwardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).EndInit();
            this.LinesTable.ResumeLayout(false);
            this.LinesTable.PerformLayout();
            this.LeftMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PlayButton;
        private System.Windows.Forms.PictureBox ForwardButton;
        private System.Windows.Forms.PictureBox BackwardButton;
        private System.Windows.Forms.Label WhatDoToday;
        private System.Windows.Forms.TableLayoutPanel LinesTable;
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
        private System.Windows.Forms.Label SongLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

