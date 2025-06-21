using Personal_library.Models;

namespace Personal_library
{
    public partial class Form1 : Form
    {
        private LibraryManager libraryManager;
        private bool isModified;
        public Form1()
        {
            InitializeComponent();
            libraryManager = new LibraryManager();
        }

        private void OpenLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                libraryManager.Deserialize(openFileDialog.FileName);
                isModified = false;
                UpdateListBox();
            }
        }

        private void UpdateListBox()
        {
            throw new NotImplementedException();
        }
    }
}
