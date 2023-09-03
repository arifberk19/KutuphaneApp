
using Kutuphane.DAL.Abstract;
using Kutuphane.DAL.EntityFramework;
using Kutuphane.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DAL.Concrete
{
    public class EfUnitOfWork : IUnitOfWork
    {
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public KutuphaneContext KutuphaneContext { get; set; }
        public EfUnitOfWork(IHttpContextAccessor httpContextAccessor, KutuphaneContext kutuphaneContext)
        {
            KutuphaneContext = kutuphaneContext;
            HttpContextAccessor = httpContextAccessor;

            KategoriRepository = new KategoriRepository(kutuphaneContext);
            KitapRepository = new KitapRepository(kutuphaneContext);
            KitapKopyaRepository = new KitapKopyaRepository(kutuphaneContext);
            PersonelRepository = new PersonelRepository(kutuphaneContext);
            UyeRepository = new UyeRepository(kutuphaneContext);
            YayineviRepository = new YayineviRepository(kutuphaneContext);
            YazarRepository = new YazarRepository(kutuphaneContext);
            EmanetRepository = new EmanetRepository(kutuphaneContext);

        }

        public IKategoriRepository KategoriRepository { get; }
        public IKitapRepository KitapRepository { get; }
        public IKitapKopyaRepository KitapKopyaRepository { get; }
        public IPersonelRepository PersonelRepository { get; }
        public IUyeRepository UyeRepository { get; }
        public IYayineviRepository YayineviRepository { get; }
        public IYazarRepository YazarRepository { get; }
        public IEmanetRepository EmanetRepository { get; }


        public async Task<int> SaveChangesAsync()
        {
            foreach (var entity in KutuphaneContext.ChangeTracker.Entries<AuditableEntity>())
            {
                if(entity.State == EntityState.Added)
                {
                    entity.Entity.EkleyenPersonelId = 1;
                    entity.Entity.EklenmeTarihi = DateTime.Now;
                    if (entity.Entity.AktifMi == null)
                        entity.Entity.AktifMi = true;
                    entity.Entity.SilindiMi = false;
                }
                if(entity.State == EntityState.Modified)
                {
                    entity.Entity.GuncellenmeTarihi = DateTime.Now;

                }
            }
            var sonuc = await KutuphaneContext.SaveChangesAsync();
            return sonuc;
        }
    }
}
