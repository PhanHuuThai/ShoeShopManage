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
    public partial class EmployeeForm : Form
    {

        public static string Ma = "";
        static EmployeeForm _obj;
        public Hoadon hd;
        public Employee_user Employeeuser;
       public SanPhamUserControl sanpham = new SanPhamUserControl(1);

        public DiemDanhUserControl dd;

        public static EmployeeForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new EmployeeForm(null);
                }
                return _obj;
            }
        }
        public Panel panel4_
        {
            get { return panel4; }
            set { panel4 = value; }
        }
        
        public EmployeeForm(string MANV)
        { 
            Ma = MANV;
            Employee_user Employeeuser = new Employee_user(Ma);
            DiemDanhUserControl dd = new DiemDanhUserControl(Ma);
            Hoadon hd = new Hoadon(Ma,0);
            
            InitializeComponent();
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _obj = this;
            Employee_user Employeeuser = new Employee_user(Ma);
            Hoadon hd = new Hoadon(Ma,0);
            sanpham.Dock = DockStyle.Fill;
            panel4.Controls.Add(sanpham);
            hd.Dock = DockStyle.Fill;
            panel4.Controls.Add(hd);
            Employeeuser.Dock = DockStyle.Fill;
            panel4.Controls.Add(Employeeuser);
            EmployeeForm.Instance.panel4_.Controls["Employee_user"].BringToFront();
            DiemDanhUserControl dd = new DiemDanhUserControl(Ma);
            dd.Dock = DockStyle.Fill;
            panel4.Controls.Add(dd);
            MaGiamGia_user Giamgia= new MaGiamGia_user();
            Giamgia.Dock = DockStyle.Fill;
            panel4.Controls.Add(Giamgia);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            EmployeeForm.Instance.panel4_.Controls["Employee_user"].BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //EmployeeForm.Instance.panel4_.Controls[]
            //EmployeeForm.Instance.panel4_.Controls["SPofNVusercontrol"].BringToFront();


            EmployeeForm.Instance.panel4_.Controls["SanPhamUserControl"].BringToFront();
            sanpham.ShowSP();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmployeeForm.Instance.panel4_.Controls["Hoadon"].BringToFront();
            
           
        }



        private void button6_Click(object sender, EventArgs e)
        {
            
            this.Close();
            Loginform a = new Loginform();
            a.Show();
        }


        private void butdiemdanh_Click(object sender, EventArgs e)
        {
            EmployeeForm.Instance.panel4_.Controls["DiemDanhUserControl"].BringToFront();
        }
    }
}
