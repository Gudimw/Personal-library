using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace Personal_library.Models
{
    public class LibraryManager
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Publisher> Publishers { get; set; } = new List<Publisher>();


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
        /// Цей метод викликається після десеріалізації або при створенні нового LibraryManager.
        /// </summary>
        public void InitializeDefaultData()
        {
            if (!Genres.Any())
            {
                Genres.Add(new Genre { Name = "Фантастика", Description = "Жанр, що містить елементи наукової фантастики, фентезі та жахів." });
                Genres.Add(new Genre { Name = "Детектив", Description = "Жанр, зосереджений на розслідуванні злочинів." });
                Genres.Add(new Genre { Name = "Роман", Description = "Літературний жанр, що розповідає про події та досвід персонажів." });
            }

            if (!Publishers.Any())
            {
                Publishers.Add(new Publisher { Name = "Книголав" });
                Publishers.Add(new Publisher { Name = "Наш Формат" });
                Publishers.Add(new Publisher { Name = "Видавництво Старого Лева" });
            }

            // if (!Books.Any() && Genres.Any() && Publishers.Any())
            // {
            //     Books.Add(new Book
            //     {
            //         Title = "Дюна",
            //         Author = "Френк Герберт",
            //         PublisherId = Publishers.FirstOrDefault(p => p.Name == "Книголав")?.Id ?? Guid.Empty,
            //         PublicationYear = 1965,
            //         GenreId = Genres.FirstOrDefault(g => g.Name == "Фантастика")?.Id ?? Guid.Empty,
            //         Origin = "Куплена",
            //         IsAvailable = true,
            //         Rating = 5,
            //         Description = "Епічний науково-фантастичний роман."
            //     });
            // }
        }

        /// <summary>
        /// Повертає список книг, що належать до певного жанру.
        /// </summary>
        public List<Book> GetBooksByGenre(Guid genreId)
        {
            return Books.Where(b => b.GenreId == genreId).ToList();
        }

        /// <summary>
        /// Повертає список книг, виданих певним видавцем.
        /// </summary>
        public List<Book> GetBooksByPublisher(Guid publisherId)
        {
            return Books.Where(b => b.PublisherId == publisherId).ToList();
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
                // Можна також кинути виняток, щоб викликаючий код міг його обробити
                // throw; 
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
                    deserializedLibrary.Publishers = deserializedLibrary.Publishers ?? new List<Publisher>();

                    deserializedLibrary.InitializeDefaultData();

                    deserializedLibrary.UpdateBooksGenreNames();
                    deserializedLibrary.UpdateBooksPublisherNames();

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
        /// Допоміжний метод для оновлення властивості PublisherName у кожній книзі
        /// на основі Id видавця. Викликається після завантаження або зміни видавця.
        /// </summary>
        public void UpdateBooksPublisherNames()
        {
            foreach (var book in Books)
            {
                var publisher = Publishers.FirstOrDefault(p => p.Id == book.PublisherId);
                book.PublisherName = publisher?.Name ?? "Невідомий видавець";
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
            UpdateBooksPublisherNames();
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
                existingBook.PublisherId = updatedBook.PublisherId;
                existingBook.PublicationYear = updatedBook.PublicationYear;
                existingBook.GenreId = updatedBook.GenreId;
                existingBook.Origin = updatedBook.Origin;
                existingBook.IsAvailable = updatedBook.IsAvailable;
                existingBook.LentTo = updatedBook.LentTo;
                existingBook.Rating = updatedBook.Rating;
                existingBook.Description = updatedBook.Description;

                UpdateBooksGenreNames();
                UpdateBooksPublisherNames();
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

        // --- Методи для керування видавцями ---

        /// <summary>
        /// Додає нового видавця до бібліотеки.
        /// </summary>
        public void AddPublisher(Publisher publisher)
        {
            if (publisher == null) throw new ArgumentNullException(nameof(publisher));

            if (Publishers.Any(p => p.Name.Equals(publisher.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Видавець з назвою '{publisher.Name}' вже існує.");
            }
            Publishers.Add(publisher);
        }

        /// <summary>
        /// Видаляє видавця за його ID.
        /// Не дозволяє видалити видавця, якщо до нього прив'язані книги.
        /// </summary>
        public void DeletePublisher(Guid publisherId)
        {
            if (Books.Any(b => b.PublisherId == publisherId))
            {
                throw new InvalidOperationException("Неможливо видалити видавця, оскільки до нього прив'язані книги.");
            }
            var publisherToRemove = Publishers.FirstOrDefault(p => p.Id == publisherId);
            if (publisherToRemove != null)
            {
                Publishers.Remove(publisherToRemove);
            }
            else
            {
                throw new ArgumentException($"Видавця з ID {publisherId} не знайдено для видалення.");
            }
        }

        /// <summary>
        /// Оновлює інформацію про існуючого видавця.
        /// </summary>
        public void UpdatePublisher(Publisher updatedPublisher)
        {
            var existingPublisher = Publishers.FirstOrDefault(p => p.Id == updatedPublisher.Id);
            if (existingPublisher != null)
            {
                // Перевірка на унікальність назви видавця під час оновлення
                if (!existingPublisher.Name.Equals(updatedPublisher.Name, StringComparison.OrdinalIgnoreCase) && Publishers.Any(p => p.Name.Equals(updatedPublisher.Name, StringComparison.OrdinalIgnoreCase) && p.Id != updatedPublisher.Id))
                {
                    throw new ArgumentException($"Видавець з назвою '{updatedPublisher.Name}' вже існує.");
                }
                existingPublisher.Name = updatedPublisher.Name;

                UpdateBooksPublisherNames();
            }
            else
            {
                throw new ArgumentException($"Видавця з ID {updatedPublisher.Id} не знайдено для оновлення.");
            }
        }
    }
}

