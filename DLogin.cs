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
    public partial class DLogin : Form
    {
       // SqlDataAdapter sda;
        SqlCommand cmd;
        //  MyConnection mc;
        SqlDataReader dr;
       // DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
       // int indexROw;
        string password, username;
        public DLogin()
        {
            InitializeComponent();
            this.textBox2.PasswordChar='*';
        }

        private void DLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * from Doctors where Login_id = '" + textBox1.Text + "'", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                password = dr["Password"].ToString();
                username = dr["Login_id"].ToString();



            }
            conn.Close();
            string un = textBox1.Text;
            string pw = textBox2.Text;
            if
                (un == username && pw == password)
            {
                DocPage doc = new DocPage();
                doc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed..");

            }
            
               
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Doctors doctor = new Doctors();
            doctor.Show();
            
        }
    }
}
