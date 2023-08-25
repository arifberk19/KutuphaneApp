using Kutuphane.Entity.Model;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.WebUI.Models
{
    public class KitapDto : BaseDto
    {
        public string Isbn { get; set; }
        public string Adi { get; set; }
        public DateTime YayinTarih { get; set; }
        public int SayfaSayisi { get; set; }
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }
        public int YayineviId { get; set; }
        public Yayinevi? Yayinevi { get; set; }
        public int YazarId { get; set; }
        public Yazar? Yazar { get; set; }

        public virtual ICollection<KitapKopya>? KitapKopyalari { get; set; }
    }
}
