using System;
using System.Collections.Generic;
using System.Text;
using SegundaOportunidad.Services.Result.Models;
using System.Threading.Tasks;
using SegundaOportunidad.Services.Result.Core;

namespace SegundaOportunidad.Services.Contracts
{
    public interface ICategoriaProductoService 
    {
        ServiceResultCategoriaProducto GetCategorias();
        Task <ServiceResultCategoriaProducto> SaveCategoria(Models.CategoriaProductoServicesModel oCategoria);
        Task<ServiceResultCategoriaProducto> UpdateCategoria(Models.CategoriaProductoServicesModel oCategoria);
        Task<ServiceResultCategoriaProducto> DeleteCategoria(Models.CategoriaProductoServicesModel oCategoria);
        Task<ServiceResultCategoriaProducto> GetCategoriaById(int Id);

    }
}
