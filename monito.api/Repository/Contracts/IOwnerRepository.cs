using monito.api.Domain.Model;

namespace monito.api.Repository.Contracts
{
    public interface IOwnerRepository
    {
        Task<List<Owner>> GetAllAsync();
        Task<Owner?> GetByIdAsync(int id);
        Task<Owner> CreateAsync(Owner owner);
        Task<Owner?> UpdateAsync(int id,Owner owner);
        Task<Owner?> DeleteAsync(int id);
    }
}
