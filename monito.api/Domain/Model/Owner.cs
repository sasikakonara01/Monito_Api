namespace monito.api.Domain.Model
{
    public class Owner
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation Property - One owner can have multiple pets
        public ICollection<Pet> Pets { get; set; }
    }
}
