using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VMS
{
    public partial class Home : UserControl
    {
        private int _adminId;
        public SqlConnection conn = new SqlConnection("Data Source=ECARTESTECH\\SQLEXPRESS;Initial Catalog=VMS;User ID=sa;Password=sn;Trust Server Certificate=True");
        public Home(int AdminId)
        {
            _adminId = AdminId;
            InitializeComponent();
            DataLoad();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PassMaking newPass = new PassMaking(_adminId);
            newPass.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            In checkIn = new In();
            checkIn.Show();
        }

        private void checkOutBtn_Click(object sender, EventArgs e)
        {
            Out checkOut = new Out();
            checkOut.Show();
        }



        //Data showing Btn Starts Here
        private void checkedListBtn_Click(object sender, EventArgs e)
        {
            CheckedInDataLoad();
        }

        private void CheckedOutListBtn_Click(object sender, EventArgs e)
        {
            CheckedOutDataLoad();
        }

        private void expiredListBtn_Click(object sender, EventArgs e)
        {
            ExpiredDataLoad();
        }

        //Data Showing Btn Ends Here

        //Data load for all Visitors 
        private void DataLoad()
        {

            string currentdate = DateAndTime.Now.ToString("dd/MM/yyyy");
            conn.Open();
            // In Visitors
            string inVisitors = "Select Count(*) from visit_pass where status = 1 ";
            using (SqlCommand Cmd = new SqlCommand(inVisitors, conn))
            {
                int result = (int)Cmd.ExecuteScalar();
                if (result > 0)
                {
                    InVisitors.Text = $"{result}";
                }
                else
                {
                    InVisitors.Text = "0";
                }
            }


            // out Visitors
            string outVisitors = "Select Count(*) from visit_pass where status = 0";
            using (SqlCommand Cmd = new SqlCommand(outVisitors, conn))
            {
                int result = (int)Cmd.ExecuteScalar();
                if (result > 0)
                {
                    OutVisitors.Text = $"{result}";
                }
                else
                {

                    OutVisitors.Text = "0";
                }
            }



            //Expired visitors
            string expiredVisitors = "Select Count(*) from visit_pass where Validity < @Validity";
            using (SqlCommand Cmd = new SqlCommand(expiredVisitors, conn))
            {
                Cmd.Parameters.AddWithValue("@Validity", currentdate);
                int result = (int)Cmd.ExecuteScalar();
                if (result > 0)
                {
                    ExpiredVisitors.Text = $"{result}";
                }
                else
                {
                    ExpiredVisitors.Text = "0";
                }
            }
            string query = @"SELECT Id AS ID , Name AS NAME, Mob AS CONTACT_NO, Purpose AS PURPOSE, Validity AS VALIDITY, LastIn AS LAST_IN ,LastOut AS LAST_OUT, CASE WHEN status = 1 THEN 'Active' ELSE 'Inactive' END AS STATUS FROM visit_pass ";

            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            }
           conn.Close();

            

        }

        //Data load for Checked In 
        private void CheckedInDataLoad()
        {
            conn.Open();
            string query = @"SELECT Id AS ID , Name AS NAME, Mob AS CONTACT_NO, Purpose AS PURPOSE, Validity AS VALIDITY, CASE WHEN status = 1 THEN 'Active' ELSE 'Inactive' END AS STATUS , LastIn AS LAST_IN ,LastOut AS LAST_OUT FROM visit_pass Where status = 1";
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            }
            conn.Close();
        }
        //Data load for Checked In 
        private void CheckedOutDataLoad()
        {

            conn.Open();
            string query = @"SELECT Id AS ID , Name AS NAME, Mob AS CONTACT_NO, Purpose AS PURPOSE, Validity AS VALIDITY , CASE WHEN status = 0 THEN 'Inactive' ELSE 'Active' END AS STATUS ,LastIn AS LAST_IN ,LastOut AS LAST_OUT FROM visit_pass Where status = 0";
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            }

            conn.Close();
        }
        //Data load for Checked In 
        private void ExpiredDataLoad()
        {

            conn.Open();
            string currentdate = DateAndTime.Now.ToString("dd/MM/yyyy");
            string query = @"SELECT Id AS ID , Name AS NAME, Mob AS CONTACT_NO, Purpose AS PURPOSE, Validity AS VALIDITY, CASE WHEN status = 1 THEN 'Active' ELSE 'Inactive' END AS STATUS , LastIn AS LAST_IN ,LastOut AS LAST_OUT FROM visit_pass where Validity < " + currentdate;
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            }
            conn.Close();
        }

    }
}
