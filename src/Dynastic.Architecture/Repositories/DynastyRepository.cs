using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynastic.Domain.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Dynastic.Architecture.Repositories
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
            return dynasticContext.Set<Dynasty>()
                .Where(d => d.Id.Equals(id))
                .Include(d => d.Members)
                .ThenInclude(m => m.Relationships)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Dynasty>> GetUserDynasties(string id)
        {
            return await dynasticContext.Set<UserDynasties>().Where(d => d.Id.Equals(id)).Include(d => d.Dynasty)
                .Select(d => d.Dynasty).ToListAsync();
        }
        
        public async Task<Dynasty> Create(Dynasty input)
        {
            var query = dynasticContext.Add(input);
            await dynasticContext.SaveChangesAsync();
            return query.Entity;
        }

        public async Task<Dynasty> Create(string userId, Dynasty input)
        {
            var query = dynasticContext.Add(new UserDynasties() { Dynasty = input, Id = userId});
            await dynasticContext.SaveChangesAsync();
            return query.Entity.Dynasty;
        }

        public async Task<Dynasty> Update(Dynasty input)
        {
            var query = dynasticContext.Update(input);
            await dynasticContext.SaveChangesAsync();
            return query.Entity;
        }

        public Task<Dynasty> Delete(Dynasty input)
        {
            throw new NotImplementedException();
        }
    }
}