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
    public partial class Nhanvienusercontrol : UserControl
    {
        public Nhanvienusercontrol()
        {
            InitializeComponent();
            showNV();
            setcbb(); 
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void setcbb()
        {
            cbbSort.Items.Add("Ma Nhan Vien");
            cbbSort.Items.Add("Ten Nhan Vien");
            cbbSort.Items.Add("Luong co ban");

        }
        public void showNV()
        {
            dataGridView1.DataSource = QLNHANVIENBLL.instance.GetNhanvienViews(QLNHANVIENBLL.instance.GetListNhanVien());
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            AddNV f = new AddNV("",0);
            f.d = new AddNV.Mydel(showNV);

            f.Show();
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                AddNV f = new AddNV(dataGridView1.SelectedRows[0].Cells["MaNV"].Value.ToString(),0);
                f.d = new AddNV.Mydel(showNV);
                f.Show();
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    QLNHANVIENBLL.instance.DelNV(i.Cells["MaNV"].Value.ToString());
                }
            }
            showNV();
        }

        private void butSort_Click(object sender, EventArgs e)
        {
            if (cbbSort.SelectedItem == null)
                MessageBox.Show("Chua chon thuoc tinh sap xep");
            else 
            dataGridView1.DataSource = QLNHANVIENBLL.instance.GetNhanvienViews(QLNHANVIENBLL.instance.SortNV(cbbSort.SelectedItem.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QLNHANVIENBLL.instance.GetNhanvienViews(QLNHANVIENBLL.instance.SeachNV(txtSearch.Text));
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                AddNV f = new AddNV(dataGridView1.SelectedRows[0].Cells["MaNV"].Value.ToString(), 1);
                f.d = new AddNV.Mydel(showNV);
                f.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            QLNHANVIENBLL.instance.resetLuong();
            showNV();
        }
    }
}
