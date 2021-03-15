using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SegundaOportunidad.Services.Contracts;
using SegundaOportunidad.Services.Models;
using SegundaOportunidad.Services.Result.Core;
using SegundaOportunidad.Services.Result.Models;
using SegundaOportunidad.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaOportunidad.WebUi.Controllers
{
    public class CategoriaProductoController : Controller
    {
        private readonly ICategoriaProductoService _CategoriaService;

        public CategoriaProductoController(ICategoriaProductoService categoriaProductoService)
        {
            _CategoriaService = categoriaProductoService;
        }

        // GET: CategoriaProducto
        [HttpGet]
        public ActionResult Index()
        {
            var result = _CategoriaService.GetCategorias();

            var Categorias = ((List<ResultCategoriaProductoServiceModel>)result.Data).Select(cat => new CategoriaProductoWebUiModel()
            {
                Categoria_Producto_ID = cat.Categoria_Producto_ID,
                Nombre = cat.Nombre
            }).ToList();

            return View(Categorias);
        }

        // GET: CategoriaProductoController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            ResultCategoriaProductoServiceModel result = new ResultCategoriaProductoServiceModel();

            result = (ResultCategoriaProductoServiceModel)(await _CategoriaService.GetCategoriaById(id)).Data;
            CategoriaProductoWebUiModel oCategoriaProductoWebUiModel = new CategoriaProductoWebUiModel()
            {
                Categoria_Producto_ID = result.Categoria_Producto_ID,
                Nombre = result.Nombre

            };
            return View(oCategoriaProductoWebUiModel);

        }

        // GET: CategoriaProductoController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            ResultCategoriaProductoServiceModel resultCategoria = (ResultCategoriaProductoServiceModel)(await _CategoriaService.GetCategoriaById(id)).Data;

            var catarmentEdit = new CategoriaProductoWebUiModel()
            {
                Categoria_Producto_ID = resultCategoria.Categoria_Producto_ID,
                Nombre = resultCategoria.Nombre
            };


            return View(catarmentEdit);
        }

        // POST: CategoriaProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoriaProductoWebUiModel categoriaWebUiModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var result = await _CategoriaService.UpdateCategoria(new CategoriaProductoServicesModel()
                {
                    Categoria_Producto_ID = categoriaWebUiModel.Categoria_Producto_ID,
                    Nombre = categoriaWebUiModel.Nombre
                });

                if (!result.success)
                {
                    ViewData["Message"] = result.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));



            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaProductoController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoriaProductoServicesModel CategoriaProductoServicesModel)
        {
            ServiceResult result;

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                result = await _CategoriaService.SaveCategoria(new CategoriaProductoServicesModel()
                {
                    Nombre = CategoriaProductoServicesModel.Nombre
                });

                if (!result.success)
                {
                    ViewData["Message"] = result.message;
                    return View();

                }
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

    }
}