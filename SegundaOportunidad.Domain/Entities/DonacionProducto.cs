using System.Collections.Generic;


namespace SegundaOportunidad.Domain.Entities
{
    public class DonacionProducto : BaseEntities.BaseEntity
    {
        public int Producto_Id { get; set; }
        public int Donacion_Id { get; set; }
        public int Cantidad { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Donacion Donaciones { get; set; }
        public DonacionProducto()
        {
        }
    }
}