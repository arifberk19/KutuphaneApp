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
using System.Text.Json;

namespace Kutuphane.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmanetController : Controller
    {
        private string baseUrl = "https://localhost:7212/Emanet";

        public EmanetController()
        {
        }

        // GET: Emanet
        [HttpGet("/Admin/Emanet/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<EmanetDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<EmanetDto>());
            else
                return View(sonuc);
        }

        //GET: Emanet/Details/5
        [HttpGet("/Admin/Emanet/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonuc = await RestHelper.GetRequestAsync<EmanetDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);

        }

        // GET: Emanet/Create
        [HttpGet("/Admin/Emanet/Create")]
        public async Task<IActionResult> Create()

        {
            string url = "https://localhost:7212";
            var kitapkopyaListesi = await RestHelper.GetRequestAsync<List<KitapKopyaDto>>(url + "/KitapKopya/Listele");
            ViewBag.KitapKopya = new SelectList(kitapkopyaListesi, "ID", "KitapKopyaNo");

            var uyeListesi = await RestHelper.GetRequestAsync<List<UyeDto>>(url + "/Uye/Listele");
            ViewBag.Uye = new SelectList(uyeListesi, "ID", "Adi");

            var personelListesi = await RestHelper.GetRequestAsync<List<PersonelDto>>(url + "/Personel/Listele");
            ViewBag.Personel = new SelectList(personelListesi, "ID", "Adi");
            return View();
        }

            // POST: Emanet/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmanetTarih,TeslimTarih,SonTeslimTarih,KitapKopyaId,PersonelId,UyeId")] EmanetDto emanet)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<EmanetDto, EmanetDto>(baseUrl + "/Ekle", emanet);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(emanet);
        }

        // GET: Emanet/Edit/5
        [HttpGet("/Admin/Emanet/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<EmanetDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
            {
                string url = "https://localhost:7212";
                var kitapkopyaListesi = await RestHelper.GetRequestAsync<List<KitapKopyaDto>>(url + "/KitapKopya/Listele");
                ViewBag.KitapKopya = new SelectList(kitapkopyaListesi, "ID", "KopyaNo");

                var uyeListesi = await RestHelper.GetRequestAsync<List<UyeDto>>(url + "/Uye/Listele");
                ViewBag.Uye = new SelectList(uyeListesi, "ID", "Adi");

                var personelListesi = await RestHelper.GetRequestAsync<List<PersonelDto>>(url + "/Personel/Listele");
                ViewBag.Personel = new SelectList(personelListesi, "ID", "Adi");
                return View();
            }
            return View(sonuc);

        }

        // POST: Emanet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmanetTarih,TeslimTarih,SonTeslimTarih,KitapKopyaId,PersonelId,UyeId,ID,GuncelleyenPersonelId,EkleyenPersonelId,EklenmeTarihi,GuncellenmeTarihi,SilindiMi,AktifMi")] EmanetDto emanet)
        {
            if (id != emanet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<EmanetDto, EmanetDto>(baseUrl + "/Guncelle/?id=" + id, emanet, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(emanet);
        }

        // GET: Emanet/Delete/5
        [HttpGet("/Admin/Emanet/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<EmanetDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // POST: Emanet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var url = baseUrl + "/Sil/?id=" + id;
            var client = new RestClient();
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
