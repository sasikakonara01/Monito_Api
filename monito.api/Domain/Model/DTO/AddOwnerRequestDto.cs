using System.ComponentModel.DataAnnotations;

namespace monito.api.Domain.Model.DTO
{
    public class AddOwnerRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
