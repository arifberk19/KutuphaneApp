using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Entity.Model
{
    [Table("Uye")]
    public class Uye : AuditableEntity
    {
        public Uye()
        {
            Emanetler = new HashSet<Emanet>();
        }
                
        [MaxLength(50)]
        [Required]
        public string Adi { get; set; }
        [MaxLength(50)]
        [Required]
        public string Soyadi { get; set; }
        [MaxLength(10)]
        [Required]
        public string Cinsiyet { get; set; }
        [MaxLength(11)]
        [Required]
        public string Telefon { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(250)]
        [Required]
        public string Adres { get; set; }
        
        [MaxLength(250)]
        public string Sifre { get; set; }

        [NotMapped]
        public string AdSoyad => Adi + " " + Soyadi;

        public virtual ICollection<Emanet>? Emanetler { get; set; }
        public virtual ICollection<KitapKopya>? RezerveKitaplar { get; set; }
    }
}
