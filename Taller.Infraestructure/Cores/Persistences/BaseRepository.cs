using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Cores.Models;
using Taller.Domain.Cores.Repositories;
using Taller.Infraestructure.Cores.Context;

namespace Taller.Infraestructure.Cores.Persistences
{
    public abstract class BaseRepository<T, ID> : IBaseRepository<T, ID> where T : CoreModel<ID>
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _dbSet;
        protected BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual async Task<T?> DisabledByIdAsync(ID id)
        {
            T? entity = await _dbSet.FindAsync(id);

            if (entity is null) throw new Exception("No se encontro informacion para el id: " + id);

            entity.State = false;
            _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync();


            return entity;
        }

        public async Task<IReadOnlyList<T>> FindAllAsync()
        {
            return await _dbSet
                .Where(x => x.State == true)
                .ToListAsync();
        }

        public Task<T?> FindByIdAsync(ID id)
        {
            throw new NotImplementedException();
        }

        public Task<T> SaveAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
