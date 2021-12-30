using System;
using System.Linq;
using System.Threading.Tasks;
using Dynastic.Domain;
using Dynastic.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dynastic.Architecture.Repositories
{
    public class PersonRepository : IPersonRepository
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

        public async Task<Relationship> AddRelationship(Guid personId, Guid partnerId)
        {
            // TODO : Optimize
            var person = await context.Set<Person>().Where(p => p.Id.Equals(personId)).Include(p => p.Relationships).FirstOrDefaultAsync();
            var partner = await context.Set<Person>().Where(p => p.Id.Equals(partnerId)).Include(p => p.Relationships).FirstOrDefaultAsync();
            var rel = new Relationship() { PersonId = person.Id, PartnerId = partner.Id };
            person.Relationships.Add(rel);
            partner.Relationships.Add(new Relationship() { PersonId = partner.Id, PartnerId = person.Id });
            context.Update(person);
            context.Update(partner);
            await context.SaveChangesAsync();
            return rel;
        }

        public Task<Person> Update(Person input)
        {
            throw new NotImplementedException();
        }
    }
}