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
    public class KategoriController : Controller
    {
        private string baseUrl = "https://localhost:7212/Kategori";

        public KategoriController()
        {
        }

        // GET: kategori
        [HttpGet("/Admin/Kategori/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<KategoriDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<KategoriDto>());
            else
                return View(sonuc);
        }

        // GET: kategori/Details/5
        [HttpGet("/Admin/Kategori/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonuc = await RestHelper.GetRequestAsync<KategoriDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // GET: kategori/Create
        [HttpGet("/Admin/Kategori/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: kategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adi")] KategoriDto kategori)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<KategoriDto, KategoriDto>(baseUrl + "/Ekle", kategori);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // GET: kategori/Edit/5
        [HttpGet("/Admin/Kategori/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<KategoriDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: kategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adi")] KategoriDto kategori)
        {
            if (id != kategori.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<KategoriDto, KategoriDto>(baseUrl + "/Guncelle/?id=" + id, kategori, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(kategori);
        }

        // GET: kategori/Delete/5
        [HttpGet("/Admin/Kategori/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<KategoriDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: kategori/Delete/5
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
