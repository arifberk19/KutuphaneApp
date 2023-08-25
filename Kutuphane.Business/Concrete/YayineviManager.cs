using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;

namespace Kutuphane.Business.Concrete
{
    public class YayineviManager : IYayineviManager
    {
        IUnitOfWork UnitOfWork { get; set; }
        public YayineviManager(IUnitOfWork unitOfWork) 
        { 
            UnitOfWork = unitOfWork;
        }
        public async Task<Yayinevi> Ekle(Yayinevi entity)
        {
            await UnitOfWork.YayineviRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Yayinevi> Getir(Expression<Func<Yayinevi, bool>> filtre, params string[] includeParams)
        {
           return await UnitOfWork.YayineviRepository.Getir(filtre, includeParams);
        }

        public async Task<Yayinevi> GetirID(int id)
        {
           return await UnitOfWork.YayineviRepository.GetirID(id);

        }

        public async Task<Yayinevi> Guncelle(Yayinevi entity)
        {
            await UnitOfWork.YayineviRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Yayinevi>> Listele(Expression<Func<Yayinevi, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.YayineviRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.YayineviRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();

        }
    }
}
