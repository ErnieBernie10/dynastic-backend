using System;
using System.Threading.Tasks;
using Dynastic.Domain.Common;
using Dynastic.Domain.Models;

namespace Dynastic.Architecture.Repositories
{
    public interface IRepository<T> where T : Base
    {
        Task<T> GetById(Guid id);
        Task<T> Create(T input);
        Task<T> Update(T input);
        Task<T> Delete(T input);
    }
}