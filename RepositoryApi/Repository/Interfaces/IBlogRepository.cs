using RepositoryApi.Models;
using System.Collections.Generic;

namespace RepositoryApi.Repository.Interfaces
{
    public interface IBlogRepository: IRepository<Blog>
    {
         IEnumerable<Blog> GetAllWithPost();
    }
}