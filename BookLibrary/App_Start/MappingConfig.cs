using AutoMapper;
using BookLibrary.Model;
using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.App_Start
{
    public class MappingConfig
    {

        public static void RegisterMappings()
        {

            Mapper.CreateMap<Book, BookViewModel>();
            Mapper.CreateMap<BookViewModel, Book>();

        }

    }
}