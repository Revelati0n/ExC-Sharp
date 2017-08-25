using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Faker;

namespace UserSystemProject
{
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
        }
        
        private void addUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            (new Form1()).Show();
        }

        private void addUser_Load(object sender, EventArgs e)
        {
            GenUser();
        }

        private void GenUser()
        {
            textBox1.Text = Faker.Internet.UserName();
            textBox2.Text = Faker.Internet.Password(5, 10);
            textBox3.Text = Faker.Name.First();
            textBox4.Text = Faker.Name.Last();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenUser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlClass SqlFucntion = new SqlClass();

            if(SqlFucntion.addUserToDatabse(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text)){
                MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "ดำเนินการสำเร็จ");
                Form1 loginForm = new Form1();
                loginForm.textBox1.Text = textBox1.Text;
                loginForm.textBox2.Text = textBox2.Text;
                loginForm.login();
                this.Hide();
            }else{
                MessageBox.Show("เพิ่มข้อมูลล้มเหลว", "ดำเนินการล้มเหลว");
            }

        }
    }
}
