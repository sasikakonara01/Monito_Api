using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using monito.api.Data;
using monito.api.Domain.Model;
using monito.api.Domain.Model.DTO;
using monito.api.Repository.Contracts;

namespace monito.api.Repository
{
    public class SQLPetRepository : IPetRepository
    {
        private readonly MonitoDbContext _monitoDbContext;

        public SQLPetRepository(MonitoDbContext monitoDbContext)
        {
            _monitoDbContext = monitoDbContext;
        }
        public async Task<List<Pet>> GetAllAsync()
        {
            return await _monitoDbContext.Pets.ToListAsync();
        }


        public async Task<Pet> CreateAsync(Pet pet)
        {
            await _monitoDbContext.Pets.AddAsync(pet);
            await _monitoDbContext.SaveChangesAsync();
            return pet;
        }


        public async Task<Pet?> GetByIdAsync(int id)
        {
          var petExsists = await _monitoDbContext.Pets.FirstOrDefaultAsync(x=>x.Id == id);
            if (petExsists == null)
            {
                return null;
            }
            return petExsists;
        }

        public async Task<Pet?> UpdateAsync(int id, Pet pet)
        {
            var petExsists = await _monitoDbContext.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (petExsists == null) {
                return null;
            }

            petExsists.Name = pet.Name;
            petExsists.Gender = pet.Gender;
            petExsists.AgeInMonths = pet.AgeInMonths;
            petExsists.Size = pet.Size;
            petExsists.Color = pet.Color;
            petExsists.Vaccinated = pet.Vaccinated;
            petExsists.Dewormed = pet.Dewormed;
            petExsists.Cert = pet.Cert;
            petExsists.Microchip = pet.Microchip;
            petExsists.Location = pet.Location;
            petExsists.PublishedDate = pet.PublishedDate;
            petExsists.AdditionalInfo = pet.AdditionalInfo;
            petExsists.ImagePath = pet.ImagePath;
            petExsists.OwnerId = pet.OwnerId;
            await _monitoDbContext.SaveChangesAsync();

            return petExsists;
        }

        public async Task<Pet?> DeleteAsync(int id)
        {
           var petExsists =await _monitoDbContext.Pets.FirstOrDefaultAsync(p => p.Id == id);
            if (petExsists == null) { 
             return null;
            }
            _monitoDbContext.Pets.Remove(petExsists);
           await _monitoDbContext.SaveChangesAsync();
            return petExsists;
        }
    }
}
