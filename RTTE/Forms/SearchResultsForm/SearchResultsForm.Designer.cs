namespace RTTE.Forms
{
    partial class SearchResultsForm
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
            searchResultsTreeView = new TreeView();
            selectBtn = new Button();
            searchTermLabel = new Label();
            SuspendLayout();
            // 
            // searchResultsTreeView
            // 
            searchResultsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            searchResultsTreeView.BorderStyle = BorderStyle.None;
            searchResultsTreeView.Location = new Point(12, 25);
            searchResultsTreeView.Name = "searchResultsTreeView";
            searchResultsTreeView.Size = new Size(639, 375);
            searchResultsTreeView.TabIndex = 0;
            // 
            // selectBtn
            // 
            selectBtn.Location = new Point(256, 406);
            selectBtn.Name = "selectBtn";
            selectBtn.Size = new Size(136, 31);
            selectBtn.TabIndex = 1;
            selectBtn.Text = "Select";
            selectBtn.UseVisualStyleBackColor = true;
            selectBtn.Click += selectBtn_Click;
            // 
            // searchTermLabel
            // 
            searchTermLabel.AutoSize = true;
            searchTermLabel.Location = new Point(12, 7);
            searchTermLabel.Name = "searchTermLabel";
            searchTermLabel.Size = new Size(38, 15);
            searchTermLabel.TabIndex = 2;
            searchTermLabel.Text = "label1";
            // 
            // SearchResultsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 439);
            Controls.Add(searchTermLabel);
            Controls.Add(selectBtn);
            Controls.Add(searchResultsTreeView);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SearchResultsForm";
            ShowInTaskbar = false;
            Text = "Search Results";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView searchResultsTreeView;
        private Button selectBtn;
        private Label searchTermLabel;
    }
}