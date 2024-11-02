using monito.api.Domain.Model;

namespace monito.api.Repository
{
    public interface IPetRepository
    {
            Task<List<Pet>> GetAllAsync();
            Task<Pet?>GetByIdAsync(int id);
            Task<Pet>CreateAsync(Pet pet);
            Task<Pet?> UpdateAsync(int id, Pet pet);
            Task<Pet?> DeleteAsync(int id);

    }


}
