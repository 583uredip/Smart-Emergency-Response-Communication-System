using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_1.Models;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_Project_1
{
    public partial class ForgetPass : Form
    {
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void ForgetPass_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoginForm lo = new LoginForm();
            lo.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text == "Show")
            {
                linkLabel1.Text = "Hide";
                NewPasswordText.UseSystemPasswordChar = false;
            }
            else if (linkLabel1.Text == "Hide")
            {
                linkLabel1.Text = "Show";
                NewPasswordText.UseSystemPasswordChar = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ForgetEmailText.Text) || string.IsNullOrWhiteSpace(NewPasswordText.Text) ||
                string.IsNullOrWhiteSpace(NewPasswordText.Text))
            {
                MessageBox.Show("All fields are required!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string checkUserQuery = "SELECT COUNT(*) FROM dbo.Users WHERE [Name] = @username";
            SqlConnection conCheck1 = DBHelper.GetConnection();
            SqlCommand cmdCheck1 = new SqlCommand(checkUserQuery, conCheck1);
            cmdCheck1.Parameters.AddWithValue("@username", ForgetNameText.Text.Trim());
            conCheck1.Open();
            int userCount = (int)cmdCheck1.ExecuteScalar();
            conCheck1.Close();

            if (userCount == 0)
            {
                MessageBox.Show("This Username does not exist! Please enter a valid Username.",
                                "Invalid Username",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ForgetNameText.Focus();
                return;
            }
            string checkEmailQuery = "SELECT COUNT(*) FROM dbo.Users WHERE [Email] = @email";
            SqlConnection conCheck2 = DBHelper.GetConnection();
            SqlCommand cmdCheck2 = new SqlCommand(checkEmailQuery, conCheck2);
            cmdCheck2.Parameters.AddWithValue("@email", ForgetEmailText.Text.Trim());
            conCheck2.Open();
            int emailCount = (int)cmdCheck2.ExecuteScalar();
            conCheck2.Close();

            if (emailCount == 0)
            {
                MessageBox.Show("This Email does not exist! Please enter a valid Email.",
                                "Invalid Email",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ForgetEmailText.Focus();
                return;
            }


            string updateQuery = "UPDATE dbo.Login SET Password = @newpass WHERE UserName = @username";
            SqlConnection con = DBHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@newpass", NewPasswordText.Text.Trim());
            cmd.Parameters.AddWithValue("@username", ForgetNameText.Text.Trim());

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Password Changed Successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoginForm lo = new LoginForm();
                    lo.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password Change Failed! Try again.", "Error",
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

        private void ForgetNameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void ForgetEmailText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
