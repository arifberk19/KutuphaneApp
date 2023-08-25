using Kutuphane.Entity.Model;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.WebUI.Models
{
    public class YazarDto : BaseDto
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public virtual ICollection<Kitap>? Kitaplar { get; set; }
    }
}
