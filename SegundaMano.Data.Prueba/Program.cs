using System;
using System.Collections.Generic;
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

            try
            {
                using (SegundaOportunidadContext context = new SegundaOportunidadContext(cnnString))
                {
                    CategoriaProductoRepository oCategoriaRep = new CategoriaProductoRepository(context);
                    var a=oCategoriaRep.GetById(1);

                    Console.WriteLine(a);
                    Console.ReadLine();
                }
            }
            catch (Exception)
            {

                throw;
            }
              
        }
    }
}
