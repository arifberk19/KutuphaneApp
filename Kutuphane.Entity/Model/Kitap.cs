using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Entity.Model
{
    [Table("Kitap")]
    public class Kitap : AuditableEntity
    {
        public Kitap()
        {
            KitapKopyalari = new HashSet<KitapKopya>();
        }
        
        [MaxLength(15)]
        [Required]
        public string Isbn { get; set; }
        [MaxLength(100)]
        [Required]
        public string Adi { get; set; }
        [Required]
        public DateTime YayinTarih { get; set; }

        public int SayfaSayisi { get; set; }

        [Required]
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }

        [Required]
        public int YayineviId { get; set; }
        public Yayinevi? Yayinevi { get; set; }

        [Required]
        public int YazarId { get; set; }
        public virtual Yazar? Yazar { get; set; }

        public virtual ICollection<KitapKopya>? KitapKopyalari { get; set; }
    }
}
