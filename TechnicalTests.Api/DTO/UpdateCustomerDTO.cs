using System.ComponentModel.DataAnnotations;

namespace TechnicalTests.Api.DTO
{
    public class UpdateCustomerNameDTO
    {
        [Required(ErrorMessage = "FullName is required.")]
        public string FullName { get; set; } = null!;
    }
}
