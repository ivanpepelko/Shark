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

        List<string> Folders = new List<string>();
        string Home;
        string CurrentDir;
        ImageList Icons;
        public const string FS = @"\";

        public MainWindow() {
            InitializeComponent();
            InitializeIcons();

            Home = @"C:\Users\" + Environment.UserName;
            SetFileBrowserDirectory(Home);

            InitializePlaces();
            placesTree.ExpandAll();
        }

        private void MainWindow_Resize(object sender, EventArgs e) {
            placesTree.Location = new Point(12, 49);
            placesTree.Width = (int)(0.2 * (float)Width);
            placesTree.Height = Height - menuStrip.Height - labelPlaces.Height - fileStatus.Height - 60;

            filesListView.Location = new Point(placesTree.Width + 16, 49);
            currentPathTextBox.Location = new Point(placesTree.Width + 16, 23);
            filesListView.Width = Width - placesTree.Width - 42;
            currentPathTextBox.Width = filesListView.Width;
            filesListView.Height = placesTree.Height;
        }

        private void InitializeIcons() {
            Icons = new ImageList();

            Icons.Images.Add("folder", Properties.Resources.folder);

            filesListView.LargeImageList = Icons;
            filesListView.SmallImageList = Icons;
        }

        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e) {
            filesListView.View = View.SmallIcon;
        }

        private void largeIconsToolStripMenuItem_Click(object sender, EventArgs e) {
            filesListView.View = View.LargeIcon;
        }

        private void SetFileBrowserDirectory(string dir) {
            DirectoryInfo dirinfo = new DirectoryInfo(dir);

            if (dirinfo.Attributes.HasFlag(FileAttributes.Directory)) {

                filesListView.Items.Clear();
                Cursor = Cursors.WaitCursor;

                try {
                    CurrentDir = dirinfo.FullName;
                    currentPathTextBox.Text = CurrentDir;

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


                } catch (System.IO.IOException ex) {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                }
            } else {
                try {
                    System.Diagnostics.Process.Start(CurrentDir + @"\" + filesListView.FocusedItem.Text);
                } catch (Win32Exception ex) {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void filesListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            //todo
            string fullname = CurrentDir + FS + e.Item.Text;
            bool isMultiSelect = (filesListView.SelectedItems.Count > 1);

            FileInfo finfo = new FileInfo(fullname);

            if (!finfo.Attributes.HasFlag(FileAttributes.Directory) && !isMultiSelect) {

                long size = finfo.Length;
                int order = 0;

                while (size > 1024) {
                    size /= 1024;
                    order++;
                };

                string[] units = new string[] { "bytes", "KB", "MB", "GB" };

                quickPropertiesLabel.Text = string.Format(
                    "Name: {0}    Size: {1} {2}",
                    finfo.Name,
                    Math.Round(finfo.Length / Math.Pow(1024, order), 2),
                    units[order]
                );
            } else if (finfo.Attributes.HasFlag(FileAttributes.Directory) && !isMultiSelect) {
            } else if (isMultiSelect) {
                quickPropertiesLabel.Text = string.Format("{0} items selected.", filesListView.SelectedItems.Count);
            }


        }

        private void InitializePlaces() {

            //libraries
            TreeNode[] libraries = new TreeNode[] {
                new TreeNode("Documents") {
                    Tag = Home + @"\Documents"
                },
                new TreeNode("Music") {
                    Tag = Home + @"\Music"
                },
                new TreeNode("Pictures"){
                    Tag = Home + @"\Pictures"
                },
                new TreeNode("Videos"){
                    Tag = Home + @"\Videos"
                },
                new TreeNode("Downloads"){
                    Tag = Home + @"\Downloads"
                },
                new TreeNode("Desktop"){
                    Tag = Home + @"\Desktop"
                }
            };

            //home
            TreeNode home = new TreeNode("Home", libraries) {
                Tag = Home
            };

            //drives
            List<TreeNode> drives = new List<TreeNode>();
            foreach (string n in Environment.GetLogicalDrives()) {
                drives.Add(new TreeNode(n) {
                    Tag = n
                });
            }

            //computer
            placesTree.Nodes.Add(new TreeNode(Environment.MachineName, new TreeNode[] {
                home, new TreeNode("Drives", drives.ToArray())
            }));

        }

        private void placesTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (e.Node.Tag != null && e.Button == MouseButtons.Left)
                SetFileBrowserDirectory((string)e.Node.Tag);
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e) {
            SetFileBrowserDirectory(CurrentDir + @"\..");
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e) {
            filesListView.View = View.List;
        }

    }
}
