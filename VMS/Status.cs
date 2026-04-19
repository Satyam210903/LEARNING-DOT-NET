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

namespace VMS
{
    public partial class Status : UserControl
    {
        public SqlConnection conn = new SqlConnection("Data Source=ECARTESTECH\\SQLEXPRESS;Initial Catalog=VMS;User ID=sa;Password=sn;Trust Server Certificate=True");
        public Status(int AdminId)
        {
            InitializeComponent();
            DataLoad(AdminId);
        }


        //Data Load Function
        private void DataLoad(int AdminId)
        {
            string query = @"SELECT Id AS ID , Name AS NAME, Mob AS CONTACT_NO, Purpose AS PURPOSE, Validity AS VALIDITY, CASE WHEN status = 1 THEN 'Active' ELSE 'Inactive' END AS STATUS , LastIn AS LAST_IN ,LastOut AS LAST_OUT FROM visit_pass";
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ReadOnly = true;


            }
        }

    }
}
