using TechnicalTests.Api.DTO;
using TechnicalTests.Api.Entities;

namespace TechnicalTests.Api.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetCustomers();
        Task<CustomerDTO> UpdateCustomer(int id, UpdateCustomerNameDTO customer);
        Task DeleteCustomer(int id);
        Task<Customer> CreateCustomer(CreateCustomerDTO customerDTO);
    }
}
