using Kutuphane.Entity.Model;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.WebUI.Models
{
    public class PersonelDto : BaseDto
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string? Telefon { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }

        public virtual List<Emanet>? Emanetler { get; set; }
    }
}
