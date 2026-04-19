using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace VMS
{
    public partial class Login : Form
    {
        public SqlConnection conn = new SqlConnection("Data Source=ECARTESTECH\\SQLEXPRESS;Initial Catalog=VMS;User ID=sa;Password=sn;Trust Server Certificate=True");
        public Login()
        {
            InitializeComponent();
            userTxt.Text = "admin";
            passTxt.Text = "1234";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = userTxt.Text.Trim();
            string pass = passTxt.Text.Trim();
           
            
            /*if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please Provide All the Details.", "error");
            }
            else
            {
                if (user == "admin" && pass == "admin123")
                {
                    MessageBox.Show("Login Successfull.", "Success");
                    Form1 form = new Form1();
                    form.Show();
                    this.Hide();
                }
            }*/

            // Database Insert 
            try
            {
                conn.Open();
                string CheckUser = "Select Id from admin where name = @name and password = @password";
                using (SqlCommand Cmd = new SqlCommand(CheckUser, conn))
                {
                    Cmd.Parameters.AddWithValue("@name", user);
                    Cmd.Parameters.AddWithValue("@password", pass);
                    int result = (int)Cmd.ExecuteScalar();
                    if (result > 0)
                    {
                        int AdminId = result;
                        MessageBox.Show("Login Successfull.", "Success");
                        conn.Close();
                        this.Hide();
                        Form1 form = new Form1(AdminId);
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Account Not found with this username.", "Error");
                        conn.Close();

                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
