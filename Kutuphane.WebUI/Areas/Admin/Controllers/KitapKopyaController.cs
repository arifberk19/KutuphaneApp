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
using System.Drawing;

namespace Kutuphane.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class kitapkopyaController : Controller
    {
        private string baseUrl = "https://localhost:7212/kitapkopya";

        public kitapkopyaController()
        {
        }
        // GET: Kitap
        [HttpGet("/Admin/KitapKopya/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<KitapKopyaDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<KitapKopyaDto>());
            else
                return View(sonuc);
        }

        // GET: Kitap/Details/5
        [HttpGet("/Admin/KitapKopya/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonuc = await RestHelper.GetRequestAsync<KitapKopyaDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }
        
        // GET: Kitap/Create
        [HttpGet("/Admin/KitapKopya/Create")]
        public async Task<IActionResult> Create()

        {
            string url = "https://localhost:7212";
            var kitapListesi = await RestHelper.GetRequestAsync<List<KitapDto>>(url + "/Kitap/Listele");
            ViewBag.Kitap = new SelectList(kitapListesi, "ID", "Adi");
            return View();
        }

        // POST: KitapKopya/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KopyaNo,KitapId")] KitapKopyaDto kitapKopya)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<KitapKopyaDto, KitapKopyaDto>(baseUrl + "/Ekle", kitapKopya);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(kitapKopya);
        }

        // GET: KitapKopya/Edit/5
        [HttpGet("/Admin/KitapKopya/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<KitapKopyaDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
            {
                string url = "https://localhost:7212";
                var kitapListesi = await RestHelper.GetRequestAsync<List<KitapDto>>(url + "/Kitap/Listele");
                ViewBag.Kitap = new SelectList(kitapListesi, "ID", "Adi");
                return View();
            }

            return View(sonuc);
        }
        // POST: KitapKopya/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KopyaNo,KitapId,ID,GuncelleyenPersonelId,EkleyenPersonelId,EklenmeTarihi,GuncellenmeTarihi,SilindiMi,AktifMi")] KitapKopyaDto kitapKopya)
        {
            if (id != kitapKopya.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<KitapKopyaDto, KitapKopyaDto>(baseUrl + "/Guncelle/?id=" + id, kitapKopya, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(kitapKopya);
        }

        // GET: KitapKopya/Delete/5
        [HttpGet("/Admin/KitapKopya/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<KitapKopyaDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: KitapKopya/Delete/5
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
