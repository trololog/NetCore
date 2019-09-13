using Microsoft.EntityFrameworkCore;
using RepositoryData.Data.Model;

namespace RepositoryData.Data
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options): base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}