using System.Collections.Generic;
using RepositoryData.Data.Model;

namespace RepositoryData.Data.Interfaces
{
    public interface IAuthorRepository: IRepository<Author>
    {
         IEnumerable<Author> GetAllWithBooks();
         Author GetWithBooks(int id);
    }
}