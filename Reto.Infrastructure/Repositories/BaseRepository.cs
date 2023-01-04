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
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public AppDbContext AppDbContext { get; set; }
        protected BaseRepository(AppDbContext appDbContext) 
        {
            AppDbContext = appDbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return AppDbContext.Set<T>().ToList();
        }
        public T? FindById(int id)
        {
            return AppDbContext.Set<T>().Find(id);
        }
        public T Add(T entity)
        {
            AppDbContext.Set<T>().Add(entity);
            AppDbContext.SaveChanges();
            return entity;
        }
        public async Task<bool> Delete(T entity)
        {
            if(entity== null)
            {
                return false;
            }
            AppDbContext.Set<T>().Remove(entity);
            await AppDbContext.SaveChangesAsync();
            return true;

        }
        public async Task<bool> Update(T entity)
        {
            AppDbContext.Set<T>().Update(entity);
            await AppDbContext.SaveChangesAsync();
            return true;
        }
    }
}
