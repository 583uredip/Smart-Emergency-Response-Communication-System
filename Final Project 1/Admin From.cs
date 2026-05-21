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
    public partial class Admin_From : Form
    {
        public Admin_From()
        {
            InitializeComponent();
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.Login WHERE UserName LIKE '%" + guna2TextBox1.Text + "%' ORDER BY LoginId DESC";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            NameTextBox.Text = row.Cells["UserName"].Value.ToString();
            PasswordTextBox.Text = row.Cells["Password"].Value.ToString();
            comboBox1.Text = row.Cells["Role"].Value.ToString();

            int status = Convert.ToInt32(row.Cells["Status"].Value);
            AccStatuesBox.Text = status == 1 ? "Active(True)" : "Pending/Disabled(False)";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.Login WHERE Role != 'Admin' ORDER BY LoginId DESC";
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
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) || string.IsNullOrWhiteSpace(AccStatuesBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
                string.IsNullOrWhiteSpace(BloodGroupBox.Text) ||
                string.IsNullOrWhiteSpace(guna2TextBox4.Text))
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
            SqlConnection conCheck = DBHelper.GetConnection();
            SqlCommand cmdCheck = new SqlCommand(checkUser, conCheck);
            cmdCheck.Parameters.AddWithValue("@user", NameTextBox.Text.Trim());
            conCheck.Open();
            int userCount = (int)cmdCheck.ExecuteScalar();
            conCheck.Close();

            if (userCount > 0)
            {
                MessageBox.Show("This Username already exists!", "Duplicate Username",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NameTextBox.Focus();
                return;
            }
            if (comboBox1.Text == "User" && !string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                string checkEmail = "SELECT COUNT(*) FROM dbo.Users WHERE [Email]=@email";
                SqlConnection conEmail = DBHelper.GetConnection();
                SqlCommand cmdEmail = new SqlCommand(checkEmail, conEmail);
                cmdEmail.Parameters.AddWithValue("@email", EmailTextBox.Text.Trim());
                conEmail.Open();
                int emailCount = (int)cmdEmail.ExecuteScalar();
                conEmail.Close();

                if (emailCount > 0)
                {
                    MessageBox.Show("This Email already exists!", "Duplicate Email",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    EmailTextBox.Focus();
                    return;
                }
            }

            int status = AccStatuesBox.Text == "Active(True)" ? 1 : 0;

            string insertLogin = "INSERT INTO dbo.Login ([UserName], [Password], [Status], [Role]) " +
                                 "VALUES (@username, @pass, @status, @role);" +
                                 "SELECT SCOPE_IDENTITY();";

            SqlConnection conLogin = DBHelper.GetConnection();
            SqlCommand cmdLogin = new SqlCommand(insertLogin, conLogin);
            cmdLogin.Parameters.AddWithValue("@username", NameTextBox.Text.Trim());
            cmdLogin.Parameters.AddWithValue("@pass", PasswordTextBox.Text.Trim());
            cmdLogin.Parameters.AddWithValue("@status", status);
            cmdLogin.Parameters.AddWithValue("@role", comboBox1.Text);

            int newLoginId = 0;
            try
            {
                conLogin.Open();
                newLoginId = Convert.ToInt32(cmdLogin.ExecuteScalar());
                conLogin.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Login Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                conLogin.Close();
                return;
            }
            if (comboBox1.Text == "User")
            {
                string insertUser = "INSERT INTO dbo.Users ([Name], [Email], [LoginId], [Phone], [Address], [BloodGroup]) " +
                                    "VALUES (@name, @email, @loginid, @phone, @address, @blood)";

                SqlConnection conUser = DBHelper.GetConnection();
                SqlCommand cmdUser = new SqlCommand(insertUser, conUser);
                cmdUser.Parameters.AddWithValue("@name", NameTextBox.Text.Trim());
                cmdUser.Parameters.AddWithValue("@email", EmailTextBox.Text.Trim());
                cmdUser.Parameters.AddWithValue("@loginid", newLoginId);
                cmdUser.Parameters.AddWithValue("@phone", PhoneTextBox.Text.Trim());
                cmdUser.Parameters.AddWithValue("@address", AddressTextBox.Text.Trim());
                cmdUser.Parameters.AddWithValue("@blood", BloodGroupBox.Text);          

                try
                {
                    conUser.Open();
                    cmdUser.ExecuteNonQuery();
                    conUser.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("User Error: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conUser.Close();
                }
            }

            MessageBox.Show("Account Added Successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            guna2Button6_Click(sender, e);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(AccStatuesBox.Text))
             
            {
                MessageBox.Show("All fields are required!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int status = AccStatuesBox.Text == "Active(True)" ? 1 : 0;

            string updateQuery = "UPDATE dbo.Login SET Password=@pass, Role=@role, Status=@status WHERE UserName=@user";
            SqlConnection con = DBHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@user", NameTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", PasswordTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@role", comboBox1.Text);
            cmd.Parameters.AddWithValue("@status", status);

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Account Updated Successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    guna2Button6_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Update Failed!", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Please select a user first!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this user?\nAll related data will also be deleted!",
                                                   "Confirm Delete",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string deleteBlood = "DELETE FROM dbo.BloodRequests WHERE LoginId = " +
                                         "(SELECT LoginId FROM dbo.Login WHERE UserName=@user)";
                    SqlConnection con1 = DBHelper.GetConnection();
                    SqlCommand cmd1 = new SqlCommand(deleteBlood, con1);
                    cmd1.Parameters.AddWithValue("@user", NameTextBox.Text.Trim());
                    con1.Open();
                    cmd1.ExecuteNonQuery();
                    con1.Close();

                    string deleteUser = "DELETE FROM dbo.Users WHERE LoginId = " +
                                        "(SELECT LoginId FROM dbo.Login WHERE UserName=@user)";
                    SqlConnection con2 = DBHelper.GetConnection();
                    SqlCommand cmd2 = new SqlCommand(deleteUser, con2);
                    cmd2.Parameters.AddWithValue("@user", NameTextBox.Text.Trim());
                    con2.Open();
                    cmd2.ExecuteNonQuery();
                    con2.Close();
                    string deleteLogin = "DELETE FROM dbo.Login WHERE UserName=@user";
                    SqlConnection con3 = DBHelper.GetConnection();
                    SqlCommand cmd3 = new SqlCommand(deleteLogin, con3);
                    cmd3.Parameters.AddWithValue("@user", NameTextBox.Text.Trim());
                    con3.Open();
                    cmd3.ExecuteNonQuery();
                    con3.Close();

                    MessageBox.Show("Deleted Successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    guna2Button6_Click(sender, e);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            LoginForm lo = new LoginForm();
            lo.Show();
            this.Hide();
        }

        private void ClearFields()
        {
            NameTextBox.Clear();
            PasswordTextBox.Clear();
            PhoneTextBox.Clear();
            EmailTextBox.Clear();
            AddressTextBox.Clear();
            BloodGroupBox.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            AccStatuesBox.SelectedIndex = -1;
        }
        private void Admin_From_Load(object sender, EventArgs e)
        {
           
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e) { }
        private void EmailTextBox_TextChanged(object sender, EventArgs e) { }
        private void PasswordTextBox_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void BloodGroupBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void PhoneTextBox_TextChanged(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
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