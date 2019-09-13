using System.Collections.Generic;
using RepositoryData.Data.Model;
using System;

namespace RepositoryData.Data.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        IEnumerable<Book> GetAllWithAuthor();
        IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate);
        IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate);
    }
}