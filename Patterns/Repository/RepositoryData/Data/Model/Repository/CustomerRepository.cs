using RepositoryData.Data.Interfaces;

namespace RepositoryData.Data.Model.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}