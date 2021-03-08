using System;
using System.Collections.Generic;
using System.Text;
using SegundaOportunidad.Domain.Entities;
using SegundaOportunidad.Services.Core;
using System.Threading.Tasks;

namespace SegundaOportunidad.Services.Contracts
{
    public interface ICategoriaProductoService 
    {
        CategoriaProductoResult GetCategorias();
        Task <CategoriaProductoResult> SaveCategoria(Models.CategoriaProductoServicesModel oCategoria);
        Task<CategoriaProductoResult> UpdateCategoria(Models.CategoriaProductoServicesModel oCategoria);
        Task<CategoriaProductoResult> GetCategoriaById(int Id);
    }
}
