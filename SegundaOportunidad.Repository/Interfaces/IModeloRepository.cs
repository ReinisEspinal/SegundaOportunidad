using SegundaOportunidad.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace SegundaOportunidad.Repository.Interfaces
{
    public interface IModeloRepository : IBaseRepository<Modelo>
    {
        Task AddModelo(Modelo oModelo);
        void UpdateModelo(Modelo oModelo);
        IEnumerable<Modelo> GetModelos();
        Task<Modelo> GetModeloById(int id);
        Task<bool> SaveModelo();
        Task<bool> ExisteModelo();
    }
}
