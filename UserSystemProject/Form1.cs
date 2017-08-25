using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Faker;
using System.Data.SqlClient;

namespace UserSystemProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new addUser()).Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login();
        }
        public void login()
        {
            button2.Enabled = false;
            button1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            SqlClass SqlFucntion = new SqlClass();

            if (SqlFucntion.checkUserLogin(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("เข้าสู่ระบบสำเร็จ", "ดำเนินการสำเร็จ");
                userInformation userInfo = new userInformation();
                userInfo.Username = textBox1.Text;
                userInfo.loadInfo();
                userInfo.Show();
                button2.Enabled = true;
                button1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("เข้าสู่ระบบล้มเหลว", "ดำเนินการล้มเหลว");
                button2.Enabled = true;
                button1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
        }
    }
}
