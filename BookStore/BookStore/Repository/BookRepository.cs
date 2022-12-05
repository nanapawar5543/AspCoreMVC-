using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookstoreContext _context = null;
        public BookRepository(BookstoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel bookModel)
        {
            var book = new Books()
            {
                BookAuthor = bookModel.BookAuthor,
                BookTitle = bookModel.BookTitle,
                BookDescription = bookModel.BookDescription,
                LanguageID = bookModel.LanguageID,
                
                BookCategory = bookModel.BookCategory,
                NoofPages = bookModel.NoofPages.HasValue?bookModel.NoofPages.Value:0,
                CreatedOn = DateTime.Now
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book.BookID;
        }
        public async Task<List<BookModel>> LisOfBooks()
        {
            return await _context.Books.Select(book=>new BookModel()
            {
                BookID = book.BookID,
                BookAuthor = book.BookAuthor,
                BookTitle = book.BookTitle,
                BookDescription = book.BookDescription,
                LanguageID = book.LanguageID,
                BookLanguage = book.language.Name,
                BookCategory = book.BookCategory,
                NoofPages = book.NoofPages,
                CreatedOn = book.CreatedOn
            }).ToListAsync();
        }
        public async Task<BookModel> Book(int id)
        {
            return await _context.Books.Where(temp => temp.BookID == id).Select(book => new BookModel()
            {
                BookID = book.BookID,
                BookAuthor = book.BookAuthor,
                BookTitle = book.BookTitle,
                BookDescription = book.BookDescription,
                LanguageID = book.LanguageID,
                BookLanguage = book.language.Name,
                BookCategory = book.BookCategory,
                NoofPages = book.NoofPages,
                CreatedOn = book.CreatedOn
            }).FirstOrDefaultAsync();
        }
        public List<BookModel> SearchBooks(string title = "", string author = "")
        {
            var books = new List<BookModel>();
            return books;
        }
        
    }
}
