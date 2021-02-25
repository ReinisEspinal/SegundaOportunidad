using SegundaOportunidad.Domain.Entities;
using SegundaOportunidad.Repository.BaseRepository;
using SegundaOportunidad.Repository.Context;
using SegundaOportunidad.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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


        public IEnumerable<CategoriaProducto> GetCategorias() => FindAll(cd => !cd.Deleted);

        public Task AgregarCategoria(CategoriaProducto oC) => Add(oC);
    }
}
