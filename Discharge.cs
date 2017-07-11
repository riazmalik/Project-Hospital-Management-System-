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
    public partial class Discharge : Form
    {
        SqlDataAdapter sda;
        SqlCommand cmd;
        //  MyConnection mc;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
        // int indexROw;
        public Discharge()
        {
            InitializeComponent();
        }

        private void Discharge_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from InPatient where P_ID='" + comboBox2.Text + "';", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr["Admission_Date"].ToString();

            }
            conn.Close();
            conn.Open();
            cmd = new SqlCommand("select * from Bill where P_id='" + comboBox2.Text + "';", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox5.Text = dr["B_id"].ToString();
                textBox4.Text = dr["Status"].ToString();

            }
            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            conn.Open();

            cmd = new SqlCommand("select P_ID from InPatient where Name='" + textBox2.Text + "' and Status='Admit'", conn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                comboBox2.Items.Add(dr["P_ID"].ToString());

            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            cmd = new SqlCommand("Insert into Discharge(Name,P_ID,B_id,AdmissionDate,DischargeDate,Description)values(@Name,@P_ID,@B_id,@AdmissionDate,@DischargeDate,@Description);", conn);
           
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@P_ID", comboBox2.Text);
            cmd.Parameters.AddWithValue("@B_id", textBox5.Text);
            cmd.Parameters.AddWithValue("@AdmissionDate", textBox3.Text);
            cmd.Parameters.AddWithValue("@DischargeDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Description", textBox7.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            cmd = new SqlCommand("Update InPatient set Status='Discharged'where P_ID='"+comboBox2.Text+"'" , conn);
            cmd.ExecuteReader();
            conn.Close();


            MessageBox.Show("Patient has Been Discharged after'"+textBox7.Text+"'.....!!");
        }
    }
}
