using System;
using System.Threading.Tasks;
using Dynastic.API.DTO;
using Dynastic.Application.Persons.Queries;
using Dynastic.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dynastic.API.Controllers
{
    [Authorize]
    public class PeopleController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(string id)
        {
            return Ok(await Mediator.Send(new GetPersonByIdQuery() { Id = id })); 
        }

        [HttpPost("{id}/Relationships")]
        public async Task<ActionResult<Relationship>> PostRelationship(string id, CreateRelationshipDTO model)
        {
            //var relationship = await personRepository.AddRelationship(new Guid(id), new Guid(model.Person));
            //return CreatedAtAction(nameof(GetPerson), new { id = relationship.Person.Id }, relationship);
            throw new NotImplementedException();
        } 
        
    }
}