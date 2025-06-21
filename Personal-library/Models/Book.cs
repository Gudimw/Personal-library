using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_library.Models
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public Guid GenreId { get; set; } // Зв'язок з Genre за ID

        [System.Text.Json.Serialization.JsonIgnore] // Ця властивість не буде серіалізована
        public string GenreName { get; set; } = string.Empty; // Назва жанру для зручності відображення

        public string Origin { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public string? LentTo { get; set; }
        public int Rating { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            // Використовуємо GenreName для відображення, що буде оновлено
            return $"{Title} - {Author} ({PublicationYear}) [{GenreName}]";
        }
    }
}
