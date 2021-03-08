using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaOportunidad.WebUi.Controllers
{
    public class CategoriaProducto : Controller
    {
        // GET: CategoriaProducto
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoriaProducto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriaProducto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProducto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CategoriaProducto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriaProducto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CategoriaProducto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriaProducto/Delete/5
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
