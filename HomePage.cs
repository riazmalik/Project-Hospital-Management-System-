using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System__Project_
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label2.Text = DateTime.Now.ToLongDateString();
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Appointment appoint = new Appointment();
            appoint.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PatientInfo patientdetail = new PatientInfo();
            patientdetail.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pharmacy pharm = new Pharmacy();
            pharm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Discharge discharge = new Discharge();
            discharge.Show();
        }
    }
}
