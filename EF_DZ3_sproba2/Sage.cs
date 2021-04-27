using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DZ3_sproba2
{
    public class Sage
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public DateTime Age { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Sage()
        {
            Books = new List<Book>();
        }
        public override string ToString() => $"{Name}";
    }
}
