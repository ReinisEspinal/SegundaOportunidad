using System;
using System.Collections.Generic;
using System.Text;

namespace SegundaOportunidad.Services.Result.Models
{
    public class ResultModeloServiceModel
    {

        public int Modelo_Id { get; set; }
        public string Nombre { get; set; }
        public int Marca_Id { get; set; }
        public string NombreMarca
        {
            get; set;
        }
    }
}
