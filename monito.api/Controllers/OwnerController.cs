using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using monito.api.CustomActionFilters;
using monito.api.Domain.Model;
using monito.api.Domain.Model.DTO;
using monito.api.Repository.Contracts;

namespace monito.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IMapper mapper, IOwnerRepository ownerRepository)
        {
            _mapper = mapper;
            _ownerRepository = ownerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var OwnerListDomain = await _ownerRepository.GetAllAsync();
            if (OwnerListDomain == null)
            {
                return NotFound();

            }
            var OwnerListDto = _mapper.Map<List<OwnerDto>>(OwnerListDomain);
            return Ok(OwnerListDto);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var OwnerDomain = await _ownerRepository.GetByIdAsync(id);
            if (OwnerDomain == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OwnerDto>(OwnerDomain));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create(AddOwnerRequestDto addOwnerRequestDto)
        {
                var OwnerDomain = _mapper.Map<Owner>(addOwnerRequestDto);
                OwnerDomain = await _ownerRepository.CreateAsync(OwnerDomain);

                if (OwnerDomain == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<OwnerDto>(OwnerDomain));
           
        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOwnerRequestDto updateOwnerRequestDto)
        {
           
                var OwnerDomain = _mapper.Map<Owner>(updateOwnerRequestDto);
                OwnerDomain = await _ownerRepository.UpdateAsync(id, OwnerDomain);
                if (OwnerDomain == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<OwnerDto>(OwnerDomain));
            
           
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var OwnerDomain = await _ownerRepository.DeleteAsync(id);
            if (OwnerDomain == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OwnerDto>(OwnerDomain));

        }
    }
}
