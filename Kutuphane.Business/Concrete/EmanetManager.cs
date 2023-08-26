using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;

namespace Kutuphane.Business.Concrete
{
    public class EmanetManager : IEmanetManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public EmanetManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Emanet> Ekle(Emanet entity)
        {
            var bostaRezerveKopya = await UnitOfWork.KitapKopyaRepository.Getir(x=>x.ID ==  entity.KitapKopyaId && x.SilindiMi == false && x.AktifMi == true && 
            !(x.RezerveBitisTarihi>DateTime.Now));
            if(bostaRezerveKopya != null)
            {
                return null;
            }
            var emanetteKopya = await UnitOfWork.EmanetRepository.Getir(x => x.KitapKopyaId == entity.KitapKopyaId && x.TeslimTarih == null);
            if(emanetteKopya != null)
            {
                return null;
            }
            await UnitOfWork.EmanetRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Emanet> Getir(Expression<Func<Emanet, bool>> filtre, params string[] includeParams)
        {
           
            return await UnitOfWork.EmanetRepository.Getir(filtre, includeParams);
        }

        public async Task<Emanet> GetirID(int id)
        {
            return await UnitOfWork.EmanetRepository.GetirID(id);
        }

        public async Task<Emanet> Guncelle(Emanet entity)
        {
            await UnitOfWork.EmanetRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Emanet>> Listele(Expression<Func<Emanet, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.EmanetRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.EmanetRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
} 
