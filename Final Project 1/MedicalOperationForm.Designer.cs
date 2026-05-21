
namespace Final_Project_1
{
    partial class MedicalOperationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.HospitalPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.Hospital_Button_Logout = new Guna.UI2.WinForms.Guna2Button();
            this.Hospital_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.HospitalPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(121, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(734, 356);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.Red;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.White;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.Black;
            this.guna2Button3.Location = new System.Drawing.Point(615, 489);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.guna2Button3.Size = new System.Drawing.Size(124, 55);
            this.guna2Button3.TabIndex = 17;
            this.guna2Button3.Text = "Delete";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Red;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(206, 489);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.guna2Button1.Size = new System.Drawing.Size(111, 55);
            this.guna2Button1.TabIndex = 15;
            this.guna2Button1.Text = "Show";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(351, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 31);
            this.label2.TabIndex = 16;
            this.label2.Text = "Medical Operation";
            // 
            // HospitalPanel1
            // 
            this.HospitalPanel1.BackColor = System.Drawing.Color.IndianRed;
            this.HospitalPanel1.Controls.Add(this.Hospital_Button_Logout);
            this.HospitalPanel1.Controls.Add(this.Hospital_Label);
            this.HospitalPanel1.Controls.Add(this.label1);
            this.HospitalPanel1.ForeColor = System.Drawing.Color.Red;
            this.HospitalPanel1.Location = new System.Drawing.Point(-55, -3);
            this.HospitalPanel1.Name = "HospitalPanel1";
            this.HospitalPanel1.Size = new System.Drawing.Size(1002, 80);
            this.HospitalPanel1.TabIndex = 14;
            // 
            // Hospital_Button_Logout
            // 
            this.Hospital_Button_Logout.BackColor = System.Drawing.Color.Red;
            this.Hospital_Button_Logout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Hospital_Button_Logout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Hospital_Button_Logout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Hospital_Button_Logout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Hospital_Button_Logout.FillColor = System.Drawing.Color.White;
            this.Hospital_Button_Logout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hospital_Button_Logout.ForeColor = System.Drawing.Color.Black;
            this.Hospital_Button_Logout.Location = new System.Drawing.Point(751, 13);
            this.Hospital_Button_Logout.Name = "Hospital_Button_Logout";
            this.Hospital_Button_Logout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Hospital_Button_Logout.Size = new System.Drawing.Size(210, 44);
            this.Hospital_Button_Logout.TabIndex = 2;
            this.Hospital_Button_Logout.Text = "BACK";
            this.Hospital_Button_Logout.Click += new System.EventHandler(this.Hospital_Button_Logout_Click);
            // 
            // Hospital_Label
            // 
            this.Hospital_Label.AutoSize = true;
            this.Hospital_Label.BackColor = System.Drawing.Color.Transparent;
            this.Hospital_Label.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hospital_Label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Hospital_Label.Location = new System.Drawing.Point(119, 23);
            this.Hospital_Label.Name = "Hospital_Label";
            this.Hospital_Label.Size = new System.Drawing.Size(478, 31);
            this.Hospital_Label.TabIndex = 1;
            this.Hospital_Label.Text = "HOSPITAL EMERGENCY SYSTEM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // MedicalOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 556);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HospitalPanel1);
            this.Name = "MedicalOperationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedicalOperationForm";
            this.Load += new System.EventHandler(this.MedicalOperationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.HospitalPanel1.ResumeLayout(false);
            this.HospitalPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GradientPanel HospitalPanel1;
        private Guna.UI2.WinForms.Guna2Button Hospital_Button_Logout;
        private System.Windows.Forms.Label Hospital_Label;
        private System.Windows.Forms.Label label1;
    }
}