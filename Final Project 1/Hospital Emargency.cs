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
using Final_Project_1.Resources;

namespace Final_Project_1
{
    public partial class Hospital_Emargency : Form
    {
        public Hospital_Emargency()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoginForm lo = new LoginForm();
            lo.Show();
            this.Hide();
        }
        

        private void Hospital_Emargency_Load(object sender, EventArgs e)
        {

        }
       

        private int GetCount(string query)
        {
            SqlConnection con = DBHelper.GetConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch { return 0; }
            finally { con.Close(); }
        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void bloodBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blood_Bank b = new Blood_Bank();
            b.Show();
            this.Hide();
        }

        private void ambulanceServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AmbulanceForm ab = new AmbulanceForm();
            ab.Show();
            this.Hide();
        }

        private void medicalOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicalOperationForm mo = new MedicalOperationForm();
            mo.Show();
            this.Hide();
        }

        private void Hospital_Button_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void HospitalPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void HospitalPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
