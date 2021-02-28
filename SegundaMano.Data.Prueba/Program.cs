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
                        Categoria_Producto_ID = 1
                    };

                    #region PRUEBA DEL METODO AddCategoria
                    /*var x = new CategoriaProducto()
                    {
                        Nombre = "Herramienta",
                        Deleted = false
                    };*/
                    //  await oCategoria.AddCategoria(x);
                    // await oCategoria.Commit();
                    #endregion
                    #region PRUEBA DEL METODO UpdateCategoria
                    /*var x = new CategoriaProducto()
                    {
                        Categoria_Producto_ID = 8,
                        Nombre = "Herramienta",
                        Deleted = false
                    };*/
                    // oCategoria.UpdateCategoria(x);
                    #endregion
                    #region PRUEBA DEL METODO RemoveCategoria
                    //oCategoria.RemoveCategoria(x);
                    #endregion
                    #region PRUEBA DEL METODO GetCategorias
                    /* foreach (var b in oCategoria.GetCategorias())
                     {
                         Console.WriteLine(b.Nombre);
                     }*/
                    #endregion
                    #region PRUEBA DEL METODO GetCategoriaByID
                    var c=await oCategoria.GetCategoriaByID(2);
                    Console.Write(c.Nombre);
                    #endregion
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
