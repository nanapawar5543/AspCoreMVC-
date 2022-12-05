using Microsoft.AspNetCore.Mvc;
using BookStore.Model;
using BookStore.Repository;
using BookStore.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
        public async Task<IActionResult> AddNewBook(bool isSuccess = false,int bookid=0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.bookid = bookid;
            //ViewBag.Categories = new SelectList(GetCatagories(), "CategoryId", "CategoryName");
            ViewBag.Language=new SelectList(await _languageRepository.GetallLanguages(),"ID","Name");
            ViewBag.Categories = GetCatagories().Select(x => new SelectListItem()
            {
                Text=x.CategoryName,
                Value=x.CategoryId.ToString()
            }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookmodel)
        {
            if(ModelState.IsValid)
            {
                int bookid = await _bookRepository.AddNewBook(bookmodel);
                if (bookid > 0)
                {
                    return RedirectToAction("AddNewBook", new { isSuccess = true, bookid = bookid });
                }
                else
                {
                    return View();  
                }   
            }
            //ViewBag.Categories = new SelectList(GetCatagories(), "CategoryId", "CategoryName");
            ViewBag.Language = new SelectList(await _languageRepository.GetallLanguages(), "ID", "Name");
            ViewBag.Categories = GetCatagories().Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
            return View();
        }
        [Route("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.LisOfBooks();
            return View(books);
        }
        [Route("GetBook/{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            //dynamic data = new System.Dynamic.ExpandoObject();
            //data.book = _bookRepository.Book(id);
            //data.Name = "Nanaso";
            var book = await _bookRepository.Book(id);
            return View(book);
        }
        [HttpPost]
        [Route("SearchBooks")]
        public ActionResult SerchBooks(string title = "", string author = "")
        {
            var books = _bookRepository.SearchBooks(title, author);
            return View("GetAllBooks", books);
        }
        private List<BookCatagoryModel> GetCatagories()
        {
            return new List<BookCatagoryModel>()
            {
                new BookCatagoryModel(){CategoryId=1,CategoryName="Web Development"},
                new BookCatagoryModel(){CategoryId=2,CategoryName="Web Design"},
                new BookCatagoryModel(){CategoryId=3,CategoryName="Mobile Development"},
                new BookCatagoryModel(){CategoryId=4,CategoryName="Scripting lang."}
            };
        }
    }
}
