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

    public partial class Doctors : Form
    {
        SqlDataAdapter sda;
        SqlCommand cmd;
      //  MyConnection mc;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
        int indexROw;
        public Doctors()
        {
          
           
            InitializeComponent();
            this.textBox3.PasswordChar = '*';
            
        }


        private void Doctors_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_Management_SystemDataSet.Doctors' table. You can move, or remove it, as needed.
            this.doctorsTableAdapter.Fill(this.hospital_Management_SystemDataSet.Doctors);
           
           

            display_data();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // mc = new MyConnection();
            conn.Open();
            
            cmd=new SqlCommand("Insert into Doctors(Name,Login_id,Password,Department,Specialization,Ph#,Address,Email,Age,Gender)values(@Name,@Login_id,@Password,@Department,@Specialization,@Ph#,@Address,@Email,@Age,@Gender);",conn);

            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Login_id", textBox2.Text);
            cmd.Parameters.AddWithValue("@Password", textBox3.Text);
            cmd.Parameters.AddWithValue("@Department", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Specialization", textBox7.Text);
            cmd.Parameters.AddWithValue("@Ph#", textBox5.Text);
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);
            cmd.Parameters.AddWithValue("@Email", textBox8.Text);
            cmd.Parameters.AddWithValue("@Age", textBox4.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
        

            cmd.ExecuteNonQuery();
            conn.Close();
            display_data();

            MessageBox.Show("Reacord has been inserted");
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            int c = 0;
            conn.Open();
            cmd = new SqlCommand("select count(Login_id) from Doctors where Name='" + textBox1.Text + "'",conn);
             dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;
            }
            textBox2.Text = textBox1.Text +"_Doc_00"+ c.ToString();
            if(textBox1.Text=="")               
            {
                textBox2.Text = "";
            }

            conn.Close();
        }
        public void display_data()
        {
            conn.Open();
            cmd = new SqlCommand("select *from Doctors", conn);
             sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRow row = dataGridView1.Rows[indexROw];
                row.Cells[2].Value = textBox1.Text;
                row.Cells[0].Value = textBox2.Text;
                row.Cells[1].Value = textBox3.Text;
                row.Cells[9].Value = comboBox1.Text;
                row.Cells[8].Value = textBox4.Text;
                row.Cells[3].Value = comboBox2.Text;
                row.Cells[5].Value = textBox5.Text;
                row.Cells[6].Value = textBox6.Text;
                row.Cells[4].Value = textBox7.Text;
                row.Cells[7].Value = textBox8.Text;


                SqlCommandBuilder ccb = new SqlCommandBuilder(sda);
                sda.Update(dt);
                MessageBox.Show("Record Updated....!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry  Do not Update....");
            }

            


           
            

         


          
            
           
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox1.ReadOnly = true;            
            indexROw = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexROw];
            textBox1.Text = row.Cells[2].Value.ToString();
            textBox2.Text = row.Cells[0].Value.ToString();
            textBox3.Text = row.Cells[1].Value.ToString();
            comboBox1.Text = row.Cells[9].Value.ToString();
            textBox4.Text = row.Cells[8].Value.ToString();
            comboBox2.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
            textBox6.Text = row.Cells[6].Value.ToString();
            textBox7.Text = row.Cells[4].Value.ToString();
            textBox8.Text = row.Cells[7].Value.ToString();
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select *from Doctors where Name='"+textBox9.Text+"'", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            indexROw = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(indexROw);
        
            SqlCommandBuilder local_SqlCommandBuilder = new SqlCommandBuilder(sda);

            local_SqlCommandBuilder.ConflictOption = System.Data.ConflictOption.OverwriteChanges;

            sda.UpdateCommand = local_SqlCommandBuilder.GetUpdateCommand();

            sda.Update(((System.Data.DataTable)this.dataGridView1.DataSource));

            ((System.Data.DataTable)this.dataGridView1.DataSource).AcceptChanges();

            MessageBox.Show("Record Deleted...");
        }

        private void doctorsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
