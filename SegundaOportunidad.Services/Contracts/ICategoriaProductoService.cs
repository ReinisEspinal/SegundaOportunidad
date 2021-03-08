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
        CategoriaProducto GetCategorias();
        Task <CategoriaProductoResult> SaveCategoria(CategoriaProducto oCategoria);
        Task<CategoriaProductoResult> UpdateCategoria(CategoriaProducto oCategoria);
        Task<CategoriaProductoResult> GetCategoriaById(int Id);
    }
}
