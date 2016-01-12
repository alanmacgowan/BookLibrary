using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibrary.Controllers;
using BookLibrary.Service.Abstract;
using Rhino.Mocks;
using BookLibrary.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BookLibrary.Model;
using System.Web.Mvc;
using AutoMapper;
using BookLibrary.App_Start;

namespace BookLibrary.Tests.Controller
{
    [TestClass]
    public class BookControllerTests
    {

        private IBookService _mockService;
        private BookController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            MappingConfig.RegisterMappings();
            _mockService = MockRepository.GenerateMock<IBookService>();
            _controller = new BookController(_mockService);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockService = null;
            _controller.Dispose();
            _controller = null;
        }

        [TestMethod]
        public void Index_Action_Calls_BookService_GetAllBooks()
        {
            //Arrange
            _mockService.Stub(x => x.GetAllBooks()).Return(null);

            //Act
            _controller.Index();

            //Assert
            _mockService.AssertWasCalled(x => x.GetAllBooks());
        }

        [TestMethod]
        public void Index_Action_Returns_ViewResult()
        {
            //Arrange
            _mockService.Stub(x => x.GetAllBooks()).Return(null);

            //Act
            var result = _controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_Action_Returns_DefaultView()
        {
            //Arrange
            _mockService.Stub(x => x.GetAllBooks()).Return(null);

            //Act
            var result = _controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void Index_Action_Returns_View_With_BookViewModel()
        {
            //Arrange
            _mockService.Stub(x => x.GetAllBooks()).Return(null);

            //Act
            var result = _controller.Index() as ViewResult;

            //Assert
            Assert.IsInstanceOfType(result.Model, typeof(IList<BookViewModel>));
        }

        [TestMethod]
        public void Index_Action_Returns_View_With_ViewModel_Containing_Same_Data()
        {
            //Arrange
            var books = new List<Book>();
            books.Add(new Book { Id = 1, Title = "aaa", Description = "a", Year = 1993 });
            books.Add(new Book { Id = 2, Title = "bbb", Description = "b", Year = 1994 });

            _mockService.Stub(x => x.GetAllBooks()).Return(books);

            var booksVM = books.Select(Mapper.Map<BookViewModel>).ToList();

            //Act
            var viewResult = _controller.Index() as ViewResult;
            var viewModel = viewResult.Model as List<BookViewModel>;

            //Assert
            Assert.AreEqual(booksVM.Count(), viewModel.Count());
        }

    }
}
