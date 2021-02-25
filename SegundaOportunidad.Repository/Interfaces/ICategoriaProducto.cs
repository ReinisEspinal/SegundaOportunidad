using SegundaOportunidad.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SegundaOportunidad.Repository.Interfaces
{
    public interface ICategoriaProducto
    {
        Task <IEnumerable<CategoriaProducto>>GetAllCategories();
    }
}
