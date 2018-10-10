using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookRental.Models;
using BookRental.ViewModel;
using Microsoft.AspNet.Identity;
using System.Net;

namespace BookRental.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();

        }

        // GET: Customer
        [Authorize]
        public ActionResult AboutMe()
        {

            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AboutMe(Customer customer)
        {
            var cust = new Customer()
            {
                CustomerId = User.Identity.GetUserId(),
                Cust_FName = customer.Cust_FName,
                Cust_LName = customer.Cust_LName,
                Cust_BOD = customer.Cust_BOD
            };

            _context.Customer.Add(cust);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult DisplaytMe()
        {
            if (!User.IsInRole("CanManageBook"))
            {
                var userId = User.Identity.GetUserId();

                var user = _context.Customer.Single(c => c.CustomerId == userId);

                return View(user);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult RentBook()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult RentBook(int id)
        {
            var book = _context.Book.Single(b => b.Id == id);
            var userid = User.Identity.GetUserId();
            var customer = _context.Customer.Single(c => c.CustomerId == userid);

            if (book.Book_Quantity == 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('This Book is not available');</script>");
            }
            else
            {
                book.Book_Quantity--;

                var rent = new Rental
                {
                    Customer = customer,
                    Book = book,
                    DateRented = DateTime.Now
                };
                _context.Rental.Add(rent);
                _context.SaveChanges();

                return RedirectToAction("ReadBooks", "Book");
            }
        }
        [Authorize]
        public ActionResult ViewRentedBooks()
        {
            if (!User.IsInRole("CanManageBook"))
            {

                RentBookViewModel book = new RentBookViewModel();
                var userId = User.Identity.GetUserId();
                book.Rental = _context.Rental.Include("Book").Where(c => c.Customer.CustomerId == userId).ToList();

                return View(book);
            }
            else
                return RedirectToAction("AddBook", "Book");
        }

        [Authorize]
        public ActionResult UnRent(int id , int bid)
        {
            var userId = User.Identity.GetUserId();
            var book = _context.Rental.Include("Book").Single(b => b.Book.Id == id && b.Id==bid && b.Customer.CustomerId == userId);
            var bk = _context.Book.Single(bo => bo.Id == id);

            _context.Rental.Remove(book);
            bk.Book_Quantity++;
            _context.SaveChanges();

            
            return RedirectToAction("ViewRentedBooks", "Customer");
        }

        
    }
}