using System.ComponentModel.DataAnnotations;

namespace TechnicalTests.Api.DTO
{
    public class CustomerDTO
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Id { get; set; }
    }
}
