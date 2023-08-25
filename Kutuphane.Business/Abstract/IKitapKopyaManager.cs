using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.Entity.Model;

namespace Kutuphane.Business.Abstract
{
    public interface IKitapKopyaManager : IGenericManager<KitapKopya>
    {
        Task Rezerve(KitapKopya entity, int uyeId); 
    }
}
