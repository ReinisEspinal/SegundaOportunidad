using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Venta
    {
        [Key]
        public int Venta_ID { get; set; }
        public int Persona_ID { get; set; }
        public DateTime Fecha { get; set; }
        public int Venta_Total { get; set; }

        public virtual ICollection<Persona> Peronas { get; set; }

        public Venta()
        {

        }

    }
}
