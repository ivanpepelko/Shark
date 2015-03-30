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
    public partial class RenameDialog : NewFolderDialog {

        MainWindow mw;
        string filename;

        public RenameDialog() {
            InitializeComponent();
            mw = Program.mw;
            filename = mw.filesListView.SelectedItems[0].Text;
            folderNameTextBox.Text = filename;
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // RenameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 66);
            this.Name = "RenameDialog";
            this.Text = "Rename";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override void okButton_Click(object sender, EventArgs e) {
            if (folderNameTextBox.Text == "") {
                MessageBox.Show("File/Directory name cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                try {
                    FileInfo finfo = new FileInfo(Path.Combine(mw.CurrentDir, filename));
                    finfo.MoveTo(Path.Combine(mw.CurrentDir, folderNameTextBox.Text));
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                Close();
            }


        }


    }
}
