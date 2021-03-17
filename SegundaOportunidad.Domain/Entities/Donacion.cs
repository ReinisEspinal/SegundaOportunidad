using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Donacion : BaseEntities.BaseEntity
    {
        [Key]
        public int Donacion_Id { get; set; }
        public int Persona_Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ICollection<DonacionProducto> DonacionesProductos { get; set; }
        public Donacion()
        {
            this.DonacionesProductos = new HashSet<DonacionProducto>();
        }
    }
}
