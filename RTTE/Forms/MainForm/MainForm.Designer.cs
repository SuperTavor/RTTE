namespace RTTE.Forms.MainForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode1 = new TreeNode("Text");
            textTreeView = new TreeView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            exportAsTXTToolStripMenuItem = new ToolStripMenuItem();
            importTXTIntoCurrentFileToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            massReplaceToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            rTTEVersion100ToolStripMenuItem = new ToolStripMenuItem();
            textColorComboBox = new ComboBox();
            textColorLabel = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textTreeView
            // 
            textTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textTreeView.BackColor = SystemColors.Window;
            textTreeView.BorderStyle = BorderStyle.None;
            textTreeView.ForeColor = SystemColors.ActiveCaptionText;
            textTreeView.Location = new Point(12, 60);
            textTreeView.Name = "textTreeView";
            treeNode1.Name = "TextNode";
            treeNode1.Text = "Text";
            textTreeView.Nodes.AddRange(new TreeNode[] { treeNode1 });
            textTreeView.Size = new Size(700, 363);
            textTreeView.TabIndex = 0;
            textTreeView.NodeMouseDoubleClick += TextTreeView_NodeMouseDoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, searchToolStripMenuItem, massReplaceToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(736, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, exportAsTXTToolStripMenuItem, importTXTIntoCurrentFileToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(243, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(243, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // exportAsTXTToolStripMenuItem
            // 
            exportAsTXTToolStripMenuItem.Enabled = false;
            exportAsTXTToolStripMenuItem.Name = "exportAsTXTToolStripMenuItem";
            exportAsTXTToolStripMenuItem.Size = new Size(243, 22);
            exportAsTXTToolStripMenuItem.Text = "Export as plaintext";
            exportAsTXTToolStripMenuItem.Click += exportAsTOMLToolStripMenuItem_Click;
            // 
            // importTXTIntoCurrentFileToolStripMenuItem
            // 
            importTXTIntoCurrentFileToolStripMenuItem.Enabled = false;
            importTXTIntoCurrentFileToolStripMenuItem.Name = "importTXTIntoCurrentFileToolStripMenuItem";
            importTXTIntoCurrentFileToolStripMenuItem.Size = new Size(243, 22);
            importTXTIntoCurrentFileToolStripMenuItem.Text = "Import plaintext into current file";
            importTXTIntoCurrentFileToolStripMenuItem.Click += importTXTIntoCurrentFileToolStripMenuItem_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Enabled = false;
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            searchToolStripMenuItem.Size = new Size(54, 20);
            searchToolStripMenuItem.Text = "Search";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // massReplaceToolStripMenuItem
            // 
            massReplaceToolStripMenuItem.Enabled = false;
            massReplaceToolStripMenuItem.Name = "massReplaceToolStripMenuItem";
            massReplaceToolStripMenuItem.Size = new Size(87, 20);
            massReplaceToolStripMenuItem.Text = "Mass replace";
            massReplaceToolStripMenuItem.Click += massReplaceToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rTTEVersion100ToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // rTTEVersion100ToolStripMenuItem
            // 
            rTTEVersion100ToolStripMenuItem.Enabled = false;
            rTTEVersion100ToolStripMenuItem.Name = "rTTEVersion100ToolStripMenuItem";
            rTTEVersion100ToolStripMenuItem.Size = new Size(166, 22);
            rTTEVersion100ToolStripMenuItem.Text = "RTTE Version 1.0.1";
            // 
            // textColorComboBox
            // 
            textColorComboBox.Enabled = false;
            textColorComboBox.FormattingEnabled = true;
            textColorComboBox.Location = new Point(76, 31);
            textColorComboBox.Name = "textColorComboBox";
            textColorComboBox.Size = new Size(121, 23);
            textColorComboBox.TabIndex = 2;
            textColorComboBox.SelectedIndexChanged += textColorComboBox_SelectedIndexChanged;
            // 
            // textColorLabel
            // 
            textColorLabel.AutoSize = true;
            textColorLabel.Location = new Point(12, 34);
            textColorLabel.Name = "textColorLabel";
            textColorLabel.Size = new Size(58, 15);
            textColorLabel.TabIndex = 3;
            textColorLabel.Text = "Text color";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(736, 441);
            Controls.Add(textColorLabel);
            Controls.Add(textColorComboBox);
            Controls.Add(textTreeView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Rhythm Thief Text Editor";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TreeView textTreeView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem rTTEVersion100ToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem massReplaceToolStripMenuItem;
        private ComboBox textColorComboBox;
        private Label textColorLabel;
        private ToolStripMenuItem exportAsTXTToolStripMenuItem;
        private ToolStripMenuItem importTXTIntoCurrentFileToolStripMenuItem;
    }
}