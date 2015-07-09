using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibrary.Model
{
    public class Author : BaseEntity
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
