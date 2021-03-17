using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
namespace SegundaOportunidad.Domain.Entities
{
    public class CategoriaProducto : BaseEntities.BaseEntity
    {

        [Key]
        [Column("CATEGORIA_PRODUCTO_ID")]
        public int Categoria_Producto_Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }

        public CategoriaProducto()
        {
            this.Productos = new HashSet<Producto>();
        }


    }
}
