using BookLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Abstract
{

    public interface IBookRepository : IRepository<Book>
    {
        IQueryable<Book> GetBooksByAuthor(int authorId);
    }

}
