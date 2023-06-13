using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class OwnerForm : Form
    {
        static OwnerForm _obj;
        public DoanhThuTuan dtt = new DoanhThuTuan();
        public DoanhThuThang dthuthang = new DoanhThuThang();
        public DoanhThuNam dtn = new DoanhThuNam();
        public Nhanvienusercontrol nv = new Nhanvienusercontrol();
        public Owner_User owneruser = new Owner_User();
        //public sanpham sp = new sanpham();
        public Hoadon hd=new Hoadon("",1);
        public SanPhamUserControl sp = new SanPhamUserControl(0);
       // public Hoadon hd=new Hoadon();
        public static OwnerForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new OwnerForm();
                }
                return _obj;
            }
        }
        public Panel PannelContain_
        {
            get { return PannelContain; }
            set { PannelContain = value; }
        }
        public OwnerForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _obj = this; 
            dtt.Dock = DockStyle.Fill;
            PannelContain.Controls.Add(dtt);
            dthuthang.Dock = DockStyle.Fill;
            PannelContain.Controls.Add(dthuthang);
            dtn.Dock = DockStyle.Fill;
            PannelContain.Controls.Add(dtn);
            owneruser.Dock = DockStyle.Fill;
            PannelContain.Controls.Add(nv);
            owneruser.Dock = DockStyle.Fill;
            PannelContain.Controls.Add(owneruser);
            owneruser.Dock = DockStyle.Fill;
            PannelContain.Controls.Add(sp);
            owneruser.Dock = DockStyle.Fill;
            PannelContain.Controls.Add(hd);
            OwnerForm.Instance.PannelContain_.Controls["Owner_User"].BringToFront(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DoanhThuTuan dtt = new DoanhThuTuan();
            //dtt.Dock = DockStyle.Fill;
            //PannelContain.Controls.Add(dtt);
        }

        private void PannelContain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["Nhanvienusercontrol"].BringToFront();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["SanPhamUserControl"].BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Loginform a = new Loginform();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["DoanhThuTuan"].BringToFront();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["Owner_User"].BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OwnerForm.Instance.PannelContain_.Controls["Hoadon"].BringToFront();
        }
    }
}
