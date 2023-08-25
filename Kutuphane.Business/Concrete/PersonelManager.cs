using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;

namespace Kutuphane.Business.Concrete
{
    public class PersonelManager : IPersonelManager
    {
        IUnitOfWork UnitOfWork { get; set; }
        public PersonelManager(IUnitOfWork unitOfWork) { 
            UnitOfWork = unitOfWork;
        }
        public async Task<Personel> Ekle(Personel entity)
        {
            await UnitOfWork.PersonelRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Personel> Getir(Expression<Func<Personel, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.PersonelRepository.Getir(filtre, includeParams);
        }

        public async Task<Personel> GetirID(int id)
        {
            return await UnitOfWork.PersonelRepository.GetirID(id);
        }

        public async Task<Personel> Guncelle(Personel entity)
        {
            await UnitOfWork.PersonelRepository.Guncelle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Personel>> Listele(Expression<Func<Personel, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.PersonelRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.PersonelRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}