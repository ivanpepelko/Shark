using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;

namespace Shark {
    public partial class MainWindow : Form {

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {

            StringCollection cplist = new StringCollection();
            foreach (ListViewItem fl in filesListView.SelectedItems) {
                cplist.Add(getFullFileName(fl.Text));
            }

            Clipboard.SetFileDropList(cplist);

        }

        private void messageToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(filesListView.FocusedItem.Text);
        }

        private void filesListView_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left)
                SetFileBrowserDirectory(CurrentDir + @"\" + filesListView.FocusedItem.Text);
        }

        private void filesListView_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                contextMenu.Show(filesListView, e.Location);
        }
    }
}
