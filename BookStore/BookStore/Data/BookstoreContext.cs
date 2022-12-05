using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookstoreContext:DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options):base(options)
        {

        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Languages { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=LAPTOP-LN3AL050;Databse=BookStore;Integrated Security=true");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
