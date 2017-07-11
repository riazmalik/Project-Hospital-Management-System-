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
    public partial class Employee : Form
    {
        SqlDataAdapter sda;
        SqlCommand cmd;
        //  MyConnection mc;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
        int indexROw;

        public Employee()
        {
            InitializeComponent();
            this.textBox3.PasswordChar = '*';
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_Management_SystemDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.hospital_Management_SystemDataSet.Employee);




            display_data();
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int c = 0;
            conn.Open();
            cmd = new SqlCommand("select count(Login_id) from Employee where Post='" + comboBox3.Text + "'", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;
              
            }
            textBox2.Text =  textBox1.Text+"_"+ comboBox3.Text + c.ToString();
            if (comboBox3.Text=="")
            {
                textBox2.Text = "";
            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // mc = new MyConnection();
            conn.Open();

            cmd = new SqlCommand("Insert into Employee(Name,Post,Login_id,Password,Department,Ph#,Address,Age,Gender,Email)values(@Name,@Post,@Login_id,@Password,@Department,@Ph#,@Address,@Age,@Gender,@Email);", conn);

            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Post", comboBox3.Text);
            cmd.Parameters.AddWithValue("@Login_id", textBox2.Text);
            cmd.Parameters.AddWithValue("@Password", textBox3.Text);
            cmd.Parameters.AddWithValue("@Department",comboBox2.Text);
            cmd.Parameters.AddWithValue("@Ph#", textBox5.Text);
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);
            cmd.Parameters.AddWithValue("@Age", textBox4.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Email", textBox8.Text);


            cmd.ExecuteNonQuery();
            conn.Close();
          display_data();

            MessageBox.Show("Employee has been Registered..!!");
            
        }
        public void display_data()
        {
            conn.Open();
            cmd = new SqlCommand("select *from Employee", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
            indexROw = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexROw];
            textBox1.Text = row.Cells[2].Value.ToString();
            textBox2.Text = row.Cells[0].Value.ToString();
            textBox3.Text = row.Cells[1].Value.ToString();
            comboBox1.Text = row.Cells[8].Value.ToString();
            textBox4.Text = row.Cells[7].Value.ToString();
            comboBox2.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
            textBox6.Text = row.Cells[6].Value.ToString();
            comboBox3.Text = row.Cells[4].Value.ToString();
            textBox8.Text = row.Cells[9].Value.ToString();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRow row = dataGridView1.Rows[indexROw];
                row.Cells[2].Value = textBox1.Text;
                row.Cells[0].Value = textBox2.Text;
                row.Cells[1].Value = textBox3.Text;
                row.Cells[8].Value = comboBox1.Text;
                row.Cells[7].Value = textBox4.Text;
                row.Cells[3].Value = comboBox2.Text;
                row.Cells[5].Value = textBox5.Text;
                row.Cells[6].Value = textBox6.Text;
                row.Cells[4].Value = comboBox3.Text;
                row.Cells[9].Value = textBox8.Text;


                SqlCommandBuilder ccb = new SqlCommandBuilder(sda);
                sda.Update(dt);
                MessageBox.Show("Record Updated....!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry  Do not Update....");
            }

            
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select *from Employee where Name='" + textBox9.Text + "'", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        
    }
}
