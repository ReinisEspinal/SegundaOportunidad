using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SegundaOportunidad.Domain.Entities
{
    public class Almacen : BaseEntities.BaseEntity
    {
        [Key]
        public int Almacen_Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }

        public Almacen()
        {
            this.Inventarios = new HashSet<Inventario>();
        }
    }
}
