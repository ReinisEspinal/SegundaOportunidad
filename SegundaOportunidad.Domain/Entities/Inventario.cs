using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Inventario : BaseEntities.BaseEntity
    {
        [Key]
        public int Inventario_Id { get; set; }
        public int Almacen_Id { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Almacen Almacen { get; set; }
        public virtual ICollection<InventarioProducto> InventariosProductos { get; set; }
        public Inventario()
        {
            this.InventariosProductos = new HashSet<InventarioProducto>();
        }
    }
}
