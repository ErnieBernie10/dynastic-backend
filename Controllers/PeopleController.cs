using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynastic.DTO;
using Dynastic.Models;
using Dynastic.Repositories;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dynastic.Controllers
{
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

        [HttpPost()]
        public async Task<ActionResult<Person>> PostPerson(CreatePersonDTO model)
        {
            var person = await personRepository.Create(model.Adapt<Person>());
            return CreatedAtAction(nameof(GetPerson), new { id =  person.Id }, person);
        }

        [HttpPost("{id}/relationships")]
        public async Task<ActionResult<Relationship>> PostRelationsship(string id, CreateRelationshipDTO model)
        {
            var relationship = await personRepository.AddRelationship(new Guid(id), new Guid(model.Person));
            return CreatedAtAction(nameof(GetPerson), new { id = relationship.Person.Id }, relationship);
        } 
        
        [HttpGet("{id}/Tree")]
        public async Task<ActionResult<Person>> GetTree(string id)
        {
            var tree = await personRepository.GetTree(new Guid(id));
            return Ok(tree);
        }
    }
}