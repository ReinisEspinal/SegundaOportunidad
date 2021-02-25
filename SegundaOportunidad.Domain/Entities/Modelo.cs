﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SegundaOportunidad.Domain.Entities
{
    public class Modelo
    {

        public int Modelo_ID { get; set; }
        public string Nombre { get; set; }
        public int Marca_ID { get; set; }

        public virtual ICollection<Marca> Marcas { get; set; }

        public Modelo()
        {
            Marcas = new HashSet<Marca>();
        }
    }
}