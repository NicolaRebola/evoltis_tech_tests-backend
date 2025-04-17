using Microsoft.EntityFrameworkCore;
using System.Threading;
using TechnicalTests.Api.Data;
using TechnicalTests.Api.Entities;
using TechnicalTests.Api.Exceptions;

namespace TechnicalTests.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;
        public CustomerRepository(AppDbContext appDbContext) {
            _dbContext = appDbContext;
        }

        public async Task<Customer> CreateCustomer(Customer customer, CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task Delete(Customer customer, CancellationToken cancellationToken = default)
        {
            _dbContext.Customers.Remove(customer);
            await SaveChanges();
        }

        public async Task<Customer> FindById(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Customers.FindAsync(new object[] { id }, cancellationToken);
        }

        public Task<List<Customer>> GetAll()
        {
            return _dbContext.Customers.ToListAsync();
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}