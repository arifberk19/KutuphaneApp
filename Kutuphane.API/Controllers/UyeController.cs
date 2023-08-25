using Kutuphane.Business.Abstract;
using Kutuphane.Business.Concrete;
using Kutuphane.Entity.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kutuphane.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UyeController : ControllerBase
    {
        private IUyeManager UyeManager;
        public UyeController(IUyeManager uyeManager)
        {
            UyeManager = uyeManager;
        }

        // GET api/<UyeController>/5
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await UyeManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await UyeManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }
        // POST api/<UyeController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Uye uye)
        {
            if (string.IsNullOrEmpty(uye.Adi) || string.IsNullOrEmpty(uye.Soyadi) || string.IsNullOrEmpty(uye.Cinsiyet) || string.IsNullOrEmpty(uye.Telefon) || string.IsNullOrEmpty(uye.Adres))
                return BadRequest();
            await UyeManager.Ekle(uye);
            return Ok(uye);
        }

        // PUT api/<UyeController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Uye uye)
        {
            var uy = await UyeManager.GetirID(id);
            if (uy == null)
                return NotFound();
            else
            {
                await UyeManager.Guncelle(uye);
                return Ok(uy);
            }
        }

        // DELETE api/<UyeController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var uye = await UyeManager.GetirID(id);
            if (uye == null)
                return NotFound();
            else
            {
                await UyeManager.Sil(id);
                return Ok();
            }
        }
    }
}
