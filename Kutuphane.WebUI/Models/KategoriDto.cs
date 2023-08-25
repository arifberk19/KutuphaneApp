using Kutuphane.Entity.Model;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.WebUI.Models
{
    public class KategoriDto : BaseDto
    {
        public string Adi { get; set; }

        public virtual ICollection<Kitap>? Kitaplar { get; set; }
    }
}