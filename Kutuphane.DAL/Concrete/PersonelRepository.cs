using Kutuphane.DAL.Abstract;
using Kutuphane.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.DAL.Concrete
{
    public class PersonelRepository : EfRepostiory<Personel>, IPersonelRepository
    {
        public PersonelRepository(DbContext context) : base(context)
        {
        }
    }
}
