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
    public partial class Accident_Report : Form
    {
        private string _mediaPath = "";
        public Accident_Report()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image/Video Files|*.jpg;*.jpeg;*.png;*.mp4;*.avi";
                openFileDialog.Title = "Select Media File";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _mediaPath = openFileDialog.FileName;
                    MessageBox.Show("File Selected: " + _mediaPath, "File Selected",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Accident_Report_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(AccDescriptionTextBox.Text) || string.IsNullOrWhiteSpace(AccLocationTextBox.Text)
                )
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


            string insertQuery = "INSERT INTO dbo.AccidentReports (UserName, Description, Location,MediaPath, Status, ReportDate) " +
                                "VALUES (@username, @desc, @location, @media, 'Pending', GETDATE())";

            SqlConnection con = DBHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@username", guna2TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", AccDescriptionTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@location", AccLocationTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@media", _mediaPath);

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Accident Report Submitted Successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AccDescriptionTextBox.Clear();
                    AccDescriptionTextBox.Clear();
                    AccLocationTextBox.Clear();
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

        private void AccDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
