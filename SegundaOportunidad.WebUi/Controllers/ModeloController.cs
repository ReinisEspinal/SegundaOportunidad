using Microsoft.AspNetCore.Mvc;
using SegundaOportunidad.Services.Contracts;
using SegundaOportunidad.Services.Models;
using SegundaOportunidad.Services.Result.Core;
using SegundaOportunidad.Services.Result.Models;
using SegundaOportunidad.WebUi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaOportunidad.WebUi.Controllers
{
    public class ModeloController : Controller
    {
        private readonly IModeloService _ModeloService;

        public ModeloController(IModeloService ModeloService)
        {
            _ModeloService = ModeloService;
        }

        // GET: Modelo
        [HttpGet]
        public ActionResult Index()
        {
            var result = _ModeloService.GetModelos();
          
            return View(result.Data);
        }

        // GET: ModeloController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            ResultModeloServiceModel result = new ResultModeloServiceModel();

            result = (ResultModeloServiceModel)(await _ModeloService.GetModeloById(id)).Data;
            ModeloWebUiModel oModeloWebUiModel = new ModeloWebUiModel()
            {
                Modelo_Id = result.Marca_Id,
                Nombre = result.Nombre

            };
            return View(oModeloWebUiModel);

        }

        // GET: ModeloController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            ResultModeloServiceModel resultModelo = (ResultModeloServiceModel)(await _ModeloService.GetModeloById(id)).Data;

            var catarmentEdit = new ModeloWebUiModel()
            {
                Modelo_Id = resultModelo.Modelo_Id,
                Nombre = resultModelo.Nombre
            };


            return View(catarmentEdit);
        }

        // POST: ModeloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ModeloWebUiModel ModeloWebUiModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var result = await _ModeloService.UpdateModelo(new ModeloServicesModel()
                {
                    Modelo_Id = ModeloWebUiModel.Modelo_Id,
                    Nombre = ModeloWebUiModel.Nombre
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

        // GET: ModeloController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModeloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ModeloServicesModel ModeloServicesModel)
        {
            ServiceResult result;

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                result = await _ModeloService.SaveModelo(new ModeloServicesModel()
                {
                    Nombre = ModeloServicesModel.Nombre
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
