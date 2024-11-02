using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using monito.api.Domain.Model;
using monito.api.Domain.Model.DTO;
using monito.api.Repository.Contracts;

namespace monito.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductController(IMapper mapper , IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProductRequestDto addProductRequestDto)
        {

            var productDomainmodel = _mapper.Map<Product>(addProductRequestDto);
             productDomainmodel = await _productRepository.CreateAsync(productDomainmodel);
            var productDto = _mapper.Map<ProductDto>(productDomainmodel);
            return Created("", 
                new { 
                    Message="Created Product Successfully",
                    Data = productDto });
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
        
           var poductListDomain= await _productRepository.GetAllAsync();
            var productListDto = _mapper.Map<List<ProductDto>>(poductListDomain);
            return Ok(productListDto);
            

        }


    }
}
