using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Entity.Model
{
    [Table("Emanet")]
    public class Emanet : AuditableEntity
    {
        [Required]
        public DateTime EmanetTarih { get; set; } 
        public DateTime? TeslimTarih { get; set; }
        [Required]
        public DateTime SonTeslimTarih { get; set; }

        [Required]
        public int KitapKopyaId { get; set; }
        public KitapKopya? KitapKopya { get; set; }

        [Required]
        public int UyeId { get; set; }
        public Uye? Uye { get; set; }
        
        [Required]
        public int PersonelId { get; set; }
        public Personel? Personel { get; set; }

    }
}
