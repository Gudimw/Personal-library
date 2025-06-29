﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_library.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; // Можливо, у вас є

        public Genre()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
