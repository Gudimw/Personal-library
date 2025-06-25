using System.Text.Json.Serialization;
using System.Text.Json;
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
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        // Конструктор за замовчуванням (використовується при десеріалізації)
        public LibraryManager()
        {
        }

        /// <summary>
        /// Ініціалізує LibraryManager з даними за замовчуванням, якщо колекції порожні.
        /// </summary>
        public void InitializeDefaultData()
        {
            if (!Genres.Any())
            {
                Genres.Add(new Genre { Name = "Фантастика", Description = "Жанр, що містить елементи наукової фантастики, фентезі та жахів." });
                Genres.Add(new Genre { Name = "Детектив", Description = "Жанр, зосереджений на розслідуванні злочинів." });
                Genres.Add(new Genre { Name = "Роман", Description = "Літературний жанр, що розповідає про події та досвід персонажів." });
            }
        }

        /// <summary>
        /// Зберігає поточний стан бібліотеки в JSON файл.
        /// </summary>
        public void Save(string path)
        {
            try
            {
                var json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(path, json);
                Console.WriteLine($"Дані бібліотеки успішно збережено до {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні файлу '{path}': {ex.Message}");
            }
        }

        /// <summary>
        /// Завантажує дані бібліотеки з JSON файлу.
        /// </summary>
        public LibraryManager Load(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл '{path}' не знайдено. Створюємо нову бібліотеку.");
                var newManager = new LibraryManager();
                newManager.InitializeDefaultData();
                return newManager;
            }

            try
            {
                string json = File.ReadAllText(path);
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                };
                LibraryManager? deserializedLibrary = JsonSerializer.Deserialize<LibraryManager>(json, options);

                if (deserializedLibrary != null)
                {
                    deserializedLibrary.Books = deserializedLibrary.Books ?? new List<Book>();
                    deserializedLibrary.Genres = deserializedLibrary.Genres ?? new List<Genre>();

                    deserializedLibrary.InitializeDefaultData();

                    deserializedLibrary.UpdateBooksGenreNames();

                    Console.WriteLine($"Дані бібліотеки успішно завантажено з {path}");
                    return deserializedLibrary;
                }
                else
                {
                    Console.WriteLine("Десеріалізований об'єкт LibraryManager є null. Повертаємо нову бібліотеку.");
                    var newManager = new LibraryManager();
                    newManager.InitializeDefaultData();
                    return newManager;
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Помилка десеріалізації JSON з '{path}': {ex.Message}");
                var newManager = new LibraryManager();
                newManager.InitializeDefaultData();
                return newManager;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Загальна помилка при завантаженні файлу '{path}': {ex.Message}");
                var newManager = new LibraryManager();
                newManager.InitializeDefaultData();
                return newManager;
            }
        }

        /// <summary>
        /// Допоміжний метод для оновлення властивості GenreName у кожній книзі
        /// на основі Id жанру. Викликається після завантаження або зміни жанру.
        /// </summary>
        public void UpdateBooksGenreNames()
        {
            foreach (var book in Books)
            {
                var genre = Genres.FirstOrDefault(g => g.Id == book.GenreId);
                book.GenreName = genre?.Name ?? "Невідомий жанр";
            }
        }

        /// <summary>
        /// Додає нову книгу до бібліотеки.
        /// </summary>
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            Books.Add(book);
            UpdateBooksGenreNames();
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
                existingBook.PublisherName = updatedBook.PublisherName;
                existingBook.PublicationYear = updatedBook.PublicationYear;
                existingBook.GenreId = updatedBook.GenreId;
                existingBook.Origin = updatedBook.Origin;
                existingBook.IsAvailable = updatedBook.IsAvailable;
                existingBook.LentTo = updatedBook.LentTo;
                existingBook.Rating = updatedBook.Rating;
                existingBook.Description = updatedBook.Description;

                UpdateBooksGenreNames();
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
                if (!existingGenre.Name.Equals(updatedGenre.Name, StringComparison.OrdinalIgnoreCase) && Genres.Any(g => g.Name.Equals(updatedGenre.Name, StringComparison.OrdinalIgnoreCase) && g.Id != updatedGenre.Id))
                {
                    throw new ArgumentException($"Жанр з назвою '{updatedGenre.Name}' вже існує.");
                }
                existingGenre.Name = updatedGenre.Name;
                existingGenre.Description = updatedGenre.Description;

                UpdateBooksGenreNames();
            }
            else
            {
                throw new ArgumentException($"Жанр з ID {updatedGenre.Id} не знайдено для оновлення.");
            }
        }

        public LibraryStats GetLibraryStatistics()
        {
            LibraryStats stats = new LibraryStats();

            stats.TotalBooks = Books.Count;

            stats.AvailableBooks = Books.Count(b => b.IsAvailable);
            stats.LentBooks = Books.Count(b => !b.IsAvailable);

            stats.BooksByGenre = Books
                .GroupBy(book => book.GenreId)
                .Join(Genres,
                      bookGroup => bookGroup.Key,
                      genre => genre.Id,
                      (bookGroup, genre) => new { GenreName = genre.Name, Count = bookGroup.Count() })
                .ToDictionary(g => g.GenreName, g => g.Count);

            if (Books.Any())
            {
                stats.AverageRating = Books.Average(b => b.Rating);
            }
            else
            {
                stats.AverageRating = 0;
            }

            return stats;
        }
    }
}

