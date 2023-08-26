using Kutuphane.Business.Abstract;
using Kutuphane.Business.Concrete;
using Kutuphane.Entity.Model;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kutuphane.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KitapKopyaController : ControllerBase
    {
        private readonly IKitapKopyaManager KitapKopyaManager;
        public KitapKopyaController(IKitapKopyaManager kitapkopyaManager)
        {
            KitapKopyaManager = kitapkopyaManager;
        }
        // GET: api/<KitapKopyaController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await KitapKopyaManager.Listele(x => x.AktifMi == true && x.SilindiMi == false,"Kitap", "EnSonRezerveEdenUye");
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<KitapKopyaController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await KitapKopyaManager.Getir(x => x.ID == id, "Kitap", "EnSonRezerveEdenUye");
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }
        // POST api/<KitapKopyaController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] KitapKopya kitapKopya)
        {
            if (kitapKopya.KopyaNo == 0 || kitapKopya.KitapId == 0)
                return BadRequest();
            await KitapKopyaManager.Ekle(kitapKopya);
            return Ok(kitapKopya);
        }

        // PUT api/<KitapKopyaController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] KitapKopya kitapKopya)
        {
            var kiko = await KitapKopyaManager.GetirID(id);
            if (kiko == null)
                return NotFound();
            else
            {
                await KitapKopyaManager.Guncelle(kitapKopya);
                return Ok(kiko);
            }
        }

        // DELETE api/<KitapKopyaController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var kitapkopya = await KitapKopyaManager.GetirID(id);
            if (kitapkopya == null)
                return NotFound();
            else
            {
                await KitapKopyaManager.Sil(id);
                return Ok();
            }

        }

        [HttpPut("Rezerve")]
        public async Task<IActionResult> Rezerve(int id, [FromBody] int? uyeId)
        {
            var kiko = await KitapKopyaManager.GetirID(id);
            if (kiko == null || uyeId == null)
                return NotFound();
            else
            {
                await KitapKopyaManager.Rezerve(kiko,uyeId.Value);
                return Ok(true);
            }
        }
    }
}
