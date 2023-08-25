using Kutuphane.Entity.Model;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.WebUI.Models
{
    public class YayineviDto :BaseDto
    {
        public string Adi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<Kitap>? Kitaplar { get; set; }
    }
}
