using BT1CK.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1CK.DAL
{
    public class CreateDB : CreateDatabaseIfNotExists<QLSP>
    {
        protected override void Seed(QLSP context)
        {
            context.MonAns.AddRange(new MonAn[]
            {
                new MonAn{MaMonAn=1,TenMonAn="Mi Tom"},
                new MonAn{MaMonAn=2,TenMonAn="My Quang"},
                new MonAn{MaMonAn=3,TenMonAn="Pho Bo"},
                new MonAn{MaMonAn=4,TenMonAn="Che Lien"},
                new MonAn{MaMonAn=5,TenMonAn="Bun Dau Mam Tom"},

            });
            context.NguyenLieus.AddRange(new NguyenLieu[]
            {
                new NguyenLieu{MaNguyenLieu=1,TenNguyenLieu="Mi",TinhTrang=true},
                new NguyenLieu{MaNguyenLieu=2,TenNguyenLieu="Tom",TinhTrang=true},
                new NguyenLieu{MaNguyenLieu=3,TenNguyenLieu="Thit Bo",TinhTrang=true},
                new NguyenLieu{MaNguyenLieu=4,TenNguyenLieu="Sua tuoi",TinhTrang=true},
                new NguyenLieu{MaNguyenLieu=5,TenNguyenLieu="Bun",TinhTrang=true},

            });
            context.MonAnNguyenLieus.AddRange(new MonAnNguyenLieu[]
            {
                new MonAnNguyenLieu{Ma="101",SoLuong=1,DonViTinh="Kg",MaMonAn=1,MaNguyenLieu=1},
                new MonAnNguyenLieu{Ma="102",SoLuong=1,DonViTinh="Kg",MaMonAn=2,MaNguyenLieu=2},
                new MonAnNguyenLieu{Ma="103",SoLuong=1,DonViTinh="Kg",MaMonAn=3,MaNguyenLieu=3},
                new MonAnNguyenLieu{Ma="104",SoLuong=1,DonViTinh="Kg",MaMonAn=4,MaNguyenLieu=4},
                new MonAnNguyenLieu{Ma="105",SoLuong=1,DonViTinh="Kg",MaMonAn=5,MaNguyenLieu=5},
                new MonAnNguyenLieu{Ma="106",SoLuong=1,DonViTinh="Kg",MaMonAn=2,MaNguyenLieu=3},

            });
        }
    }
}
