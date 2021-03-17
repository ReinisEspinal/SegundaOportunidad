using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Venta : BaseEntities.BaseEntity
    {
        [Key]
        public int Venta_Id { get; set; }
        public int Persona_Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Venta_Total { get; set; }

        public virtual Persona Perona { get; set; }

        public virtual ICollection<ConceptoVenta> ConceptosVentas { get; set; }

        public Venta()
        {
            this.ConceptosVentas = new HashSet<ConceptoVenta>();
        }

    }
}
