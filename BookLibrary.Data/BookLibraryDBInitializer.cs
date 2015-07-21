using BookLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data
{

    public class BookLibraryDBInitializer : DropCreateDatabaseIfModelChanges<BookLibraryContext>
    {

        protected override void Seed(BookLibraryContext context)
        {

            context.Authors.Add(new Author
            {
                FirstName = "Andrew ",
                LastName = "Peters",
                Books = new List<Book>() {
                                            new Book { Title = "Test Book 1", Description = "3333", ISBN = "eedsd2232", Year = 1988 },
                                            new Book { Title = "Peters 3", Description = "xxxxxxxx", ISBN = "9393j3j39ejddd", Year = 1986 }
                                         }
            });

            context.Authors.Add(new Author
            {
                FirstName = "Peter",
                LastName = "Perez",
                Books = new List<Book>() {
                                            new Book { Title = "Book 3", Description = "gggfgfgf ", ISBN = "ee4422323d2", Year = 1922 },
                                            new Book { Title = "Pet Book", Description = "dfsdsdsdsd", ISBN = "93aaa33339ejddd", Year = 1945 }
                                         }
            });

            base.Seed(context);
        }

    }

}
