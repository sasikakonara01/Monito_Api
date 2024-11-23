using monito.api.Domain.Model;

namespace monito.api.Repository.Contracts
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetAllAsync(string? filterOn = null, string? filterQuery = null);
        Task<Pet?> GetByIdAsync(int id);
        Task<Pet> CreateAsync(Pet pet);
        Task<Pet?> UpdateAsync(int id, Pet pet);
        Task<Pet?> DeleteAsync(int id);

    }


}
