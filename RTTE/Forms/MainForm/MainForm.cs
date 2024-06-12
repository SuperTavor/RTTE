using Microsoft.VisualBasic;
using RTTE.Xeen.RhythmThief.EXCLSupport;
using System.Security.Cryptography;
namespace RTTE.Forms.MainForm
{
    public partial class MainForm : Form
    {
        private EXCL _currentFile = new();
        public MainForm()
        {
            InitializeComponent();
            textColorComboBox.DataSource = Enum.GetValues(typeof(EXCLTextColor));
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Rhythm Thief Text File (*.bin)|*.bin";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Open(ofd.FileName);
            }
           
        }

        private void Open(string fileName)
        {
            _currentFile = new EXCL();
            try
            {
                _currentFile.Load(File.ReadAllBytes(fileName));
                textTreeView.Nodes[0].Nodes.Clear();
                foreach (var entry in _currentFile.Entries)
                {
                    TreeNode node = new TreeNode(entry.Content);
                    textTreeView.Nodes[0].Nodes.Add(node);
                }
                textColorComboBox.SelectedItem = _currentFile.TextColor;
                textColorComboBox.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                searchToolStripMenuItem.Enabled = true;
                massReplaceToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null && e.Node.Parent == textTreeView.Nodes[0] && e.Node.IsSelected)
            {
                var newText = Interaction.InputBox("Enter your text here:", "RTTE", e.Node.Text);
                if (newText != string.Empty)
                    e.Node.Text = newText;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textTreeView.Nodes[0].Nodes.Count; i++)
            {
                _currentFile.Entries[i].Content = textTreeView.Nodes[0].Nodes[i].Text;
            }

            var exclBytes = _currentFile.Save();
            var sfd = new SaveFileDialog();
            sfd.Filter = "Rhythm Thief Text File (*.bin)|*.bin";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, exclBytes);
            }
            MessageBox.Show($"Finished saving to {sfd.FileName}");
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //text, offsetInMainTreeView
            Dictionary<string, int> searchResults = new();
            var searchTerms = Interaction.InputBox("Search terms (not case sensitive):", "RTTE").Trim();
            if (string.IsNullOrEmpty(searchTerms))
            {
                return;
            }
            foreach (TreeNode node in textTreeView.Nodes[0].Nodes)
            {
                if (node.Text.ToLower().Contains(searchTerms.ToLower()))
                {
                    searchResults[node.Text] = node.Index;
                }
            }
            if (searchResults.Count == 0)
            {
                MessageBox.Show("No results found.");
                return;
            }
            var srForm = new SearchResultsForm(searchResults, searchTerms);
            if (srForm.ShowDialog() == DialogResult.OK)
            {
                this.textTreeView.SelectedNode = textTreeView.Nodes[0].Nodes[srForm.SelectedIndexInMainTreeView];
            }
        }

        private void massReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toReplace = Interaction.InputBox("String to replace:", "RTTE");
            var replaceWith = Interaction.InputBox("Replace with: ", "RTTE");
            foreach (TreeNode node in textTreeView.Nodes[0].Nodes)
            {
                node.Text = node.Text.Replace(toReplace, replaceWith);
            }
            textTreeView.Refresh();
        }


        private void textColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentFile.TextColor = (EXCLTextColor)textColorComboBox.SelectedItem!;
        }
    }
}
