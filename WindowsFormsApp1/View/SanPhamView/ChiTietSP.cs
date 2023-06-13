using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.BLL; 
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class ChiTietSP : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public string MSP;  
        public ChiTietSP(string MaSP, int x)
        {
            InitializeComponent();
            MSP = MaSP;
            GUI();        
            if(x ==1)
            {
                button2.Visible = false;
                button3.Visible = false;
                button1.Visible = false;
                Txtpic.Visible = false;
                label6.Visible = false;
                txtID.Enabled = false;
                txtName.Enabled = false;
                txtPrice.Enabled = false;
                txtSize36.Enabled = false;
                txtSize37.Enabled = false;
                txtSize38.Enabled = false;
                txtSize39.Enabled = false;
                txtSize40.Enabled = false;
                txtSize41.Enabled = false;
                txtSize42.Enabled = false;
                txtSize43.Enabled = false;
                


            } 
            
        }
        public void GUI()
        {
            SanPham s= QLSANPHAMBLL.instance.GetSPbyMaSP(MSP);
            txtID.Text = QLSANPHAMBLL.instance.setMaSP();
            txtID.Enabled = false;
           

            if (MSP != "")
            {
                pictureBox1.Image = new Bitmap(updatename(Path.GetFullPath("a")) + "Resources" + ((char)92) + getname(s.Link) + ".jpg");
                txtID.Text = MSP;
                Txtpic.Text = (s.Link);
                txtName.Text = s.TenSP;
                txtPrice.Text = s.GiaSP;
                txtSize36.Text = QLSANPHAMBLL.instance.GetSLbyMaSPandSize(s.MSP, 36).ToString();
                txtSize37.Text = QLSANPHAMBLL.instance.GetSLbyMaSPandSize(s.MSP, 37).ToString();
                txtSize38.Text = QLSANPHAMBLL.instance.GetSLbyMaSPandSize(s.MSP, 38).ToString();
                txtSize39.Text = QLSANPHAMBLL.instance.GetSLbyMaSPandSize(s.MSP, 39).ToString();
                txtSize40.Text = QLSANPHAMBLL.instance.GetSLbyMaSPandSize(s.MSP, 40).ToString();
                txtSize41.Text = QLSANPHAMBLL.instance.GetSLbyMaSPandSize(s.MSP, 41).ToString();
                txtSize42.Text = QLSANPHAMBLL.instance.GetSLbyMaSPandSize(s.MSP, 42).ToString();
                txtSize43.Text = QLSANPHAMBLL.instance.GetSLbyMaSPandSize(s.MSP, 43).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null || txtID.Text == "" || Txtpic.Text == "" || txtName.Text == "" || txtPrice.Text == "")
                MessageBox.Show("co thuoc tinh chua duoc nhap");
          
            else if (txtSize36.Text == "0" && txtSize37.Text == "0" && txtSize38.Text == "0" && txtSize39.Text == "0" && txtSize40.Text == "0" && txtSize41.Text == "0"
                && txtSize42.Text == "0" && txtSize43.Text == "0")
                MessageBox.Show("so luong phai lon hon 0");
            else
            {
              
                if(txtSize36.Text == "")
                    txtSize36.Text = "0";
                if(txtSize37.Text == "")
                    txtSize37.Text = "0";
                if (txtSize38.Text == "")
                    txtSize38.Text = "0";
                if (txtSize39.Text == "")
                    txtSize39.Text = "0";
                if (txtSize40.Text == "")
                    txtSize40.Text = "0";
                if (txtSize41.Text == "")
                    txtSize41.Text = "0";
                if (txtSize42.Text == "")
                    txtSize42.Text = "0";
                if (txtSize43.Text == "")
                    txtSize43.Text = "0";

                QLSANPHAMBLL.instance.AddUpdateSP(new SanPham
                {
                    MSP = txtID.Text,
                    Link = Txtpic.Text,
                    GiaSP = txtPrice.Text,
                    TenSP = txtName.Text,
                    TongSLSP = Convert.ToInt32(txtSize36.Text) + Convert.ToInt32(txtSize37.Text) + Convert.ToInt32(txtSize38.Text) + Convert.ToInt32(txtSize39.Text) + Convert.ToInt32(txtSize40.Text) + Convert.ToInt32(txtSize41.Text) + Convert.ToInt32(txtSize42.Text) + Convert.ToInt32(txtSize43.Text)
                });
                QLSANPHAMBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 36, SoLuong = Convert.ToInt32(txtSize36.Text) });
                QLSANPHAMBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 37, SoLuong = Convert.ToInt32(txtSize37.Text) });
                QLSANPHAMBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 38, SoLuong = Convert.ToInt32(txtSize38.Text) });
                QLSANPHAMBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 39, SoLuong = Convert.ToInt32(txtSize39.Text) });
                QLSANPHAMBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 40, SoLuong = Convert.ToInt32(txtSize40.Text) });
                QLSANPHAMBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 41, SoLuong = Convert.ToInt32(txtSize41.Text) });
                QLSANPHAMBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 42, SoLuong = Convert.ToInt32(txtSize42.Text) });
                QLSANPHAMBLL.instance.AddSLSP(new SoLuongSP { MSP = txtID.Text, Size = 43, SoLuong = Convert.ToInt32(txtSize42.Text) });
                d();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        public string getname(string s)
        {
            string n = "";
            int f=0, l=0;

            for (int i = s.Length-1; i > 0; i--)
            {
                if (s[i]=='.')
                    l = i;
                if (s[i].CompareTo((char)92) == 0)
                {
                    f = i;
                break;
                 }
            }
            for (int i = f+1;i<l;i++)
            {
                n += s[i];
            }
            return n;
        }

        public string updatename(string s)
        {
            int count=0, n=0;
            string l = "";
            for(int i = s.Length-1;i>0;i--)
            {
                if(s[i]==((char)92))
                    count++;
                if (count == 2)
                    n = i;
            }
            l= s.Substring(0,n);
            return l;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(file.FileName);
                    Txtpic.Text = (file.FileName);
                }
                catch (Exception x)
                {
                    MessageBox.Show("chon sai loai file");
                }
                
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
