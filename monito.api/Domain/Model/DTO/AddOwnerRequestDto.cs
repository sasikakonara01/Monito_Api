using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace monito.api.Domain.Model.DTO
{
    public class AddOwnerRequestDto
    {
        [Required]
        [MaxLength(50,ErrorMessage ="Name Is to long")]
        [MinLength(3,ErrorMessage = "Minimum lenth is 3 letters,")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [MinLength(10, ErrorMessage = "Minimum lenth is 10 letters,")]
        public string PhoneNumber { get; set; }
    }
}
