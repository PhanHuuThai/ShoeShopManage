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
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1
{
    public partial class Loginform : Form
    {
        QLSHOP db = new QLSHOP();
        public Loginform()
        {
            InitializeComponent();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            forgetpasswordform a = new forgetpasswordform();
            a.Show();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (QLACCOUNTQLL.instance.getaccount(txtTK.Text, txtMK.Text) == 1)
            {
                this.Hide();
                EmployeeForm a = new EmployeeForm((txtTK.Text));
                a.Show();
            }
            else if (QLACCOUNTQLL.instance.getaccount(txtTK.Text, txtMK.Text) == 2)
            {
                this.Hide();
                OwnerForm a = new OwnerForm();
                a.Show();
            }
            else
            {
                MessageBox.Show("Ten tai khoan hoac mat khau khong dung");
            }
        }
    }
}
