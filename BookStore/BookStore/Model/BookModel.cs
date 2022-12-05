using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Model
{
    public class BookModel
    {
        public int BookID { get; set; }
        [Required]
        [Display(Name ="Book Title")]
        public string BookTitle { get; set; }
        [Required]
        [Display(Name = "Book Author")]
        public string BookAuthor { get; set; }
        [Required]
        [Display(Name = "Book Description")]
        public string BookDescription { get; set; }
        [Required]
        [Display(Name = "Book Category")]
        public string BookCategory { get; set; }
        [Required]
        [Display(Name = "Book Language")]
        public int LanguageID { get; set; }
        public string BookLanguage { get; set; }    
        [Required]
        [Display(Name = "Total pages")]
        public int? NoofPages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
