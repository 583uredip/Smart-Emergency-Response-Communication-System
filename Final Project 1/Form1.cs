using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using Final_Project_1.Models;

namespace Final_Project_1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginText1.Text) ||string.IsNullOrWhiteSpace(LoginText2.Text))
            {
                MessageBox.Show("Username and Password cannot be empty!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            string query = "SELECT LoginId, Role, Status FROM dbo.Login WHERE UserName=@user AND Password=@pass";

            SqlConnection con = DBHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", LoginText1.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", LoginText2.Text.Trim());

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int loginId = Convert.ToInt32(reader["LoginId"]);
                    string role = reader["Role"].ToString();
                    int status = Convert.ToInt32(reader["Status"]);
                    reader.Close();

                    if (status == 0)
                    {
                        MessageBox.Show("Admin has Disabled your account!\nPlease contact admin.",
                                        "Account Disabled",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (role == "User")
                    {
                        UserOparetion u = new UserOparetion(loginId); 
                        u.Show();
                        this.Hide();
                    }
                    else if (role == "Hospital")
                    {
                        Hospital_Emargency h = new Hospital_Emargency();
                        h.Show();
                        this.Hide();
                    }
                    else if (role == "Police")
                    {
                        Police_From po = new Police_From();
                        po.Show();
                        this.Hide();
                    }
                    else if (role == "Admin")
                    {
                        Admin_From ad = new Admin_From();
                        ad.Show();
                        this.Hide();
                    }
                }
                else
                {
                    reader.Close();
                    MessageBox.Show("Wrong Username or Password!", "Error",
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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            RegistrationFrom re = new RegistrationFrom();
            re.Show();
            this.Hide();

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ForgetPasswordButton_Click(object sender, EventArgs e)
        {
            ForgetPass forget = new ForgetPass();
            forget.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(linkLabel1.Text=="Show")
            {
                linkLabel1.Text = "Hide";
                LoginText2.UseSystemPasswordChar = false;
            }
            else if (linkLabel1.Text == "Hide")
            {
                linkLabel1.Text = "Show";
                LoginText2.UseSystemPasswordChar = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LoginText1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
