﻿using System;
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
    public class yayineviController : Controller
    {
        private string baseUrl = "https://localhost:7212/yayinevi";

        public yayineviController()
        {
        }
        // GET: Yayinevi
        [HttpGet("/Admin/Yayinevi/Index")]
        public async Task<IActionResult> Index()
        {
            var sonuc = await RestHelper.GetRequestAsync<List<YayineviDto>>(baseUrl + "/Listele");
            if (sonuc is null)
                return View(new List<YayineviDto>());
            else
                return View(sonuc);
        }

        // GET: Yayinevi/Details/5
        [HttpGet("/Admin/Yayinevi/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonuc = await RestHelper.GetRequestAsync<YayineviDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }

        // GET: Yayinevi/Create
        [HttpGet("/Admin/Yayinevi/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yayinevi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adi,Adres,Telefon")] YayineviDto yayinevi)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<YayineviDto, YayineviDto>(baseUrl + "/Ekle", yayinevi);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));
            }
            return View(yayinevi);
        }


        // GET: Yayinevi/Edit/5
        [HttpGet("/Admin/Yayinevi/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<YayineviDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }


        // POST: Yayinevi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adi,Adres,Telefon")] YayineviDto yayinevi)
        {
            if (id != yayinevi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sonuc = await RestHelper.PostRequestAsync<YayineviDto, UyeDto>(baseUrl + "/Guncelle/?id=" + id, yayinevi, Method.Put);
                if (sonuc is null)
                    return BadRequest();
                else
                    return RedirectToAction(nameof(Index));

            }
            return View(yayinevi);
        }

        // GET: Yayinevi/Delete/5
        [HttpGet("/Admin/Yayinevi/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sonuc = await RestHelper.GetRequestAsync<YayineviDto>(baseUrl + "/Getir/?id=" + id);
            if (sonuc is null)
                return NotFound();
            else
                return View(sonuc);
        }
        // POST: Yayinevi/Delete/5
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
