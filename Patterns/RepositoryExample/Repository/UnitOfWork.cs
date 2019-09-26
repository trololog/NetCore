using RepositoryExample.Repository.Interfaces;

namespace RepositoryExample.Repository
{
    public class UnitOfWork: IUnitOfWork
    {       
        private readonly BloggingContext _context;

        public UnitOfWork(BloggingContext context) 
        {
            _context = context;
            Blogs = new BlogRepository(context);
        }

        public IBlogRepository Blogs { get; }

        public int Complete() 
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}