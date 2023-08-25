using Kutuphane.Business.Abstract;
using Kutuphane.Business.Concrete;
using Kutuphane.Entity.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kutuphane.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class YayineviController : ControllerBase
    {

        private IYayineviManager YayineviManager;
        public YayineviController(IYayineviManager yayineviManager)
        {
            YayineviManager = yayineviManager;
        }
        // GET: <YayineviController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await YayineviManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }
        // GET <YayineviController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await YayineviManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST <YayineviController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Yayinevi yayinevi)
        {
            if (string.IsNullOrEmpty(yayinevi.Adi) || string.IsNullOrEmpty(yayinevi.Adres) || string.IsNullOrEmpty(yayinevi.Telefon))
                return BadRequest();
            await YayineviManager.Ekle(yayinevi);
            return Ok(yayinevi);
        }

        // PUT <YayineviController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Yayinevi yayinevi)
        {
            var yayin = await YayineviManager.GetirID(id);
            if (yayin == null)
                return NotFound();
            else
            {
                await YayineviManager.Guncelle(yayinevi);
                return Ok(yayin);
            }
        }

        // DELETE <YayineviController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var yayinevi = await YayineviManager.GetirID(id);
            if (yayinevi == null)
                return NotFound();
            else
            {
                await YayineviManager.Sil(id);
                return Ok();
            }
        }
    }
}
