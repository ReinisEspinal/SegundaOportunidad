using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaOportunidad.WebUi.Models
{
    public class ModeloWebUiModel
    {
        public int Modelo_Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(50, ErrorMessage = "El nombre del modelo no puede mayor a 50")]
        public string Nombre { get; set; }
        public int Marca_ID { get; set; }
    }
}
