

using System.ComponentModel.DataAnnotations;

namespace SegundaOportunidad.Domain.Entities
{
    public class Persona
    {
        [Key]
        public int Persona_ID { get; set; }
        public string Nombre {get;set;}
        public int Apellido { get; set;}
        public int Tipo_Documento { get; set; }

        public Persona()
        {

        }

    }

}
