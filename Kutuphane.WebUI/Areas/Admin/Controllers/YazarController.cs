using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kutuphane.DAL.EntityFramework;
using Kutuphane.Entity.Model;
using Kutuphane.WebUI.Models;
using RestSharp;

namespace Kutuphane.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class yazarController : Controller
    {
        private string baseUrl = "https://localhost:7212/yazar";

        public yazarController()
        {
        }

        // GET: Yazar
        [HttpGet("/Admin/Yazar/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<YazarDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<YazarDto>());
            else
                return View(sonuc);
        }

        // GET: Yazar/Details/5
        [HttpGet("/Admin/Yazar/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonuc = await RestHelper.GetRequestAsync<YazarDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // GET: Yazar/Create
        [HttpGet("/Admin/Yazar/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yazar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adi,Soyadi")] YazarDto yazar)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<YazarDto, YazarDto>(baseUrl + "/Ekle", yazar);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(yazar);
        }


        // GET: Yazar/Edit/5
        [HttpGet("/Admin/Yazar/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<UyeDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: Yazar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adi,Soyadi")] YazarDto yazar)
        {
            if (id != yazar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<YazarDto, YazarDto>(baseUrl + "/Guncelle/?id=" + id, yazar, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(yazar);
        }

        // GET: Yazar/Delete/5
        [HttpGet("/Admin/Yazar/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<YazarDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: Yazar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var url = baseUrl + "/Sil/?id=" + id;
            using (var client = new RestClient())
            {
                var request = new RestRequest(url, Method.Delete);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                var resp = await client.ExecuteAsync(request);
                if (resp.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return BadRequest();
            }
        }

    }
}