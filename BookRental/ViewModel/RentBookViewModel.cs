using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookRental.Models;
namespace BookRental.ViewModel
{
    public class RentBookViewModel
    {
        public IEnumerable<Rental> Rental { get; set; }
        public IEnumerable<Book> Book { get; set; }
        public string Book_Name { get; set; }
        public string Author { get; set; }


    }
}