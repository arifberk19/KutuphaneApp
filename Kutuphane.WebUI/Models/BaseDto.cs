namespace Kutuphane.WebUI.Models
{
    public class BaseDto
    {
        public int ID { get; set; }
        public bool? SilindiMi { get; set; }
        public bool? AktifMi { get; set; }
        public int? EkleyenPersonelId { get; set; }
        public int? GuncelleyenPersonelId { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime? GuncellenmeTarihi { get; set; }
    }
}