using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Inventario : BaseEntities.BaseEntity
    {
        [Key]
        public int Inventario_ID { get; set; }
        public int Almacen_ID { get; set; }
        public int Producto_ID { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }

        public virtual ICollection<Almacen> Almacenes { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public Inventario()
        {
            Almacenes = new HashSet<Almacen>();
            Productos = new HashSet<Producto>();
        }
    }
}
