using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SegundaOportunidad.Repository.Interfaces
{
    interface IBaseRepository<TEntity> 
    {
        Task Add(TEntity entity);
        Task <IEnumerable<TEntity>> GetAll();
    }
}
