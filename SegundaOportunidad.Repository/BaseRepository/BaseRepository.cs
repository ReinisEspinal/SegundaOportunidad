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

        public virtual async Task Add(TEntity entity)
        {
            await _entity.AddAsync(entity);
        }
        public virtual async Task Add(params TEntity[] entities)
        {
            await _entity.AddRangeAsync(entities);

        }
        public virtual void Update(TEntity entity)
        {
            _entity.Update(entity);
        }
        public virtual void Remove(TEntity entity)
        {
            _entity.Remove(entity);
        }
        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return await _entity.SingleOrDefaultAsync(filter);
        }
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return _entity.Where(filter);
        }
        public async Task<TEntity> GetById(int value)
        {
            return await _entity.FindAsync(value);
        }
        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await _entity.AnyAsync(filter);
        }
        public virtual async Task<bool> Commit()
        {
            return await context.SaveChangesAsync() > 0;
        }
        public Task<bool> RollBack()
        {
            throw new NotImplementedException();
        }
    }
}
