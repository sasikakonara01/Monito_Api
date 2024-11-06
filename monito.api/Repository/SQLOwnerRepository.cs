using Microsoft.EntityFrameworkCore;
using monito.api.Data;
using monito.api.Domain.Model;
using monito.api.Repository.Contracts;

namespace monito.api.Repository
{
    public class SQLOwnerRepository : IOwnerRepository
    {
        private readonly MonitoDbContext _monitoDbContext;

        public SQLOwnerRepository(MonitoDbContext monitoDbContext)
        {
            _monitoDbContext = monitoDbContext;
        }

        public async Task<Owner> CreateAsync(Owner owner)
        {
         await _monitoDbContext.Owners.AddAsync(owner);
         await _monitoDbContext.SaveChangesAsync();

            return owner;
        }

        public async Task<Owner?> DeleteAsync(int id)
        {
         var OwnerExsists =  await _monitoDbContext.Owners.FirstOrDefaultAsync(x=>x.Id == id);
            if (OwnerExsists == null)
            {
                return null;
            }
            _monitoDbContext.Owners.Remove(OwnerExsists);
           await _monitoDbContext.SaveChangesAsync();
            return OwnerExsists;
        }

        public async Task<List<Owner>> GetAllAsync()
        {
         var OwnerList= await _monitoDbContext.Owners.ToListAsync();
            return OwnerList;
        }

        public async Task<Owner?> GetByIdAsync(int id)
        {
          var OwnerExsists = await _monitoDbContext.Owners.FirstOrDefaultAsync(x=>x.Id==id);
            if (OwnerExsists == null)
            {
                return null;
            }
            return OwnerExsists;
        }

        public async Task<Owner?> UpdateAsync(int id, Owner owner)
        {
            var OwnerExsists =  await _monitoDbContext.Owners.FirstOrDefaultAsync(x => x.Id == id);
                
                if (OwnerExsists == null) { 
                 return null;
                }
                OwnerExsists.Name = owner.Name;
                OwnerExsists.Email = owner.Email;
                OwnerExsists.PhoneNumber = owner.PhoneNumber;
                await _monitoDbContext.SaveChangesAsync();
            return OwnerExsists;
                
            
        }


    }
}
