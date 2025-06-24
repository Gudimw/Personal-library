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
        public string PublisherName { get; set; } = "Невідомий видавець";
        public int PublicationYear { get; set; }
        public Guid GenreId { get; set; }
        public string LibrarySection { get; set; } = "Невизначено";
        public string Origin { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string LentTo { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Description { get; set; } = string.Empty;

        public string? ImageBase64 { get; set; }

        // Ці властивості не серіалізуються
        [JsonIgnore]
        public string GenreName { get; set; } = "Невідомий жанр";


        public Book()
        {
            Id = Guid.NewGuid();
            IsAvailable = true;
            Rating = 1;
            PublicationYear = DateTime.Now.Year;
        }
    }
}
