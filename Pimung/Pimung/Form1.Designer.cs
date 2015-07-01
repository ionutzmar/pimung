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
            this.UpperMenu = new System.Windows.Forms.Splitter();
            this.SuspendLayout();
            // 
            // UpperMenu
            // 
            this.UpperMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpperMenu.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.UpperMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpperMenu.Location = new System.Drawing.Point(0, 0);
            this.UpperMenu.Name = "UpperMenu";
            this.UpperMenu.Size = new System.Drawing.Size(284, 67);
            this.UpperMenu.TabIndex = 0;
            this.UpperMenu.TabStop = false;
            this.UpperMenu.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.UpperMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter UpperMenu;


    }
}

