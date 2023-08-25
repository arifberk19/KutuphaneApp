using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DAL.Concrete
{
    public class YayineviRepository : EfRepostiory<Yayinevi>, IYayineviRepository
    {
        public YayineviRepository(DbContext context) : base(context)
        {
        }
    }
}

