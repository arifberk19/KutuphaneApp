using Kutuphane.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DAL.EntityFramework
{
    public class KutuphaneContext : DbContext
    {
        public KutuphaneContext() : base()
        {

        }

        public KutuphaneContext(DbContextOptions<KutuphaneContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=KutuphaneDB;Trusted_Connection=True;");
            }
        }
        public DbSet<Personel>? Personeller { get; set; }
        public DbSet<Uye>? Uyeler { get; set; }
        public DbSet<Yazar>? Yazarlar { get; set; }
        public DbSet<Kitap>? Kitaplar { get; set; }
        public DbSet<Kategori>? Kategoriler { get; set; }
        public DbSet<Emanet>? Emanetler { get; set; }
        public DbSet<KitapKopya>? KitapKopyalar { get; set; }
        public DbSet<Yayinevi>? Yayinevler { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KitapKopya>()
                .HasOne(r => r.EnSonRezerveEdenUye)
                .WithMany(r => r.RezerveKitaplar)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
