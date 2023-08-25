using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Entity.Model
{
    [Table("Kategori")]
    public class Kategori : AuditableEntity
    {
        public Kategori()
        {
            Kitaplar = new HashSet<Kitap>();
        }

        [MaxLength(50)]
        [Required]
        public string Adi { get; set; }

        public virtual ICollection<Kitap>? Kitaplar { get; set; }
    }
}
