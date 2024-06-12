using Microsoft.VisualBasic;
using RTTE.Xeen.RhythmThief.EXCLSupport;
using System.Text;
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
                exportAsTXTToolStripMenuItem.Enabled = true;
                importTXTIntoCurrentFileToolStripMenuItem.Enabled = true;
                textTreeView.Nodes[0].Text = Path.GetFileNameWithoutExtension(fileName);
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message, "RTTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrEmpty(toReplace))
            {
                MessageBox.Show("Please input something.");
                return;
            }
            var replaceWith = Interaction.InputBox("Replace with: ", "RTTE");
            int replaced = 0;
            foreach (TreeNode node in textTreeView.Nodes[0].Nodes)
            {
                if (node.Text != node.Text.Replace(toReplace, replaceWith))
                    replaced++;
                node.Text = node.Text.Replace(toReplace, replaceWith);
            }
            MessageBox.Show($"{replaced} entries edited.");
            textTreeView.Refresh();
        }


        private void textColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentFile.TextColor = (EXCLTextColor)textColorComboBox.SelectedItem!;
        }

        private void exportAsTOMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder tomlSb = new();
            foreach (TreeNode node in textTreeView.Nodes[0].Nodes)
            {
                tomlSb.Append($"text{textTreeView.Nodes[0].Nodes.IndexOf(node)} = {node.Text}\n");
            }
            var sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            sfd.Title = "Save as Plain Text";
            sfd.DefaultExt = "txt";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(sfd.FileName, tomlSb.ToString());
                    MessageBox.Show("Saved.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error writing TXT: ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void importTXTIntoCurrentFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Open your plaintext";
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<string> fields = new();
                    foreach(var line in File.ReadAllLines(ofd.FileName))
                    {
                        var parts = line.Split('=',2);
                        fields.Add(parts[1].Trim());
                    }
                    for(int i = 0; i < textTreeView.Nodes[0].Nodes.Count; i++)
                    {
                        textTreeView.Nodes[0].Nodes[i].Text = fields[i];
                    }
                    textTreeView.Refresh();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading plaintext file: " + ex.Message, "RTTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
