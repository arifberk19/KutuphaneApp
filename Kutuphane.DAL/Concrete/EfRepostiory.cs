using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.DAL.Abstract;
using Kutuphane.DAL.EntityFramework;
using Kutuphane.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DAL.Concrete
{
    public class EfRepostiory<T> : IRepository<T> where T : AuditableEntity
    {
        private readonly DbContext Context;
        private readonly DbSet<T> DbSet;
        public EfRepostiory(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task Ekle(T entity)
        {
            await Task.Run(() =>
            {
                DbSet.AddAsync(entity);
            });
        }

        public async Task<T> Getir(Expression<Func<T, bool>> filtre, params string[] includeParams)
        {
            IQueryable<T> query = DbSet;

            if (filtre != null)
                query = query.Where(filtre);

            if (includeParams.Length > 0)
            {
                foreach (var param in includeParams)
                {
                  query = query.Include(param);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetirID(int id)
        {
            IQueryable<T> query = DbSet;
            return await query.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task Guncelle(T entity)
        {
            var entity2 = await GetirID(entity.ID);
            Context.Entry<T>(entity2).State = EntityState.Detached;
            await Task.Run(() => { DbSet.Update(entity); });
        }

        public async Task<IEnumerable<T>> Listele(Expression<Func<T, bool>> filtre, params string[] includeParams)
        {
            IQueryable<T> query = DbSet;

            if (filtre != null)
                query = query.Where(filtre);

            if (includeParams.Length > 0)
            {
                foreach (var param in includeParams)
                {
                    query = query.Include(param);
                }
            }
            return await Task.Run(()=> query);
        }

        public async Task Sil(int id)
        {
            var entity = await GetirID(id);
            entity.SilindiMi = true;
            await Task.Run(() => { DbSet.Update(entity); });

        }
    }
}
