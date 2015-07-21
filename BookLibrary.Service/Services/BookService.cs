using BookLibrary.Repositories.Abstract;
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


        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            return await _bookRepository.UpdateAsync(book);
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            return await _bookRepository.InsertAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            _bookRepository.DeleteAsync(book);
        }

    }
}
