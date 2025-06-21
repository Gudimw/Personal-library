using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace Personal_library.Models
{
    public class LibraryManager
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Genre> Genres { get; set; } = new List<Genre>();

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public LibraryManager()
        {
        }

        /// <summary>
        /// Повертає список книг, що належать до певного жанру.
        /// </summary>
        /// <param name="genreId">Унікальний ідентифікатор жанру.</param>
        /// <returns>Список книг заданого жанру.</returns>
        public List<Book> GetBooksByGenre(Guid genreId)
        {
            return Books.Where(b => b.GenreId == genreId).ToList();
        }

        /// <summary>
        /// Серіалізує поточний стан бібліотеки в JSON файл за вказаним шляхом.
        /// </summary>
        /// <param name="path">Шлях до файлу для збереження.</param>
        public void Serialize(string path)
        {
            try
            {
                var json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні файлу: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Десеріалізує дані бібліотеки з JSON файлу за вказаним шляхом.
        /// Цей метод буде статичним, оскільки він створює екземпляр LibraryManager.
        /// </summary>
        /// <param name="path">Шлях до файлу для завантаження.</param>
        /// <returns>Завантажений об'єкт LibraryManager або новий, якщо завантаження не вдалося.</returns>
        public LibraryManager Deserialize(string path)
        {
            if (!File.Exists(path))
            {
                return new LibraryManager();
            }

            try
            {
                string json = File.ReadAllText(path, Encoding.Unicode);
                LibraryManager? deserializedLibrary = JsonSerializer.Deserialize<LibraryManager>(json);

                if (deserializedLibrary != null)
                {
                    // Оновлюємо списки, якщо вони були null після десеріалізації
                    deserializedLibrary.Books = deserializedLibrary.Books ?? new List<Book>();
                    deserializedLibrary.Genres = deserializedLibrary.Genres ?? new List<Genre>();

                    // Оновлюємо назви жанрів у книгах після завантаження
                    deserializedLibrary.UpdateBooksGenreNames();
                    return deserializedLibrary;
                }
                else
                {
                    Console.WriteLine("Десеріалізований об'єкт LibraryManager є null. Повертаємо нову бібліотеку.");
                    return new LibraryManager();
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Помилка десеріалізації JSON: {ex.Message}");
                return new LibraryManager(); // Повертаємо нову, порожню бібліотеку у випадку помилки
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Загальна помилка при завантаженні файлу: {ex.Message}");
                return new LibraryManager();
            }
        }

        /// <summary>
        /// Допоміжний метод для оновлення властивості GenreName у кожній книзі
        /// на основі Id жанру. Викликається після завантаження даних.
        /// </summary>
        public void UpdateBooksGenreNames()
        {
            foreach (var book in Books)
            {
                var genre = Genres.FirstOrDefault(g => g.Id == book.GenreId);
                book.GenreName = genre?.Name ?? "Невідомий жанр"; // Встановлюємо назву жанру або "Невідомий"
            }
        }

        /// <summary>
        /// Додає нову книгу до бібліотеки.
        /// </summary>
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            Books.Add(book);
            // Оновлюємо назву жанру для щойно доданої книги
            var genre = Genres.FirstOrDefault(g => g.Id == book.GenreId);
            book.GenreName = genre?.Name ?? "Невідомий жанр";
        }

        /// <summary>
        /// Оновлює інформацію про існуючу книгу.
        /// </summary>
        public void UpdateBook(Book updatedBook)
        {
            var existingBook = Books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (existingBook != null)
            {
                // Копіюємо дані з оновленої книги
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.Publisher = updatedBook.Publisher;
                existingBook.PublicationYear = updatedBook.PublicationYear;
                existingBook.GenreId = updatedBook.GenreId;
                existingBook.Origin = updatedBook.Origin;
                existingBook.IsAvailable = updatedBook.IsAvailable;
                existingBook.LentTo = updatedBook.LentTo;
                existingBook.Rating = updatedBook.Rating;
                existingBook.Description = updatedBook.Description;

                // Оновлюємо назву жанру після зміни Id жанру
                var genre = Genres.FirstOrDefault(g => g.Id == existingBook.GenreId);
                existingBook.GenreName = genre?.Name ?? "Невідомий жанр";
            }
            else
            {
                throw new ArgumentException($"Книгу з ID {updatedBook.Id} не знайдено для оновлення.");
            }
        }

        /// <summary>
        /// Видаляє книгу за її ID.
        /// </summary>
        public void DeleteBook(Guid bookId)
        {
            var bookToRemove = Books.FirstOrDefault(b => b.Id == bookId);
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
            }
            else
            {
                throw new ArgumentException($"Книгу з ID {bookId} не знайдено для видалення.");
            }
        }

        /// <summary>
        /// Додає новий жанр до бібліотеки.
        /// </summary>
        public void AddGenre(Genre genre)
        {
            if (genre == null) throw new ArgumentNullException(nameof(genre));
            if (Genres.Any(g => g.Name.Equals(genre.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Жанр з назвою '{genre.Name}' вже існує.");
            }
            Genres.Add(genre);
        }

        /// <summary>
        /// Видаляє жанр за його ID.
        /// Не дозволяє видалити жанр, якщо до нього прив'язані книги.
        /// </summary>
        public void DeleteGenre(Guid genreId)
        {
            if (Books.Any(b => b.GenreId == genreId))
            {
                throw new InvalidOperationException("Неможливо видалити жанр, оскільки до нього прив'язані книги.");
            }
            var genreToRemove = Genres.FirstOrDefault(g => g.Id == genreId);
            if (genreToRemove != null)
            {
                Genres.Remove(genreToRemove);
            }
            else
            {
                throw new ArgumentException($"Жанр з ID {genreId} не знайдено для видалення.");
            }
        }

        /// <summary>
        /// Оновлює інформацію про існуючий жанр.
        /// </summary>
        public void UpdateGenre(Genre updatedGenre)
        {
            var existingGenre = Genres.FirstOrDefault(g => g.Id == updatedGenre.Id);
            if (existingGenre != null)
            {
                if (!existingGenre.Name.Equals(updatedGenre.Name, StringComparison.OrdinalIgnoreCase) && Genres.Any(g => g.Name.Equals(updatedGenre.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException($"Жанр з назвою '{updatedGenre.Name}' вже існує.");
                }
                existingGenre.Name = updatedGenre.Name;
                existingGenre.Description = updatedGenre.Description;
                // Після оновлення назви жанру, оновлюємо назви в усіх книгах, що його використовують
                UpdateBooksGenreNames();
            }
            else
            {
                throw new ArgumentException($"Жанр з ID {updatedGenre.Id} не знайдено для оновлення.");
            }
        }
    }
}
