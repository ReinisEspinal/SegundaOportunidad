using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SegundaOportunidad.Domain.Entities
{
    public class Modelo : BaseEntities.BaseEntity
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.Column("MODELO_ID")]
        public int Modelo_Id { get; set; }
        public string Nombre { get; set; }
        public int Marca_ID { get; set; }

        public virtual Marca Marca { get; set; }

        public Modelo()
        {
      
        }
    }
}
