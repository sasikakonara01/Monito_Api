using Microsoft.EntityFrameworkCore;
using monito.api.Domain.Model;

namespace monito.api.Data
{
    public class MonitoDbContext : DbContext
    {
        public MonitoDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            

        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
