using Personal_library.Models;
using System;
using System.Windows.Forms;

namespace Personal_library.Forms
{
    public partial class GenresEditForm : Form
    {
        private LibraryManager _manager;

        public GenresEditForm(LibraryManager manager)
        {
            InitializeComponent();
            _manager = manager;
            genreBindingSource.DataSource = _manager.Genres;
        }

        private void GenresEditForm_Load(object sender, EventArgs e)
        {
            lbGenres.ClearSelected();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (AddGenresForm addForm = new AddGenresForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    Genre newGenre = addForm.AddedGenre;

                    try
                    {
                        _manager.AddGenre(newGenre);
                        genreBindingSource.ResetBindings(false);

                        MessageBox.Show($"Жанр '{newGenre.Name}' було успішно додано.",
                                        "Операція успішна",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (genreBindingSource.Current is Genre selected)
            {
                var result = MessageBox.Show($"Видалити жанр '{selected.Name}'?",
                                             "Підтвердження видалення",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _manager.DeleteGenre(selected.Id);
                        genreBindingSource.Remove(selected);
                        MessageBox.Show("Жанр видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Оберіть жанр для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Genre genre in _manager.Genres)
                {
                    _manager.UpdateGenre(genre);
                }

                MessageBox.Show("Усі зміни збережено.", "Збережено", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            genreBindingSource.DataSource = null;
            genreBindingSource.DataSource = _manager.Genres;
        }
    }
}
