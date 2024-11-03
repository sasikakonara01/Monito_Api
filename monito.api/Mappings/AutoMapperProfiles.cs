using AutoMapper;
using monito.api.Domain.Model;
using monito.api.Domain.Model.DTO;

namespace monito.api.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Pet,PetDto>().ReverseMap();
            CreateMap<Pet,AddPetRequestDto>().ReverseMap();
            CreateMap<Pet, UpdatePetRequestDto>().ReverseMap();

            CreateMap<Product, AddProductRequestDto>().ReverseMap();
            CreateMap<ProductDto,Product>().ReverseMap();
            CreateMap<Product,UpdateProductRequestDto>().ReverseMap();

        }
    }
}
