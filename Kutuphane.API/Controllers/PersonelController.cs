using Kutuphane.Business.Abstract;
using Kutuphane.Business.Concrete;
using Kutuphane.Entity.Model;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kutuphane.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private IPersonelManager PersonelManager;
        public PersonelController(IPersonelManager personelManager)
        {
            PersonelManager = personelManager;
        }

        // GET: api/<PersonelController>
        [HttpGet("Listele")]
        public async Task<IActionResult> Listele()
        {
            var sonuc = await PersonelManager.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            if (sonuc == null)
                return NotFound();
            return Ok(sonuc);
        }

        // GET api/<PersonelController>/5
        [HttpGet("Getir")]
        public async Task<IActionResult> Getir(int id)
        {
            var sonuc = await PersonelManager.Getir(x => x.ID == id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return Ok(sonuc);
        }

        // POST api/<PersonelController>
        [HttpPost("Ekle")]
        public async Task<IActionResult> Ekle([FromBody] Personel personel)
        {
            if (string.IsNullOrEmpty(personel.Adi) || string.IsNullOrEmpty(personel.Soyadi) || string.IsNullOrEmpty(personel.Email) || string.IsNullOrEmpty(personel.Sifre))
                return BadRequest();
            await PersonelManager.Ekle(personel);
            return Ok(personel);
        }

        // PUT api/<PersonelController>/5
        [HttpPut("Guncelle")]
        public async Task<IActionResult> Guncelle(int id, [FromBody] Personel personel)
        {
            var pers = await PersonelManager.GetirID(id);
            if (pers == null)
                return NotFound();
            else
            {
                await PersonelManager.Guncelle(personel);
                return Ok(pers);
            }

        }

        // DELETE api/<PersonelController>/5
        [HttpDelete("Sil")]
        public async Task<IActionResult> Sil(int id)
        {
            var personel = await PersonelManager.GetirID(id);
            if (personel == null)
                return NotFound();
            else
            {
                await PersonelManager.Sil(id);
                return Ok();
            }
        }
    }
}
