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

                    Console.WriteLine("bflistindex: {0};", BFListIndex);
                    Pepelko.DebugInfo.printf(BFList);

                    /* back- forward
                    if (!IsBack && !IsForward) {
                        BFList.Add(CurrentDir);
                        ForwardList.Clear();
                    }
                    if (BFList.Count > 1)
                        backToolStripMenuItem.Enabled = true;
                    if (ForwardList.Count < 0)
                        backToolStripMenuItem.Enabled = false;

                    //*/

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

            int order = 0;

            while (size_bytes > 1024) {
                size_bytes /= 1024;
                order++;
            };

            string[] units = new string[] { "bytes", "KB", "MB", "GB" };

            if (filesListView.SelectedItems.Count == 1) {
                return string.Format("Size: {0} {1}",
                    Math.Round(size_bytes, 2),
                    units[order]);
            } else {
                return string.Format("{0} files selected, total size of files: {1} {2}",
                    files_count,
                    Math.Round(size_bytes, 2),
                    units[order]);
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

    }
}
