using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class CategoriaProducto : BaseEntities.BaseEntity
    {
        [Key]
        public int Categoria_Producto_ID { get; set; }
       public string Nombre { get; set; }


        public CategoriaProducto()
        {

        }
    }
}
