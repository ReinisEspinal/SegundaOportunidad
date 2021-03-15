using Microsoft.EntityFrameworkCore;
using SegundaOportunidad.Domain.Entities;

namespace SegundaOportunidad.Repository.Context
{
    public class SegundaOportunidadContext : DbContext
    {
        private string _cnnString;
        public SegundaOportunidadContext(/*string _cnnString*/)
        {
            //this._cnnString = _cnnString;
        }
        public SegundaOportunidadContext(DbContextOptions<SegundaOportunidadContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{ options.UseSqlServer(_cnnString); }


        //  public virtual DbSet<Almacen> TBL_ALMACEN { get; set; }
        public virtual DbSet<CategoriaProducto> TBL_CATEGORIA_PRODUCTO { get; set; }
        public virtual DbSet<CategoriaProducto> TBL_MARCA { get; set; }
        //public virtual DbSet<Marca> TBL_MARCA { get; set; }
        //public virtual DbSet<ConceptoVenta> TBL_CONCEPTO_VENTA { get; set; }
        //public virtual DbSet<Donacion> TBL_DONACION { get; set; }
        //public virtual DbSet<Inventario> TBL_INVENTARIO { get; set; }
        //public virtual DbSet<Modelo> TBL_MODELO { get; set; }
        //public virtual DbSet<Persona> TBL_PERSONA { get; set; }
        //public virtual DbSet<Producto> TBL_PRODUCTO { get; set; }
        //public virtual DbSet<Proveedor> TBL_PROVEEDOR { get; set; }
        //public virtual DbSet<Venta> TBL_VENTA { get; set; }
    }
}