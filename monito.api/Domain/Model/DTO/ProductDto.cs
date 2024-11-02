namespace monito.api.Domain.Model.DTO
{
    public class ProductDto
    {

        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string ImagePath { get; set; } 

        // Additional fields related to product type
        public string ProductType { get; set; }
    }
}
