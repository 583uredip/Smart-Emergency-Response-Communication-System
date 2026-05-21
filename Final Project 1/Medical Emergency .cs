using Final_Project_1.Models;
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

namespace Final_Project_1
{
    public partial class Medical_Emergency : Form
    {
        public Medical_Emergency()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UserOparetion usr = new UserOparetion(0);
            usr.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text) ||  string.IsNullOrWhiteSpace(guna2TextBox2.Text) || string.IsNullOrWhiteSpace(guna2TextBox3.Text) ||
                string.IsNullOrWhiteSpace(guna2TextBox4.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("All fields are required!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        
            string checkQuery = "SELECT COUNT(*) FROM dbo.Users WHERE [Name] = @username";
            SqlConnection conCheck = DBHelper.GetConnection();
            SqlCommand cmdCheck = new SqlCommand(checkQuery, conCheck);
            cmdCheck.Parameters.AddWithValue("@username", guna2TextBox4.Text.Trim());
            conCheck.Open();
            int userCount = (int)cmdCheck.ExecuteScalar();
            conCheck.Close();

            if (userCount == 0)
            {
                MessageBox.Show("This Username does not exist! Please enter a valid Username.",
                                "Invalid Username",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox4.Focus(); 
                return;
            }

           
            string insertQuery = "INSERT INTO dbo.MedicalReports (UserName, PatientName, Description, Location, Severity, Status, ReportDate) " +
                                 "VALUES (@username, @patient, @desc, @location, @severity, 'Pending', GETDATE())";

            SqlConnection con = DBHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@username", guna2TextBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@patient", guna2TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", guna2TextBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@location", guna2TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@severity", comboBox1.Text);

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Medical Emergency Reported Successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox3.Clear();
                    guna2TextBox4.Clear();
                    comboBox1.SelectedIndex = -1;

                    UserOparetion usr = new UserOparetion(0);
                    usr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Submission Failed! Try again.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        private void Medical_Emergency_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
