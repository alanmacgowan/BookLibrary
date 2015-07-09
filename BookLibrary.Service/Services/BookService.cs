using BookLibrary.Data.Abstract;
using BookLibrary.Model;
using BookLibrary.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Service.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public Book UpdateBook(Book book)
        {
            return _bookRepository.Update(book);
        }

        public Book CreateBook(Book book)
        {
            return _bookRepository.Insert(book);
        }

        public void DeleteBook(int id)
        {
            var book = _bookRepository.GetById(id);
            _bookRepository.Delete(book);
        }
    }
}
