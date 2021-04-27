using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DZ3_sproba2
{
    public class SageBook
    {
        public int Id { get; set; }
        public int SageID { get; set; }
        public int BookID { get; set; }
        
        public SageBook()
        {
            Sages = new List<Sage>();
            Books = new List<Book>();
        }
    }
}
