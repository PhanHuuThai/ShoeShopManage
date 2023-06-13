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
using System.Threading;

namespace WindowsFormsApp1
{
    
    public partial class MaGiamGia_user : UserControl
    {
        public MaGiamGia_user()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public string GetMGG()
        {
            string mgg = "";
            int i = 0; 
            Random r= new Random();
            while (i<5)
            {
                mgg=mgg+Convert.ToChar(64+r.Next(1,25));
                i++;
            }
            return mgg;
        }
        private void btmo_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int x=random.Next(1,4);
            string y = GetMGG(); 
            pictureBox2.Image = global::WindowsFormsApp1.Properties.Resources.hộp_quà_mở; 
            if (x==1)
            {
                QLHDBLL.instance.AddMGG(new MaGiamGia { phantram = 3, TenMGG = y });
                MessageBox.Show("Ban da trung ma giam gia 3% : "+y);
            }
            if (x == 2)
            {
                QLHDBLL.instance.AddMGG(new MaGiamGia { phantram = 5, TenMGG = y });
                MessageBox.Show("Ban da trung ma giam gia 5% : " + y);
            }
            if (x == 3)
            {
                QLHDBLL.instance.AddMGG(new MaGiamGia { phantram = 7, TenMGG = y });
                MessageBox.Show("Ban da trung ma giam gia 7% : " + y);
            }
            if (x == 4)
            {
                QLHDBLL.instance.AddMGG(new MaGiamGia { phantram = 9, TenMGG = y });
                MessageBox.Show("Ban da trung ma giam gia 9% : " + y);
            }
            pictureBox2.Image = global::WindowsFormsApp1.Properties.Resources.dong;
            EmployeeForm.Instance.panel4_.Controls["Hoadon"].BringToFront();
        }
    }
}
