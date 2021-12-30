using Dynastic.Domain;
using Dynastic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dynastic.Architecture.Repositories
{
    public interface IDynastyRepository : IRepository<Dynasty>
    {
        Task<Dynasty> Create(Dynasty input);
        Task<Dynasty> Create(string userId, Dynasty input);
        Task<Dynasty> Delete(Dynasty input);
        Task<Dynasty> GetById(Guid id);
        Task<List<Dynasty>> GetUserDynasties(string id);
        Task<Dynasty> Update(Dynasty input);
    }
}