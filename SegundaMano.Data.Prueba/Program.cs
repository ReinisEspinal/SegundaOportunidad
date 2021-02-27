using System;
using System.Collections.Generic;
using SegundaOportunidad.Domain.Entities;
using SegundaOportunidad.Repository.Context;
using SegundaOportunidad.Repository.Repositories;
using System.Threading.Tasks;
namespace SegundaMano.Data.Prueba
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string cnnString = @"Data Source = MSI\SQLEXPRESS01;Initial Catalog =DB_SEGUNDA_OPORTUNIDAD; Integrated Security = True; MultipleActiveResultSets=True";

            Console.WriteLine("***LISTA DE PUREBA***");
            try
            {
                using (var db = new SegundaOportunidadContext(cnnString))
                {
                  var oCategoria = new CategoriaProductoRepository(db);

                    var x = new CategoriaProducto()
                    {
                        Nombre = "Cell",
                        Deleted = false
                    };

                    //  await oCategoria.AddCategoria(x);
                    // await oCategoria.Commit();

                    /*db.TBL_CATEGORIA_PRODUCTO.Add(x);
                    db.SaveChanges();
                    Console.WriteLine("Agregado");*/

                    foreach (var b in oCategoria.Listar())
                    {
                        Console.WriteLine(b);
                    }
                }
            }
            catch (Exception)
           {
                throw;
            }
            Console.ReadLine();
        }



    }
}
