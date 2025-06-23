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

            bookBindingSource.DataSource = null; // Спершу очищаємо, щоб скинути прив'язку
            bookBindingSource.DataSource = filteredBooks;

            listBox1.DisplayMember = "Title";

            groupBox1.Text = $"Книги ({filteredBooks.Count} з {libraryManager.Books.Count})";
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

            // Фільтрація за текстовими полями (Назва, Автор, Опис)
            string searchText = textBox1.Text.Trim().ToLower(); // Пошук за назвою
            string authorText = textBox2.Text.Trim().ToLower(); // Пошук за автором

            // Комбінований пошук: шукаємо збіги в Назві АБО Авторі АБО Описі
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredBooks = filteredBooks.Where(b =>
                    b.Title.ToLower().Contains(searchText) ||
                    b.Description?.ToLower().Contains(searchText) == true // Опис може бути null
                );
            }
            if (!string.IsNullOrWhiteSpace(authorText))
            {
                // Якщо користувач ввів і в поле "Назва", і в поле "Автор",
                // застосовуємо їх як окремі фільтри, посилюючи комбінацію
                filteredBooks = filteredBooks.Where(b => b.Author.ToLower().Contains(authorText));
            }


            // 2. Фільтрація за жанром (ComboBox1)
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "Всі")
            {
                string selectedGenreName = comboBox1.SelectedItem.ToString();
                // Знаходимо ID жанру за назвою
                Guid selectedGenreId = libraryManager.Genres
                                            .FirstOrDefault(g => g.Name.Equals(selectedGenreName, StringComparison.OrdinalIgnoreCase))
                                            .Id;
                filteredBooks = filteredBooks.Where(b => b.GenreId == selectedGenreId);
            }

            // 3. Фільтрація за видавництвом (ComboBox2)
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() != "Всі")
            {
                string selectedPublisher = comboBox2.SelectedItem.ToString();
                filteredBooks = filteredBooks.Where(b => b.PublisherName.Equals(selectedPublisher, StringComparison.OrdinalIgnoreCase));
            }

            // 4. Фільтрація за походженням книги (ComboBox3)
            if (comboBox3.SelectedItem != null && comboBox3.SelectedItem.ToString() != "Всі")
            {
                string selectedOrigin = comboBox3.SelectedItem.ToString();
                filteredBooks = filteredBooks.Where(b => b.Origin.Equals(selectedOrigin, StringComparison.OrdinalIgnoreCase));
            }

            // 5. Фільтрація за роком видання (textBox4 - Від, textBox3 - До)
            if (int.TryParse(textBox4.Text, out int yearFrom))
            {
                filteredBooks = filteredBooks.Where(b => b.PublicationYear >= yearFrom);
            }
            if (int.TryParse(textBox3.Text, out int yearTo))
            {
                filteredBooks = filteredBooks.Where(b => b.PublicationYear <= yearTo);
            }

            // 6. Фільтрація за оцінкою (TrackBar1 - Від, TrackBar2 - До)
            int minRating = trackBar1.Value;
            int maxRating = trackBar2.Value;

            // Оновлюємо лейбли trackBar
            label6.Text = $"Оцінка від: {minRating}";
            label7.Text = $"Оцінка до: {maxRating}";

            filteredBooks = filteredBooks.Where(b => b.Rating >= minRating && b.Rating <= maxRating);

            // 7. Фільтрація за наявністю книги (RadioButton)
            if (radioButton2.Checked) // У наявності
            {
                filteredBooks = filteredBooks.Where(b => b.IsAvailable);
            }
            else if (radioButton3.Checked) // Віддані
            {
                filteredBooks = filteredBooks.Where(b => !b.IsAvailable);
            }
            // Якщо radioButton1.Checked ("Всі"), то не фільтруємо за наявністю

            return filteredBooks.ToList();
        }

        private void InitializeFilterComboBoxes()
        {
            // Очищаємо ComboBox'и перед заповненням
            comboBox1.Items.Clear(); // Жанр
            comboBox2.Items.Clear(); // Видавництво
            comboBox3.Items.Clear(); // Походження книги

            // Додаємо опцію "Всі"
            comboBox1.Items.Add("Всі");
            comboBox2.Items.Add("Всі");
            comboBox3.Items.Add("Всі");

            // Заповнюємо ComboBox для жанрів
            var uniqueGenres = libraryManager.Genres.Select(g => g.Name).Distinct().OrderBy(name => name).ToList();
            foreach (var genreName in uniqueGenres)
            {
                comboBox1.Items.Add(genreName);
            }

            // Заповнюємо ComboBox для видавництв
            var uniquePublishers = libraryManager.Books.Select(b => b.PublisherName).Distinct().OrderBy(p => p).ToList();
            foreach (var publisher in uniquePublishers)
            {
                comboBox2.Items.Add(publisher);
            }

            // Заповнюємо ComboBox для походження книги
            var uniqueOrigins = libraryManager.Books.Select(b => b.Origin).Distinct().OrderBy(o => o).ToList();
            foreach (var origin in uniqueOrigins)
            {
                comboBox3.Items.Add(origin);
            }

            // Встановлюємо "Всі" як вибраний елемент за замовчуванням
            comboBox1.SelectedItem = "Всі";
            comboBox2.SelectedItem = "Всі";
            comboBox3.SelectedItem = "Всі";

            // Оновлюємо значення TrackBar з поточними значеннями
            label6.Text = $"Оцінка від: {trackBar1.Value}";
            label7.Text = $"Оцінка до: {trackBar2.Value}";

            // Ініціалізуємо текстові поля для року, якщо потрібно
            textBox4.Text = ""; // Рік "Від"
            textBox3.Text = ""; // Рік "До"
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
                    MessageBox.Show($"Книгу '{addedBook.Title}' успішно додано!", "Додавання книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Будь ласка, оберіть книгу для редагування.", "Редагування книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Створюємо копію книги для редагування
            Book bookToEdit = selectedBook;

            using (BookDetailsForm bookDetailsForm = new BookDetailsForm(bookToEdit, libraryManager.Genres))
            {
                if (bookDetailsForm.ShowDialog() == DialogResult.OK)
                {
                    libraryManager.UpdateBook(bookDetailsForm.EditedBook);

                    UpdateListBox();
                    isModified = true;
                    MessageBox.Show($"Книгу '{bookDetailsForm.EditedBook.Title}' успішно оновлено!", "Редагування книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    isModified = true;
                    MessageBox.Show($"Книгу '{selectedBook.Title}' успішно видалено.", "Видалення книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при видаленні книги: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Не вдалося знайти дані про вибрану книгу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (BookDetailsForm bookDetailsForm = new BookDetailsForm(selectedBook, libraryManager.Genres))
            {
                if (bookDetailsForm.ShowDialog() == DialogResult.OK)
                {
                    libraryManager.UpdateBook(bookDetailsForm.EditedBook);
                    UpdateListBox();
                    isModified = true;
                    MessageBox.Show($"Книгу '{bookDetailsForm.EditedBook.Title}' успішно оновлено!", "Редагування книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SaveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.Title = "Зберегти файл бібліотеки";
            //saveFileDialog.FileName = Path.GetFileName(_currentFilePath); 
            //saveFileDialog.InitialDirectory = Path.GetDirectoryName(_currentFilePath);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    libraryManager.Save(saveFileDialog.FileName);
                    MessageBox.Show("Бібліотеку успішно збережено!", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні бібліотеки: {ex.Message}", "Помилка збереження", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
