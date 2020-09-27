using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRI.Mvc.Infrastructure;
using MriApi;

namespace MRI.Mvc.Controllers
{
    public class ClinicsController : Controller
    {
        readonly Client _client;
        public ClinicsController(Client client)
        {
            _client = client;
        }
        // GET: ClinicsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClinicsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicsController/Create
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

        // GET: ClinicsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClinicsController/Edit/5
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

        // GET: ClinicsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClinicsController/Delete/5
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
