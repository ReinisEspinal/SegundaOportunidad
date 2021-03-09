using SegundaOportunidad.Services.Contracts;
using SegundaOportunidad.Services.Result.Models;
using SegundaOportunidad.Services.Models;
using SegundaOportunidad.Services.Result.Core;
using SegundaOportunidad.Repository.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace SegundaOportunidad.Services
{
    public class CategoriaProductoService : ICategoriaProductoService
    {
        public readonly ICategoriaProductoRepository _categoriaProductoRep;
        private readonly ILogger<CategoriaProductoService> _logger;
        public CategoriaProductoService(ICategoriaProductoRepository categoriaProductoRep, ILogger<CategoriaProductoService> logger)
        {
            _categoriaProductoRep = categoriaProductoRep;
            _logger = logger;
        }

        public async Task<ResultCategoriaProducto> GetCategoriaById(int id)
        {
            var result = new ResultCategoriaProducto();

            try
            {
                var oCategoria = await _categoriaProductoRep.GetCategoriaByID(id);
                result.Data = new ResultCategoriaProductoModel()
                {
                    Nombre = oCategoria.Nombre
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                result.success = false;
                result.message = "Error obteniendo la categoria";
            }

            return result.Data;
        }

        public ResultCategoriaProductoModel GetCategorias()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResultCategoriaProducto> SaveCategoria(CategoriaProductoServicesModel oCategoria)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResultCategoriaProducto> UpdateCategoria(CategoriaProductoServicesModel oCategoria)
        {
            throw new System.NotImplementedException();
        }

    }
}
