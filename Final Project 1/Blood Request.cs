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
    public partial class Blood_Request : Form
    {
        string conStr = @"Data Source=desktop-udmdgkf\sqlexpress;Initial Catalog=Smart Emargency System Bd;Integrated Security=True;TrustServerCertificate=True";
        private int _loginId;

        public Blood_Request(int loginId)
        {
            _loginId = loginId;
            InitializeComponent();
        }
        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UserOparetion u = new UserOparetion(_loginId);
            u.Show();
            this.Hide();
        }

        private void Blood_Request_Load(object sender, EventArgs e)
        {

        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BloodPatientTextBox.Text) ||string.IsNullOrWhiteSpace(BloodPhoneTextBox.Text) || string.IsNullOrWhiteSpace(BloodcomboBox.Text) || string.IsNullOrWhiteSpace(BloodLocationTextBox.Text))
            {
                MessageBox.Show("All fields are required!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string insertQuery = "INSERT INTO dbo.BloodRequests (PatientName, BloodGroup, Location, Phone, IsUrgent, Status, RequestDate, LoginId) " +
                                 "VALUES (@patient, @blood, @location, @phone, @urgent, 'Open', GETDATE(), @loginId)";

            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@patient", BloodPatientTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@blood", BloodcomboBox.Text);
            cmd.Parameters.AddWithValue("@location", BloodLocationTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@phone", BloodPhoneTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@urgent", BloodCheckBox.Checked ? 1 : 0);
            cmd.Parameters.AddWithValue("@loginId", _loginId);

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Blood Request Submitted Successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BloodPatientTextBox.Clear();
                    BloodPhoneTextBox.Clear();
                    BloodcomboBox.SelectedIndex = -1;
                    BloodLocationTextBox.Clear();
                    BloodCheckBox.Checked = false;

                
                    UserOparetion u = new UserOparetion(_loginId);
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

        private void BloodPhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
