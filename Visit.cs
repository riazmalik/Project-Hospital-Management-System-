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

namespace Hospital_Management_System__Project_
{
    public partial class Visit : Form
    {
        SqlDataAdapter sda;
        SqlCommand cmd;
        //  MyConnection mc;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
       int indexROw;
        public Visit()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();

            cmd = new SqlCommand("select Name from Doctors where Department='" + comboBox2.Text + "'", conn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                comboBox3.Items.Add(dr["Name"].ToString());

            }

            conn.Close();
        }

        private void Visit_Load(object sender, EventArgs e)
        {
            display_data();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();

            cmd = new SqlCommand("select Name from InPatient where Doctor='" + comboBox3.Text + "'", conn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                comboBox1.Items.Add(dr["Name"].ToString());

            }

            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select *from InPatient where Name='" + comboBox1.Text + "'", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            
        }
        public void display_data()
        {
            conn.Open();
            cmd = new SqlCommand("select *from InPatient ", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[indexROw];
            row.Cells[13].Value = comboBox4.Text;
           
            SqlCommandBuilder ccb = new SqlCommandBuilder(sda);
            sda.Update(dt);
            MessageBox.Show("Submited Report....!!");
               
        }
    }
}
