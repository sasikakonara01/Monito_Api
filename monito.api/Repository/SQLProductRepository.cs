using Microsoft.AspNetCore.Http.HttpResults;
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

        public async  Task<List<Product>> GetAllAsync(string? filterOn = null, string? filterQuery = null)
        {
           var ProductList = _monitoDbContext.Products.AsQueryable();
            
            //Filtering
            if(string.IsNullOrWhiteSpace(filterOn)==false&& string.IsNullOrWhiteSpace(filterQuery)==false)
            {
               if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    ProductList = ProductList.Where(x=>x.Name.Contains(filterQuery));
                }
                if (filterOn.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    ProductList = ProductList.Where(x => x.Description.Contains(filterQuery));
                }
            }



            return await ProductList.ToListAsync();
        }

        public async Task<Product?>GetByIdAsync(int id)
        {
            
            var productExsisits = await _monitoDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (productExsisits == null)
            {
                return null;
            }
            return productExsisits;
        
    }

        public async Task<Product?>UpdateAsync(int id, Product product)
        { 
            var productExsist = await _monitoDbContext.Products.FirstOrDefaultAsync(x=>x.Id == id);

            if (productExsist == null)
            {
                return null;
            }

            //Saving updated Data
          productExsist.Name = product.Name;
          productExsist.Description= product.Description;
          productExsist.Price= product.Price;
          productExsist.Size= product.Size;
          productExsist.ImagePath=product.ImagePath;
          productExsist.ProductType= product.ProductType;
             
            await _monitoDbContext.SaveChangesAsync();

            return productExsist;
    }


        public async Task<Product?> DeleteAsync(int id)
        {
           var productExsists = await _monitoDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (productExsists == null) 
            {
                return null;
            }

            _monitoDbContext.Products.Remove(productExsists);
            await _monitoDbContext.SaveChangesAsync();
            return productExsists;

        }
    }
}
