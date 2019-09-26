using RepositoryApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RepositoryApi.Repository.Interfaces;

namespace RepositoryApi.Repository
{
    public class BlogRepository: Repository<Blog>, IBlogRepository
    {
        public BlogRepository(RepositoryContext context): base(context) {

        }
        public IEnumerable<Blog> GetAllWithPost() {
            return _context.Blogs.Include(b => b.Posts);
        }
    }
}