using Personal_library.Models; // Потрібно додати для доступу до класу Genre
using System;
using System.Windows.Forms;

namespace Personal_library.Forms
{
    public partial class AddGenresForm : Form
    {
        public Genre AddedGenre { get; private set; }

        public AddGenresForm()
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        /// <summary>
        /// Обробник натискання на кнопку "OK" (Зберегти).
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string genreName = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(genreName))
            {
                MessageBox.Show(
                    "Назва жанру не може бути порожньою.",
                    "Помилка введення",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtName.Focus();
                return;
            }

            AddedGenre = new Genre
            {
                Name = genreName,
                Description = txtDescription.Text.Trim()
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Обробник натискання на кнопку "Закрити".
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}