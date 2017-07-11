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
    public partial class Operation : Form
    {
        SqlDataAdapter sda;
        SqlCommand cmd;
        //  MyConnection mc;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
        //  int indexROw;
        public Operation()
        {
            InitializeComponent();
        }

        private void Operation_Load(object sender, EventArgs e)
        {
            display_data();
            conn.Open();

            cmd = new SqlCommand("select Name from InPatient where Prefered='Operation'", conn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                comboBox4.Items.Add(dr["Name"].ToString());

            }

            conn.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from InPatient where Name='" + comboBox4.SelectedItem + "';", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["P_id"].ToString();
                textBox7.Text = dr["Gender"].ToString();
                textBox3.Text = dr["Age"].ToString();
                textBox1.Text = dr["Departement"].ToString();
                textBox5.Text = dr["Doctor"].ToString();

            }
            conn.Close();
            textBox4.Text = "InPatient";
            // textBox4.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            cmd = new SqlCommand("Insert into Operation(Name,P_ID,Gender,Age,PType,Departement,Doctor,OperationDate,OperationType)values(@Name,@P_ID,@Gender,@Age,@PType,@Departement,@Doctor,@OperationDate,@OperationType);", conn);

            cmd.Parameters.AddWithValue("@Name", comboBox4.Text);
            cmd.Parameters.AddWithValue("@P_ID", textBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", textBox7.Text);
            cmd.Parameters.AddWithValue("@Age", textBox3.Text);
            cmd.Parameters.AddWithValue("@PType", textBox3.Text);
            cmd.Parameters.AddWithValue("@Departement", textBox1.Text);
            cmd.Parameters.AddWithValue("@Doctor", textBox5.Text);
            cmd.Parameters.AddWithValue("@OperationDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@OperationType", textBox6.Text);



            cmd.ExecuteNonQuery();
            conn.Close();
            display_data();

            MessageBox.Show("Appointment has been Given..!!");
        }
        public void display_data()
        {
            conn.Open();
            cmd = new SqlCommand("select *from Operation ", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
    }
}
