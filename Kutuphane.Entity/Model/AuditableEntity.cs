using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Entity.Model
{
    public class AuditableEntity : BaseEntity
    {
		public int? EkleyenPersonelId { get; set; }
		public int? GuncelleyenPersonelId { get; set; }
		public DateTime EklenmeTarihi { get; set; }
		public DateTime? GuncellenmeTarihi { get; set; }
    }
}
