using AutoMapper;
using TechnicalTests.Api.DTO;
using TechnicalTests.Api.Entities;

namespace TechnicalTests.Api.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
