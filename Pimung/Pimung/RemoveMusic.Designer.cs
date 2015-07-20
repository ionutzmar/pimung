namespace Pimung
{
    partial class RemoveMusicDialog
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
            this.checkListBox = new System.Windows.Forms.CheckedListBox();
            this.whichMusic = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkListBox
            // 
            this.checkListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkListBox.FormattingEnabled = true;
            this.checkListBox.Items.AddRange(new object[] {
            "sdfg",
            "dsfhy",
            "tju",
            "hf",
            "dngsg",
            "strhyujhd",
            "fg",
            "fstrh",
            "yjt",
            "u",
            "hgfd"});
            this.checkListBox.Location = new System.Drawing.Point(39, 87);
            this.checkListBox.Name = "checkListBox";
            this.checkListBox.Size = new System.Drawing.Size(150, 154);
            this.checkListBox.TabIndex = 0;
            // 
            // whichMusic
            // 
            this.whichMusic.AutoSize = true;
            this.whichMusic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.whichMusic.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.whichMusic.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.whichMusic.Location = new System.Drawing.Point(0, 0);
            this.whichMusic.Name = "whichMusic";
            this.whichMusic.Size = new System.Drawing.Size(253, 29);
            this.whichMusic.TabIndex = 1;
            this.whichMusic.Text = "Choose what to remove:";
            // 
            // RemoveMusicDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.whichMusic);
            this.Controls.Add(this.checkListBox);
            this.Name = "RemoveMusicDialog";
            this.Text = "RemoveMusic";
            this.Load += new System.EventHandler(this.RemoveMusic_Load);
            this.Resize += new System.EventHandler(this.RemoveMusic_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkListBox;
        private System.Windows.Forms.Label whichMusic;
    }
}