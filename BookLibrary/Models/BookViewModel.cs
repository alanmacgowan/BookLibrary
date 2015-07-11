using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class BookViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }
        
        [Display(Name = "Year Published")]
        public int Year { get; set; }

    }
}