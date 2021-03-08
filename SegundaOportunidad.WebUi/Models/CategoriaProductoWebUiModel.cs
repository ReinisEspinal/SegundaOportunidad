using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaOportunidad.WebUi.Models
{
    public class CategoriaProductoWebUiModel
    {
        public int Categoria_Producto_ID { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(50, ErrorMessage = "El nombre del departamento no puede mayor a 50")]
        public string Nombre { get; set; }

    }
}
