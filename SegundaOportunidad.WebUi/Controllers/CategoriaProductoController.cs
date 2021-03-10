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

        // GET: CategoriaProductoServicesModelController
        public ActionResult Index()
        {
            var result =  _CategoriaService.GetCategorias();

            var Categorias = ((List<ResultCategoriaProductoModel>)result.Data).Select(cat => new CategoriaProductoWebUiModel()
            {
                Nombre = cat.Nombre
            }).ToList();

            return View(Categorias);
        }

        // GET: CategoriaProductoServicesModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriaProductoServicesModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProductoServicesModelController/Create
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

        // GET: CategoriaProductoServicesModelController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ResultCategoriaProductoModel resultCategoria = (ResultCategoriaProductoModel)(await _CategoriaService.GetCategoriaById(id)).Data;

            var catarmentEdit = new CategoriaProductoServicesModel()
            {
               Nombre = resultCategoria.Nombre
            };


            return View(catarmentEdit);
        }

        // POST: CategoriaProductoServicesModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoriaProductoServicesModel CategoriaProductoServicesModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var result = await _CategoriaService.UpdateCategoria(new CategoriaProductoServicesModel()
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

        // GET: CategoriaProductoServicesModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriaProductoServicesModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
