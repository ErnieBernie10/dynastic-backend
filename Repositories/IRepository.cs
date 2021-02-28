using System;
using System.Threading.Tasks;
using Dynastic.Models;

namespace Dynastic.Repositories
{
    public interface IRepository<T> where T : Base
    {
        Task<T> GetById(Guid id);
        Task<T> Create(T input);
        Task<T> Update(T input);
        Task<T> Delete(T input);
    }
}