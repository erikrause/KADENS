using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MriApi;

namespace MRI.Mvc.Controllers
{
    public class InspectionsController : Controller
    {
        readonly MriApiClient _client;
        public InspectionsController(MriApiClient client)
        {
            _client = client;
        }

        // GET: InspectionsController
        public async Task<ActionResult> Index()
        {
            return View(await _client.InspectionsGetAsync());
        }

        // GET: InspectionsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _client.InspectionsGetAsync(id));
        }

        // GET: InspectionsController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: InspectionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
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

        // GET: InspectionsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _client.InspectionsGetAsync(id));
        }

        // POST: InspectionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
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

        // GET: InspectionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InspectionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
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
