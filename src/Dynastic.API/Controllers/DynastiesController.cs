using System;
using System.Linq;
using System.Security.Claims;
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
            var dynasty = await dynastyRepository.GetById(new Guid(id));
            if (dynasty is null)
            {
                return NotFound();
            }
            return Ok(dynasty.ToTree().NestedTree);
        }

        [HttpGet()]
        public async Task<ActionResult<Dynasty>> GetDynastiesForUser()
        {
            var userId = User.Identity?.Name;
            var dynasties = await dynastyRepository.GetUserDynasties(userId);
            return Ok(dynasties);
        }

        [HttpPost()]
        public async Task<ActionResult<Dynasty>> PostDynasty(CreateDynastyDTO model)
        {
            var dynasty = await dynastyRepository.Create(User.Identity?.Name, model.Adapt<Dynasty>());
            return CreatedAtAction(nameof(GetDynasty), new { id = dynasty.Id }, dynasty);
        }
        
        [HttpPost("{id}/Members")]
        public async Task<ActionResult<Person>> PostPerson(string id, CreatePersonDTO model)
        {
            Guid? motherId = string.IsNullOrEmpty(model.MotherId) ? null : new Guid(model.MotherId);
            Guid? fatherId = string.IsNullOrEmpty(model.FatherId) ? null : new Guid(model.FatherId);
            var person = await personRepository.Create(new Person()
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Middlename = model.Middlename,
                BirthDate = model.BirthDate,
                MotherId = motherId,
                FatherId = fatherId
            });
            if (motherId is not null && fatherId is not null)
            {
                await personRepository.AddRelationship(motherId.Value, fatherId.Value);
            }
            var dynasty = await dynastyRepository.GetById(new Guid(id));
            dynasty.Members.Add(person);
            await dynastyRepository.Update(dynasty);
            
            return CreatedAtAction(nameof(GetTree), new { id =  person.Id }, person);
        }
        
    }
}