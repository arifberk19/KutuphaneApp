using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DAL.Concrete
{
    public class KategoriRepository : EfRepostiory<Kategori>, IKategoriRepository
    {
        public KategoriRepository(DbContext context) : base(context)
        {
        }
    }
}
