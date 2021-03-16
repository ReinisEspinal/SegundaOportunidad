using SegundaOportunidad.Services.Result.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SegundaOportunidad.Services.Contracts
{
    public interface IMarcaService
    {
        ServiceResultMarca GetMarcas();
        Task<ServiceResultMarca> SaveMarca(Models.MarcaServicesModel omarca);
        Task<ServiceResultMarca> UpdateMarca(Models.MarcaServicesModel omarca);
        Task<ServiceResultMarca> DeleteMarca(Models.MarcaServicesModel omarca);
        Task<ServiceResultMarca> GetMarcaById(int Id);
    }
}
