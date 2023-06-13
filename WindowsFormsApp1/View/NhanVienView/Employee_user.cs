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
    
    public partial class Employee_user : UserControl
    {
        public string MaNV="" ; 
        public Employee_user(string Ma)
        {
            InitializeComponent();
            MaNV = Ma;
            NhanVien s = QLNHANVIENBLL.instance.GetNVByMaNV(MaNV);
            textBox1.Text = s.MaNV;
            textBox4.Text = s.Name;
            if (s.Gender)
                textBox2.Text = "Nam";
            else textBox2.Text = "Nu";
            textBox3.Text = s.DiaChi;
            textBox5.Text = s.SDT.ToString();
            textBox6.Text = s.Gmail;
            textBox7.Text = s.NgaySinh.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangepasswordNV f = new ChangepasswordNV();
            f.Show();  
        }

       
    }
}
