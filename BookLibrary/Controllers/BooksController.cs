using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookLibrary.Model;
using BookLibrary.Models;
using BookLibrary.Service.Abstract;
using AutoMapper;

namespace BookLibrary.Controllers
{
    public class BooksController : Controller
    {
        private IBookService _bookService;


        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult IndexSync()
        {
            var bookList =  _bookService.GetAllBooks();
            var booksVMList = new List<BookViewModel>();
            if (bookList != null)
            {
                booksVMList = bookList.Select(Mapper.Map<BookViewModel>).ToList();
            }

            return View("Index", booksVMList);
        }

        public async Task<ActionResult> Index()
        {
            var bookList = await _bookService.GetAllBooksAsync();
            var booksVMList = new List<BookViewModel>();
            if (bookList != null)
            {
                booksVMList = bookList.Select(Mapper.Map<BookViewModel>).ToList();
            }

            return View(booksVMList);
        }

        // GET: Books/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<BookViewModel>(book));
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,ISBN,Year")] BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = Mapper.Map<Book>(model);
                await _bookService.CreateBookAsync(book);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Books/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<BookViewModel>(book));
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,ISBN,Year")] BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = Mapper.Map<Book>(model);
                await _bookService.UpdateBookAsync(book);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //// GET: Books/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Book book = await db.Books.FindAsync(id);
        //    if (book == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(book);
        //}

        //// POST: Books/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Book book = await db.Books.FindAsync(id);
        //    db.Books.Remove(book);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

    }
}
