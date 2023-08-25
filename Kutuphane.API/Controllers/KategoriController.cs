using Kutuphane.Business.Abstract;
using Kutuphane.Entity.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kutuphane.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private IKategoriManager KategoriManager;
        public KategoriController(IKategoriManager kategoriManager)
        {
            KategoriManager = kategoriManager;
        }

        // GET: api/<KategoriController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await KategoriManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<KategoriController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await KategoriManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc); 
        }

        // POST api/<KategoriController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Kategori kategori)
        {
            if (string.IsNullOrEmpty(kategori.Adi))
                return BadRequest();
            await KategoriManager.Ekle(kategori);
            return Ok(kategori);
        }

        // PUT api/<KategoriController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Kategori kategori)
        {
            var kat = await KategoriManager.GetirID(id);
            if (kat == null)
                return NotFound();
            else
            {
                await KategoriManager.Guncelle(kategori);
                return Ok(kat);
            }
        }

        // DELETE api/<KategoriController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var kategori = await KategoriManager.GetirID(id);
            if (kategori == null)
                return NotFound();
            else
            {
                await KategoriManager.Sil(id); 
                return Ok();
            }
        }
    }
}
