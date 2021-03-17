using System.ComponentModel.DataAnnotations;

namespace SegundaOportunidad.Domain.Entities
{
    public class InventarioProducto : BaseEntities.BaseEntity
    {
        [Key]
        public int Inventario_Id { get; set; }
        [Key]
        public int Producto_Id { get; set; }
        public int Cantidad { get; set; }

        public virtual Inventario Inventario { get; set; }
        public virtual Producto Producto { get; set; }

        public InventarioProducto()
        {

        }
    }
}