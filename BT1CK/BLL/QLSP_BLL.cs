using BT1CK.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT1CK.DTO;

namespace BT1CK.BLL
{
    public class QLSP_BLL
    {
        QLSP db = new QLSP();
        private static QLSP_BLL _Instance;

        public static QLSP_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QLSP_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        public List<CBBItem> getCbbMonAn()
        {
            List<CBBItem> data = new List<CBBItem>();
            foreach(var i in db.MonAns.Select(p => p))
            {
                data.Add(new CBBItem {Value= i.MaMonAn,Text=i.TenMonAn });
            }
            return data;
        }
        public List<SPView> getAllSPView()
        {
            List<SPView> data = new List<SPView>();
            foreach(var i in db.MonAnNguyenLieus.Select(p => p))
            {
                data.Add(new SPView
                {
                    Ma=i.Ma,
                    TenNguyenLieu=i.NguyenLieu.TenNguyenLieu,
                    SoLuong=i.SoLuong,
                    DonViTinh=i.DonViTinh,
                    TinhTrang=i.NguyenLieu.TinhTrang
                });
            }
            return data;
        }
        public List<SPView> getSPViewByMaMonAn(int MaMonAn)
        {
            List<SPView> data = new List<SPView>();
            if (MaMonAn == 0)
            {
                return getAllSPView();
            }
            foreach (var i in db.MonAnNguyenLieus.Select(p => p))
            {
               if(i.MaMonAn == MaMonAn)
                {
                    data.Add(new SPView
                    {
                        Ma = i.Ma,
                        TenNguyenLieu = i.NguyenLieu.TenNguyenLieu,
                        SoLuong = i.SoLuong,
                        DonViTinh = i.DonViTinh,
                        TinhTrang = i.NguyenLieu.TinhTrang
                    });
                }
            }
            return data;
        }
        public List<SPView> getSPViewBySearch(int MaMonAn,string txtSearch)
        {
            List<SPView> data = new List<SPView>();
            foreach(SPView i in getSPViewByMaMonAn(MaMonAn))
            {
                if (i.TenNguyenLieu.Contains(txtSearch))
                {
                    data.Add(i);
                }
            }
            return data;
        }
        public void DelSP(string Ma)
        {
            var c= db.MonAnNguyenLieus.Find(Ma);
            db.MonAnNguyenLieus.Remove(c);
            db.SaveChanges();
        }
        public List<SPView> getSPViewBySort(List<SPView> list,string txtSort)
        {
            List<SPView> data = new List<SPView>();
            if(txtSort=="Tên Nguyên Liệu")
            {
                data = list.OrderBy(p => p.TenNguyenLieu).ToList();
            }else if(txtSort=="Tình Trạng")
            {
                data = list.OrderBy(p => p.TinhTrang).ToList();
            }
            else if(txtSort=="Số Lượng")
            {
                data = list.OrderBy(p => p.SoLuong).ToList();
            }
            else if(txtSort=="Đơn Vị Tính")
            {
                data = list.OrderBy(p => p.DonViTinh).ToList();
            }
            return data;
        }
        // form2
        public List<CBBItem> getCbbNguyenLieu()
        {
            List<CBBItem> data = new List<CBBItem>();
            foreach (var i in db.NguyenLieus.Select(p => p))
            {
                data.Add(new CBBItem { Value = i.MaNguyenLieu, Text = i.TenNguyenLieu });
            }
            return data;
        }
        public  List<string> getcbbDonViTinh(){
            List<string> data = new List<string>();
            foreach(var i in db.MonAnNguyenLieus.Select(p => p)){
                data.Add(i.DonViTinh);
            }
            return data;
        }
        public bool getTinhTrang(int MaNguyenLieu)
        {
            var c = db.NguyenLieus.Find(MaNguyenLieu);
            if (c.TinhTrang) return true;
            return false;
        }
        public bool CheckAddUpdate(string Ma)
        {
            if (Ma == "") return false;
            return true;
        }
        public void UpdateBLL(MonAnNguyenLieu s)
        {
            var c = db.MonAnNguyenLieus.Find(s.Ma);
            c.SoLuong = s.SoLuong;
            c.DonViTinh = s.DonViTinh;
            c.MaNguyenLieu = s.MaNguyenLieu;
            db.SaveChanges();

        }
        public void AddBLL(MonAnNguyenLieu s)
        {
            foreach(var i in db.MonAnNguyenLieus.Select(p => p))
            {
                s.Ma=Convert.ToString(Convert.ToInt32(i.Ma) + 1);
            }
            db.MonAnNguyenLieus.Add(s);
            db.SaveChanges();
        }
        public void AddUpdate(MonAnNguyenLieu s)
        {
            if (CheckAddUpdate(s.Ma))
            {
                UpdateBLL(s);
            }
            else
            {
                AddBLL(s);
            }
        }
        public MonAnNguyenLieu getSPbyMaSP(string MaSP)
        {
            var c = db.MonAnNguyenLieus.Find(MaSP);
            return new MonAnNguyenLieu
            {
                Ma=c.Ma,
                SoLuong=c.SoLuong,
                DonViTinh=c.DonViTinh,
                MaMonAn=c.MaMonAn,
                MaNguyenLieu=c.MaNguyenLieu
            };
        }
    }
}
