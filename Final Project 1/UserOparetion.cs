using Final_Project_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_1
{
    public partial class UserOparetion : Form
    {
        private int _loginId;

        public UserOparetion(int loginId)
        {
            _loginId = loginId;
            InitializeComponent();
        }

        public UserOparetion()
        {
            _loginId = 0;
            InitializeComponent();
        }

        private void UserOparetion_Load(object sender, EventArgs e)
        {
            LoadBloodFeed();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            LoadBloodFeed();
        }

        private void LoadBloodFeed()
        {
            flowPanel.Controls.Clear();

            string query = @"SELECT r.PatientName, r.BloodGroup, r.Location, 
                                    r.Phone, r.IsUrgent, r.RequestDate, 
                                    u.Name as RequesterName 
                             FROM dbo.BloodRequests r 
                             JOIN dbo.Users u ON r.LoginId = u.LoginId 
                             WHERE r.Status = 'Open' 
                             ORDER BY r.IsUrgent DESC, r.RequestDate DESC";

            SqlConnection con = DBHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No active blood requests at the moment.",
                        Font = new Font("Segoe UI", 12, FontStyle.Italic),
                        ForeColor = Color.White,
                        AutoSize = true,
                        Margin = new Padding(10)
                    };
                    flowPanel.Controls.Add(lblEmpty);
                    return;
                }

                while (reader.Read())
                {
                    Panel card = CreateBloodCard(
                        reader["PatientName"].ToString(),
                        reader["BloodGroup"].ToString(),
                        reader["Location"].ToString(),
                        reader["Phone"].ToString(),
                        (bool)reader["IsUrgent"],
                        (DateTime)reader["RequestDate"],
                        reader["RequesterName"].ToString()
                    );
                    flowPanel.Controls.Add(card);
                }
                reader.Close();
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


        private Panel CreateBloodCard(string patient, string bloodGroup, string location,
                                       string phone, bool isUrgent, DateTime date, string requester)
        {
            Panel card = new Panel
            {
                Width = 580,
                Height = 130,
                BackColor = isUrgent ? Color.FromArgb(200, 255, 235, 238)
                                     : Color.FromArgb(200, 255, 255, 255),
                Margin = new Padding(5, 5, 5, 8),
                BorderStyle = BorderStyle.FixedSingle
            };

            Panel strip = new Panel
            {
                Dock = DockStyle.Left,
                Width = 8,
                BackColor = isUrgent ? Color.FromArgb(211, 47, 47)
                                     : Color.FromArgb(0, 122, 204)
            };
            card.Controls.Add(strip);

            Label lblGroup = new Label
            {
                Text = bloodGroup,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = isUrgent ? Color.FromArgb(183, 28, 28)
                                     : Color.FromArgb(13, 71, 161),
                Location = new Point(18, 15),
                Size = new Size(70, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle
            };
            card.Controls.Add(lblGroup);

            Label lblPatient = new Label
            {
                Text = "👤 Patient: " + patient,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(100, 10),
                AutoSize = true
            };

            Label lblLocation = new Label
            {
                Text = "📍 " + location,
                Font = new Font("Segoe UI", 10),
                Location = new Point(100, 38),
                AutoSize = true,
                ForeColor = Color.DimGray
            };

            Label lblPhone = new Label
            {
                Text = "📞 " + phone + "  (By: " + requester + ")",
                Font = new Font("Segoe UI", 10),
                Location = new Point(100, 62),
                AutoSize = true,
                ForeColor = Color.DimGray
            };

            Label lblFooter = new Label
            {
                Text = isUrgent ? "⚠️ URGENT • " + date.ToString("g")
                                : "🕐 " + date.ToString("g"),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = isUrgent ? Color.Red : Color.Gray,
                Location = new Point(100, 95),
                AutoSize = true
            };

            card.Controls.Add(lblPatient);
            card.Controls.Add(lblLocation);
            card.Controls.Add(lblPhone);
            card.Controls.Add(lblFooter);

            return card;
        }


        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Accident_Report re = new Accident_Report();
            re.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Medical_Emergency me = new Medical_Emergency();
            me.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            LoginForm lo = new LoginForm();
            lo.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Blood_Request bo = new Blood_Request(_loginId);
            bo.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Crime_Report re = new Crime_Report();
            re.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Coming Soon!", "Coming Soon",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is Coming Soon!", "Coming Soon",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}