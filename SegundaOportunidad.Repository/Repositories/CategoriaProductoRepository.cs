using SegundaOportunidad.Domain.Entities;
using SegundaOportunidad.Repository.BaseRepository;
using SegundaOportunidad.Repository.Context;
using SegundaOportunidad.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegundaOportunidad.Repository.Repositories
{
    public class CategoriaProductoRepository : BaseRepository<CategoriaProducto>, ICategoriaProductoRepository
    {

        private readonly SegundaOportunidadContext segundaOportunidadContext;
        public CategoriaProductoRepository(SegundaOportunidadContext segundaOportunidadContext) : base(segundaOportunidadContext)
        {
            this.segundaOportunidadContext = segundaOportunidadContext;
        }

        public async Task<CategoriaProducto> GetCategoriaByID(int id)
        {
           return await GetById(id);
        }
    }
}
