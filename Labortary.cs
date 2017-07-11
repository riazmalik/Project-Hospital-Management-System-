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
    public partial class Labortary : Form
    {
        SqlDataAdapter sda;
        SqlCommand cmd;
        //  MyConnection mc;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
        int indexROw;
        public Labortary()
        {
            InitializeComponent();
        }

        private void Labortary_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int c = 0;
            conn.Open();
            cmd = new SqlCommand("select count(T_ID) from Medical_Test where Name='" + textBox2.Text + "'", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox1.Text = textBox2.Text + "_Med>Test_" + c.ToString();
            if (textBox2.Text == "")
            {
                textBox1.Text = "";
            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            cmd = new SqlCommand("Insert into Medical_Test(Name,T_ID,Gender,Age,BloodGroup,ReportDate,PType,Status,Description,TestType)values(@Name,@T_ID,@Gender,@Age,@BloodGroup,@ReportDate,@PType,@Status,@Description,@TestType);", conn);

            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@T_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Age", textBox3.Text);
            cmd.Parameters.AddWithValue("@BloodGroup", comboBox3.Text);
            cmd.Parameters.AddWithValue("@ReportDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Ptype", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Status", textBox4.Text);           
            cmd.Parameters.AddWithValue("@Description", textBox7.Text);
            cmd.Parameters.AddWithValue("@TestType", comboBox4.Text);


            cmd.ExecuteNonQuery();
            conn.Close();
            display_data();

            MessageBox.Show("Test Sample Conducted..!!");
            
        }
        public void display_data()
        {
            conn.Open();
            cmd = new SqlCommand("select *from Medical_Test", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select *from Medical_Test where Name='" + textBox9.Text + "'", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
