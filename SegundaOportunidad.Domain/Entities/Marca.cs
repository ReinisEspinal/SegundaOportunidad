using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Marca : BaseEntities.BaseEntity
    {
        [Key]
        public int Marca_ID { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public Marca()
        {

        }
    }
}
