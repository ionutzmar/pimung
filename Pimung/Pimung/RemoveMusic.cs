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
        public RemoveMusicDialog()
        {
            InitializeComponent();
        }

        private void RemoveMusic_Load(object sender, EventArgs e)
        {
            RemoveMusic_Resize(sender, e);
        }

        private void RemoveMusic_Resize(object sender, EventArgs e)
        {
            whichMusic.Location = new Point((this.Width - whichMusic.Width) / 2, 20);
            checkListBox.Location = new Point(20, whichMusic.Location.Y + whichMusic.Height + 20);
            checkListBox.Width = this.Width - 40;
            checkListBox.Height = this.Height - checkListBox.Location.X - 40;
        }
    }
}
