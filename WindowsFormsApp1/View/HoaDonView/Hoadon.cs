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
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1
{
    public partial class Hoadon : UserControl
    {
        // QLSHOPBLL QL = new QLSHOPBLL(); 
        public string MA = ""; 
        public Hoadon(string MA1,int x)
        {
            MA = MA1; 
            InitializeComponent();
            showHD();
            setcbb();
            if(x ==1)
            {
                button5.Visible = false;
            }    
        }

        public void setcbb()
        {
            cbbSort.Items.Add("Ma hoa don");
            cbbSort.Items.Add("Tong so luong");
            cbbSort.Items.Add("Tong tien");
            datefrom.MaxDate = DateTime.Now;
            datefrom.MinDate = QLHDBLL.instance.GetDayTimeFrom(); 
            datefrom.Value= QLHDBLL.instance.GetDayTimeFrom();
            dateend.MaxDate = DateTime.Now;
            dateend.MinDate = QLHDBLL.instance.GetDayTimeFrom();
        }
        public void GUI()
        {
           // txt
        }
        public void showHD()
        {
            dataGridView1.DataSource = QLHDBLL.instance.GetHoaDonView(QLHDBLL.instance.sortMaHD());

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            addHD a = new addHD(MA,"",0);
            a.d = new addHD.Mydel(showHD);
            a.Show();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QLACCOUNTQLL.instance.GetListacc(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    QLHDBLL.instance.DelHD(i.Cells["MaHD"].Value.ToString());
                }
            }
            showHD(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (cbbSort.SelectedItem == null)
                MessageBox.Show("Chua chon thuoc tinh sap xep");
            else dataGridView1.DataSource = QLHDBLL.instance.GetHoaDonView(QLHDBLL.instance.SortHD(cbbSort.SelectedItem.ToString()));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QLHDBLL.instance.GetHoaDonView(QLHDBLL.instance.SearchHD(txtSearch.Text));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string a = QLNHANVIENBLL.instance.GetMaNVByName(dataGridView1.SelectedRows[0].Cells["TenNV"].Value.ToString());
                addHD f = new addHD(a, dataGridView1.SelectedRows[0].Cells["MaHD"].Value.ToString(), 1);
                f.d = new addHD.Mydel(showHD);
                f.Show();
            }
        }


        private void datefrom_ValueChanged(object sender, EventArgs e)
        {
            
            if (datefrom.Value.Year> dateend.Value.Year || 
                (datefrom.Value.Year>= dateend.Value.Year && datefrom.Value.Month> dateend.Value.Month) ||
                (datefrom.Value.Year >= dateend.Value.Year && datefrom.Value.Month >= dateend.Value.Month && datefrom.Value.Day > dateend.Value.Day))
            {
                MessageBox.Show("Day from bigger than Day End "); 
            }
            else
            {
                dataGridView1.DataSource = QLHDBLL.instance.GetHoaDonView(QLHDBLL.instance.GetListHDbyDay(datefrom.Value,dateend.Value));
            }
        }

        private void dateend_ValueChanged(object sender, EventArgs e)
        {
            if (datefrom.Value.Year > dateend.Value.Year ||
                (datefrom.Value.Year >= dateend.Value.Year && datefrom.Value.Month > dateend.Value.Month) ||
                (datefrom.Value.Year >= dateend.Value.Year && datefrom.Value.Month >= dateend.Value.Month && datefrom.Value.Day > dateend.Value.Day))
            {
                MessageBox.Show("Day from bigger than Day End ");
            }
            else
            {
                dataGridView1.DataSource = QLHDBLL.instance.GetHoaDonView(QLHDBLL.instance.GetListHDbyDay(datefrom.Value, dateend.Value));
            }
        }
    }
}
