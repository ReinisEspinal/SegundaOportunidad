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
        public ResultCategoriaProducto GetCategorias()
        {
            ResultCategoriaProducto result = new ResultCategoriaProducto();

            try
            {
                result.Data = _categoriaProductoRep.FindAll(d => !d.Deleted).Select(d => new ResultCategoriaProductoModel()
                {
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
        public async Task<ResultCategoriaProducto> SaveCategoria(CategoriaProductoServicesModel oCategoria)
        {
            ResultCategoriaProducto result = new ResultCategoriaProducto();
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

                oCategoria.Categoria_Producto_ID = newCategoriaProducto.Categoria_Producto_ID;

                result.Data = oCategoria;
            }
            catch (Exception e) { _logger.LogError($"Error: {e.Message}"); result.success = false; result.message = "Error agregando la informacion de la categoria"; }

            return result.Data;
        }
        public async Task<ResultCategoriaProducto> UpdateCategoria(CategoriaProductoServicesModel oCategoria)
        {
            ResultCategoriaProducto result = new ResultCategoriaProducto();
            try
            {
                _categoriaProductoRep.UpdateCategoria(new CategoriaProducto()
                {
                    Categoria_Producto_ID = oCategoria.Categoria_Producto_ID,
                    Nombre = oCategoria.Nombre
                });

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
        private async Task<bool> ValidateCategoria(string nombre)
        {
            return await _categoriaProductoRep.Exists(cd => cd.Nombre == nombre);
        }
    }
}
