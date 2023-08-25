using Kutuphane.Business.Abstract;
using Kutuphane.Business.Concrete;
using Kutuphane.Entity.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kutuphane.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KitapController : ControllerBase
    {
        private IKitapManager KitapManager;
        public KitapController(IKitapManager kitapManager)
        {
            KitapManager = kitapManager;
        }


        // GET: api/<KitapController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await KitapManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<KitapController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await KitapManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<KitapController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Kitap kitap)
        {
            if (string.IsNullOrEmpty(kitap.Isbn) || string.IsNullOrEmpty(kitap.Adi))
                return BadRequest();
            await KitapManager.Ekle(kitap);
            return Ok(kitap);
        }

        // PUT api/<KitapController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Kitap kitap)
        {
            var kit = await KitapManager.GetirID(id);
            if (kit == null)
                return NotFound();
            else
            {
                await KitapManager.Guncelle(kitap);
                return Ok(kit);
            }
        }

        // DELETE api/<KitapController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var kitap = await KitapManager.GetirID(id);
            if (kitap == null)
                return NotFound();
            else
            {
                await KitapManager.Sil(id);
                return Ok();
            }
        }
    }
}
