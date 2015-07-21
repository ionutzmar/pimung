using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pimung
{
    public partial class RemoveMusicDialog : Form
    {
        List<int> indices = new List<int>();
        List<int> reverseIndices = new List<int>();
        private Form1 mainForm = null;
        public RemoveMusicDialog(Form callingForm)
        {
            mainForm = callingForm as Form1; 
            InitializeComponent();
        }

        private void RemoveMusic_Load(object sender, EventArgs e)
        {
            RemoveMusic_Resize(sender, e);
            for (int i = 0; i < this.mainForm.SongsPaths.Count; i++)
            {
                checkListBox.Items.Add(this.mainForm.MusicToTable[i].currentMedia.getItemInfo("Title"));
            }
        }

        private void RemoveMusic_Resize(object sender, EventArgs e)
        {
            whichMusic.Location = new Point((this.Width - whichMusic.Width) / 2, 20);
            checkListBox.Location = new Point(20, whichMusic.Location.Y + whichMusic.Height + 20);
            checkListBox.Width = this.Width - 60;
            checkListBox.Height = this.Height - checkListBox.Location.Y - 120;
            okButton.Location = new Point(this.Width / 2 + 50, checkListBox.Location.Y + checkListBox.Height + 50);
            cancelButton.Location = new Point(this.Width / 2 - 50 - cancelButton.Width, checkListBox.Location.Y + checkListBox.Height + 50);
        }

        private void okButton_Click(object sender, EventArgs e) 
        {
            foreach (int indexChecked in checkListBox.CheckedIndices)
            {
               indices.Add(indexChecked);
            }

            descendingOrdering(indices);
            foreach (int indexChecked in reverseIndices)
            {
                this.mainForm.SongsPaths.RemoveAt(indexChecked);
            }
            this.mainForm.LoadMusicInTable(this.mainForm.SongsPaths);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoveMusicDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainForm.rmMusicIsOpen = false;
        }

        private void descendingOrdering(List<int> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                reverseIndices.Add(list[list.Count - i - 1]);
            }
        }
    }
}