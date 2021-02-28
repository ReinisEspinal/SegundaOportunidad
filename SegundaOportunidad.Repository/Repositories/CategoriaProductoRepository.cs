using SegundaOportunidad.Domain.Entities;
using SegundaOportunidad.Repository.BaseRepository;
using SegundaOportunidad.Repository.Context;
using SegundaOportunidad.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace SegundaOportunidad.Repository.Repositories
{
    public class CategoriaProductoRepository : BaseRepository<CategoriaProducto>, ICategoriaProductoRepository
    {

        private readonly SegundaOportunidadContext segundaOportunidadContext;
        public CategoriaProductoRepository(SegundaOportunidadContext segundaOportunidadContext) : base(segundaOportunidadContext)
        {
            this.segundaOportunidadContext = segundaOportunidadContext;
        }


        public async Task AddCategoria(CategoriaProducto c)
        {
            await base.Add(c);
        }
        public void UpdateCategoria(CategoriaProducto c)
        {
            base.Update(c);
        }
        public void RemoveCategoria(CategoriaProducto c)
        {
            base.Remove(c);
        }
        public IEnumerable<CategoriaProducto> GetCategorias()
        {
            return base.FindAll(x => !x.Deleted);
        }
        public async Task<CategoriaProducto> GetCategoriaByID(int id)
        {
            
            return await base.GetById(id);
        }
        #region UTILIZANDO LINQ PARA OBTENER DATOS
        /*public List<string> Listar()
        {
            var lst = (from b in segundaOportunidadContext.TBL_CATEGORIA_PRODUCTO select b.Nombre).ToList();
            return lst;
        }*/
        #endregion
        public async Task SaveCategoria()
        {
            await base.Commit();
        }
    }
}
