using Microsoft.EntityFrameworkCore;
using monito.api.Data;
using monito.api.Domain.Model;
using monito.api.Repository.Contracts;

namespace monito.api.Repository
{
    public class SQLProductRepository : IProductRepository

    {
        private readonly MonitoDbContext _monitoDbContext;

        public SQLProductRepository(MonitoDbContext monitoDbContext)
        {
            _monitoDbContext = monitoDbContext;
        }



        public async Task<Product> CreateAsync(Product product)
        {
          await _monitoDbContext.Products.AddAsync(product);
            await _monitoDbContext.SaveChangesAsync();
            return product;
        }

       public async  Task<List<Product>> GetAllAsync()
        {
           var ProductList = await _monitoDbContext.Products.ToListAsync();
            return ProductList;
        }

        
    }
}
