

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SegundaOportunidad.Domain.Entities
{
    public class Persona : BaseEntities.BaseEntity
    {
        [Key]
        public int Persona_Id { get; set; }
        public string Nombre {get;set;}
        public int Apellido { get; set;}
        public int Tipo_Documento { get; set; }

        public virtual ICollection<Donacion> Donaciones { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
        public Persona()
        {
            this.Donaciones = new HashSet<Donacion>();
            this.Ventas = new HashSet<Venta>();
        }

    }

}
