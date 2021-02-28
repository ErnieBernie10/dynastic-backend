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
    public class DynastiesController : ControllerBase
    {
        private readonly DynastyRepository repository;
        public DynastiesController(DynastyRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dynasty>> GetDynasty(string id)
        {
            return Ok(await repository.GetById(new Guid(id)));
        }

        [HttpPost()]
        public async Task<ActionResult<Dynasty>> PostDynasty(CreateDynastyDTO model)
        {
            var dynasty = await repository.Create(model.Adapt<Dynasty>());
            return CreatedAtAction(nameof(GetDynasty), new { id = dynasty.Id }, dynasty);
        }
        
    }
}