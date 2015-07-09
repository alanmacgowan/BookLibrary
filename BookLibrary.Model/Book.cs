using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Model
{
    public class Book : BaseEntity
    {

        public int Id { get; set; }

        public string Name  { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public virtual Author Author { get; set; }

    }
}
