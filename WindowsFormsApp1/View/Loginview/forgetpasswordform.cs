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
    public partial class forgetpasswordform : Form
    {
        
        public forgetpasswordform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if(QLACCOUNTQLL.instance.forgotpassword(textBox1.Text,textBox2.Text)=="0")
            {
                MessageBox.Show("Ten tai khoan hoac gmail sai");
            }
            
            else
            {
                textBox4.Text = QLACCOUNTQLL.instance.forgotpassword(textBox1.Text, textBox2.Text);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Loginform a= new Loginform();
            a.Show();
        }
    }
}
