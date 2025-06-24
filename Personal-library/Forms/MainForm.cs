using Personal_library.Forms;
using Personal_library.Models;
using Personal_library.Properties;
using System.IO; // Додайте цей using для Path

namespace Personal_library
{
    public partial class MainForm : Form
    {
        private LibraryManager libraryManager;
        private bool isModified;
        private string currentFilePath = string.Empty; // для відстеження поточного шляху до файлу

        public MainForm()
        {
            InitializeComponent();
            libraryManager = new LibraryManager();

            listView1.DoubleClick += listView1_DoubleClick;

            InitializeFilterComboBoxes();

            this.AcceptButton = button1;
            this.FormClosing += MainForm_FormClosing;
            isModified = false;
        }

        private void OpenLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isModified && AskToSaveModifiedChanges() == DialogResult.Cancel)
            {
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    libraryManager = libraryManager.Load(openFileDialog.FileName);
                    currentFilePath = openFileDialog.FileName;
                    isModified = false;
                    UpdateListBox();
                    InitializeFilterComboBoxes();
                    MessageBox.Show("Бібліотеку успішно завантажено!", "Відкриття", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при завантаженні бібліотеки: {ex.Message}", "Помилка завантаження", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateListBox()
        {
            var filteredBooks = ApplyFilters();
            listView1.Items.Clear();
            listView1.LargeImageList = new ImageList { ImageSize = new Size(64, 96) };

            int index = 0;
            foreach (var book in filteredBooks)
            {
                Image coverImage;
                if (!string.IsNullOrEmpty(book.ImageBase64))
                {
                    try
                    {
                        byte[] imageBytes = Convert.FromBase64String(book.ImageBase64);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            coverImage = Image.FromStream(ms);
                        }
                    }
                    catch
                    {
                        using (MemoryStream ms = new MemoryStream(Properties.Resources.book_png_3))
                        {
                            coverImage = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream(Properties.Resources.book_png_3))
                    {
                        coverImage = Image.FromStream(ms);
                    }
                }

                listView1.LargeImageList.Images.Add(coverImage);

                var item = new ListViewItem
                {
                    Text = book.Title,
                    ImageIndex = index++,
                    Tag = book
                };
                listView1.Items.Add(item);
            }

            groupBox1.Text = $"Книги ({filteredBooks.Count} з {libraryManager.Books.Count})";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private List<Book> ApplyFilters()
        {
            IEnumerable<Book> filteredBooks = libraryManager.Books;

            string searchText = textBox1.Text.Trim().ToLower();
            string authorText = textBox2.Text.Trim().ToLower();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredBooks = filteredBooks.Where(b =>
                    b.Title.ToLower().Contains(searchText) ||
                    b.Description?.ToLower().Contains(searchText) == true
                );
            }
            if (!string.IsNullOrWhiteSpace(authorText))
            {
                filteredBooks = filteredBooks.Where(b => b.Author.ToLower().Contains(authorText));
            }

            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "Всі")
            {
                string selectedGenreName = comboBox1.SelectedItem.ToString();
                Guid selectedGenreId = libraryManager.Genres
                                                .FirstOrDefault(g => g.Name.Equals(selectedGenreName, StringComparison.OrdinalIgnoreCase))
                                                .Id;
                filteredBooks = filteredBooks.Where(b => b.GenreId == selectedGenreId);
            }

            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() != "Всі")
            {
                string selectedPublisher = comboBox2.SelectedItem.ToString();
                filteredBooks = filteredBooks.Where(b => b.PublisherName.Equals(selectedPublisher, StringComparison.OrdinalIgnoreCase));
            }

            if (comboBox3.SelectedItem != null && comboBox3.SelectedItem.ToString() != "Всі")
            {
                string selectedOrigin = comboBox3.SelectedItem.ToString();
                filteredBooks = filteredBooks.Where(b => b.Origin.Equals(selectedOrigin, StringComparison.OrdinalIgnoreCase));
            }

            if (comboBox4.SelectedItem != null && comboBox4.SelectedItem.ToString() != "Всі")
            {
                string selectedSection = comboBox4.SelectedItem.ToString();
                filteredBooks = filteredBooks.Where(b => b.LibrarySection.Equals(selectedSection, StringComparison.OrdinalIgnoreCase));
            }

            if (int.TryParse(textBox4.Text, out int yearFrom))
            {
                filteredBooks = filteredBooks.Where(b => b.PublicationYear >= yearFrom);
            }
            if (int.TryParse(textBox3.Text, out int yearTo))
            {
                filteredBooks = filteredBooks.Where(b => b.PublicationYear <= yearTo);
            }

            int minRating = trackBar1.Value;
            int maxRating = trackBar2.Value;

            label6.Text = $"Оцінка від: {minRating}";
            label7.Text = $"Оцінка до: {maxRating}";

            filteredBooks = filteredBooks.Where(b => b.Rating >= minRating && b.Rating <= maxRating);

            if (radioButton2.Checked)
            {
                filteredBooks = filteredBooks.Where(b => b.IsAvailable);
            }
            else if (radioButton3.Checked)
            {
                filteredBooks = filteredBooks.Where(b => !b.IsAvailable);
            }

            return filteredBooks.ToList();
        }

        private void InitializeFilterComboBoxes()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();

            comboBox1.Items.Add("Всі");
            comboBox2.Items.Add("Всі");
            comboBox3.Items.Add("Всі");
            comboBox4.Items.Add("Всі");

            var uniqueGenres = libraryManager.Genres.Select(g => g.Name).Distinct().OrderBy(name => name).ToList();
            foreach (var genreName in uniqueGenres)
            {
                comboBox1.Items.Add(genreName);
            }

            var uniquePublishers = libraryManager.Books.Select(b => b.PublisherName).Distinct().OrderBy(p => p).ToList();
            foreach (var publisher in uniquePublishers)
            {
                comboBox2.Items.Add(publisher);
            }

            var uniqueOrigins = libraryManager.Books.Select(b => b.Origin).Distinct().OrderBy(o => o).ToList();
            foreach (var origin in uniqueOrigins)
            {
                comboBox3.Items.Add(origin);
            }

            var uniqueSections = libraryManager.Books
                .Select(b => b.LibrarySection)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct()
                .OrderBy(s => s)
                .ToList();

            foreach (var section in uniqueSections)
            {
                comboBox4.Items.Add(section);
            }

            comboBox1.SelectedItem = "Всі";
            comboBox2.SelectedItem = "Всі";
            comboBox3.SelectedItem = "Всі";
            comboBox4.SelectedItem = "Всі";

            label6.Text = $"Оцінка від: {trackBar1.Value}";
            label7.Text = $"Оцінка до: {trackBar2.Value}";

            textBox4.Text = "";
            textBox3.Text = "";
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            var selectedItem = listView1.SelectedItems[0];
            var selectedBook = selectedItem.Tag as Book;

            using (var bookDetailsForm = new BookDetailsForm(selectedBook, libraryManager.Genres))
            {
                if (bookDetailsForm.ShowDialog() == DialogResult.OK)
                {
                    libraryManager.UpdateBook(bookDetailsForm.EditedBook);
                    UpdateListBox();
                    UpdateCombobox();
                    isModified = true;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { UpdateListBox(); }
        private void textBox2_TextChanged(object sender, EventArgs e) { UpdateListBox(); }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { UpdateListBox(); }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { UpdateListBox(); }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { UpdateListBox(); }
        private void trackBar1_Scroll(object sender, EventArgs e) { UpdateListBox(); }
        private void trackBar2_Scroll(object sender, EventArgs e) { UpdateListBox(); }
        private void textBox4_TextChanged(object sender, EventArgs e) { UpdateListBox(); }
        private void textBox3_TextChanged(object sender, EventArgs e) { UpdateListBox(); }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { UpdateListBox(); }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { UpdateListBox(); }
        private void radioButton3_CheckedChanged(object sender, EventArgs e) { UpdateListBox(); }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) { UpdateListBox(); }

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
                    UpdateCombobox();
                    isModified = true;
                    MessageBox.Show($"Книгу '{addedBook.Title}' успішно додано!", "Додавання книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void EditSelectedBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book selectedBook = null;

            if (listView1.SelectedItems.Count > 0)
            {
                selectedBook = listView1.SelectedItems[0].Tag as Book;
            }

            if (selectedBook == null)
            {
                MessageBox.Show("Будь ласка, оберіть книгу для редагування.", "Редагування книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Book bookToEdit = selectedBook;

            using (BookDetailsForm bookDetailsForm = new BookDetailsForm(bookToEdit, libraryManager.Genres))
            {
                if (bookDetailsForm.ShowDialog() == DialogResult.OK)
                {
                    libraryManager.UpdateBook(bookDetailsForm.EditedBook);
                    UpdateListBox();
                    UpdateCombobox();
                    isModified = true;
                    MessageBox.Show($"Книгу '{bookDetailsForm.EditedBook.Title}' успішно оновлено!", "Редагування книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteChoosedBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book selectedBook = null;

            if (listView1.SelectedItems.Count > 0)
            {
                selectedBook = listView1.SelectedItems[0].Tag as Book;
            }

            if (selectedBook == null)
            {
                MessageBox.Show("Будь ласка, оберіть книгу для видалення.", "Видалення книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"Ви впевнені, що хочете видалити книгу '{selectedBook.Title}'?",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    libraryManager.DeleteBook(selectedBook.Id);
                    UpdateListBox();
                    UpdateCombobox();
                    isModified = true;
                    MessageBox.Show($"Книгу '{selectedBook.Title}' успішно видалено.", "Видалення книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при видаленні книги: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLibrary();
        }

        private void SaveLibrary()
        {
            string savePath = currentFilePath;
            if (string.IsNullOrEmpty(savePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.Title = "Зберегти файл бібліотеки";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    savePath = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }

            try
            {
                libraryManager.Save(savePath);
                currentFilePath = savePath;
                isModified = false;
                MessageBox.Show("Бібліотеку успішно збережено!", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні бібліотеки: {ex.Message}", "Помилка збереження", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenresEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (GenresEditForm genresManagerForm = new GenresEditForm(libraryManager))
            {
                genresManagerForm.ShowDialog();

                InitializeFilterComboBoxes();
                UpdateListBox();
                UpdateCombobox();
                isModified = true;
            }
        }

        public void UpdateCombobox()
        {
            string selectedGenreText = comboBox1.SelectedItem?.ToString();
            string selectedPublisherText = comboBox2.SelectedItem?.ToString();
            string selectedOriginText = comboBox3.SelectedItem?.ToString();

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            comboBox1.Items.Add("Всі");
            comboBox2.Items.Add("Всі");
            comboBox3.Items.Add("Всі");

            var uniqueGenres = libraryManager.Genres.Select(g => g.Name).Distinct().OrderBy(name => name).ToList();
            foreach (var genreName in uniqueGenres)
            {
                comboBox1.Items.Add(genreName);
            }

            var uniquePublishers = libraryManager.Books.Select(b => b.PublisherName).Distinct().OrderBy(p => p).ToList();
            foreach (var publisher in uniquePublishers)
            {
                comboBox2.Items.Add(publisher);
            }

            var uniqueOrigins = libraryManager.Books.Select(b => b.Origin).Distinct().OrderBy(o => o).ToList();
            foreach (var origin in uniqueOrigins)
            {
                comboBox3.Items.Add(origin);
            }

            if (!string.IsNullOrEmpty(selectedGenreText) && comboBox1.Items.Contains(selectedGenreText))
            {
                comboBox1.SelectedItem = selectedGenreText;
            }
            else
            {
                comboBox1.SelectedItem = "Всі";
            }

            if (!string.IsNullOrEmpty(selectedPublisherText) && comboBox2.Items.Contains(selectedPublisherText))
            {
                comboBox2.SelectedItem = selectedPublisherText;
            }
            else
            {
                comboBox2.SelectedItem = "Всі";
            }

            if (!string.IsNullOrEmpty(selectedOriginText) && comboBox3.Items.Contains(selectedOriginText))
            {
                comboBox3.SelectedItem = selectedOriginText;
            }
            else
            {
                comboBox3.SelectedItem = "Всі";
            }
        }

        private void LibraryStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibraryStats currentStats = libraryManager.GetLibraryStatistics();

            MessageBox.Show(
                $"Загальна кількість книг: {currentStats.TotalBooks}\n" +
                $"Книг у наявності: {currentStats.AvailableBooks}\n" +
                $"Відданих книг: {currentStats.LentBooks}\n" +
                $"Середня оцінка: {currentStats.AverageRating:F2}\n\n" +
                "Книг за жанрами:\n" +
                string.Join("\n", currentStats.BooksByGenre.Select(kvp => $"  - {kvp.Key}: {kvp.Value}")),
                "Статистика Бібліотеки",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private DialogResult AskToSaveModifiedChanges()
        {
            if (isModified)
            {
                DialogResult result = MessageBox.Show(
                    "У вас є незбережені зміни. Зберегти їх перед виходом?",
                    "Незбережені зміни",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SaveLibrary();
                    if (isModified)
                    {
                        return DialogResult.Cancel;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return DialogResult.Cancel;
                }
            }
            return DialogResult.No;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModified)
            {
                DialogResult result = AskToSaveModifiedChanges();
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}