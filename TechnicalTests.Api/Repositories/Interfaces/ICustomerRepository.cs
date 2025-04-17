using TechnicalTests.Api.Entities;

namespace TechnicalTests.Api.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomer(Customer customer, CancellationToken cancellationToken = default);
        Task<List<Customer>> GetAll();
        Task<Customer> FindById(int id, CancellationToken cancellationToken = default);
        Task Delete(Customer customer, CancellationToken cancellationToken = default);
        Task SaveChanges(CancellationToken cancellationToken = default);
    }
}