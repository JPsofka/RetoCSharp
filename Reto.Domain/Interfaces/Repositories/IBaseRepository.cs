using Reto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T? FindById(int id);
        IEnumerable<T> GetAll();
        Task<T> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);

    }
}
