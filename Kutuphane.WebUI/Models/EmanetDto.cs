using Kutuphane.Entity.Model;

namespace Kutuphane.WebUI.Models
{
    public class EmanetDto :BaseDto
    {
        public DateTime EmanetTarih { get; set; }
        public DateTime? TeslimTarih { get; set; }
        public DateTime SonTeslimTarih { get; set; }
        public int KitapKopyaId { get; set; }
        public KitapKopya? KitapKopya { get; set; }
        public int kategoriId { get; set; }
        public int UyeId { get; set; }
        public Uye? Uye { get; set; }
        public int PersonelId { get; set; }
        public Personel? Personel { get; set; }
    }
}
