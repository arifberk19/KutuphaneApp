using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DAL.Concrete
{
    public class KitapKopyaRepository : EfRepostiory<KitapKopya>, IKitapKopyaRepository
    {
        public KitapKopyaRepository(DbContext context) : base(context)
        {
        }
    }
}
