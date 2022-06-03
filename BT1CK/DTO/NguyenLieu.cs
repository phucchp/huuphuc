using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BT1CK.DTO
{
    public class NguyenLieu
    {
        public NguyenLieu()
        {
            this.MonAnNguyenLieus = new HashSet<MonAnNguyenLieu>();
        }
        [Key]
        public int MaNguyenLieu { get; set; }
        public string TenNguyenLieu { get; set; }
        public bool TinhTrang { get; set; }
        public virtual ICollection<MonAnNguyenLieu> MonAnNguyenLieus { get; set; }

    }
}
