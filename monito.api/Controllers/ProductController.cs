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

        public ProductController(IMapper mapper, IProductRepository productRepository)
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
                    Message = "Created Product Successfully",
                    Data = productDto });

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var poductListDomain = await _productRepository.GetAllAsync();
            var productListDto = _mapper.Map<List<ProductDto>>(poductListDomain);
            return Ok(productListDto);


        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id) 
        {
           var productDomain= await _productRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(productDomain));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id , [FromBody] UpdateProductRequestDto updateProductRequestDto) 
        {
           var productDomain = _mapper.Map<Product>(updateProductRequestDto);
            productDomain= await _productRepository.UpdateAsync(id, productDomain);
            if (productDomain == null)
            { 
            return NotFound();
            }
            // convert domain model to dto
            var productDto = _mapper.Map<ProductDto>(productDomain);
            return Ok(productDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var deleteProduct = await _productRepository.DeleteAsync(id);
            if (deleteProduct == null)
            {
                return NotFound();
            }
            var deleteProductDto = _mapper.Map<ProductDto>(deleteProduct);

            return Ok(
                new
                {
                    Message = "Deleted SuccessFully",
                    Data = deleteProductDto
                });
        
        }
    }
}
