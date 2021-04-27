using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DZ
{
    public class Sage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Age { get; set; }
        public int? SageID { get; set; }
        public virtual SageBook sageBook { get; set; }
    }
}
