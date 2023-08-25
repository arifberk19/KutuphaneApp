using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DAL.Concrete
{
    public class YazarRepository : EfRepostiory<Yazar>, IYazarRepository
    {
        public YazarRepository(DbContext context) : base(context)
        {
        }
    }
}

