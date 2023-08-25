using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.Concrete;
using Kutuphane.Core.DTO;
using Kutuphane.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Kutuphane.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManager AccountManager;
        private readonly IConfiguration Configuration;

        public AccountController(IAccountManager accountManager, IConfiguration configuration)
        {
            AccountManager = accountManager;
            Configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Sifre))
                return BadRequest();
            var user = await AccountManager.KullaniciGetir(login);
            if (user == null)
            {
                return NotFound(ApiSonuc<LoginDto>.AuthenticationError());
            }
            else
            {
                var key = Encoding.UTF8.GetBytes(Configuration.GetValue<string>("AppSettings:JWTKey"));

                var claims = new List<Claim>();

                claims.Add(new Claim("Email", user.Email));
                claims.Add(new Claim("ID", user.ID.ToString()));

                var jwt = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(30),
                    claims: claims,
                    issuer: "http://Kutuphane.com",
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);
                user.Token = token;

                return Ok(ApiSonuc<LoginDto>.SuccessWithData(user));

            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Uye Uye)
        {
            if (string.IsNullOrEmpty(Uye.Email) || string.IsNullOrEmpty(Uye.Sifre) || string.IsNullOrEmpty(Uye.Adi) || string.IsNullOrEmpty(Uye.Soyadi))
                return BadRequest();
            var user = await AccountManager.UyeGetir(Uye);
            if (user != null)
            {
                return NotFound(ApiSonuc<LoginDto>.RegistraionError());
            }
            else
            {
                user = await AccountManager.UyeEkle(Uye);
                var key = Encoding.UTF8.GetBytes(Configuration.GetValue<string>("AppSettings:JWTKey"));

                var claims = new List<Claim>();

                claims.Add(new Claim("Email", user.Email));
                claims.Add(new Claim("ID", user.ID.ToString()));
                    
                var jwt = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(30),
                    claims: claims,
                    issuer: "http://Kutuphane.com",
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);
                user.Token = token;

                return Ok(ApiSonuc<LoginDto>.SuccessWithData(user));

            }

        }
    }
}
