using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Final_Project_1.Models;

namespace Final_Project_1.Resources
{
    public partial class Blood_Bank : Form
    {
       // string conStr = @"Data Source=desktop-udmdgkf\sqlexpress;Initial Catalog=Smart Emargency System Bd;Integrated Security=True;TrustServerCertificate=True";

        public Blood_Bank()
        {
            InitializeComponent();
        }

        private void Hospital_Button_Logout_Click(object sender, EventArgs e)
        {
            Hospital_Emargency ho = new Hospital_Emargency();
            ho.Show();
           this.Hide();
          
        
        
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Blood_Bank_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM [Smart Emargency System Bd].[dbo].[BloodRequests] ORDER BY RequestDate DESC";
            SqlConnection con = DBHelper.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to delete!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int requestId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["RequestId"].Value);

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?",  "Confirm Delete",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM [Smart Emargency System Bd].[dbo].[BloodRequests] WHERE RequestId = @id";
                SqlConnection con = DBHelper.GetConnection();
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@id", requestId);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2Button1_Click(sender, e); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            }
    }
}
