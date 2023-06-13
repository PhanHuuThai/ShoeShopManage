using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.BLL;

namespace WindowsFormsApp1
{
    public partial class DiemDanhUserControl : UserControl
    {
        public string MaNV = "";
        double hour = 0;
        double minute = 0;

        public DiemDanhUserControl(string ma)
        {
            InitializeComponent();
            MaNV = ma;
            NhanVien s = QLNHANVIENBLL.instance.GetNVByMaNV(MaNV);
            txtID.Text = s.MaNV;
            txtName.Text = s.Name;
            butcheckout.Visible = false;
        }

        private void butdiemdanh_Click(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString();
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            EmployeeForm s = new EmployeeForm(MaNV);
            butcheckout.Visible = true;
            butdiemdanh.Visible = false;
        }

        private void butcheckout_Click(object sender, EventArgs e)
        {
            double x = (DateTime.Now.Hour - hour) + (DateTime.Now.Minute - minute)/60;
            QLNHANVIENBLL.instance.AddGio(MaNV, x);
            txtcheckout.Text = DateTime.Now.ToString();
        }

        
    }
}
