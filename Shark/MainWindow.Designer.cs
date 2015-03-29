namespace Shark {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesListView = new System.Windows.Forms.ListView();
            this.placesTree = new System.Windows.Forms.TreeView();
            this.fileStatus = new System.Windows.Forms.StatusStrip();
            this.quickPropertiesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelPlaces = new System.Windows.Forms.Label();
            this.currentPathTextBox = new System.Windows.Forms.TextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.fileStatus.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem,
            this.forwardToolStripMenuItem,
            this.upToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.largeIconsToolStripMenuItem,
            this.listToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backToolStripMenuItem.Enabled = false;
            this.backToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("backToolStripMenuItem.Image")));
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.backToolStripMenuItem.Text = "back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.forwardToolStripMenuItem.Enabled = false;
            this.forwardToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("forwardToolStripMenuItem.Image")));
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.forwardToolStripMenuItem.Text = "forward";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.forwardToolStripMenuItem_Click);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.upToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("upToolStripMenuItem.Image")));
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.upToolStripMenuItem.Text = "up";
            this.upToolStripMenuItem.Click += new System.EventHandler(this.upToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.smallIconsToolStripMenuItem.Text = "smallIcons";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.smallIconsToolStripMenuItem_Click);
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.largeIconsToolStripMenuItem.Text = "largeIcons";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.largeIconsToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.listToolStripMenuItem.Text = "list";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.detailsToolStripMenuItem.Text = "details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // filesListView
            // 
            this.filesListView.Location = new System.Drawing.Point(192, 49);
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(580, 488);
            this.filesListView.TabIndex = 2;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.List;
            this.filesListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.filesListView_ItemSelectionChanged);
            this.filesListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filesListView_KeyDown);
            this.filesListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filesListView_MouseClick);
            this.filesListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.filesListView_MouseDoubleClick);
            // 
            // placesTree
            // 
            this.placesTree.Location = new System.Drawing.Point(12, 49);
            this.placesTree.Name = "placesTree";
            this.placesTree.Size = new System.Drawing.Size(174, 488);
            this.placesTree.TabIndex = 4;
            this.placesTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.placesTree_NodeMouseClick);
            // 
            // fileStatus
            // 
            this.fileStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quickPropertiesLabel});
            this.fileStatus.Location = new System.Drawing.Point(0, 540);
            this.fileStatus.Name = "fileStatus";
            this.fileStatus.Size = new System.Drawing.Size(784, 22);
            this.fileStatus.TabIndex = 3;
            this.fileStatus.Text = "statusStrip1";
            // 
            // quickPropertiesLabel
            // 
            this.quickPropertiesLabel.Name = "quickPropertiesLabel";
            this.quickPropertiesLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // labelPlaces
            // 
            this.labelPlaces.AutoSize = true;
            this.labelPlaces.Location = new System.Drawing.Point(12, 30);
            this.labelPlaces.Name = "labelPlaces";
            this.labelPlaces.Size = new System.Drawing.Size(39, 13);
            this.labelPlaces.TabIndex = 5;
            this.labelPlaces.Text = "Places";
            // 
            // currentPathTextBox
            // 
            this.currentPathTextBox.Location = new System.Drawing.Point(192, 23);
            this.currentPathTextBox.Name = "currentPathTextBox";
            this.currentPathTextBox.Size = new System.Drawing.Size(580, 20);
            this.currentPathTextBox.TabIndex = 6;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.messageToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(121, 92);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // messageToolStripMenuItem
            // 
            this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
            this.messageToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.messageToolStripMenuItem.Text = "Message";
            this.messageToolStripMenuItem.Click += new System.EventHandler(this.messageToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.currentPathTextBox);
            this.Controls.Add(this.labelPlaces);
            this.Controls.Add(this.fileStatus);
            this.Controls.Add(this.placesTree);
            this.Controls.Add(this.filesListView);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shark";
            this.Load += new System.EventHandler(this.MainWindow_Resize);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.fileStatus.ResumeLayout(false);
            this.fileStatus.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ListView filesListView;
        private System.Windows.Forms.TreeView placesTree;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip fileStatus;
        private System.Windows.Forms.ToolStripStatusLabel quickPropertiesLabel;
        private System.Windows.Forms.Label labelPlaces;
        private System.Windows.Forms.TextBox currentPathTextBox;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;

    }
}

