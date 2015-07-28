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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveMusicDialog));
            this.checkListBox = new System.Windows.Forms.CheckedListBox();
            this.whichMusic = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkListBox
            // 
            this.checkListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkListBox.CheckOnClick = true;
            this.checkListBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkListBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkListBox.FormattingEnabled = true;
            this.checkListBox.HorizontalScrollbar = true;
            this.checkListBox.Location = new System.Drawing.Point(39, 87);
            this.checkListBox.Name = "checkListBox";
            this.checkListBox.Size = new System.Drawing.Size(150, 134);
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
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(96, 328);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(265, 328);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // RemoveMusicDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 466);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.whichMusic);
            this.Controls.Add(this.checkListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "RemoveMusicDialog";
            this.Text = "RemoveMusic";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RemoveMusicDialog_FormClosed);
            this.Load += new System.EventHandler(this.RemoveMusic_Load);
            this.Resize += new System.EventHandler(this.RemoveMusic_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkListBox;
        private System.Windows.Forms.Label whichMusic;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}