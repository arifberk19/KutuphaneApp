using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Entity.Model
{
    [Table("Yazar")]
    public class Yazar : AuditableEntity
    {
        public Yazar()
        {
            Kitaplar = new HashSet<Kitap>();
        }

        [Required]
        [StringLength(50)]
        public string Adi { get; set; }
        [Required]
        [StringLength(50)]
        public string Soyadi { get; set; }

        public virtual ICollection<Kitap>? Kitaplar { get; set; }
    }
}
