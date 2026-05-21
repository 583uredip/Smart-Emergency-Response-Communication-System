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
    public partial class RegistrationFrom : Form
    {
        string conStr = @"Data Source=desktop-udmdgkf\sqlexpress;Initial Catalog=Smart Emargency System Bd;Integrated Security=True;TrustServerCertificate=True";
        public RegistrationFrom()
        {
            InitializeComponent();
        }

        private void Reglabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void RegistrationFrom_Load(object sender, EventArgs e)
        {

        }

        private void RegPanel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void label7_Click(object sender, EventArgs e)
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
                PasswordTextBox.UseSystemPasswordChar = false;
            }
            else if (linkLabel1.Text == "Hide")
            {
                linkLabel1.Text = "Show";
                PasswordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegSubmitButton_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||string.IsNullOrWhiteSpace(EmailTextBox.Text) ||string.IsNullOrWhiteSpace(PhoneTextBox.Text)  ||string.IsNullOrWhiteSpace(PasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                string.IsNullOrWhiteSpace(BloodGroupBox.Text))
            {
                MessageBox.Show("All fields are required!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!EmailTextBox.Text.Trim().Contains("@")|| !EmailTextBox.Text.Trim().Contains("."))
            {
                MessageBox.Show("Please enter a valid email address!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EmailTextBox.Focus();
                return;
            }



            string checkUser = "SELECT COUNT(*) FROM dbo.Login WHERE [UserName]=@user";
            SqlConnection conCheck1 = new SqlConnection(conStr);
            SqlCommand cmdCheck1 = new SqlCommand(checkUser, conCheck1);
            cmdCheck1.Parameters.AddWithValue("@user", NameTextBox.Text.Trim());
            conCheck1.Open();
            int userCount = (int)cmdCheck1.ExecuteScalar();
            conCheck1.Close();

            if (userCount > 0)
            {
                MessageBox.Show("This Username already exists! Try another.", "Duplicate Username",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NameTextBox.Focus();
                return;
            }

            string checkEmail = "SELECT COUNT(*) FROM dbo.Users WHERE [Email]=@email";
            SqlConnection conCheck2 = new SqlConnection(conStr);
            SqlCommand cmdCheck2 = new SqlCommand(checkEmail, conCheck2);
            cmdCheck2.Parameters.AddWithValue("@email", EmailTextBox.Text.Trim());
            conCheck2.Open();
            int emailCount = (int)cmdCheck2.ExecuteScalar();
            conCheck2.Close();

            if (emailCount > 0)
            {
                MessageBox.Show("This Email already exists! Try another.", "Duplicate Email",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EmailTextBox.Focus();
                return;
            }

          
            string insertLogin = "INSERT INTO dbo.Login ([UserName], [Password], [Status], [Role]) " +
                                 "VALUES (@username, @pass, @status, @role);" +
                                 "SELECT SCOPE_IDENTITY();"; 

            SqlConnection conLogin = new SqlConnection(conStr);
            SqlCommand cmdLogin = new SqlCommand(insertLogin, conLogin);
            cmdLogin.Parameters.AddWithValue("@username", NameTextBox.Text.Trim());
            cmdLogin.Parameters.AddWithValue("@pass", PasswordTextBox.Text.Trim());
            cmdLogin.Parameters.AddWithValue("@status", 1);
            cmdLogin.Parameters.AddWithValue("@role", "User");

            int newLoginId = 0;
            try
            {
                conLogin.Open();
                newLoginId = Convert.ToInt32(cmdLogin.ExecuteScalar()); 
                conLogin.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Login Table Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                conLogin.Close();
                return;
            }

           
            string insertUser = "INSERT INTO dbo.Users ([Name], [Email], [LoginId], [Phone], [Address], [BloodGroup]) " +
                                "VALUES (@name, @email, @loginid, @phone, @address, @blood)";

            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(insertUser, con);
            cmd.Parameters.AddWithValue("@name", NameTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@email", EmailTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@loginid", newLoginId); 
            cmd.Parameters.AddWithValue("@phone", PhoneTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@address", AddressTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@blood", BloodGroupBox.Text);

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Registration Completed Successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                 
                    NameTextBox.Clear();
                    EmailTextBox.Clear();
                    PasswordTextBox.Clear();
                    AddressTextBox.Clear();
                    PhoneTextBox.Clear();
                    BloodGroupBox.SelectedIndex = -1;

                 
                    LoginForm lo = new LoginForm();
                    lo.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Registration Failed!", "Error",
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
        private void BloodGroupBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; 
            }
        }
    }
}
