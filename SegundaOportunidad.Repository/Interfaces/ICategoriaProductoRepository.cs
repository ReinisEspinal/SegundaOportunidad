using SegundaOportunidad.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegundaOportunidad.Repository.Interfaces
{
    public interface ICategoriaProductoRepository : IBaseRepository<CategoriaProducto>
    {
        Task AddCategoria(CategoriaProducto c);
        void UpdateCategoria(CategoriaProducto c);
        void RemoveCategoria(CategoriaProducto c);
        IEnumerable<CategoriaProducto> GetCategorias();
        Task<CategoriaProducto> GetCategoriaByID(int id);
        Task<bool> ExisteCategoria();
        Task SaveCategoria();
    }
}
