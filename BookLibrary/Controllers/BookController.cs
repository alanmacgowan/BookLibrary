using BookLibrary.Service.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class BookController : Controller
    {

        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Book
        public ActionResult Index()
        {
            var bookList = _bookService.GetAllBooks().ToList();

            return View(bookList);
        }
    }
}