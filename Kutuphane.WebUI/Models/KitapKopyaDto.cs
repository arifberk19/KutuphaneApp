using Kutuphane.Entity.Model;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.WebUI.Models
{
    public class KitapKopyaDto : BaseDto
    {
        public int KopyaNo { get; set; }
        public int KitapId { get; set; }

        public int? EnSonRezerveEdenUyeId { get; set; }
        public DateTime? RezerveBitisTarihi { get; set; }

        public string KitapKopyaNo => Kitap?.Adi + "(" + KopyaNo + ")";

        public Uye? EnSonRezerveEdenUye { get; set; }
        public Kitap? Kitap { get; set; }

        public virtual ICollection<Emanet>? Emanetler { get; set; }
    }
}
