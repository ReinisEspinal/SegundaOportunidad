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
        ResultCategoriaProductoModel GetCategorias();
        Task <ResultCategoriaProducto> SaveCategoria(Models.CategoriaProductoServicesModel oCategoria);
        Task<ResultCategoriaProducto> UpdateCategoria(Models.CategoriaProductoServicesModel oCategoria);
        Task<ResultCategoriaProducto> GetCategoriaById(int Id);
    }
}
