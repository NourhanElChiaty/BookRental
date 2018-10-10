using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookRental.Models;
using BookRental.ViewModel;
using Microsoft.AspNet.Identity;

namespace BookRental.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController()
        {
            _context = new ApplicationDbContext();

        }
        // GET: Book
        [Authorize]
        public ActionResult AddBook()
        {
            if (User.IsInRole("CanManageBook"))
           
                return View("AddBook");
                return RedirectToAction("ReadBooks","Book");
            
        }
        [Authorize]
        [HttpPost]
        public ActionResult SaveBook(Book book)
        {
            var b = new Book()
            {
                Book_Name=book.Book_Name,
                Book_Author=book.Book_Author,
                Book_ISBN=book.Book_ISBN,
                Book_Quantity=book.Book_Quantity,
                Book_Release=book.Book_Release
            };

            _context.Book.Add(b);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public ActionResult ReadBooks(string query = null)
        {
            var book = _context.Book.ToList();
            
            
           
            if (!String.IsNullOrWhiteSpace(query))
            {
               book = book.Where(b => b.Book_Name.Contains(query)|| b.Book_Author.Contains(query)).ToList();
            }
            var viewmodel = new BookViewModel
            {
                Books =book
            };
            return View("ReadBooks",viewmodel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Search(BookViewModel viewmodel)
        {

            return RedirectToAction("ReadBooks", "Book", new { query = viewmodel.SearchTerm });
        }

    }
}