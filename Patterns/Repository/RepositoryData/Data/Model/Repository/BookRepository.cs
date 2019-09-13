using System;
using System.Collections.Generic;
using RepositoryData.Data.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RepositoryData.Data.Model.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context): base(context)
        {
            
        }

        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(b => b.Authors)
                .Where(predicate);
        }

        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Borrowers)
                .Where(predicate);
        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            return _context.Books.Include(a => a.Authors);
        }
    }
}