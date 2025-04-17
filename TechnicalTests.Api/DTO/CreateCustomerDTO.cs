using System.ComponentModel.DataAnnotations;

namespace TechnicalTests.Api.DTO
{
    public class CreateCustomerDTO
    {
        [Required(ErrorMessage = "FullName is required.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email format is invalid.")]
        public string Email { get; set; }
    }
}
