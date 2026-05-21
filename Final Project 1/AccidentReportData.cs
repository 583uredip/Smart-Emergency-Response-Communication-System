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
    public partial class AccidentReportData : Form
    {
        public AccidentReportData()
        {
            InitializeComponent();
        }

        private void AccidentReportData_Load(object sender, EventArgs e)
        {
            dataGridView1.CellMouseEnter += (s, ev) =>
            {
                if (ev.RowIndex >= 0 && dataGridView1.Columns[ev.ColumnIndex].Name == "MediaPath")
                    dataGridView1.Cursor = Cursors.Hand;
                else
                    dataGridView1.Cursor = Cursors.Default;
            };
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.AccidentReports ORDER BY ReportDate DESC";
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "MediaPath")
            {
                string mediaPath = dataGridView1.Rows[e.RowIndex].Cells["MediaPath"].Value.ToString();

                if (string.IsNullOrWhiteSpace(mediaPath))
                {
                    MessageBox.Show("No media file available!", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!System.IO.File.Exists(mediaPath))
                {
                    MessageBox.Show("File not found!\nPath: " + mediaPath, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ext = System.IO.Path.GetExtension(mediaPath).ToLower();

                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp")
                {
                    Form imgForm = new Form
                    {
                        Text = "Evidence Image",
                        Size = new Size(800, 600),
                        StartPosition = FormStartPosition.CenterScreen
                    };

                    PictureBox pb = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        Image = Image.FromFile(mediaPath),
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    imgForm.Controls.Add(pb);
                    imgForm.ShowDialog();
                }
                else
                {
                    System.Diagnostics.Process.Start(mediaPath);
                }
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

            int reportId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ReportId"].Value);

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?",
                                                   "Confirm Delete",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM dbo.AccidentReports WHERE ReportId = @id";
                SqlConnection con = DBHelper.GetConnection();
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@id", reportId);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully!", "Success",
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

        private void Hospital_Button_Logout_Click(object sender, EventArgs e)
        {
            Police_From po = new Police_From();
            po.Show();
            this.Hide();
        }
    }
}