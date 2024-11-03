using System.ComponentModel.DataAnnotations;

namespace monito.api.Domain.Model.DTO
{
    public class UpdatePetRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int AgeInMonths { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Color { get; set; }

        public bool? Vaccinated { get; set; }

        public bool? Dewormed { get; set; }

        public bool? Cert { get; set; } // Certification

        public bool? Microchip { get; set; }

        public string Location { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }

        public string? AdditionalInfo { get; set; }
        [Required]
        public string ImagePath { get; set; } // For storing the path to the image file

        // Foreign Key for Owner
        [Required]
        public int OwnerId { get; set; } // Owner reference
    }
}
