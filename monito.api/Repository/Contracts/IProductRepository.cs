using monito.api.Domain.Model;

namespace monito.api.Repository.Contracts
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<List<Product>> GetAllAsync();
        
    }
}
