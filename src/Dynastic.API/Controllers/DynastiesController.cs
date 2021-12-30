using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dynastic.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dynastic.Application.Dynasties.Queries;
using Dynastic.Application.Dynasties.Commands;

namespace Dynastic.API.Controllers
{
    [Authorize]
    public class DynastiesController : ApiControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<Dynasty>> GetDynasty(string id)
        {
            return Ok(await Mediator.Send(new GetDynastyByIdQuery() {  Id = id }));
        }
        
        [HttpGet("{id}/Tree")]
        public async Task<ActionResult<Person>> GetTree(string id)
        {
            //var dynasty = await dynastyRepository.GetById(new Guid(id));
            //if (dynasty is null)
            //{
            //    return NotFound();
            //}
            //return Ok(dynasty.ToTree().NestedTree);
            throw new NotImplementedException();
        }
        
        [HttpGet("{id}/FlatTree")]
        public async Task<ActionResult<Person>> GetFlatTree(string id)
        {
            //var dynasty = await dynastyRepository.GetById(new Guid(id));
            //if (dynasty is null)
            //{
            //    return NotFound();
            //}

            //var tree = dynasty.ToTree();


            //return Ok(tree.Adapt<FlatTreeDTO>());
            throw new NotImplementedException();
        }

        [HttpGet()]
        public async Task<ActionResult<IList<Dynasty>>> GetDynastiesForUser()
        {
            return Ok(await Mediator.Send(new GetDynastiesForUserQuery()));
        }

        [HttpPost()]
        public async Task<ActionResult<Dynasty>> PostDynasty(CreateDynastyCommand model)
        {
            var id = await Mediator.Send(model);
            return CreatedAtAction(nameof(GetDynasty), new { id });
        }
        
        [HttpPost("{id}/Members")]
        public async Task<ActionResult<Person>> PostPerson(string id, CreateMemberCommand model)
        {
            var guid = await Mediator.Send(model);
            return CreatedAtAction(nameof(GetTree), new { id });
        }
        
    }
}