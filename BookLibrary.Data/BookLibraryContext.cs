using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookLibrary.Model;

namespace BookLibrary.Data
{
    public class BookLibraryContext : DbContext
    {


        public BookLibraryContext()
            : base("name=BookLibraryContext")
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }


    }
}
