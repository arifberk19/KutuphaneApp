using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Core.DTO;
using Kutuphane.Entity.Model;

namespace Kutuphane.Business.Abstract
{
    public interface IAccountManager : IGenericManager<LoginDto>
    {
        Task<LoginDto?> KullaniciGetir(LoginDto login);
        Task<LoginDto> UyeEkle(Uye uye);
        Task<LoginDto?> UyeGetir(Uye uye);
    }
}