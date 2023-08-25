using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DAL.Concrete
{
    public class KitapRepository : EfRepostiory<Kitap>, IKitapRepository
    {
        public KitapRepository(DbContext context) : base(context)
        {
        }
    }
}

