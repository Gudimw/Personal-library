using Personal_library.Models;

namespace Personal_library.Forms
{
    public partial class BookDetailsForm : Form
    {
        public Book EditedBook { get; private set; }

        // Список доступних жанрів для ComboBox
        private List<Genre> availableGenres;

        /// <summary>
        /// Конструктор для BookDetailsForm.
        /// </summary>
        public BookDetailsForm(Book book, List<Genre> genres)
        {
            InitializeComponent();
            EditedBook = book;
            availableGenres = genres;

            InitializeFormFields();

            checkBox1.CheckedChanged += CheckBoxIsAvailable_CheckedChanged;
            trackBar1.Scroll += TrackBarRating_Scroll;

            LoadBookData();
            CheckBoxIsAvailable_CheckedChanged(this, EventArgs.Empty);
            TrackBarRating_Scroll(this, EventArgs.Empty);
        }

        private void InitializeFormFields()
        {

            // Заповнення ComboBox для жанрів
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = availableGenres;

            // Заповнення ComboBox для походження книги
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Куплена");
            comboBox2.Items.Add("Подарована");
            comboBox2.Items.Add("Знайдена");
            comboBox2.Items.Add("Обмін");
            comboBox2.Items.Add("Інше");
            comboBox2.SelectedIndex = 0;
        }

        private void LoadBookData()
        {
            textBox1.Text = EditedBook.Title;
            textBox2.Text = EditedBook.Author;
            textBox3.Text = EditedBook.PublisherName;

            if (EditedBook.GenreId != Guid.Empty)
            {
                var selectedGenre = availableGenres.FirstOrDefault(g => g.Id == EditedBook.GenreId);
                if (selectedGenre != null)
                {
                    comboBox1.SelectedItem = selectedGenre;
                }
            }
            else
            {
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }

            if (!string.IsNullOrWhiteSpace(EditedBook.Origin) && comboBox2.Items.Contains(EditedBook.Origin))
            {
                comboBox2.SelectedItem = EditedBook.Origin;
            }
            else
            {
                if (comboBox2.Items.Count > 0)
                {
                    comboBox2.SelectedIndex = 0;
                }
            }

            checkBox1.Checked = EditedBook.IsAvailable;
            textBox4.Text = EditedBook.LentTo;
            trackBar1.Value = EditedBook.Rating > 0 ? EditedBook.Rating : 1; // Якщо 0, ставимо 1
            textBox5.Text = EditedBook.Description;

            this.Text = EditedBook.Id == Guid.Empty ? "Додати нову книгу" : "Редагувати книгу";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                EditedBook.Title = textBox1.Text.Trim();
                EditedBook.Author = textBox2.Text.Trim();
                EditedBook.PublisherName = textBox3.Text.Trim();
                EditedBook.PublicationYear = (int)numericUpDown1.Value;

                if (comboBox1.SelectedItem is Genre selectedGenre)
                {
                    EditedBook.GenreId = selectedGenre.Id;
                }

                EditedBook.Origin = comboBox2.SelectedItem?.ToString();
                EditedBook.IsAvailable = checkBox1.Checked;
                EditedBook.LentTo = checkBox1.Checked ? string.Empty : textBox4.Text.Trim();
                EditedBook.Rating = trackBar1.Value;
                EditedBook.Description = textBox5.Text.Trim();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CheckBoxIsAvailable_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = !checkBox1.Checked;
            if (checkBox1.Checked)
            {
                textBox4.Text = string.Empty;
            }
        }

        private void TrackBarRating_Scroll(object sender, EventArgs e)
        {
        }

        private bool ValidateForm()
        {
            // Проста валідація для обов'язкових полів
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Будь ласка, введіть назву книги.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Будь ласка, введіть автора книги.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Будь ласка, введіть видавництво книги.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return false;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, оберіть жанр книги.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return false;
            }
            if (!checkBox1.Checked && string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Якщо книга віддана, будь ласка, вкажіть, кому вона віддана.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return false;
            }

            return true;
        }
    }
}