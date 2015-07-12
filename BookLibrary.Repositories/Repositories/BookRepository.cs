using BookLibrary.Repositories.Abstract;
using BookLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Data;

namespace BookLibrary.Repositories.Repositories
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
