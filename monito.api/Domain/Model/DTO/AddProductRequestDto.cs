namespace monito.api.Domain.Model.DTO
{
    public class AddProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string ImagePath { get; set; }
        public string ProductType { get; set; }
    }
}
