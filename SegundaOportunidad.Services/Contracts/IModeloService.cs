using System;
using System.Collections.Generic;
using System.Text;
using SegundaOportunidad.Services.Result.Models;
using System.Threading.Tasks;
using SegundaOportunidad.Services.Result.Core;

namespace SegundaOportunidad.Services.Contracts
{
    public interface IModeloService
    {
        ServiceResultModelo GetModelos();
        Task <ServiceResultModelo> SaveModelo(Models.ModeloServicesModel oModelo);
        Task<ServiceResultModelo> UpdateModelo(Models.ModeloServicesModel oModelo);
        Task<ServiceResultModelo> DeleteModelo(Models.ModeloServicesModel oModelo);
        Task<ServiceResultModelo> GetModeloById(int Id);

    }
}
