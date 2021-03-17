using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Producto : BaseEntities.BaseEntity
    {
        [Key]
        public int Producto_Id { get; set; }
        public string Nombre { get; set; }
        public int? Modelo_Id { get; set; }
        public int Proveedor_Id { get; set; }
        public int Categoria_Producto_ID { get; set; }
        public int Costo { get; set; }


        public virtual CategoriaProducto CategoriasProducto { get; set; }
        public virtual Modelo Modelo { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<ConceptoVenta> ConceptoVentas { get; set; }
        public virtual ICollection<DonacionProducto> DonacionProducto { get; set; }
        public virtual ICollection<InventarioProducto> InventariosProductos { get; set; }
        public Producto()
        {
            this.ConceptoVentas = new HashSet<ConceptoVenta>();
            this.DonacionProducto = new HashSet<DonacionProducto>();
            this.InventariosProductos = new HashSet<InventarioProducto>();

        }
    }
}
