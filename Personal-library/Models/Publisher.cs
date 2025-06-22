using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_library.Models
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Publisher()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
