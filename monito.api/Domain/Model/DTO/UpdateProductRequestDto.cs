using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace monito.api.Domain.Model.DTO
{
    public class UpdateProductRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public string ProductType { get; set; }
    }
}
