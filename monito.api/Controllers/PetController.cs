﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monito.api.Data;
using monito.api.Domain.Model;
using monito.api.Domain.Model.DTO;
using monito.api.Repository;
using System.Drawing;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace monito.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
       
        private readonly IPetRepository _petRepository;
        private readonly IMapper mapper;

        public PetController( IPetRepository petRepository , IMapper mapper)
        {
           
            _petRepository = petRepository;
            this.mapper = mapper;
        }
        //get all pets
        //api/pets
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var petsDomain = await _petRepository.GetAllAsync();
            var petDto =  mapper.Map<List<PetDto>>(petsDomain);

            return Ok(petDto);
        }

        //get single pet
        //api/pet/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var petDomain = await _petRepository.GetByIdAsync(id);

            if (petDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PetDto>(petDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPetRequestDto addPetRequestDto)
        {
            var petDomainModel=mapper.Map<Pet>(addPetRequestDto);

            petDomainModel = await _petRepository.CreateAsync(petDomainModel);

            var petDto = mapper.Map<PetDto>(petDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = petDomainModel.Id }, petDto);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePetRequestDto updatePetRequestDto)
        {
            //map dto to domain model

            var petDomainModel = mapper.Map<Pet>(updatePetRequestDto);
            

            // check this id exsists

            petDomainModel = await _petRepository.UpdateAsync(id,petDomainModel);

            if (petDomainModel == null)
            {
                return NotFound();
            }

            
            //ConvertDomain Model to Dto
            var petDto = new PetDto
            {
                Name = petDomainModel.Name,
                Gender = petDomainModel.Gender,
                AgeInMonths = petDomainModel.AgeInMonths,
                Size = petDomainModel.Size,
                Color = petDomainModel.Color,
                Vaccinated = petDomainModel.Vaccinated,
                Dewormed = petDomainModel.Dewormed,
                Cert = petDomainModel.Cert,
                Microchip = petDomainModel.Microchip,
                Location = petDomainModel.Location,
                PublishedDate = petDomainModel.PublishedDate,
                AdditionalInfo = petDomainModel.AdditionalInfo,
                ImagePath = petDomainModel.ImagePath,
                OwnerId = petDomainModel.OwnerId,

            };

            return Ok(new
            {
                Message = "Pet Information Update Successfully",
                Data = petDto

            });

        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

           var deletePetData= await _petRepository.DeleteAsync(id);

            if (deletePetData == null) { 
                return NotFound();
            }

            //return the deleted region back
            var petDto = new PetDto
            {
                Name = deletePetData.Name,
                Gender = deletePetData.Gender,
                AgeInMonths = deletePetData.AgeInMonths,
                Size = deletePetData.Size,
                Color = deletePetData.Color,
                Vaccinated = deletePetData.Vaccinated,
                Dewormed = deletePetData.Dewormed,
                Cert = deletePetData.Cert,
                Microchip = deletePetData.Microchip,
                Location = deletePetData.Location,
                PublishedDate = deletePetData.PublishedDate,
                AdditionalInfo = deletePetData.AdditionalInfo,
                ImagePath = deletePetData.ImagePath,
                OwnerId = deletePetData.OwnerId,

            };

            return Ok(new {
                        Message="SucessFully Deleted",
                        Data=petDto
                           }
             );

        }
    }
}