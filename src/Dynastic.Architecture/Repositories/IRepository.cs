using System;
using System.Threading.Tasks;
using Dynastic.Application.Common;
using Dynastic.Architecture.Models;

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