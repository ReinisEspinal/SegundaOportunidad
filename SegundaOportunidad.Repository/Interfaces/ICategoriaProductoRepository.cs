using SegundaOportunidad.Domain.Entities;
using System.Collections.Generic;


namespace SegundaOportunidad.Repository.Interfaces
{
    public interface ICategoriaProductoRepository: IBaseRepository<CategoriaProducto>
    {
        IEnumerable<CategoriaProducto> GetCategorias();
    }
}
