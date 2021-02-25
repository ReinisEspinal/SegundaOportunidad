using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SegundaOportunidad.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int value);
        Task<TEntity> Find(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
        Task Add(TEntity entity);
        Task Add(params TEntity[] entities);
        void Remove(TEntity entity);

        void Update(TEntity entity);

    }
}
