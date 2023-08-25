using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Business.Abstract
{
    public interface IGenericManager<T>
    {
        Task<T> GetirID(int id);
        Task<T> Getir(Expression<Func<T,bool>> filtre, params string[] includeParams);
        Task<IEnumerable<T>> Listele(Expression<Func<T, bool>> filtre, params string[] includeParams);
        Task<T> Ekle(T entity);
        Task<T> Guncelle(T entity);
        Task Sil(int id);
    }
}
