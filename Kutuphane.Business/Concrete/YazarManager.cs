using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.DAL.Abstract;
using Kutuphane.DAL.Concrete;
using Kutuphane.Entity.Model;

namespace Kutuphane.Business.Concrete
{
    public class YazarManager : IYazarManager
    {
        IUnitOfWork UnitOfWork { get; set; }
        public YazarManager(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public async Task<Yazar> Ekle(Yazar entity)
        {
            await UnitOfWork.YazarRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Yazar> Getir(Expression<Func<Yazar, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.YazarRepository.Getir(filtre, includeParams); 
        }

        public async Task<Yazar> GetirID(int id)
        {
           return await UnitOfWork.YazarRepository.GetirID(id);
        }

        public async Task<Yazar> Guncelle(Yazar entity)
        {
            await UnitOfWork.YazarRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Yazar>> Listele(Expression<Func<Yazar, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.YazarRepository.Listele(filtre, includeParams);         
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.YazarRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
