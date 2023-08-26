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
    public class uyeController : Controller
    {
        private string baseUrl = "https://localhost:7212/uye";

        public uyeController()
        {
        }

        // GET: uye
        [HttpGet("/Admin/Uye/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<UyeDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<UyeDto>());
            else
                return View(sonuc);
        }

        // GET: uye/Details/5
        [HttpGet("/Admin/Uye/Details")]
        public async Task<IActionResult> Details(int? id)
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

        // GET: uye/Create
        [HttpGet("/Admin/Uye/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: uye/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adi,Soyadi,Cinsiyet,Telefon,EMail,Adres")] UyeDto uye)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<UyeDto, UyeDto>(baseUrl + "/Ekle", uye);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(uye);
        }

        // GET: uye/Edit/5
        [HttpGet("/Admin/Uye/Edit")]
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

        // POST: uye/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adi,Soyadi,Cinsiyet,Telefon,EMail,Adres,ID,GuncelleyenPersonelId,EkleyenPersonelId,EklenmeTarihi,GuncellenmeTarihi,SilindiMi,AktifMi")] UyeDto uye)
        {
            if (id != uye.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<UyeDto, UyeDto>(baseUrl + "/Guncelle/?id=" + id, uye, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(uye);
        }

        // GET: uye/Delete/5
        [HttpGet("/Admin/Uye/Delete")]
        public async Task<IActionResult> Delete(int? id)
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

        // POST: uye/Delete/5
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
