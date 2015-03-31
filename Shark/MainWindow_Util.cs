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
using System.Threading;

namespace Shark {
    public partial class MainWindow : Form {

        private string getFullFileName(string file_name) {
            return string.Format(CurrentDir + @"\" + file_name);
        }

        private void SetFileBrowserDirectory(string dir) {
            DirectoryInfo dirinfo = new DirectoryInfo(dir);

            if (dirinfo.Attributes.HasFlag(FileAttributes.Directory)) {

                filesListView.Items.Clear();
                Cursor = Cursors.WaitCursor;

                try {
                    CurrentDir = dirinfo.FullName;
                    currentPathTextBox.Text = CurrentDir;

                    #region Back&Forward Functionality
                    if (!IsBack && !IsForward) {
                        if (BFList.Count > 1 && (BFList.LastIndexOf(BFList.Last()) - BFListIndex) > 0)
                            BFList.RemoveRange(BFListIndex + 1, BFList.LastIndexOf(BFList.Last()) - BFListIndex);
                        if (BFList.Count == 0 || BFList.Last() != CurrentDir) {
                            BFList.Add(CurrentDir);
                            BFListIndex++;
                        }
                    }
                    if (BFListIndex == 0 || !(BFList.Count > 1)) {
                        backToolStripMenuItem.Enabled = false;
                    } else {
                        backToolStripMenuItem.Enabled = true;
                    }
                    if ((BFList.Count - 1) > BFListIndex) {
                        forwardToolStripMenuItem.Enabled = true;
                    } else {
                        forwardToolStripMenuItem.Enabled = false;
                    }
                    #endregion

                    foreach (DirectoryInfo dinfo in dirinfo.GetDirectories()) {
                        if (!dinfo.Attributes.HasFlag(FileAttributes.Hidden)) {
                            filesListView.Items.Add(dinfo.Name, Icons.Images.IndexOfKey("folder"));
                        }
                    }

                    foreach (FileInfo finfo in dirinfo.GetFiles()) {
                        if (!finfo.Attributes.HasFlag(FileAttributes.Hidden)) {
                            string ext = finfo.Extension;
                            Icons.Images.Add(ext, Icon.ExtractAssociatedIcon(finfo.FullName));
                            filesListView.Items.Add(finfo.Name, Icons.Images.IndexOfKey(ext));
                        }
                    }

                    Cursor = Cursors.Default;

                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BFList.RemoveAt(BFListIndex);
                    BFListIndex--;
                    Cursor = Cursors.Default;
                }
            } else {
                try {
                    System.Diagnostics.Process.Start(getFullFileName(filesListView.FocusedItem.Text));
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private string getSelectedItemsSizeString() {

            int files_count = 0;
            double size_bytes = 0;

            foreach (ListViewItem fs in filesListView.SelectedItems) {
                FileInfo finfo = new FileInfo(getFullFileName(fs.Text));
                if (!finfo.Attributes.HasFlag(FileAttributes.Directory)) {
                    size_bytes += finfo.Length;
                    files_count++;
                }

            }

            int magnitude = 0;

            while (size_bytes > 1024) {
                size_bytes /= 1024;
                magnitude++;
            };

            string[] units = new string[] { "bytes", "KB", "MB", "GB" };

            if (filesListView.SelectedItems.Count == 1) {
                return string.Format("Size: {0} {1}",
                    Math.Round(size_bytes, 2),
                    units[magnitude]);
            } else {
                return string.Format("{0} files selected, total size of files: {1} {2}",
                    files_count,
                    Math.Round(size_bytes, 2),
                    units[magnitude]);
            }

        }

        private string getSelectedFoldersCountString() {

            int count = 0;

            foreach (ListViewItem fs in filesListView.SelectedItems) {
                FileInfo finfo = new FileInfo(getFullFileName(fs.Text));
                if (finfo.Attributes.HasFlag(FileAttributes.Directory)) {
                    count++;
                }

            }

            return string.Format("{0} folders selected.", count);

        }

        private string getSizeString(FileInfo finfo) {

            if (finfo.Attributes.HasFlag(FileAttributes.Directory)) {
                throw new Exception("directory");
            }

            double size_bytes = finfo.Length;
            int magnitude = 0;

            while (size_bytes > 1024) {
                size_bytes /= 1024;
                magnitude++;
            };

            string[] units = new string[] { "bytes", "KB", "MB", "GB" };

            return string.Format("Size: {0} {1}", Math.Round(size_bytes, 2), units[magnitude]);
        }

        private Color twist(Color c) {
            return Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
        }

        private void changeTheme() {
            fileStatus.ForeColor = twist(fileStatus.ForeColor);
            fileStatus.BackColor = twist(fileStatus.BackColor);
            filesListView.ForeColor = twist(filesListView.ForeColor);
            filesListView.BackColor = twist(filesListView.BackColor);
            placesTree.ForeColor = twist(placesTree.ForeColor);
            placesTree.BackColor = twist(placesTree.BackColor);
            currentPathTextBox.ForeColor = twist(currentPathTextBox.ForeColor);
            currentPathTextBox.BackColor = twist(currentPathTextBox.BackColor);
            menuStrip.ForeColor = twist(menuStrip.ForeColor);
            menuStrip.BackColor = twist(menuStrip.BackColor);
            BackColor = twist(BackColor);
            ForeColor = twist(ForeColor);
        }

        private void pasteFile(string target) {
            StringCollection plist = Clipboard.GetFileDropList();
            foreach (string f in plist) {
                try {
                    FileInfo finfo = new FileInfo(f);
                    finfo.CopyTo(Path.Combine(CurrentDir, finfo.Name));
                    SetFileBrowserDirectory(CurrentDir);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
