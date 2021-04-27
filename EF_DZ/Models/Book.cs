using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DZ
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? BookID { get; set; }
        public virtual SageBook sageBook { get; set; }
    }
}
