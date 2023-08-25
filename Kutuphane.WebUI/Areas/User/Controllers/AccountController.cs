using Kutuphane.WebUI.Helper.SessionHelper;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.AspNetCore.Http;
using Kutuphane.Core.DTO;
using System.Security.Cryptography;
using System.Text;
using Kutuphane.WebUI.Models;
using Kutuphane.WebUI.Areas.Admin.Controllers;

namespace Kutuphane.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor HttpContextAccessor;

        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        [HttpGet("/User/Account/UserLogin")]
        public IActionResult Index()
        {
            HttpContextAccessor.HttpContext.Session.Clear();
            return View();
        }

        [HttpGet("/User/Account/Logout")]
        public IActionResult Logout()
        {
            HttpContextAccessor.HttpContext.Session.Clear();
            return Redirect("/User/Account/UserLogin");
        }

        [HttpPost("/User/Account/Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin(LoginDto loginDTO)
        {
            var url = "https://localhost:7212/Account/Login";
            var data = Encoding.ASCII.GetBytes(loginDTO.Sifre);
            var hashed = MD5.HashData(data);
            loginDTO.Sifre = Encoding.ASCII.GetString(hashed);
            var res = await RestHelper.PostRequestAsync<LoginDto, ApiSonuc<LoginDto>>(url, loginDTO);

            //var responseObject = JsonConvert.DeserializeObject<ApiResult<LoginDTO>>(restResponse.Content);

            if (res == null)
            {                
                ViewBag.LoginError = "Kullanıcı Adı Veya Şifre Yanlış";
                ViewData["LoginError"] = "Kullanıcı Adı Veya Şifre Yanlış";
                return View("Index");
            }
            SessionManager.LoggedUser = res.Data;

            return Redirect("/User/Home/Index");

        }

        [HttpGet("/User/Account/Register")]
        public IActionResult Register()
        {
            HttpContextAccessor.HttpContext.Session.Clear();
            return View();
        }

        [HttpPost("/User/Account/Register")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(UyeDto uyeDto)
        {
            var url = "https://localhost:7212/Account/Register";
            var data = Encoding.ASCII.GetBytes(uyeDto.Sifre);
            var hashed = MD5.HashData(data);
            uyeDto.Sifre = Encoding.ASCII.GetString(hashed);
            var res = await RestHelper.PostRequestAsync<UyeDto, ApiSonuc<LoginDto>>(url, uyeDto);

            //var responseObject = JsonConvert.DeserializeObject<ApiResult<LoginDTO>>(restResponse.Content);
            if (res == null)
            {
                ViewBag.RegisterError = "Kullanıcı oluşturulamadı";
                ViewData["RegisterError"] = "Kullanıcı oluşturulamadı";
                return View("Register");
            }

            SessionManager.LoggedUser = res.Data;
            return Redirect("/User/Home/Index");

        }

        [HttpGet("/User/Account/KitapList")]
        public async Task<IActionResult> KitapList()
        {
            var url = "https://localhost:7212/KitapKopya/Listele";
            var res = await RestHelper.GetRequestAsync<List<KitapKopyaDto>>(url);
            return View(res);
        }

        [HttpPost("/User/Account/Rezerve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rezerve(int kitapKopyaId)
        {
            var url = $"https://localhost:7212/KitapKopya/Rezerve/?id={kitapKopyaId}";
            var res = await RestHelper.PostRequestAsync<int?, bool>(url, SessionManager.LoggedUser?.ID);
            if (!res)
            {
                ViewBag.RezerveError = "Rezerve edilemedi";
                ViewData["RezerveError"] = "Rezerve edilemedi";
            }
            return View("KitapList");
		}
    }
}
