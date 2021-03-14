using System;
using System.Threading.Tasks;
using Dynastic.API.DTO;
using Dynastic.Application.Common;
using Dynastic.Architecture.Models;
using Dynastic.Architecture.Repositories;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dynastic.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DynastiesController : ControllerBase
    {
        private readonly DynastyRepository dynastyRepository;
        private readonly PersonRepository personRepository;
        public DynastiesController(DynastyRepository dynastyRepository, PersonRepository personRepository)
        {
            this.dynastyRepository = dynastyRepository;
            this.personRepository = personRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dynasty>> GetDynasty(string id)
        {
            return Ok(await dynastyRepository.GetById(new Guid(id)));
        }
        
        [HttpGet("{id}/Tree")]
        public async Task<ActionResult<Person>> GetTree(string id)
        {
            var person = await personRepository.GetPerson(new Guid(id));
            return Ok(new Tree(person));
        }

        [HttpPost()]
        public async Task<ActionResult<Dynasty>> PostDynasty(CreateDynastyDTO model)
        {
            var dynasty = await dynastyRepository.Create(model.Adapt<Dynasty>());
            return CreatedAtAction(nameof(GetDynasty), new { id = dynasty.Id }, dynasty);
        }
        
        [HttpPost("{id}/Members")]
        public async Task<ActionResult<Person>> PostPerson(string id, CreatePersonDTO model)
        {
            var person = await personRepository.Create(model.Adapt<Person>());
            var dynasty = await dynastyRepository.GetById(new Guid(id));
            var ageComparison = dynasty.Head.BirthDate.CompareTo(person.BirthDate);
            if (ageComparison > 0)
            {
                dynasty.Head = person;
            }
            await dynastyRepository.Update(dynasty);
            
            return CreatedAtAction(nameof(GetTree), new { id =  person.Id }, person);
        }
        
    }
}