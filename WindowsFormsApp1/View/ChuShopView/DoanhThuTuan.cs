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
    public partial class DoanhThuTuan : UserControl
    {
        public DoanhThuTuan()
        {
            InitializeComponent();
            Loaddl(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["DoanhThuThang"].BringToFront();
        }
        private void Loaddl()
        {
            int d=0;
            int thang = DateTime.Now.Month; 
            int nam=DateTime.Now.Year;
            int ngay=DateTime.Now.Day;
            if (ngay <=7) d = 1;
            else if (ngay <= 14) d = 2;
            else if (ngay <=21) d = 3;
            else if (ngay >28) d = 5;
            else if (ngay <= 28) d = 4;
            //MessageBox.Show((1 + (7 * (d - 1))).ToString());
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Ngay" + (1 + (7 * (d - 1))).ToString(), QLDOANHTHUBLL.instance.GetDoanhThuTrongNgay(1+(7*(d-1)),thang,nam) );
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Ngay" + (2 + (7 * (d - 1))).ToString(), QLDOANHTHUBLL.instance.GetDoanhThuTrongNgay(2 + (7 * (d - 1)), thang, nam));
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Ngay" + (3 + (7 * (d - 1))).ToString(), QLDOANHTHUBLL.instance.GetDoanhThuTrongNgay(3 + (7 * (d - 1)), thang, nam));
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Ngay" + (4 + (7 * (d - 1))).ToString(), QLDOANHTHUBLL.instance.GetDoanhThuTrongNgay(4 + (7 * (d - 1)), thang, nam));
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Ngay" + (5 + (7 * (d - 1))).ToString(), QLDOANHTHUBLL.instance.GetDoanhThuTrongNgay(5 + (7 * (d - 1)), thang, nam));
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Ngay" + (6 + (7 * (d - 1))).ToString(), QLDOANHTHUBLL.instance.GetDoanhThuTrongNgay(6 + (7 * (d - 1)), thang, nam));
            charttuan.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Ngay" + (7 + (7 * (d - 1))).ToString(), QLDOANHTHUBLL.instance.GetDoanhThuTrongNgay(7 + (7 * (d - 1)), thang, nam));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["DoanhThuNam"].BringToFront();
        }
    }
}
