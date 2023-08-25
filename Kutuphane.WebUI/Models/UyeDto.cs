using Kutuphane.Entity.Model;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.WebUI.Models
{
    public class UyeDto : BaseDto
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyet { get; set; }
        public string Telefon { get; set; }
        public string? Email { get; set; }
        public string Adres { get; set; }
        public string Sifre { get; set; }

        public virtual ICollection<Emanet>? Emanetler { get; set; }
    }
}
