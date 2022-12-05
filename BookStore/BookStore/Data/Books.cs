using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data
{
    public class Books
    {
        [Key]
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string BookDescription { get; set; }
        public string BookCategory { get; set; }
        public int LanguageID { get; set; }
        public int NoofPages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Language language { get; set; }
    }
}
