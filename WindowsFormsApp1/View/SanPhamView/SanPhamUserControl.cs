using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL; 

namespace WindowsFormsApp1
{
    public partial class SanPhamUserControl : UserControl
    {
        public SanPhamUserControl(int x)
        {
            
            InitializeComponent();
            ShowSP();
            setcbb();
            if (x == 1)
            {
                btadd.Visible = false;
                btdelete.Visible = false;
                btupdate.Visible = false;
            }
            
        }

        public void setcbb()
        {
            cbbSort.Items.Add("Ma San Pham");
            cbbSort.Items.Add("So luong san pham");
            cbbSort.Items.Add("Gia san pham");
        }

        
        public void ShowSP()
        {
            dataGridView1.DataSource = QLSANPHAMBLL.instance.GetSPView(QLSANPHAMBLL.instance.GetListSP());
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void butadd_Click(object sender, EventArgs e)
        {
            ChiTietSP f = new ChiTietSP("",0);
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChiTietSP f = new ChiTietSP("",0);
            f.d = new ChiTietSP.Mydel(ShowSP);
            f.Show(); 
            //ShowSP();
        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ChiTietSP f = new ChiTietSP(dataGridView1.SelectedRows[0].Cells["MSP"].Value.ToString(),0);
                f.d = new ChiTietSP.Mydel(ShowSP);
                f.Show();
            }
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    QLSANPHAMBLL.instance.DellSP(i.Cells["MSP"].Value.ToString());
                }
            };
            ShowSP(); 
        }

        private void btsort_Click(object sender, EventArgs e)
        {
            if (cbbSort.SelectedItem == null)
                MessageBox.Show("Chua chon thuoc tinh sap xep"); 
            else dataGridView1.DataSource = QLSANPHAMBLL.instance.GetSPView(QLSANPHAMBLL.instance.SortSP(cbbSort.SelectedItem.ToString()));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QLSANPHAMBLL.instance.GetSPView(QLSANPHAMBLL.instance.SearchSP(txtSearch.Text));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)
            {
                ChiTietSP f = new ChiTietSP(dataGridView1.SelectedRows[0].Cells["MSP"].Value.ToString(),1);
                f.d = new ChiTietSP.Mydel(ShowSP);
                f.Show();
            }
        }

    }
}
