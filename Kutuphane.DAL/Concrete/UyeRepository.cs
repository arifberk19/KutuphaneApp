using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DAL.Concrete
{
    public class UyeRepository : EfRepostiory<Uye>, IUyeRepository
    {
        public UyeRepository(DbContext context) : base(context)
        {
        }
    }
}