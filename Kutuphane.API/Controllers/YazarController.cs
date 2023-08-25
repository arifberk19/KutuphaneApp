using Kutuphane.Business.Abstract;
using Kutuphane.Business.Concrete;
using Kutuphane.Entity.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kutuphane.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class YazarController : ControllerBase
    {
        private IYazarManager YazarManager;
        public YazarController(IYazarManager yazarManager)
        {
            YazarManager = yazarManager;
        }
        // GET: api/<YazarController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await YazarManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<YazarController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await YazarManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<YazarController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Yazar yazar)
        {
            if (string.IsNullOrEmpty(yazar.Adi) || string.IsNullOrEmpty(yazar.Soyadi))
                return BadRequest();

            await YazarManager.Ekle(yazar);
            return Ok(yazar);
        }

        // PUT api/<YazarController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Yazar yazar)
        {
            var yaz = await YazarManager.GetirID(id);
            if (yaz == null)
                return NotFound();
            else
            {
                await YazarManager.Guncelle(yazar);
                return Ok(yaz);
            }
        }

        // DELETE api/<YazarController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var yazar = await YazarManager.GetirID(id);
            if (yazar == null)
                return NotFound();
            else
            {
                await YazarManager.Sil(id);
                return Ok();
            }
        }
    }
}