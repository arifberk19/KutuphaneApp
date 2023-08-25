using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Entity.Model
{
    [Table("Personel")]
    public class Personel : AuditableEntity
    {
        public Personel()
        {
            Emanetler = new HashSet<Emanet>();
        }
                
        [MaxLength(50)]
        [Required]
        public string Adi { get; set; }
        [MaxLength(50)]
        [Required]
        public string Soyadi { get; set; }
        [MaxLength(11)]
        public string? Telefon { get; set; }
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        [MaxLength(100)]
        [Required]
        public string Sifre { get; set; }
        [NotMapped]
        public string AdSoyad => Adi + " " + Soyadi;

        public virtual ICollection<Emanet>? Emanetler { get; set; }
    }
}
