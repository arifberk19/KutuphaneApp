using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DAL.Concrete
{
    public class EmanetRepository : EfRepostiory<Emanet>, IEmanetRepository
    {
        public EmanetRepository(DbContext context) : base(context)
        {
        }
    }
}

