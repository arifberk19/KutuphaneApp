using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;
using Kutuphane.Business.Concrete;
using Kutuphane.Core.DTO;

namespace Kutuphane.Business.Concrete
{
    public class AccountManager : IAccountManager
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public AccountManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<LoginDto?> KullaniciGetir(LoginDto login)
        {
            var uye = await UnitOfWork.UyeRepository
                .Getir(x => x.SilindiMi == false && x.AktifMi == true && x.Email == login.Email && x.Sifre == login.Sifre);
            if (uye != null)
                login = new LoginDto { AdSoyad = uye.AdSoyad, ID = uye.ID, Email = uye.Email };
            else
            {
                var personel = await UnitOfWork.PersonelRepository
                    .Getir(x => x.SilindiMi == false && x.AktifMi == true && x.Email == login.Email && x.Sifre == login.Sifre);
                if (personel != null)
                    login = new LoginDto { AdSoyad = personel.AdSoyad, ID = personel.ID, Email = personel.Email };
                else
                    login = null;
            }
            return login;
        }

        public Task<LoginDto> GetirID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginDto> Getir(Expression<Func<LoginDto, bool>> filtre, params string[] includeParams)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoginDto>> Listele(Expression<Func<LoginDto, bool>> filtre, params string[] includeParams)
        {
            throw new NotImplementedException();
        }

        public Task<LoginDto> Ekle(LoginDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<LoginDto> Guncelle(LoginDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Sil(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginDto> UyeEkle(Uye uye)
        {
            await UnitOfWork.UyeRepository.Ekle(uye);
            await UnitOfWork.SaveChangesAsync();
            return new LoginDto { AdSoyad = uye.AdSoyad, ID = uye.ID, Email = uye.Email };
        }

        public async Task<LoginDto?> UyeGetir(Uye uye)
        {
            var mus = await UnitOfWork.UyeRepository.Getir(x => x.SilindiMi == false && x.AktifMi == true && x.Email == uye.Email && x.Sifre == uye.Sifre);
            LoginDto login = null;
            if (mus != null)
                login = new LoginDto { AdSoyad = uye.AdSoyad, ID = uye.ID, Email = uye.Email };
            return login;
        }
    }
}

