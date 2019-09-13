using System;
using System.Collections.Generic;
using RepositoryExample.Repository.Model;

namespace RepositoryExample.Repository.Interfaces
{
    public interface IBlogRepository: IRepository<Blog>
    {
         IEnumerable<Blog> FindWithPost(Func<Blog, bool> predicate);
    }
}