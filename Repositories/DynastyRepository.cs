using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynastic.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Dynastic.Repositories
{
    public class DynastyRepository : IRepository<Dynasty>
    {
        private readonly DynasticContext dynasticContext;

        public DynastyRepository(DynasticContext dynasticContext)
        {
            this.dynasticContext = dynasticContext;
        }

        public Task<Dynasty> GetById(Guid id)
        {
            return dynasticContext.Set<Dynasty>().Where(d => d.Id.Equals(id)).FirstOrDefaultAsync();
        }


        public async Task<Dynasty> Create(Dynasty input)
        {
            var query = dynasticContext.Add(input);
            await dynasticContext.SaveChangesAsync();
            return query.Entity;
        }

        public Task<Dynasty> Update(Dynasty input)
        {
            throw new NotImplementedException();
        }

        public Task<Dynasty> Delete(Dynasty input)
        {
            throw new NotImplementedException();
        }
    }
}