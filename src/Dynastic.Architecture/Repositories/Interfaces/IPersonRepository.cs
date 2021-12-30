using Dynastic.Domain;
using Dynastic.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Dynastic.Architecture.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Relationship> AddRelationship(Guid personId, Guid partnerId);
        Task<Person> Create(Person input);
        Task<Person> Delete(Person input);
        Task<Person> GetById(Guid id);
        Task<Person> Update(Person input);
    }
}