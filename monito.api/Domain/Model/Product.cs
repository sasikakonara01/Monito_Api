namespace monito.api.Domain.Model
{
    public class Product
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string ImagePath { get; set; } // To store the image URL or file path

        // Additional fields related to product type
        public string ProductType { get; set; } // e.g., Dog Food, Cat Food, Toys, etc.
    }
}
