namespace monito.api.Domain.Model.DTO
{
    public class UpdatePetRequestDto
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int AgeInMonths { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public bool? Vaccinated { get; set; }
        public bool? Dewormed { get; set; }
        public bool? Cert { get; set; } // Certification
        public bool? Microchip { get; set; }
        public string Location { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? AdditionalInfo { get; set; }
        public string ImagePath { get; set; } // For storing the path to the image file

        // Foreign Key for Owner
        public int OwnerId { get; set; } // Owner reference
    }
}
