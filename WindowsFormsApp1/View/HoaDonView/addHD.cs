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
    public partial class addHD : Form
    {
        public string MA = "";
        public string MB = "";
        public int check = 0; 
        public List<ChiTietHoaDonView> list = new List<ChiTietHoaDonView>() ;
        
        public delegate void Mydel();
        public Mydel d { get; set; }
        

        public addHD(string Ma,string Mb,int x)
        {
            InitializeComponent();
            //txtmagiamgia.Enabled = true;
            MA = Ma;
            MB = Mb;    
            GUI(x);
            txtidnv.Enabled = false;
            txtidhoadon.Enabled = false;
            txtnamenv.Enabled = false;
            txtday.Enabled = false;
           
        }
        public void GUI(int a)
        {
            if (a == 0)
            {
                txtidnv.Text = MA;
                txtnamenv.Text = QLNHANVIENBLL.instance.GetNVByMaNV(MA).Name;
                txtday.Text = DateTime.Now.ToString();
                txtidhoadon.Text = QLHDBLL.instance.GetMaHDLast().ToString();
                foreach (SanPham i in QLSANPHAMBLL.instance.GetListSP())
                {
                    cbidsp.Items.Add(i.TenSP);
                }
            }
            if (a == 1 )
            {

                txtidnv.Text = MA;
                txtnamenv.Text = QLNHANVIENBLL.instance.GetNVByMaNV(MA).Name;
                txtidhoadon.Text = MB;
                txttongtien.Text = QLHDBLL.instance.GetHDbyMAHD(MB).TongTien.ToString();
                txtday.Text = QLHDBLL.instance.GetHDbyMAHD(MB).NgayThang.ToString();
                dataGridView1.DataSource = QLHDBLL.instance.GetChiTietHoaDonViews(QLHDBLL.instance.searchhd(txtidhoadon.Text));
                txtmagiamgia.Text= QLHDBLL.instance.GetHDbyMAHD(MB).MGG.ToString();
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                cbidsp.Visible = false;
                txtnamesp.Visible = false;
                updownsize.Visible = false;
                updownsl.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                btcheck.Enabled = false;
                txtmagiamgia.Enabled = false;
                button3.Visible = false;
             
                

            }    
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbidsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtnamesp.Text = QLSANPHAMBLL.instance.GetMaSPbyTenSP(cbidsp.SelectedItem.ToString());
            updownsl.Maximum = (QLSANPHAMBLL.instance.GetSLSPByMSPandSize(QLSANPHAMBLL.instance.GetMaSPbyTenSP(cbidsp.SelectedItem.ToString()), Convert.ToInt32(updownsize.Value)));
            updownsl.Minimum = 0;
        }

        private void updownsize_ValueChanged(object sender, EventArgs e)
        {
            updownsl.Maximum=(QLSANPHAMBLL.instance.GetSLSPByMSPandSize(QLSANPHAMBLL.instance.GetMaSPbyTenSP(cbidsp.SelectedItem.ToString()), Convert.ToInt32( updownsize.Value)));
            updownsl.Minimum = 0; 
        }
        public void Show(List<ChiTietHoaDonView>  a)
        {
            dataGridView1.DataSource = null; 
            dataGridView1.DataSource = a;
            txttongtien.Text = Total().ToString();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public int Total ()
        {
            int tong = 0;
            foreach (ChiTietHoaDonView i in list)
            {
                tong = tong + i.TongTien;
            }
            return tong; 
        }
        public int TotalSLSP()
        {
            int dem = 0;
            foreach (ChiTietHoaDonView i in list)
            {
                dem = dem + i.SoLuong;
            }
            return dem;
        }
        public void Check(string MASP, int size)
        {
            try
            {
                foreach (ChiTietHoaDonView i in list)
                {
                    if (QLSANPHAMBLL.instance.GetMaSPbyTenSP(i.NameSP) == MASP && i.Size == size)

                    { 
                        list.Remove(i);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbidsp.SelectedIndex == -1)
                MessageBox.Show("San pham rong");
            else if(updownsl.Value == 0)
                MessageBox.Show("So luong san pham phai lon hon 0");

            else
            {
                Check(txtnamesp.Text, Convert.ToInt32(updownsize.Value));

                list.Add(new ChiTietHoaDonView { NameSP =cbidsp.SelectedItem.ToString(), Size = Convert.ToInt32(updownsize.Value), SoLuong = Convert.ToInt32(updownsl.Value), GiaThanh = QLHDBLL.instance.GetGiaThanhByMaSP(QLSANPHAMBLL.instance.GetMaSPbyTenSP(cbidsp.SelectedItem.ToString())), TongTien = QLHDBLL.instance.GetGiaThanhByMaSP(QLSANPHAMBLL.instance.GetMaSPbyTenSP(cbidsp.SelectedItem.ToString())) * Convert.ToInt32(updownsl.Value) });
                Show(list);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                    list.RemoveAt(i.Index); 
            }
            Show(list); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            {
                if (TotalSLSP()== 0)
                {
                    MessageBox.Show("Danh sach san pham rong");
                }
                else
                {

                    QLHDBLL.instance.AddHoaDon(new HoaDon { MaHD = txtidhoadon.Text, MaNV = MA, TongSL = TotalSLSP(), TongTien = Convert.ToInt32(txttongtien.Text), NgayThang = DateTime.Now,MGG=txtmagiamgia.Text });
                    foreach (ChiTietHoaDonView i in list)
                    {
                        QLHDBLL.instance.AddChitiethoadon(new ChiTietHoaDon { MaHD = txtidhoadon.Text, MSP = QLSANPHAMBLL.instance.GetMaSPbyTenSP(i.NameSP), Size = i.Size, SoLuong = i.SoLuong });
                        QLHDBLL.instance.AddSLSP(new SoLuongSP { MSP = QLSANPHAMBLL.instance.GetMaSPbyTenSP(i.NameSP), Size = i.Size, SoLuong = QLSANPHAMBLL.instance.GetSLSPByMSPandSize(QLSANPHAMBLL.instance.GetMaSPbyTenSP(i.NameSP), i.Size) - i.SoLuong }); ;
                        QLSANPHAMBLL.instance.UpdateTongSLSPbyMaSP(QLSANPHAMBLL.instance.GetMaSPbyTenSP(i.NameSP), i.SoLuong);
                    }
                    QLDOANHTHUBLL.instance.AddDoanhThu(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, new DoanhThu { NgayThang = DateTime.Now, Tongtien = Total() });
                    d();
                    
                    if (Convert.ToInt32(txttongtien.Text) > 1000000)
                    {
                        EmployeeForm.Instance.panel4_.Controls["MaGiamGia_user"].BringToFront();
                    }
                    this.Close();
                };
            }
            //catch (Exception i)
            //{
                //MessageBox.Show("Nhap thong tin loi"); 
            //}
            
        }

        private void btcheck_Click(object sender, EventArgs e)
        {
            if (check == 0)
            {
                if (QLHDBLL.instance.GetphantranbyMGG(txtmagiamgia.Text) != 0)
                {
                    txttongtien.Text = (Convert.ToInt32(txttongtien.Text) - Convert.ToInt32(txttongtien.Text) * QLHDBLL.instance.GetphantranbyMGG(txtmagiamgia.Text) / 100).ToString();
                    check = 1;
                    btcheck.Enabled = false; 
                    txtmagiamgia.Enabled = false;
                    QLHDBLL.instance.DelMGG(txtmagiamgia.Text);
                }
                else
                {
                    MessageBox.Show("Ma Giam Gia khong ton tai");
                    txtmagiamgia.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Hoa don nay da ap dung ma giam gia");
                txtmagiamgia.Text = "";
            }

        }

    }
}
