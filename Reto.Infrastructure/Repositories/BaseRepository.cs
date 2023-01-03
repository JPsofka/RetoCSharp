using Microsoft.EntityFrameworkCore;
using Reto.Domain.Interfaces.Repositories;
using Reto.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public AppDbContext AppDbContext { get; set; }
        protected BaseRepository(AppDbContext appDbContext) 
        {
            AppDbContext = appDbContext;
        }

        public IQueryable<T> GetAll()
        {
            return AppDbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return AppDbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Add(T entity)
        {
            AppDbContext.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            AppDbContext.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            AppDbContext.Set<T>().Update(entity);
        }
    }
}
