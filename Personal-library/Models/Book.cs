using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Personal_library.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public Guid PublisherId { get; set; }
        public int PublicationYear { get; set; }
        public Guid GenreId { get; set; }
        public string Origin { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string LentTo { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Description { get; set; } = string.Empty;

        // Ці властивості не серіалізуються
        [JsonIgnore]
        public string GenreName { get; set; } = "Невідомий жанр";

        [JsonIgnore]
        public string PublisherName { get; set; } = "Невідомий видавець";

        public Book()
        {
            Id = Guid.NewGuid();
            IsAvailable = true;
            Rating = 1;
            PublicationYear = DateTime.Now.Year;
        }

        // Додатковий конструктор або метод для копіювання
        public Book Clone()
        {
            return new Book
            {
                Id = this.Id,
                Title = this.Title,
                Author = this.Author,
                PublisherId = this.PublisherId,
                PublicationYear = this.PublicationYear,
                GenreId = this.GenreId,
                Origin = this.Origin,
                IsAvailable = this.IsAvailable,
                LentTo = this.LentTo,
                Rating = this.Rating,
                Description = this.Description,

                GenreName = this.GenreName,
                PublisherName = this.PublisherName
            };
        }
    }
}
