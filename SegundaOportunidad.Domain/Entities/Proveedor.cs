using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Proveedor : BaseEntities.BaseEntity
    {
        [Key]
        public int Proveedor_Id { get; set; }

        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
        public Proveedor()
        {
            this.Productos = new HashSet<Producto>();
        }
    }
}
