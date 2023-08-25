using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;

namespace Kutuphane.Business.Concrete
{
    public class KitapKopyaManager : IKitapKopyaManager
    {
        IUnitOfWork UnitOfWork { get; set; }
        public KitapKopyaManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<KitapKopya> Ekle(KitapKopya entity)
        {
            await UnitOfWork.KitapKopyaRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<KitapKopya> Getir(Expression<Func<KitapKopya, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.KitapKopyaRepository.Getir(filtre, includeParams);
        }

        public async Task<KitapKopya> GetirID(int id)
        {
            return await UnitOfWork.KitapKopyaRepository.GetirID(id);
        }

        public async Task<KitapKopya> Guncelle(KitapKopya entity)
        {
            await UnitOfWork.KitapKopyaRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<KitapKopya>> Listele(Expression<Func<KitapKopya, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.KitapKopyaRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.KitapKopyaRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Rezerve(KitapKopya entity, int uyeId)
        {
            var kitapKopya = await UnitOfWork.KitapKopyaRepository.GetirID(entity.ID);
            if (kitapKopya != null && !(kitapKopya.RezerveBitisTarihi > DateTime.Now))
            {
                kitapKopya.EnSonRezerveEdenUyeId = uyeId;
                kitapKopya.RezerveBitisTarihi = DateTime.Now.AddHours(3);
                await UnitOfWork.KitapKopyaRepository.Guncelle(entity);
                await UnitOfWork.SaveChangesAsync();
            }
        }
    }
}