using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1CK.DTO
{
    public class MonAn
    {
        public MonAn()
        {
            this.MonAnNguyenLieus = new HashSet<MonAnNguyenLieu>();
        }
        [Key]
        public int MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public virtual ICollection<MonAnNguyenLieu> MonAnNguyenLieus{get;set;}
    }
}
