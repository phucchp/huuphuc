using BT1CK.DTO;
using System;
using System.Data.Entity;
using System.Linq;

namespace BT1CK.DAL
{
    public class QLSP : DbContext
    {

        public QLSP()
            : base("name=QLSP")
        {
            Database.SetInitializer<QLSP>(new CreateDB());
        }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieus { get; set; }
        public virtual DbSet<MonAnNguyenLieu> MonAnNguyenLieus { get; set; }

    }

}