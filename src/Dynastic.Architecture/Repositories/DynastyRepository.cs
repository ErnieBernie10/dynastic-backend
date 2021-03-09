using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynastic.Architecture.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Dynastic.Architecture.Repositories
{
    public class DynastyRepository : IRepository<Dynasty>
    {
        private readonly DynasticContext DynasticContext;

        public DynastyRepository(DynasticContext DynasticContext)
        {
            this.DynasticContext = DynasticContext;
        }

        public Task<Dynasty> GetById(Guid id)
        {
            return DynasticContext.Set<Dynasty>().Where(d => d.Id.Equals(id)).FirstOrDefaultAsync();
        }


        public async Task<Dynasty> Create(Dynasty input)
        {
            var query = DynasticContext.Add(input);
            await DynasticContext.SaveChangesAsync();
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