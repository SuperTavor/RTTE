namespace RTTE.Forms
{
    public partial class SearchResultsForm : Form
    {
        private Dictionary<string, int> _searchResults = new();

        public int SelectedIndexInMainTreeView = 0;
        public SearchResultsForm(Dictionary<string,int> searchResults,string initialTerm)
        {
            _searchResults = searchResults;
            InitializeComponent();
            this.KeyDown += SearchResultsForm_KeyDown!;
            searchTermLabel.Text = "You searched for \"" + initialTerm + "\".";
            PopulateTreeview();
        }
        private void PopulateTreeview()
        {
           foreach(var kvp in _searchResults)
           {
                searchResultsTreeView.Nodes.Add(new TreeNode(kvp.Key));
           }
        }
        private void SearchResultsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = selectBtn;
                selectBtn.PerformClick();
            }
        }
        private void selectBtn_Click(object sender, EventArgs e)
        {
            if(searchResultsTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a node from your search results");
                return;
            }
            else
            {
                SelectedIndexInMainTreeView = _searchResults[searchResultsTreeView.SelectedNode.Text];
                DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }
    }
}
