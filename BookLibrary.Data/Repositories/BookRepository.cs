using BookLibrary.Data.Abstract;
using BookLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Repositories
{
    public class BookRepository : BaseRepository<Book, BookLibraryContext>, IBookRepository
    {

        public BookRepository(BookLibraryContext context)
        {
            Context = context;
            Set = Context.Books;
        } 

        public IQueryable<Book> GetBooksByAuthor(int authorId)
        {
            return Set.Where(b => b.Author.Id == authorId);
        }


    }
}
