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
	public class kitapController : Controller
	{
		private string baseUrl = "https://localhost:7212/kitap";

		public kitapController()
		{
		}
		// GET: Kitap
		[HttpGet("/Admin/Kitap/Index")]
		public async Task<IActionResult> Index()
		{
			var sonuc = await RestHelper.GetRequestAsync<List<KitapDto>>(baseUrl + "/Listele");
			if (sonuc is null)
				return View(new List<KitapDto>());
			else
				return View(sonuc);
		}

		// GET: Kitap/Details/5
		[HttpGet("/Admin/Kitap/Details")]
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var sonuc = await RestHelper.GetRequestAsync<KitapDto>(baseUrl + "/Getir/?id=" + id);
			if (sonuc is null)
				return NotFound();
			else
				return View(sonuc);
		}

		// GET: Kitap/Create
		[HttpGet("/Admin/Kitap/Create")]
		public async Task<IActionResult> Create()
		{
			string url = "https://localhost:7212";
			ViewBag.Kategori = await RestHelper.GetRequestAsync<List<KitapDto>>(url + "/Kategori/Listele");
			ViewBag.Yazar = await RestHelper.GetRequestAsync<List<KitapDto>>(url + "/Yazar/Listele");
			ViewBag.Yayinevi = await RestHelper.GetRequestAsync<List<KitapDto>>(url + "/Yayinevi/Listele");
			return View();
		}

		// POST: Kitap/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Isbn,Adi,YayinTarih,SayfaSayisi,KategoriId,YayineviId,YazarId")] KitapDto kitap)
		{
			if (ModelState.IsValid)
			{
				var sonuc = await RestHelper.PostRequestAsync<KitapDto, KitapDto>(baseUrl + "/Ekle", kitap);
				if (sonuc is null)
					return BadRequest();
				else
					return RedirectToAction(nameof(Index));
			}
			return View(kitap);
		}

		// GET: Kitap/Edit/5
		[HttpGet("/Admin/Kitap/Edit")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var sonuc = await RestHelper.GetRequestAsync<KitapDto>(baseUrl + "/Getir/?id=" + id);
			if (sonuc is null)
				return NotFound();
			else
				return View(sonuc);
		}

		// POST: Kitap/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Isbn,Adi,YayinTarih,SayfaSayisi,KategoriId,YayineviId,YazarId")] KitapDto kitap)
		{
			if (id != kitap.ID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				var sonuc = await RestHelper.PostRequestAsync<KitapDto, KitapDto>(baseUrl + "/Guncelle/?id=" + id, kitap, Method.Put);
				if (sonuc is null)
					return BadRequest();
				else
					return RedirectToAction(nameof(Index));

			}
			return View(kitap);
		}

		// GET: Kitap/Delete/5
		[HttpGet("/Admin/Kitap/Delete")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var sonuc = await RestHelper.GetRequestAsync<KitapDto>(baseUrl + "/Getir/?id=" + id);
			if (sonuc is null)
				return NotFound();
			else
				return View(sonuc);
		}

		// POST: Kitap/Delete/5
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
