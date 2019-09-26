using System;

namespace RepositoryExample.Repository.Interfaces 
{
    public interface IUnitOfWork:IDisposable
    {
        IBlogRepository Blogs { get; }

        int Complete();
    }
}