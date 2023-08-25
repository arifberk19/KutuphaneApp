using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;

namespace Kutuphane.Business.Concrete
{
    public class UyeManager : IUyeManager
    {
        private IUnitOfWork UnitOfWork { get; set; }
        public UyeManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<Uye> Ekle(Uye entity)
        {
            await UnitOfWork.UyeRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Uye> Getir(Expression<Func<Uye, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.UyeRepository.Getir(filtre, includeParams);
        }

        public async Task<Uye> GetirID(int id)
        {
            return await UnitOfWork.UyeRepository.GetirID(id);
        }

        public async Task<Uye> Guncelle(Uye entity)
        {
            await UnitOfWork.UyeRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Uye>> Listele(Expression<Func<Uye, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.UyeRepository.Listele(filtre, includeParams);

        }

        public async Task Sil(int id)
        {
            await UnitOfWork.UyeRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
