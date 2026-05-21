using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_1
{
    public partial class Police_From : Form
    {
        public Police_From()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Hospital_Button_Logout_Click(object sender, EventArgs e)
        {
            LoginForm lo = new LoginForm();
            lo.Show();
            this.Hide();
        }

        private void Police_From_Load(object sender, EventArgs e)
        {

        }

        private void crimeReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrimeReportData cr = new CrimeReportData();
            cr.Show();
            this.Hide();
        }

        private void accidentReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccidentReportData acc = new AccidentReportData();
            acc.Show();
            this.Hide();
        }
    }
}
