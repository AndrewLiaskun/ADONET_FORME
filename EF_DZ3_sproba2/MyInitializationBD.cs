using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DZ3_sproba2
{
    public class MyInitializationBD :   CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            Book b1 = new Book() { Title = "Titanik" };
            Book b2 = new Book() { Title = "Book" };
            Sage s1 = new Sage() { Name = "Bob", Age = new DateTime(2000, 1, 12) };
            Sage s2 = new Sage() { Name = "Jack", Age = new DateTime(1969, 4, 22) };
            s1.Books.Add(b1);
            s2.Books.Add(b2);
            context.Books.Add(b1);
            context.Books.Add(b2);
            context.Sages.Add(s1);
            context.Sages.Add(s2);
            context.SaveChanges();
        }
    }
}
