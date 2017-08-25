using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UserSystemProject
{
    public partial class userInformation : Form
    {
        public userInformation()
        {
            InitializeComponent();
        }

        public string UID,Username, FirstName, LastName, RegisterDate;

        public void loadInfo()
        {
            SqlClass SqlFucntion = new SqlClass();
            SqlDataReader UserDataReader = SqlFucntion.getUserInfo(Username);

            UID = UserDataReader["UID"].ToString();
            FirstName = UserDataReader["FirstName"].ToString();
            LastName = UserDataReader["LastName"].ToString();
            RegisterDate = UserDataReader["RegisterDate"].ToString();

            label1.Text = "Username: " + Username;
            label2.Text = "User ID: " + UID;
            label3.Text = "FirstName: " + FirstName;
            label4.Text = "LastName: " + LastName;
            label5.Text = "RegisterDate: " + RegisterDate;    

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UID = Username = FirstName = LastName = RegisterDate;
            this.Close();
            (new Form1()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlClass SqlFucntion = new SqlClass();
            if (SqlFucntion.userChangePassword(UID, textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("เปลี่ยนรหัสผ่านสำเร็จ", "ดำเนินการสำเร็จ");
                loadInfo();
                textBox2.Text = textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("เปลี่ยนรหัสผ่านไม่สำเร็จ", "ดำเนินการล้มเหลว");
            }           
        }
    }
}
