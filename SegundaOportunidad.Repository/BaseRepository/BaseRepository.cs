using Microsoft.EntityFrameworkCore;
using SegundaOportunidad.Domain.BaseEntities;
using SegundaOportunidad.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SegundaOportunidad.Repository.BaseRepository
{
    public class BaseRepository<TEntity> : IUnitOfWrok, IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext context;
        private DbSet<TEntity> _entity;

        public BaseRepository(Context.SegundaOportunidadContext segundaOportunidadContext)
        {
            this.context = segundaOportunidadContext;
            this._entity = context.Set<TEntity>();
        }

      
        public Task Add(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public virtual async Task Add(TEntity entity)
        {
            await context.AddAsync(entity);
        }

        public async Task<bool> Commit()
        {
            return await context.SaveChangesAsync()>0;

        }

        public Task<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetById(int value)
        {
            return await _entity.FindAsync(value);
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RollBack()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
