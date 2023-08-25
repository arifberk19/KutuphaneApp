using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.DAL.Abstract
{
    public interface IUnitOfWork
    {
        IKategoriRepository KategoriRepository { get; }
        IKitapRepository KitapRepository { get; }
        IKitapKopyaRepository KitapKopyaRepository { get; }
        IYazarRepository YazarRepository { get; }
        IYayineviRepository YayineviRepository { get; }
        IPersonelRepository PersonelRepository { get; }
        IUyeRepository UyeRepository { get; }
        IEmanetRepository EmanetRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
