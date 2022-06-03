using BT1CK.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BT1CK.BLL;

namespace BT1CK.VIEW
{
    public partial class Form2 : Form
    {
        public delegate void Mydel(int a, string b);
        public Mydel d;
        string Ma="";
        public Form2(string m)
        {
            Ma = m;
            InitializeComponent();
            cbbNguyenLieu.Items.AddRange(QLSP_BLL.Instance.getCbbNguyenLieu().ToArray());
            cbbDonViTinh.Items.AddRange(QLSP_BLL.Instance.getcbbDonViTinh().Distinct().ToArray());
            cbbTinhTrang.Items.Add("Đã nhập");
            cbbTinhTrang.Items.Add("Chưa nhập");
            GUI();
        }
        public void GUI()
        {
            if (Ma == "") return;
            MonAnNguyenLieu s= QLSP_BLL.Instance.getSPbyMaSP(Ma);
            foreach(CBBItem i in cbbNguyenLieu.Items)
            {
                if (i.Value == s.MaNguyenLieu)
                {
                    cbbNguyenLieu.SelectedItem = i;
                }
            }
            txtSoLuong.Text = s.SoLuong.ToString();
            foreach(string i in cbbDonViTinh.Items)
            {
                if (i == s.DonViTinh) cbbDonViTinh.SelectedItem = i;
            }
        }
        public MonAnNguyenLieu getTT()
        {

            MonAnNguyenLieu s = null;

            if (Ma!="")
            {
                 s = QLSP_BLL.Instance.getSPbyMaSP(Ma);
            }
            
            
            return new MonAnNguyenLieu
            {
                Ma = Ma,
                SoLuong = Convert.ToInt32(txtSoLuong.Text),
                DonViTinh = cbbDonViTinh.SelectedItem.ToString(),
              //  MaMonAn=s.MaMonAn,
                MaNguyenLieu = ((CBBItem)cbbNguyenLieu.SelectedItem).Value
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {

            QLSP_BLL.Instance.AddUpdate(getTT());
            d(0, "");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (QLSP_BLL.Instance.getTinhTrang(((CBBItem)cbbNguyenLieu.SelectedItem).Value))
            {
                cbbTinhTrang.SelectedItem = "Đã nhập";
            }else
            {
                cbbTinhTrang.SelectedItem = "Chưa nhập";

            }
            cbbTinhTrang.Enabled = false;
        }
    }
}
