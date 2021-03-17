using SegundaOportunidad.Domain.Entities;
using SegundaOportunidad.Repository.Context;
using SegundaOportunidad.Repository.Repositories;
using System;
using System.Threading.Tasks;
namespace SegundaMano.Data.Prueba
{
    class Program
    {
        static async Task Main (string[] args)
        {
           string cnnString = @"Data Source = MSI\SQLEXPRESS01;Initial Catalog =DB_SEGUNDA_OPORTUNIDAD; Integrated Security = True; MultipleActiveResultSets=True";

            Console.WriteLine("***LISTA DE PUREBA***");
            try
            {
                using (var db = new SegundaOportunidadContext(cnnString))
                {
                    #region Pruebas unitarias CRUD CategoriaProducto
                    //Inicio de pruebas
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
                        Categoria_Producto_Id = 8,
                        Nombre = "Herramienta",
                        Deleted = false
                    };*/
                    // oCategoria.UpdateCategoria(x);
                    #endregion
                    #region PRUEBA DEL METODO RemoveCategoria
                    //oCategoria.RemoveCategoria(x);
                    #endregion
                    #region PRUEBA DEL METODO GetCategorias
                    //var _categoriaRepository = new CategoriaProductoRepository(db);
                    //foreach (var b in _categoriaRepository.GetCategorias())
                    //{
                    //    Console.WriteLine(b.Nombre);
                    //}
                    #endregion
                    #region PRUEBA DEL METODO GetCategoriaByID
                    // var c = await oCategoria.GetCategoriaByID(2);
                    // Console.Write(c.Nombre);
                    #endregion
                    //Fin de las pruebas
                    #endregion
                    #region Pruebas unitarias CRUD Marca
                    //Inicio de preubas
                    #region PRUEBA METODO AddMarca
                    //var _marcaRepository = new MarcaRepository(db);
                    //Marca oMarca = new Marca
                    //{
                    //    Nombre = "Nautica",
                    //    Fecha = Convert.ToDateTime("3/1/2021"),
                    //    Deleted = false,
                    //    CreationDate = Convert.ToDateTime("3/1/2021")
                    //};
                    //await _marcaRepository.AddMarca(oMarca);
                    //await _marcaRepository.SaveMarca();
                    #endregion
                    #region PRUEBA METODO UpdateMarca
                    //var _marcaRepository = new MarcaRepository(db);

                    //Marca oMarca = new Marca()
                    //{
                    //    Marca_ID = 1,
                    //    Nombre = "Jordan",
                    //    Fecha = Convert.ToDateTime("03/15/2021")
                    //};

                    //_marcaRepository.UpdateMarca(oMarca);
                    //await _marcaRepository.SaveMarca();
                    //var x = await _marcaRepository.GetMarcaById(1);

                    // Console.Write(x.Nombre);
                    #endregion
                    #region PRUEBA METODO GetMarcas
                    //var _marcaRepository = new MarcaRepository(db);

                    //var listaMarcas = _marcaRepository.GetMarcas();

                    //foreach (var marca in listaMarcas)
                    //{
                    //    Console.WriteLine(marca.Nombre);
                    //}

                    #endregion
                    #region PRUEBA METODO GetMarcaById
                    //var _marcaRepository = new MarcaRepository(db);

                    //var x = await _marcaRepository.GetMarcaById(1);
                    //Console.WriteLine(x.Nombre);
                    #endregion
                    //Fin de las pruebas
                    #endregion
                    #region Pruebas unitarias CRUD Modelo
                    //Inicio de preubas
                    #region PRUEBA METODO AddModelo
                    //var _ModeloRepository = new ModeloRepository(db);
                    //Modelo oModelo = new Modelo
                    //{
                    //    Marca_ID = 1,
                    //    Nombre="JORDAN 23",
                    //    Deleted = false
                    //};
                    //await _ModeloRepository.AddModelo(oModelo);
                    //await _ModeloRepository.SaveModelo();

                    //Console.WriteLine(oModelo.Nombre);
                    #endregion
                    #region PRUEBA METODO UpdateModelo
                    //var _ModeloRepository = new ModeloRepository(db);

                    //Modelo oModelo = new Modelo()
                    //{
                    //    Modelo_ID = 1,
                    //    Nombre = "Jordan",
                    //    Fecha = Convert.ToDateTime("03/15/2021")
                    //};

                    //_ModeloRepository.UpdateModelo(oModelo);
                    //await _ModeloRepository.SaveModelo();
                    //var x = await _ModeloRepository.GetModeloById(1);

                    // Console.Write(x.Nombre);
                    #endregion
                    #region PRUEBA METODO GetModelos
                    //var _ModeloRepository = new ModeloRepository(db);

                    //var listaModelos = _ModeloRepository.GetModelos();

                    //foreach (var Modelo in listaModelos)
                    //{
                    //    Console.WriteLine(Modelo.Nombre);
                    //}

                    #endregion
                    #region PRUEBA METODO GetModeloById
                    //var _ModeloRepository = new ModeloRepository(db);

                    //var x = await _ModeloRepository.GetModeloById(1);
                    //Console.WriteLine(x.Nombre);
                    #endregion
                    //Fin de las pruebas
                    #endregion
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            Console.ReadLine();
        }



    }
}
