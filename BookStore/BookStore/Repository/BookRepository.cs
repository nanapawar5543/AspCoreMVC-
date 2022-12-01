using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> LisOfBooks()
        {
            return datasource();
        }
        public BookModel Book(int id)
        {
            return datasource().Where(temp => temp.ID == id).FirstOrDefault(); ;
        }
        public List<BookModel> SearchBooks(string title = "",string author="")
        {
            return datasource().Where(temp => temp.Title.Contains(title) && temp.Author.Contains(author)).ToList();
        }
        private List<BookModel> datasource()
        {
            return new List<BookModel>()
            {
                new BookModel(){ID=1,Author="Ashish",Title="How to be Rich"},
                new BookModel(){ID=2,Author="Amar",Title="Detais of Cload"},
                new BookModel(){ID=3,Author="Sagar",Title="How to be perfect farmer"},
                new BookModel(){ID=4,Author="Nilesh",Title="All about Azure"},
                new BookModel(){ID=5,Author="Mahesh",Title="About Family"},
                new BookModel(){ID=6,Author="Mahesh",Title="Be a Good man"}
            };
        }
    }
}
