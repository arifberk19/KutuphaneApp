using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Entity.Model
{
    [Table("KitapKopya")]
    public class KitapKopya : AuditableEntity
    {
        public KitapKopya()
        {
            Emanetler = new HashSet<Emanet>();
        }

        [Required]
        public int KopyaNo { get; set; }

        [Required]
        public int KitapId { get; set; }
        
        public int? EnSonRezerveEdenUyeId { get; set; }
        public DateTime? RezerveBitisTarihi { get; set; }

        public Uye? EnSonRezerveEdenUye { get; set; }
        public Kitap? Kitap { get; set; }

        public virtual ICollection<Emanet>? Emanetler { get; set; }
    }
}
