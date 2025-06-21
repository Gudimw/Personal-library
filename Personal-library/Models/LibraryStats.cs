using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_library.Models
{
    /// <summary>
    /// Допоміжний клас для статистики
    /// </summary>
    public class LibraryStats
    {
        public int TotalBooks { get; set; }
        public int AvailableBooks { get; set; }
        public int LentBooks { get; set; }
        public Dictionary<string, int> BooksByGenre { get; set; } = new Dictionary<string, int>();
        public double AverageRating { get; set; }
    }
}
