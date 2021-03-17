using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class ConceptoVenta : BaseEntities.BaseEntity
    {
        [Key]
        public int Concepto_Venta_Id { get; set; }
        public int Venta_Id { get; set; }
        public int Producto_Id { get; set; }
        public int Cantidad { get; set; }
        public int Precio_Unitario { get; set; }
        public int Importe_Producto { get; set; }

        public virtual Venta Venta { get; set; }
        public virtual Producto Productos { get; set; }

        public ConceptoVenta()
        {

        }
    }
}
