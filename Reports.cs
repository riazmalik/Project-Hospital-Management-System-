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
    public partial class Reports : Form
    {
        SqlDataAdapter sda;
        SqlCommand cmd;
        //  MyConnection mc;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
        //  int indexROw;
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select T_ID from Medical_Test where Name='" + textBox2.Text + "'and Status='Pending'", conn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                comboBox1.Items.Add(dr["T_ID"].ToString());

            }
            conn.Close();
           
         //   if
          //     (textBox2.Text == "")
          //  {
          //      comboBox1.Text = "";
          //  }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            else
            {
                conn.Open();


                cmd = new SqlCommand("select * from Medical_Test where T_ID='" + comboBox1.SelectedItem + "' ;", conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   // textBox2.Text = dr["T_ID"].ToString();
                    textBox1.Text = dr["Gender"].ToString();
                    textBox3.Text = dr["Age"].ToString();
                    textBox6.Text = dr["BloodGroup"].ToString();
                    textBox5.Text = dr["PType"].ToString();
                    textBox8.Text = dr["ReportDate"].ToString();
                    textBox4.Text = dr["Status"].ToString();
                    textBox7.Text = dr["Description"].ToString();
                    textBox9.Text = dr["TestType"].ToString();

                }
                conn.Close();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          this.panel2.Visible=true;
          this. label23.Text=  textBox2.Text;
          this.label27.Text = comboBox1.Text; ;
            this.label24.Text=textBox1.Text ;
          this.label28.Text= textBox3.Text ;
         this.label29.Text=   textBox6.Text ;
          this.label25.Text=  textBox5.Text ;
        this.label30.Text=    textBox8.Text ;
          this.label22.Text=  textBox7.Text ;
          this.label26.Text=  textBox9.Text ;
           // MessageBox.Show("Report Collected");

            conn.Open();
            cmd = new SqlCommand("Update Medical_Test set Status='Collected'",conn);
            cmd.ExecuteReader();
            conn.Close();
            MessageBox.Show("Report Collected");



        }
    }
}
