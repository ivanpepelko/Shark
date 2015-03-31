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

        List<string> BFList = new List<string>();
        int BFListIndex = -1;
        bool IsBack = false;
        bool IsForward = false;
        string Home;
        public string CurrentDir;

        ImageList Icons;

        public MainWindow() {
            InitializeComponent();
            menuStrip.Items.Insert(3, new ToolStripSeparator());
            menuStrip.Items.Insert(7, new ToolStripSeparator());
            menuStrip.Items.Insert(9, new ToolStripSeparator());

            Icons = new ImageList();

            Icons.Images.Add("folder", Properties.Resources.folder);

            filesListView.LargeImageList = Icons;
            filesListView.SmallImageList = Icons;

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
            currentPathTextBox.Location = new Point(placesTree.Width + 16, 25);
            filesListView.Width = Width - placesTree.Width - 42;
            currentPathTextBox.Width = filesListView.Width;
            filesListView.Height = placesTree.Height;
        }

        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e) {
            filesListView.View = View.SmallIcon;
        }

        private void largeIconsToolStripMenuItem_Click(object sender, EventArgs e) {
            filesListView.View = View.LargeIcon;
        }

        private void filesListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {

            string fullname = CurrentDir + @"\" + e.Item.Text;
            bool isMultiSelect = (filesListView.SelectedItems.Count > 1);

            FileInfo finfo = new FileInfo(fullname);

            if (!finfo.Attributes.HasFlag(FileAttributes.Directory) && !isMultiSelect) {

                quickPropertiesLabel.Text = string.Format(
                    "Name: {0}. {1}",
                    finfo.Name,
                    getSelectedItemsSizeString()
                );

            } else if (finfo.Attributes.HasFlag(FileAttributes.Directory) && !isMultiSelect) {
                quickPropertiesLabel.Text = string.Format("Name: {0}", finfo.Name);

            } else if (isMultiSelect) {
                quickPropertiesLabel.Text = string.Format("{0} items selected. {1}",
                    filesListView.SelectedItems.Count,
                    getSelectedItemsSizeString());
            }

            if (filesListView.SelectedItems.Count == 0)
                quickPropertiesLabel.Text = "";

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

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e) {
            filesListView.View = View.Details;
            foreach (ColumnHeader ch in filesListView.Columns) {

                int maxlen = (from ListViewItem lvi in filesListView.Items
                              select lvi.Text.Length).Max();

                ch.Width = (int)Font.Size * maxlen;
            }
        }

        private void filesListView_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.C:
                    if (ModifierKeys.HasFlag(Keys.Control))
                        copyToolStripMenuItem_Click(sender, e);
                    MessageBox.Show("File copied to clipboard");
                    break;
                case Keys.Delete:
                    deleteToolStripMenuItem_Click(sender, e);
                    break;
                case Keys.F2:
                    renameToolStripMenuItem_Click(sender, e);
                    break;
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e) {
            IsBack = true;
            if (BFList.Count > 0 && BFListIndex > 0) {
                BFListIndex--;
                SetFileBrowserDirectory(BFList[BFListIndex]);
            }
            IsBack = false;
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e) {
            IsForward = true;
            BFListIndex++;
            SetFileBrowserDirectory(BFList[BFListIndex]);
            IsForward = false;
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            NewFolderDialog nfd = new NewFolderDialog();
            nfd.ShowDialog(this);
            SetFileBrowserDirectory(CurrentDir);
        }

    }
}
