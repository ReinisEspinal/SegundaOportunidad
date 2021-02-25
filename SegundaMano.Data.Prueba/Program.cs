using System;
using SegundaOportunidad.Domain.Entities;
using SegundaOportunidad.Repository.Context;
using SegundaOportunidad.Repository.Repositories;

namespace SegundaMano.Data.Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            string cnnString = @"Data Source = MSI\SQLEXPRESS01;Initial Catalog =DB_SEGUNDA_OPORTUNIDAD; Integrated Security = True; MultipleActiveResultSets=True";

            using (SegundaOportunidadContext context = new SegundaOportunidadContext(cnnString))
            {
                CategoriaProductoRepository oCateriaPR = new CategoriaProductoRepository(context);
                CategoriaProducto oC = new CategoriaProducto() { 
                Nombre="Zapatos"};

                oCateriaPR.AgregarCategoria(oC);
                oCateriaPR.Commit();
                Console.WriteLine("Agregado"+oC.Nombre);
                Console.ReadLine();
            }
        }
    }
}
