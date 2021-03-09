using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynastic.API.DTO;
using Dynastic.Application.Common;
using Dynastic.Architecture.Models;
using Dynastic.Architecture.Repositories;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dynastic.API.Controllers
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

        [HttpPost("{id}/Relationships")]
        public async Task<ActionResult<Relationship>> PostRelationship(string id, CreateRelationshipDTO model)
        {
            var relationship = await personRepository.AddRelationship(new Guid(id), new Guid(model.Person));
            return CreatedAtAction(nameof(GetPerson), new { id = relationship.Person.Id }, relationship);
        } 
        
        [HttpGet("{id}/Tree")]
        public async Task<ActionResult<Person>> GetTree(string id)
        {
            var person = await personRepository.GetPerson(new Guid(id));
            return Ok(new Tree(person));
        }
    }
}