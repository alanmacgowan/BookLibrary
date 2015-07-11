using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Model
{
    public class Book : BaseEntity
    {

        [Required]
        public string Title  { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }
        
        public int Year { get; set; }

        public virtual Author Author { get; set; }

    }
}
