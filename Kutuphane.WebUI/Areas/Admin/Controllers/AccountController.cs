using Kutuphane.WebUI.Helper.SessionHelper;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.AspNetCore.Http;
using Kutuphane.Core.DTO;
using System.Security.Cryptography;
using System.Text;

namespace Kutuphane.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor HttpContextAccessor;

        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        [HttpGet("/Admin/Account/AdminLogin")]
        public IActionResult Index()
        {
            HttpContextAccessor.HttpContext.Session.Clear();
            return View();
        }

        [HttpGet("/Admin/Account/Logout")]
        public IActionResult Logout()
        {
            HttpContextAccessor.HttpContext.Session.Clear();
            return Redirect("/Admin/Account/AdminLogin");
        }

        [HttpPost("/Admin/Account/Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLogin(LoginDto loginDTO)
        {
            var url = "https://localhost:7212/Account/Login";
            //var data = Encoding.ASCII.GetBytes(loginDTO.Sifre);
            //var hashed = MD5.HashData(data);
            //loginDTO.Sifre = Encoding.ASCII.GetString(hashed);
            var res = await RestHelper.PostRequestAsync<LoginDto, ApiSonuc<LoginDto>>(url, loginDTO);
            
            //var responseObject = JsonConvert.DeserializeObject<ApiResult<LoginDTO>>(restResponse.Content);

            if (res == null)
            {
                ViewBag.LoginError = "Kullanıcı Adı Veya Şifre Yanlış";
                ViewData["LoginError"] = "Kullanıcı Adı Veya Şifre Yanlış";
                return View("Index");
            }
            SessionManager.LoggedUser = res.Data;

            return Redirect("/Admin/Home/Index");
        }

    }
}
