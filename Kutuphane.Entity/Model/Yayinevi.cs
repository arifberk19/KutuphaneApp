using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Entity.Model
{
    [Table("Yayinevi")]
    public class Yayinevi : AuditableEntity
    {
        public Yayinevi()
        {
            Kitaplar = new HashSet<Kitap>();
        }

        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }
        [Required]
        [MaxLength(250)]
        public string Adres { get; set; }

        [Required]
        [MaxLength(11)]
        public string Telefon { get; set; }

        public virtual ICollection<Kitap>? Kitaplar { get; set; }
    }
}
