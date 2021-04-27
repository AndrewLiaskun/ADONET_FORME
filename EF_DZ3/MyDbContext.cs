using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DZ3
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("conStr") { }
        public virtual DbSet<Sage> Sages { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}
