using System.Collections.Generic;
using RepositoryData.Data.Interfaces;
using RepositoryData.Data.Model;
using System.Linq;
using System;
using RepositoryData.Data.Model.Repository;
using RepositoryData.Data;
using Microsoft.EntityFrameworkCore;

namespace RepositoryTests
{
    public class BookRepositoryMock: Repository<Book>, IBookRepository
    {
        public BookRepositoryMock(LibraryDbContext context):base(context) {}

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
