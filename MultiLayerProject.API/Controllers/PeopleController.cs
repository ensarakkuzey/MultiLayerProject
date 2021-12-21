using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiLayerProject.API.DTOs;
using MultiLayerProject.Core.Models;
using MultiLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IService<Person> _personService;
        private readonly IMapper _mapper;

        public PeopleController(IService<Person> personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var people = await _personService.GetAllAsync();

            return Ok(people);
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDTO personDTO)
        {
            var newPerson = _mapper.Map<PersonDTO>(await _personService.AddAsync(_mapper.Map<Person>(personDTO)));

            return Created(String.Empty, newPerson);
        }

        [HttpPut]
        public IActionResult Update(PersonDTO personDTO)
        {
            var person = _personService.Update(_mapper.Map<Person>(personDTO));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var person = _personService.GetByIdAsync(id).Result;
            _personService.Remove(person);

            return NoContent();
        }
    }
}
