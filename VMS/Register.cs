using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace VMS
{
    public partial class Register : Form
    {
        public SqlConnection conn = new SqlConnection("Data Source=ECARTESTECH\\SQLEXPRESS;Initial Catalog=VMS;User ID=sa;Password=sn;Trust Server Certificate=True");
        public Register()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text.Trim();
            string mob = maskedTextBox1.Text.Trim();
            string pass = textBox3.Text.Trim();


            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            // Empty check
            if (string.IsNullOrEmpty(user) ||
                string.IsNullOrEmpty(pass) ||
                !maskedTextBox1.MaskCompleted)
            {
                MessageBox.Show("Please fill all the details.", "Error");
                return;
            }

            
            // Mobile number validation
            if (!Regex.IsMatch(mob, @"^\d{10}$"))
            {
                MessageBox.Show("Please provide a valid 10-digit mobile number.", "Error");
                return;
            }

            // Database Insert 
            try
            {

                conn.Open();
                string CheckUser = "Select Count(*) from admin where name = @name";
                using (SqlCommand Cmd = new SqlCommand(CheckUser, conn))
                {
                    Cmd.Parameters.AddWithValue("@name", user);
                    int result = (int)Cmd.ExecuteScalar();
                    if (result > 0)
                    {
                        MessageBox.Show("This user already registered.", "Error");
                        conn.Close();
                    }
                    else
                    {
                        create(user, mob, pass);
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

        private void create(string user, string mob, string pass)
        {

            // Database Insert 
            try
            {

                string query = @"INSERT INTO admin
                         (name, mob , password)
                         VALUES
                         (@name, @mob, @password)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", user);
                    cmd.Parameters.AddWithValue("@mob", mob);
                    cmd.Parameters.AddWithValue("@password", pass);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thank you, your account has been created.", "Success");

                Login login = new Login();
                login.Show();
                this.Hide();
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
    }
}
