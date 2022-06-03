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
using BT1CK.DAL;
using BT1CK.DTO;
using BT1CK.VIEW;

namespace BT1CK
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            setCBBMonAn();
            dataGridView1.DataSource = QLSP_BLL.Instance.getAllSPView();

        }
        public void setCBBMonAn()
        {
            cbbMonAn.Items.Add(new CBBItem
            {
                Value=0,Text="All"
            });
            cbbMonAn.Items.AddRange(QLSP_BLL.Instance.getCbbMonAn().ToArray());
            cbbMonAn.SelectedIndex = 0;
        }
        public void ShowAll(int MaMonAn,string txtsearch)
        {
            dataGridView1.DataSource = QLSP_BLL.Instance.getSPViewBySearch(MaMonAn,txtsearch);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cbbMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QLSP_BLL.Instance.getSPViewByMaMonAn(((CBBItem)(cbbMonAn.SelectedItem)).Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ShowAll(((CBBItem)(cbbMonAn.SelectedItem)).Value, txtSearch.Text);
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    string Ma = i.Cells["Ma"].Value.ToString();
                    QLSP_BLL.Instance.DelSP(Ma);
                }
                ShowAll(0,"");

            }
        }

        private void cbbSort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butSort_Click(object sender, EventArgs e)
        {
            List<SPView> data = new List<SPView>();
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                SPView s = dataGridView1.Rows[i].DataBoundItem as SPView;
                data.Add(s);
            }
            dataGridView1.DataSource = QLSP_BLL.Instance.getSPViewBySort(data, cbbSort.SelectedItem.ToString());

        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2("");
            f.d = new Form2.Mydel(ShowAll);
            f.Show();

        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form2 f = new Form2(dataGridView1.SelectedRows[0].Cells["Ma"].Value.ToString());
                f.d = new Form2.Mydel(ShowAll);
                f.Show();
            }
        }
    }
}
