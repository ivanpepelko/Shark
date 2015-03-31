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

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            FileInfo finfo = new FileInfo(getFullFileName(filesListView.FocusedItem.Text));

            if (!finfo.Attributes.HasFlag(FileAttributes.Directory)) {
                string properties = string.Format("Name: {0}\n{1}\nFolder: {2}\nCreated: {3}\nModified: {4}\nAccessed: {5}\nAttributes: {6}",
                    finfo.Name,
                    getSizeString(finfo),
                    finfo.Directory,
                    finfo.CreationTime,
                    finfo.LastWriteTime,
                    finfo.LastAccessTime,
                    finfo.Attributes.ToString()
                    );

                MessageBox.Show(properties, "Properties");
            } else {
                DirectoryInfo dinfo = new DirectoryInfo(finfo.FullName);
                MessageBox.Show("directory: " + dinfo.Name);
            }

        }

        private void filesListView_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (Control.ModifierKeys == Keys.Alt) {
                    propertiesToolStripMenuItem_Click(sender, e);
                } else {
                    SetFileBrowserDirectory(CurrentDir + @"\" + filesListView.FocusedItem.Text);
                }
            }

        }

        private void filesListView_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                contextMenu.Show(filesListView, e.Location);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
            RenameDialog rnd = new RenameDialog();
            rnd.ShowDialog();
            SetFileBrowserDirectory(CurrentDir);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            StringCollection rmlist = new StringCollection();
            string message = "Are you sure you want to delete ";
            foreach (ListViewItem lvi in filesListView.SelectedItems) {
                message += (lvi.Text + ", ");
                rmlist.Add(getFullFileName(lvi.Text));
            }
            message = message.Remove(message.LastIndexOf(','));
            message += "?";

            DialogResult dres = MessageBox.Show(message, "Confirm delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (dres == DialogResult.OK) {

                try {
                    foreach (string file in rmlist) {
                        FileInfo finfo = new FileInfo(file);
                        if (finfo.Attributes.HasFlag(FileAttributes.Directory)) {
                            DirectoryInfo dinfo = new DirectoryInfo(finfo.FullName);
                            dinfo.Delete(true);
                        } else {
                            finfo.Delete();
                        }
                    }
                    SetFileBrowserDirectory(CurrentDir);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            } else if (dres == DialogResult.Cancel) {
                return;
            }
        }

        private void pasteHereToolStripMenuItem_Click(object sender, EventArgs e) {
            pasteFile(CurrentDir);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            DirectoryInfo dirinfo = new DirectoryInfo(Path.Combine(CurrentDir, filesListView.FocusedItem.Text));
            if (dirinfo.Attributes.HasFlag(FileAttributes.Directory))
                pasteFile(dirinfo.FullName);
            else
                return;
        }
    }
}
