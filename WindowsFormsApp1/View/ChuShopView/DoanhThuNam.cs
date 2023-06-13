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
    public partial class DoanhThuNam : UserControl
    {
        public DoanhThuNam()
        {
            InitializeComponent();
            loaddl(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void loaddl()
        {
            chartnam.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Qúy 1", QLDOANHTHUBLL.instance.GetDoanhThuNam(1,DateTime.Now.Year));
            chartnam.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Qúy 2", QLDOANHTHUBLL.instance.GetDoanhThuNam(2, DateTime.Now.Year));
            chartnam.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Qúy 3", QLDOANHTHUBLL.instance.GetDoanhThuNam(3, DateTime.Now.Year));
            chartnam.Series["Doanh Thu (triệu đồng)"].Points.AddXY("Qúy 4", QLDOANHTHUBLL.instance.GetDoanhThuNam(4, DateTime.Now.Year));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["DoanhThuTuan"].BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["DoanhThuThang"].BringToFront();
        }
    }
}
