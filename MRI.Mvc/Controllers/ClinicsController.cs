using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRI.Mvc.Infrastructure;
using MriApi;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;

namespace MRI.Mvc.Controllers
{
    public class ClinicsController : Controller
    {
        public ClinicsController()
        {
        }
        // GET: ClinicsController
        public async Task<ActionResult> Index()
        {
            //var clinics = await _client.ApiClinicsGetAsync();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var apiClient = new MriApiClient("https://localhost:44302/", httpClient);
            var clinics = await apiClient.ClinicsGetAsync();
            return View(clinics);
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
