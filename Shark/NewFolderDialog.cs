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

namespace Shark {
    public partial class NewFolderDialog : Form {
        public NewFolderDialog() {
            InitializeComponent();
        }

        public virtual void okButton_Click(object sender, EventArgs e) {
            if (folderNameTextBox.Text == "")
                MessageBox.Show("Directory name cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else {
                try {
                    MainWindow mw = Program.mw;
                    string dir = mw.CurrentDir;
                    DirectoryInfo dinfo = new DirectoryInfo(dir);
                    DirectoryInfo subdinfo = new DirectoryInfo(Path.Combine(dir, folderNameTextBox.Text));
                    if (subdinfo.Exists) {
                        MessageBox.Show("Folder already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                    } else {
                        dinfo.CreateSubdirectory(folderNameTextBox.Text);
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Close();
            }
        }
    }
}
