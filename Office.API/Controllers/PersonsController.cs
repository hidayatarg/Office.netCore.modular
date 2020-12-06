using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Office.Core.Models;
using Office.Core.Services;

namespace Office.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        // Generic Actions from Database
        private readonly IService<Person> _personService;

        public PersonsController(IService<Person> service)
        {
            _personService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsyn(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var personToSave = await _personService.AddAsync(person);
            return Ok(personToSave);
        }

        [HttpPut]
        public IActionResult Update(Person person)
        {
            var personToUpdate = _personService.Update(person);
            return Ok(personToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Update(int id)
        {
            var person = _personService.GetByIdAsyn(id).Result;
            _personService.Remove(person);
            return NoContent();
        }
    }
}
