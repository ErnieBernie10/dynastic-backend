using System;
using System.Linq;
using System.Threading.Tasks;
using Dynastic.DTO;
using Dynastic.Models;
using Microsoft.EntityFrameworkCore;

namespace Dynastic.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly DynasticContext context;

        public PersonRepository(DynasticContext context)
        {
            this.context = context;
        }

        public async Task<Person> Create(Person input)
        {
            var added = this.context.Add(input);
            await context.SaveChangesAsync();
            return added.Entity;
        }

        public Task<Person> Delete(Person input)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetById(Guid id)
        {
            return context.Set<Person>().Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Person> GetTree(Guid id)
        {
            // TODO: Optimize
            var head = await context.Set<Person>()
                .Where(p => p.Id.Equals(id))
                .Include(p => p.FathersChildren)
                .ThenInclude(p => p.MothersChildren)
                .Include(p => p.FathersChildren)
                .ThenInclude(p => p.FathersChildren)
                .Include(p => p.MothersChildren)
                .ThenInclude(p => p.FathersChildren)
                .Include(p => p.MothersChildren)
                .ThenInclude(p => p.MothersChildren)
                .FirstOrDefaultAsync();
            return head;
        }
    public Task<Person> Update(Person input)
    {
        throw new NotImplementedException();
    }
}
}