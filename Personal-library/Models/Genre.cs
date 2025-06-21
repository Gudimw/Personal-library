using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_library.Models
{
    public class Genre
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Унікальний ID для жанру
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public override string ToString()
        {
            return Name;
        }
    }
}
