using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BookRental.Models;

namespace BookRental.ViewModel
{
    public class BookViewModel
    {
        public IEnumerable<Book> Books { get; set; }

        [Display(Name = "Name")]
        public string Book_Name { get; set; }

        [Display(Name = "Author")]
        public string Book_Author { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int Book_Quantity { get; set; }


        [Display(Name = "ISBN")]
        public int Book_ISBN { get; set; }
        public DateTime? Book_Release { get; set; }

        public string SearchTerm { get; set; }
    }
}