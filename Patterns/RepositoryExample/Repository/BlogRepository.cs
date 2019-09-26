using RepositoryExample.Repository.Model;
using RepositoryExample.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RepositoryExample.Repository
{
    public class BlogRepository: Repository<Blog>, IBlogRepository
    {
        private readonly BloggingContext _context;

        public BlogRepository(BloggingContext context): base(context)
        {
            _context = context;
        }

        public IEnumerable<Blog> FindWithPost(Func<Blog, bool> predicate)
        {
            return _context.Blogs
                .Include(b => b.Posts)
                .Where(predicate);
        }
    }
}