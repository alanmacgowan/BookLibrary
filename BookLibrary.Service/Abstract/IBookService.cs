using BookLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Service.Abstract
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Book UpdateBook(Book book);
        Book CreateBook(Book book);
        void DeleteBook(int id);
    }
}
