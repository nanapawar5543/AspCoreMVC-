using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Repository;
using BookStore.Model;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public HomeController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IActionResult> Index()
        { 
            var books = await _bookRepository.LisOfBooks();
            return View(books);
        }
        [Route("About")]
        public ActionResult About()
        {
            return View();
        }
        [Route("Contactus")]
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult ContactUs2222()
        {
            return View();
        }
    }
}
