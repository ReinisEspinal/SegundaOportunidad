using SegundaOportunidad.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SegundaOportunidad.Domain;
using SegundaOportunidad.Domain.BaseEntity;
using System.Threading.Tasks;

namespace SegundaOportunidad.Repository.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntities
    {
        public Task Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
