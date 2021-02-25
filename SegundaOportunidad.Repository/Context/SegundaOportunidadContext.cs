﻿using Microsoft.EntityFrameworkCore;
using SegundaOportunidad.Domain.Entities;

namespace SegundaOportunidad.Repository.Context
{
    public class SegundaOportunidadContext : DbContext
    {
        public SegundaOportunidadContext()
        {

        }
        public SegundaOportunidadContext(DbContextOptions<SegundaOportunidadContext> options) : base(options)
        {

        }

        public virtual DbSet<Almacen> Alamcenes { get; set; }
        public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }
        public virtual DbSet<ConceptoVenta> ConceptosVentas { get; set; }
        public virtual DbSet<Donacion> Donaciones { get; set; }
        public virtual DbSet<Inventario> Inventarios { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
    }
}