using SegundaOportunidad.Services.Contracts;
using SegundaOportunidad.Services.Result.Models;
using SegundaOportunidad.Services.Models;
using SegundaOportunidad.Services.Result.Core;
using SegundaOportunidad.Repository.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using SegundaOportunidad.Domain.Entities;

namespace SegundaOportunidad.Services
{
    public class MarcaService : IMarcaService
    {
        public readonly IMarcaRepository _MarcaRep;
        private readonly ILogger<MarcaService> _logger;
        public MarcaService(IMarcaRepository MarcaRep, ILogger<MarcaService> logger)
        {
            _MarcaRep = MarcaRep;
            _logger = logger;
        }
        public async Task<ServiceResultMarca> GetMarcaById(int id)
        {
            var result = new ServiceResultMarca();

            try
            {
                var oMarca = await _MarcaRep.GetMarcaById(id);

                result.Data = new ResultMarcaServiceModel()
                {
                    Marca_Id = oMarca.Marca_Id,
                    Nombre = oMarca.Nombre


                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                result.success = false;
                result.message = "Error obteniendo la Marca";
            }

            return result;
        }
        public ServiceResultMarca GetMarcas()
        {
            ServiceResultMarca result = new ServiceResultMarca();

            try
            {
                result.Data = _MarcaRep.FindAll(d => !d.Deleted).Select(d => new ResultMarcaServiceModel()
                {
                    Marca_Id = d.Marca_Id,
                    Nombre = d.Nombre

                }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error {e.Message}");
                result.success = false;
                result.message = "Error obteniendo las marcas";
            }
            return result;
        }
        public async Task<ServiceResultMarca> SaveMarca(MarcaServicesModel oMarca)
        {
            ServiceResultMarca result = new ServiceResultMarca();
            try
            {
                if (await ValidateMarca(oMarca.Nombre))
                {
                    result.success = false;
                    result.message = $"Esta Marca: {oMarca.Nombre} ya esta registrado";
                    return result;
                }

                Marca newMarca = new Marca()
                {
                    Nombre = oMarca.Nombre
                };
                await _MarcaRep.Add(newMarca);
                result.message = await _MarcaRep.SaveMarca() ? "Marca Agregada" : "Error agregando la Marca";

                oMarca.Marca_Id = newMarca.Marca_Id;

                result.Data = oMarca;
            }
            catch (Exception e) { _logger.LogError($"Error: {e.Message}"); result.success = false; result.message = "Error agregando la informacion de la Marca"; }

            return result.Data;
        }
        public async Task<ServiceResultMarca> UpdateMarca(MarcaServicesModel oMarca)
        {
            ServiceResultMarca result = new ServiceResultMarca();
            try
            {
                var MarcaUpdate = await _MarcaRep.GetMarcaById(oMarca.Marca_Id);

                MarcaUpdate.Nombre = oMarca.Nombre;

                _MarcaRep.UpdateMarca(MarcaUpdate);

                await _MarcaRep.SaveMarca();

                result.message = await _MarcaRep.SaveMarca() ? "Marca editada" : "Error editando la Marca";
                result.Data = oMarca;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error {e.Message}");

                result.success = false;
                result.message = "Error editando la Marca";
            }

            return result.Data;
        }
        public async Task<ServiceResultMarca> DeleteMarca(MarcaServicesModel oMarca)
        {
            ServiceResultMarca result = new ServiceResultMarca();
            try
            {

                var MarcaDelete = await _MarcaRep.GetMarcaById(oMarca.Marca_Id);
                MarcaDelete.Marca_Id = oMarca.Marca_Id;
                MarcaDelete.Deleted = true;

                _MarcaRep.UpdateMarca(MarcaDelete);

                await _MarcaRep.SaveMarca();
                result.message = await _MarcaRep.SaveMarca() ? "Marca eliminada" : "Error eliminando la Marca";
                result.Data = oMarca;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error{e.Message}");
                result.success = false;
                result.message = "Error en la eliminacion de la Marca";
            }

            return result;
        }
        private async Task<bool> ValidateMarca(string nombre)
        {
            return await _MarcaRep.Exists(cd => cd.Nombre == nombre);
        }
    }
}
