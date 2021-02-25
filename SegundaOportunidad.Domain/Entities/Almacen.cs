﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Almacen
    {
        public int Almacen_ID { get; set; }
        public string Nombre { get; set; }

        public string Direccion { get; set; }
        public int Producto_ID { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }

        public Almacen()
        {
            Productos = new HashSet<Producto>();
        }
    }
}