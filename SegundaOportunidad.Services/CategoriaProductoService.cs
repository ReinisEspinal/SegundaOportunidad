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
    public class CategoriaProductoService : ICategoriaProductoService
    {
        public readonly ICategoriaProductoRepository _categoriaProductoRep;
        private readonly ILogger<CategoriaProductoService> _logger;
        public CategoriaProductoService(ICategoriaProductoRepository categoriaProductoRep, ILogger<CategoriaProductoService> logger)
        {
            _categoriaProductoRep = categoriaProductoRep;
            _logger = logger;
        }
        public async Task<ServiceResultCategoriaProducto> GetCategoriaById(int id)
        {
            var result = new ServiceResultCategoriaProducto();

            try
            {
                var oCategoria = await _categoriaProductoRep.GetCategoriaByID(id);

                result.Data = new ResultCategoriaProductoServiceModel()
                {
                    Categoria_Producto_Id = oCategoria.Categoria_Producto_Id,
                    Nombre = oCategoria.Nombre


                };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                result.success = false;
                result.message = "Error obteniendo la categoria";
            }

            return result;
        }
        public ServiceResultCategoriaProducto GetCategorias()
        {
            ServiceResultCategoriaProducto result = new ServiceResultCategoriaProducto();

            try
            {
                result.Data = _categoriaProductoRep.FindAll(d => !d.Deleted).Select(d => new ResultCategoriaProductoServiceModel()
                {
                    Categoria_Producto_Id = d.Categoria_Producto_Id,
                    Nombre = d.Nombre

                }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error {e.Message}");
                result.success = false;
                result.message = "Error obteniendo los departamentos";
            }
            return result;
        }
        public async Task<ServiceResultCategoriaProducto> SaveCategoria(CategoriaProductoServicesModel oCategoria)
        {
            ServiceResultCategoriaProducto result = new ServiceResultCategoriaProducto();
            try
            {
                if (await ValidateCategoria(oCategoria.Nombre))
                {
                    result.success = false;
                    result.message = $"Esta categoria: {oCategoria.Nombre} ya esta registrado";
                    return result;
                }

                CategoriaProducto newCategoriaProducto = new CategoriaProducto()
                {
                    Nombre = oCategoria.Nombre
                };
                await _categoriaProductoRep.Add(newCategoriaProducto);
                result.message = await _categoriaProductoRep.SaveCategoria() ? "Categoria Agregada" : "Error agregando la categoria";

                oCategoria.Categoria_Producto_Id = newCategoriaProducto.Categoria_Producto_Id;

                result.Data = oCategoria;
            }
            catch (Exception e) { _logger.LogError($"Error: {e.Message}"); result.success = false; result.message = "Error agregando la informacion de la categoria"; }

            return result.Data;
        }
        public async Task<ServiceResultCategoriaProducto> UpdateCategoria(CategoriaProductoServicesModel oCategoria)
        {
            ServiceResultCategoriaProducto result = new ServiceResultCategoriaProducto();
            try
            {
                var categoriaUpdate = await _categoriaProductoRep.GetCategoriaByID(oCategoria.Categoria_Producto_Id);
               
                categoriaUpdate.Nombre = oCategoria.Nombre;

                _categoriaProductoRep.UpdateCategoria(categoriaUpdate);

                await _categoriaProductoRep.SaveCategoria();

                result.message = await _categoriaProductoRep.SaveCategoria() ? "Categoria editada" : "Error editando la categoria";
                result.Data = oCategoria;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error {e.Message}");

                result.success = false;
                result.message = "Error editando la categoria";
            }

            return result.Data;
        }
        public async Task<ServiceResultCategoriaProducto> DeleteCategoria(CategoriaProductoServicesModel oCategoria)
        {
            ServiceResultCategoriaProducto result = new ServiceResultCategoriaProducto();
            try
            {
              
                var categoriaDelete = await _categoriaProductoRep.GetCategoriaByID(oCategoria.Categoria_Producto_Id);
                categoriaDelete.Categoria_Producto_Id = oCategoria.Categoria_Producto_Id;
                categoriaDelete.Deleted = true;

                _categoriaProductoRep.UpdateCategoria(categoriaDelete);

                await _categoriaProductoRep.SaveCategoria();
                result.message = await _categoriaProductoRep.SaveCategoria() ? "Categoria eliminada" : "Error eliminando la categoria";
                result.Data = oCategoria;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error{e.Message}");
                result.success = false;
                result.message = "Error en la eliminacion de la categoria";
            }

            return result;
        }
        private async Task<bool> ValidateCategoria(string nombre)
        {
            return await _categoriaProductoRep.Exists(cd => cd.Nombre == nombre);
        }
    }
}
