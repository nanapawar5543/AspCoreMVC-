using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Repository;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookRepository br=null;
        public HomeController()
        {
            br = new BookRepository();
        }
        [Route("GetAllBooks")]
        public ActionResult GetAllBooks() 
        {
            var books = br.LisOfBooks();
            return View(books);
        }
        [Route("Book")]
        public ActionResult Book(int id)
        {
            var book = br.Book(id);
            return View(book);
        }
        [HttpPost]
        [Route("SearchBooks")]
        public ActionResult SerchBooks(string title="" , string author="")
        {
            var books = br.SearchBooks(title    , author);
            return View("GetAllBooks", books);
        }
        
    }
}
