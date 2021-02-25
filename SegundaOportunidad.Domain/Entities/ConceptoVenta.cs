using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class ConceptoVenta
    {
        [Key]
        public int Concepto_Venta_ID { get; set; }
        public int Venta_ID { get; set; }
        public int Producto_ID { get; set; }
        public int Cantidad { get; set; }
        public int Precio_Unitario { get; set; }
        public int Importe_Producto { get; set; }

        public ICollection<Venta> Ventas { get; set; }
        public ICollection<Producto> Productos { get; set; }

        public ConceptoVenta()
        {
            Ventas = new HashSet<Venta>();
            Productos = new HashSet<Producto>();

        }
    }
}
