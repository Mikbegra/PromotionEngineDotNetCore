using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionAPI.Controllers
{
    public class PromotionEngineController : Controller
    {
        // GET: PromotionEngineController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PromotionEngineController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PromotionEngineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PromotionEngineController/Create
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

        // GET: PromotionEngineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PromotionEngineController/Edit/5
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

        // GET: PromotionEngineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PromotionEngineController/Delete/5
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
