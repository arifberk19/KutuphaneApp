using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;

namespace Kutuphane.Business.Concrete
{
    public class KitapManager : IKitapManager
    {
        IUnitOfWork UnitOfWork { get; set; }
        public KitapManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<Kitap> Ekle(Kitap entity)
        {
            await UnitOfWork.KitapRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Kitap> Getir(Expression<Func<Kitap, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.KitapRepository.Getir(filtre, includeParams);
        }

        public async Task<Kitap> GetirID(int id)
        {
            return await UnitOfWork.KitapRepository.GetirID(id);
        }

        public async Task<Kitap> Guncelle(Kitap entity)
        {
            await UnitOfWork.KitapRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Kitap>> Listele(Expression<Func<Kitap, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.KitapRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.KitapRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}