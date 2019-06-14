using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkSystem
{
    public class Author
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameAuthor { get; set; }
        public string NameBook { get; set; }
        public string PriceBook { get; set; }
    }
}
