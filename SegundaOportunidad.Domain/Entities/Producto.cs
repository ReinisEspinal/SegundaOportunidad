using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Producto : BaseEntities.BaseEntity
    {
        [Key]
        public int Producto_ID { get; set; }
        public string Nombre { get; set; }
        public int? Modelo_ID { get; set; }
        public int Proveedor_ID { get; set; }

        public int Categoria_Producto_ID { get; set; }
        public int Costo { get; set; }


        public virtual ICollection<CategoriaProducto> CategoriasProductos { get; set; }
        public virtual ICollection<Modelo> Modelos { get; set; }
        public virtual ICollection<Proveedor> Proveedores { get; set; }
        public Producto()
        {
            CategoriasProductos = new HashSet<CategoriaProducto>();
            Modelos = new HashSet<Modelo>();
            Proveedores = new HashSet<Proveedor>();

        }
    }
}
