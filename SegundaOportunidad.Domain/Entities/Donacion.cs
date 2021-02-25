using System;
using System.Collections.Generic;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Donacion
    {
        public int Donacion_ID { get; set; }
        public int Persona_ID { get; set; }
        public DateTime Fecha { get; set; }
        public int Producto_ID { get; set; }
        public int Cantidad { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public Donacion()
        {
            Personas = new HashSet<Persona>();
            Productos = new HashSet<Producto>();
        }
    }
}
