using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Entity.Model;

namespace Kutuphane.DAL.Abstract
{
    public interface IRepository<T> where T : AuditableEntity
    {
        Task<T> GetirID(int id);
        Task<T> Getir(Expression<Func<T, bool>> filtre, params string[] includeParams);
        Task<IEnumerable<T>> Listele(Expression<Func<T, bool>> filtre, params string[] includeParams);
        Task Ekle(T entity);
        Task Guncelle(T entity);
        Task Sil(int id);
    }
}
