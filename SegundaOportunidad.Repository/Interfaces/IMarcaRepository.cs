using System.Threading.Tasks;
using SegundaOportunidad.Domain.Entities;
using System.Collections.Generic;

namespace SegundaOportunidad.Repository.Interfaces
{
   public interface IMarcaRepository : IBaseRepository<Marca>
    {
        Task AddMarca(Marca oMarca);
        void UpdateMarca(Marca oMarca);
        IEnumerable<Marca> GetMarcas();
        Task<Marca> GetMarcaById(int id);
        Task<bool> SaveMarca();
        Task<bool> ExisteMarca();
    }
}
