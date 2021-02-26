using SegundaOportunidad.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegundaOportunidad.Repository.Interfaces
{
    public interface ICategoriaProductoRepository: IBaseRepository<CategoriaProducto>
    {
       Task<CategoriaProducto> GetCategoriaByID(int id);
    }
}
