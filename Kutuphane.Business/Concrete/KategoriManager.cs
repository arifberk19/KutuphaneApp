using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;

namespace Kutuphane.Business.Concrete
{
    public class KategoriManager : IKategoriManager
    {
        IUnitOfWork UnitOfWork { get; set; }
        public KategoriManager(IUnitOfWork unitOfWork) 
        {
            this.UnitOfWork = unitOfWork;
        }
        public async Task<Kategori> Ekle(Kategori entity)
        {
            await UnitOfWork.KategoriRepository.Ekle(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<Kategori> Getir(Expression<Func<Kategori, bool>> filtre, params string[] includeParams)
        {
            return await UnitOfWork.KategoriRepository.Getir(filtre, includeParams);
        }

        public async Task<Kategori> GetirID(int id)
        {
            return await UnitOfWork.KategoriRepository.GetirID(id);
        }

        public async Task<Kategori> Guncelle(Kategori entity)
        {
            await UnitOfWork.KategoriRepository.Guncelle(entity); 
            await UnitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Kategori>> Listele(Expression<Func<Kategori, bool>> filtre, params string[] includeParams)
        {
           return await UnitOfWork.KategoriRepository.Listele(filtre, includeParams);
        }

        public async Task Sil(int id)
        {
            await UnitOfWork.KategoriRepository.Sil(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Kategori>> Toplam3KategoriGetir()
        {
            var sonuc = await UnitOfWork.KategoriRepository.Listele(x => x.AktifMi == true && x.SilindiMi == false);
            return sonuc.Take(3);
        }
    }
}
