using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace UserSystemProject
{
    class SqlClass
    {
        private SqlConnection SqlConnection()
        {
            string StrConnect = "Server=DESKTOP-6SMEV2F\\SQLEXPRESS;Database=TestSystem;User ID=sa;Password=sql";
            SqlConnection SqlConnection;
            SqlConnection = new SqlConnection(StrConnect);
            return SqlConnection;
        }

        /*
         @return true/false
         */

        public bool addUserToDatabse(string Username, string Password, string FirstName, string LastName)
        {
            SqlConnection SqlConnection = this.SqlConnection();
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "INSERT INTO [Accounts] ([Username], [Password], [FirstName], [LastName]) VALUES (@Username, @Password, @FirstName, @LastName)";
            SqlCommand.Parameters.AddWithValue("@Username", Username);
            SqlCommand.Parameters.AddWithValue("@Password", Password);
            SqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            SqlCommand.Parameters.AddWithValue("@LastName", LastName);
            SqlCommand.Connection = SqlConnection;
            try
            {
                SqlConnection.Open();
                SqlCommand.ExecuteNonQuery();
                SqlConnection.Close();
                return true;
            }
            catch (Exception Ex)
            {

                Console.WriteLine(Ex.ToString());
                return false;
            }
        }

        /*
         @return true/false
         */

        public bool checkUserLogin(string Username, string Password)
        {
            SqlConnection SqlConnection = this.SqlConnection();
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "SELECT * FROM [Accounts] WHERE [Username] = @Username AND [Password] = @Password";
            SqlCommand.Parameters.AddWithValue("@Username", Username);
            SqlCommand.Parameters.AddWithValue("@Password", Password);
            SqlCommand.Connection = SqlConnection;
            try
            {
                SqlConnection.Open();
                int num = 0;                
                num = Convert.ToInt32(SqlCommand.ExecuteScalar());
                SqlConnection.Close();
                if (num > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {              
                Console.WriteLine(Ex.ToString());
                return false;
            }
        }

        /*
         @return sqlDataReader
        */

        public SqlDataReader getUserInfo(string Username)
        {
            SqlConnection SqlConnection = this.SqlConnection();
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "SELECT [UID], [Username], [FirstName] ,[LastName] ,[RegisterDate] FROM [Accounts] WHERE [Username] = @Username";
            SqlCommand.Parameters.AddWithValue("@Username", Username);
            SqlCommand.Connection = SqlConnection;
            SqlConnection.Open();
            SqlDataReader SqlDataReader = SqlCommand.ExecuteReader();
            SqlDataReader.Read();
            return SqlDataReader;
        }

        /*
         @return true/false
        */

        public bool userChangePassword(string UID, string oldPassword, string newPassword)
        {
            SqlConnection SqlConnection = this.SqlConnection();
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "UPDATE [Accounts] SET [Password] = @newPassword WHERE [UID] = @UID AND [Password] = @oldPassword";
            SqlCommand.Parameters.AddWithValue("@UID", UID);
            SqlCommand.Parameters.AddWithValue("@newPassword", newPassword);
            SqlCommand.Parameters.AddWithValue("@oldPassword", oldPassword);
            SqlCommand.Connection = SqlConnection;
            SqlConnection.Open();            
            if (SqlCommand.ExecuteNonQuery() > 0)
            {
                SqlConnection.Close();
                return true;
            }
            else
            {
                SqlConnection.Close();
                return false;
            }
        }
    }
}
