using Personal_library.Forms;
using Personal_library.Models;

namespace Personal_library
{
    public partial class MainForm : Form
    {
        private LibraryManager libraryManager;
        private bool isModified;
        public MainForm()
        {
            InitializeComponent();
            libraryManager = new LibraryManager();

            InitializeFilterComboBoxes();

            this.AcceptButton = button1;
            listBox1.MouseDoubleClick += booksListBox_MouseDoubleClick;
        }

        private void OpenLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                libraryManager = libraryManager.Load(openFileDialog.FileName);
                isModified = false;
                UpdateListBox();
                InitializeFilterComboBoxes();
            }
        }

        private void UpdateListBox()
        {
            var filteredBooks = ApplyFilters();

            bookBindingSource.DataSource = null; // ������ �������, ��� ������� ����'����
            bookBindingSource.DataSource = filteredBooks;

            listBox1.DisplayMember = "Title";

            groupBox1.Text = $"����� ({filteredBooks.Count} � {libraryManager.Books.Count})";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            UpdateListBox();
        }


        private List<Book> ApplyFilters()
        {
            IEnumerable<Book> filteredBooks = libraryManager.Books;

            // Գ�������� �� ���������� ������ (�����, �����, ����)
            string searchText = textBox1.Text.Trim().ToLower(); // ����� �� ������
            string authorText = textBox2.Text.Trim().ToLower(); // ����� �� �������

            // ����������� �����: ������ ���� � ���� ��� ����� ��� ����
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredBooks = filteredBooks.Where(b =>
                    b.Title.ToLower().Contains(searchText) ||
                    b.Description?.ToLower().Contains(searchText) == true // ���� ���� ���� null
                );
            }
            if (!string.IsNullOrWhiteSpace(authorText))
            {
                // ���� ���������� ��� � � ���� "�����", � � ���� "�����",
                // ����������� �� �� ����� �������, ��������� ���������
                filteredBooks = filteredBooks.Where(b => b.Author.ToLower().Contains(authorText));
            }


            // 2. Գ�������� �� ������ (ComboBox1)
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "��")
            {
                string selectedGenreName = comboBox1.SelectedItem.ToString();
                // ��������� ID ����� �� ������
                Guid selectedGenreId = libraryManager.Genres
                                            .FirstOrDefault(g => g.Name.Equals(selectedGenreName, StringComparison.OrdinalIgnoreCase))
                                            .Id;
                filteredBooks = filteredBooks.Where(b => b.GenreId == selectedGenreId);
            }

            // 3. Գ�������� �� ������������ (ComboBox2)
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() != "��")
            {
                string selectedPublisher = comboBox2.SelectedItem.ToString();
                filteredBooks = filteredBooks.Where(b => b.PublisherName.Equals(selectedPublisher, StringComparison.OrdinalIgnoreCase));
            }

            // 4. Գ�������� �� ����������� ����� (ComboBox3)
            if (comboBox3.SelectedItem != null && comboBox3.SelectedItem.ToString() != "��")
            {
                string selectedOrigin = comboBox3.SelectedItem.ToString();
                filteredBooks = filteredBooks.Where(b => b.Origin.Equals(selectedOrigin, StringComparison.OrdinalIgnoreCase));
            }

            // 5. Գ�������� �� ����� ������� (textBox4 - ³�, textBox3 - ��)
            if (int.TryParse(textBox4.Text, out int yearFrom))
            {
                filteredBooks = filteredBooks.Where(b => b.PublicationYear >= yearFrom);
            }
            if (int.TryParse(textBox3.Text, out int yearTo))
            {
                filteredBooks = filteredBooks.Where(b => b.PublicationYear <= yearTo);
            }

            // 6. Գ�������� �� ������� (TrackBar1 - ³�, TrackBar2 - ��)
            int minRating = trackBar1.Value;
            int maxRating = trackBar2.Value;

            // ��������� ������ trackBar
            label6.Text = $"������ ��: {minRating}";
            label7.Text = $"������ ��: {maxRating}";

            filteredBooks = filteredBooks.Where(b => b.Rating >= minRating && b.Rating <= maxRating);

            // 7. Գ�������� �� �������� ����� (RadioButton)
            if (radioButton2.Checked) // � ��������
            {
                filteredBooks = filteredBooks.Where(b => b.IsAvailable);
            }
            else if (radioButton3.Checked) // ³����
            {
                filteredBooks = filteredBooks.Where(b => !b.IsAvailable);
            }
            // ���� radioButton1.Checked ("��"), �� �� ��������� �� ��������

            return filteredBooks.ToList();
        }

        private void InitializeFilterComboBoxes()
        {
            // ������� ComboBox'� ����� �����������
            comboBox1.Items.Clear(); // ����
            comboBox2.Items.Clear(); // �����������
            comboBox3.Items.Clear(); // ���������� �����

            // ������ ����� "��"
            comboBox1.Items.Add("��");
            comboBox2.Items.Add("��");
            comboBox3.Items.Add("��");

            // ���������� ComboBox ��� �����
            var uniqueGenres = libraryManager.Genres.Select(g => g.Name).Distinct().OrderBy(name => name).ToList();
            foreach (var genreName in uniqueGenres)
            {
                comboBox1.Items.Add(genreName);
            }

            // ���������� ComboBox ��� ����������
            var uniquePublishers = libraryManager.Books.Select(b => b.PublisherName).Distinct().OrderBy(p => p).ToList();
            foreach (var publisher in uniquePublishers)
            {
                comboBox2.Items.Add(publisher);
            }

            // ���������� ComboBox ��� ���������� �����
            var uniqueOrigins = libraryManager.Books.Select(b => b.Origin).Distinct().OrderBy(o => o).ToList();
            foreach (var origin in uniqueOrigins)
            {
                comboBox3.Items.Add(origin);
            }

            // ������������ "��" �� �������� ������� �� �������������
            comboBox1.SelectedItem = "��";
            comboBox2.SelectedItem = "��";
            comboBox3.SelectedItem = "��";

            // ��������� �������� TrackBar � ��������� ����������
            label6.Text = $"������ ��: {trackBar1.Value}";
            label7.Text = $"������ ��: {trackBar2.Value}";

            // ���������� ������� ���� ��� ����, ���� �������
            textBox4.Text = ""; // г� "³�"
            textBox3.Text = ""; // г� "��"
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }


        private void AddNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book newBook = new Book();

            using (BookDetailsForm bookDetailsForm = new BookDetailsForm(newBook, libraryManager.Genres))
            {
                if (bookDetailsForm.ShowDialog() == DialogResult.OK)
                {
                    Book addedBook = bookDetailsForm.EditedBook;

                    libraryManager.AddBook(addedBook);

                    UpdateListBox();
                    isModified = true;
                    MessageBox.Show($"����� '{addedBook.Title}' ������ ������!", "��������� �����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void EditSelectedBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book selectedBook = null;

            if (listBox1.SelectedItems.Count > 0)
            {
                selectedBook = listBox1.SelectedItems[0] as Book;
            }


            if (selectedBook == null)
            {
                MessageBox.Show("���� �����, ������ ����� ��� �����������.", "����������� �����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ��������� ���� ����� ��� �����������
            Book bookToEdit = selectedBook;

            using (BookDetailsForm bookDetailsForm = new BookDetailsForm(bookToEdit, libraryManager.Genres))
            {
                if (bookDetailsForm.ShowDialog() == DialogResult.OK)
                {
                    libraryManager.UpdateBook(bookDetailsForm.EditedBook);

                    UpdateListBox();
                    isModified = true;
                    MessageBox.Show($"����� '{bookDetailsForm.EditedBook.Title}' ������ ��������!", "����������� �����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteChoosedBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book selectedBook = null;

            if (listBox1.SelectedItems.Count > 0)
            {
                selectedBook = listBox1.SelectedItems[0] as Book;
            }

            if (selectedBook == null)
            {
                MessageBox.Show("���� �����, ������ ����� ��� ���������.", "��������� �����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"�� �������, �� ������ �������� ����� '{selectedBook.Title}'?",
                "ϳ����������� ���������",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    libraryManager.DeleteBook(selectedBook.Id);

                    UpdateListBox();
                    isModified = true;
                    MessageBox.Show($"����� '{selectedBook.Title}' ������ ��������.", "��������� �����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������� ��� �������� �����: {ex.Message}", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void booksListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }

            Book selectedBook = null;

            selectedBook = listBox1.SelectedItem as Book;

            if (selectedBook == null)
            {
                MessageBox.Show("�� ������� ������ ��� ��� ������� �����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (BookDetailsForm bookDetailsForm = new BookDetailsForm(selectedBook, libraryManager.Genres))
            {
                if (bookDetailsForm.ShowDialog() == DialogResult.OK)
                {
                    libraryManager.UpdateBook(bookDetailsForm.EditedBook);
                    UpdateListBox();
                    isModified = true;
                    MessageBox.Show($"����� '{bookDetailsForm.EditedBook.Title}' ������ ��������!", "����������� �����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SaveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.Title = "�������� ���� ��������";
            //saveFileDialog.FileName = Path.GetFileName(_currentFilePath); 
            //saveFileDialog.InitialDirectory = Path.GetDirectoryName(_currentFilePath);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    libraryManager.Save(saveFileDialog.FileName);
                    MessageBox.Show("��������� ������ ���������!", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������� ��� ��������� ��������: {ex.Message}", "������� ����������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenresEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (GenresEditForm genresManagerForm = new GenresEditForm(libraryManager))
            {
                genresManagerForm.ShowDialog();

                InitializeFilterComboBoxes();

                UpdateListBox();

                isModified = true;
            }
        }
    }
}
