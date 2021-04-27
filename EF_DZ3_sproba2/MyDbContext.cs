using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DZ3_sproba2
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("conStr") { }
        static MyDbContext()
        {
            Database.SetInitializer<MyDbContext>(new MyInitializationBD());
        }
        public virtual DbSet<Sage> Sages { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}
