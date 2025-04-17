using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using TechnicalTests.Api.Data;
using TechnicalTests.Api.DTO;
using TechnicalTests.Api.Entities;
using TechnicalTests.Api.Repositories;
using TechnicalTests.Api.Services.Interfaces;
using TechnicalTests.Api.Exceptions;

namespace TechnicalTests.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Customer> CreateCustomer(CreateCustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                FullName = customerDTO.FullName,
                Email = customerDTO.Email,
                RegistrationDate = DateTime.UtcNow
            };

            return await _customerRepository.CreateCustomer(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _customerRepository.FindById(id) ?? throw new EntityNotFoundException($"Customer with id {id} not found");
            await _customerRepository.Delete(customer);
        }

        public async Task<List<CustomerDTO>> GetCustomers()
        {
            var result = await _customerRepository.GetAll();

            return _mapper.Map<List<CustomerDTO>>(result);
        }

        public async Task<CustomerDTO> UpdateCustomer(int id, UpdateCustomerNameDTO customerDTO)
        {
            var customer = await _customerRepository.FindById(id) ?? throw new EntityNotFoundException($"Customer with id {id} not found");
            
            customer.FullName = customerDTO.FullName;
            await _customerRepository.SaveChanges();

            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}
