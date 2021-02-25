using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Almacen
    {
        [Key]
        public int Almacen_ID { get; set; }
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public Almacen()
        {
      
        }
    }
}
