using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SegundaOportunidad.Domain.Entities;
using SegundaOportunidad.Repository.Interfaces;
using SegundaOportunidad.Services.Contracts;
using SegundaOportunidad.Services.Models;
using SegundaOportunidad.Services.Result.Core;
using SegundaOportunidad.Services.Result.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaOportunidad.Services
{
    public class ModeloService : IModeloService
    {

        public readonly IModeloRepository _modeloRepository;
        public readonly IMarcaRepository _marcaRepository;
        private readonly ILogger<ModeloService> _logger;
        private readonly IConfiguration _configuration;
        public ModeloService(IModeloRepository modeloRep,
            IMarcaRepository marcaRepository, 
            ILogger<ModeloService> logger, 
            IConfiguration configuration)
        {
            _modeloRepository = modeloRep;
            _logger = logger;
            _marcaRepository = marcaRepository;
            _configuration = configuration;
        }
        public async Task<ServiceResultModelo> GetModeloById(int id)
        {
            var result = new ServiceResultModelo();

            try
            {
                var oModelo = await _modeloRepository.GetModeloById(id);
               
                result.Data = new ResultModeloServiceModel()
                {
                    Modelo_Id = oModelo.Modelo_Id,
                    Nombre= oModelo.Nombre


                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                result.success = false;
                result.message = "Error obteniendo la Modelo";
            }

            return result;
        }
        public ServiceResultModelo GetModelos()
        {
            ServiceResultModelo result = new ServiceResultModelo();

            try
            {
                var modelos = _modeloRepository.FindAll(modelo => !modelo.Deleted);
                var mars = _marcaRepository.FindAll(marca => !marca.Deleted);

                var query = (from modelo in _modeloRepository.GetModelos()
                             join marca in _marcaRepository.GetMarcas() 
                             on modelo.Marca_ID equals marca.Marca_Id
                             select new ResultModeloServiceModel
                             {
                                 Modelo_Id = modelo.Modelo_Id,
                                 Nombre = modelo.Nombre,
                                 Marca_Id = modelo.Marca_ID,
                                 NombreMarca = marca.Nombre
                                 
                             }).ToList();

                result.Data = query;

                result.success = true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error {e.Message}");
                result.success = false;
                result.message = "Error obteniendo los modelos";
            }
            return result;
        }
        public async Task<ServiceResultModelo> SaveModelo(ModeloServicesModel oModelo)
        {
            ServiceResultModelo result = new ServiceResultModelo();
            try
            {
                if (await ValidateModelo(oModelo.Nombre))
                {
                    result.success = false;
                    result.message = $"Esta Modelo: {oModelo.Nombre} ya esta registrado";
                    return result;
                }

                Modelo newModelo = new Modelo()
                {
                    Nombre = oModelo.Nombre
                };
                await _modeloRepository.Add(newModelo);
                result.message = await _modeloRepository.SaveModelo() ? "Modelo Agregada" : "Error agregando la Modelo";

                oModelo.Modelo_Id = newModelo.Modelo_Id;

                result.Data = oModelo;
            }
            catch (Exception e) { _logger.LogError($"Error: {e.Message}"); result.success = false; result.message = "Error agregando la informacion de la Modelo"; }

            return result.Data;
        }
        public async Task<ServiceResultModelo> UpdateModelo(ModeloServicesModel oModelo)
        {
            ServiceResultModelo result = new ServiceResultModelo();
            try
            {
                var ModeloUpdate = await _modeloRepository.GetModeloById(oModelo.Modelo_Id);

                ModeloUpdate.Nombre = oModelo.Nombre;

                _modeloRepository.UpdateModelo(ModeloUpdate);

                await _modeloRepository.SaveModelo();

                result.message = await _modeloRepository.SaveModelo() ? "Modelo editada" : "Error editando la Modelo";
                result.Data = oModelo;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error {e.Message}");

                result.success = false;
                result.message = "Error editando la Modelo";
            }

            return result.Data;
        }
        public async Task<ServiceResultModelo> DeleteModelo(ModeloServicesModel oModelo)
        {
            ServiceResultModelo result = new ServiceResultModelo();
            try
            {

                var ModeloDelete = await _modeloRepository.GetModeloById(oModelo.Modelo_Id);
                ModeloDelete.Modelo_Id = oModelo.Modelo_Id;
                ModeloDelete.Deleted = true;

                _modeloRepository.UpdateModelo(ModeloDelete);

                await _modeloRepository.SaveModelo();
                result.message = await _modeloRepository.SaveModelo() ? "Modelo eliminada" : "Error eliminando la Modelo";
                result.Data = oModelo;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error{e.Message}");
                result.success = false;
                result.message = "Error en la eliminacion de la Modelo";
            }

            return result;
        }
        private async Task<bool> ValidateModelo(string nombre)
        {
            return await _modeloRepository.Exists(cd => cd.Nombre == nombre);
        }
    }
}
