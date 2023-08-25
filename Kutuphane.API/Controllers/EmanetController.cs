using Kutuphane.Business.Abstract;
using Kutuphane.Business.Concrete;
using Kutuphane.Entity.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kutuphane.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmanetController : ControllerBase
    {
        private IEmanetManager EmanetManager;
        public EmanetController(IEmanetManager emanetManager)
        {
            EmanetManager = emanetManager;
        }

        // GET: api/<EmanetController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await EmanetManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }


        // GET api/<EmanetController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await EmanetManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<EmanetController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Emanet emanet)
        {
            if (!(DateTime.Now.Date < emanet.EmanetTarih || emanet.SonTeslimTarih > DateTime.Now))
                return BadRequest();
            await EmanetManager.Ekle(emanet);
            return Ok(emanet);
        }

        // PUT api/<EmanetController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Emanet emanet)
        {
            var ema = await EmanetManager.GetirID(id);
            if (ema == null)
                return NotFound();
            else
            {
                await EmanetManager.Guncelle(emanet);
                return Ok(ema);
            }


        }

    // DELETE api/<EmanetController>/5
    [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var emanet = await EmanetManager.GetirID(id);
            if (emanet == null)
                return NotFound();
            else
            {
                await EmanetManager.Sil(id);
                return Ok();
            }
        }
        }
}
