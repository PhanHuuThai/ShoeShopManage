using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Owner_User : UserControl
    {
        public Owner_User()
        {
            InitializeComponent();
            textBox1.Text = "Admin";
            textBox2.Text = "Tran Van Hai";
            textBox3.Text = "Nam ";
            textBox4.Text = "01/08/2002";
            textBox5.Text = "447 Ton Duc Thang";
            textBox6.Text = "0338186574";
            textBox7.Text = "binhphaptamquoc@gmail.com"; 
            
        }

        private void Owner_User_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            changepasswordowner f = new changepasswordowner();
            f.Show();
        }
    }
}
