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

namespace Final_Project_1
{
    public partial class Crime_Report : Form
    {
        private string _mediaPath = "";

        public Crime_Report()
        {
            InitializeComponent();
        }

        // ===== Browse Button =====
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image/Video Files|*.jpg;*.jpeg;*.png;*.mp4;*.avi";
                openFileDialog.Title = "Select Media File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _mediaPath = openFileDialog.FileName;
                    MessageBox.Show("File Selected: " + _mediaPath, "Selected",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text) ||string.IsNullOrWhiteSpace(CriDesTextBox.Text) ||string.IsNullOrWhiteSpace(CriLocaTextBox.Text))
            {
                MessageBox.Show("All fields are required!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

       
            string checkQuery = "SELECT COUNT(*) FROM dbo.Users WHERE [Name] = @username";
            SqlConnection conCheck = DBHelper.GetConnection();
            SqlCommand cmdCheck = new SqlCommand(checkQuery, conCheck);
            cmdCheck.Parameters.AddWithValue("@username", guna2TextBox1.Text.Trim());
            conCheck.Open();
            int userCount = (int)cmdCheck.ExecuteScalar();
            conCheck.Close();

            if (userCount == 0)
            {
                MessageBox.Show("This Username does not exist! Please enter a valid Username.",
                                "Invalid Username",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox1.Focus();
                return;
            }

            string insertQuery = "INSERT INTO dbo.CrimeReports (UserName, Description, Location, MediaPath, Status, ReportDate) " +
                                 "VALUES (@username, @desc, @location, @media, 'Pending', GETDATE())";

            SqlConnection con = DBHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@username", guna2TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", CriDesTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@location", CriLocaTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@media", _mediaPath);

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Crime Report Submitted Successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    guna2TextBox1.Clear();
                    CriDesTextBox.Clear();
                    CriLocaTextBox.Clear();
                    _mediaPath = "";

                    UserOparetion u = new UserOparetion(0);
                    u.Show();
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UserOparetion u = new UserOparetion(0);
            u.Show();
            this.Hide();
        }

        private void CriDesTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void CriLocaTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Crime_Report_Load(object sender, EventArgs e)
        {
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}