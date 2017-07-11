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
    public partial class OutPatient : Form
    {
        SqlDataAdapter sda;
        SqlCommand cmd;
        //  MyConnection mc;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
        //int indexROw;
    
        public OutPatient()
        {
            InitializeComponent();
        }

        private void OutPatient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_Management_SystemDataSet.OutPatient' table. You can move, or remove it, as needed.
            this.outPatientTableAdapter.Fill(this.hospital_Management_SystemDataSet.OutPatient);





            display_data();



           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int c = 0;
            conn.Open();
            cmd = new SqlCommand("select count(P_ID) from OutPatient where Name='" + textBox2.Text + "'", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox1.Text = textBox2.Text + "_OutPat_00" + c.ToString();
            if (textBox2.Text == "")
            {
                textBox1.Text = "";
            }

            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             conn.Open();

            cmd = new SqlCommand("select Name from Doctors where Department='"+comboBox2.Text+"'", conn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                comboBox3.Items.Add(dr["Name"].ToString());

            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            cmd = new SqlCommand("Insert into OutPatient(Name,P_ID,Gender,Age,Ph#,Departement,OPD_Date,Checkup_Number,DOctor)values(@Name,@P_ID,@Gender,@Age,@Ph#,@Departement,@OPD_Date,@Checkup_Number,@DOctor);", conn);

            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@P_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Age", textBox3.Text);
            cmd.Parameters.AddWithValue("@Ph#", textBox4.Text);           
            cmd.Parameters.AddWithValue("@Departement", comboBox2.Text); 
            cmd.Parameters.AddWithValue("@OPD_Date",dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Checkup_Number", textBox7.Text);
            cmd.Parameters.AddWithValue("@Doctor", comboBox3.Text);
           


            cmd.ExecuteNonQuery();
            conn.Close();
            display_data();


            MessageBox.Show("Patient has been Registered..!!");
        }


        public void display_data()
        {
            conn.Open();
            cmd = new SqlCommand("select *from OutPatient", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select *from OutPatient where Name='" + textBox9.Text + "'", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

    }
}
