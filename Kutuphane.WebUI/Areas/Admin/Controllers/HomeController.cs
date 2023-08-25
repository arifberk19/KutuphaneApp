using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;
using Kutuphane.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Kutuphane.Entity.Model;

namespace Kutuphane.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            //REST get req örneği
            var url = "https://localhost:7212/Personel/Listele";
            var client = new RestClient();
            var request = new RestRequest(url);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var resp = await client.ExecuteAsync(request);
            if (resp.IsSuccessStatusCode && !string.IsNullOrEmpty(resp.Content))
            {
				var sonuc = JsonSerializer.Deserialize<List<PersonelDto>>(resp.Content, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});
                return View(sonuc);
            }
            return Index();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}