using System;
using System.Threading.Tasks;
using Dynastic.API.DTO;
using Dynastic.Domain.Models;
using Dynastic.Architecture.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dynastic.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonRepository personRepository;

        public PeopleController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(string id)
        {
            return Ok(await personRepository.GetById(new Guid(id))); 
        }

        [HttpPost("{id}/Relationships")]
        public async Task<ActionResult<Relationship>> PostRelationship(string id, CreateRelationshipDTO model)
        {
            var relationship = await personRepository.AddRelationship(new Guid(id), new Guid(model.Person));
            return CreatedAtAction(nameof(GetPerson), new { id = relationship.Person.Id }, relationship);
        } 
        
    }
}