using Microsoft.EntityFrameworkCore;
using RepositoryExample.Repository.Model;

namespace RepositoryExample.Repository 
{
    public class BloggingContext: DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }
    }
}//https://www.programmingwithwolfgang.com/repository-and-unit-of-work-pattern/
//https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory
//https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite