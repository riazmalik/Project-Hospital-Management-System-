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
    public partial class InPatient : Form
    {
        SqlDataAdapter sda;
        SqlCommand cmd;
        //  MyConnection mc;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
        int indexROw;
       
        public InPatient()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void InPatient_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'hospital_Management_SystemDataSet.InPatient' table. You can move, or remove it, as needed.
           // this.inPatientTableAdapter.Fill(this.hospital_Management_SystemDataSet.InPatient);


           display_data();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            int c = 0;
            conn.Open();
            cmd = new SqlCommand("select count(P_ID) from InPatient where Name='" + textBox1.Text + "'", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); 
                c++;
            }
            textBox2.Text = textBox1.Text + "_InPat_00" + c.ToString();
            if (textBox1.Text == "")
            {
                textBox2.Text = "";
            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            conn.Open();

            cmd = new SqlCommand("Insert into InPatient(Name,P_ID,Gender,Age,Ph#,Admission_ID,Admission_Date,Status,Departement,Ward_Type,Bed_No,Doctor,Disease)values(@Name,@P_ID,@Gender,@Age,@Ph#,@Admission_ID,@Admission_Date,@Status,@Departement,@Ward_Type,@Bed_No,@Doctor,@Disease);", conn);

            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@P_ID", textBox2.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Age", textBox3.Text);
            cmd.Parameters.AddWithValue("@Ph#", textBox4.Text);
            cmd.Parameters.AddWithValue("@Admission_ID", textBox5.Text);
            cmd.Parameters.AddWithValue("@Admission_Date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Status", textBox6.Text);
            cmd.Parameters.AddWithValue("@Departement", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Doctor", comboBox3.Text);
            cmd.Parameters.AddWithValue("@Ward_Type", comboBox4.Text);
            cmd.Parameters.AddWithValue("@Bed_NO", textBox8.Text);
            cmd.Parameters.AddWithValue("@Disease", textBox10.Text);


            cmd.ExecuteNonQuery();
            conn.Close();
           display_data();

            MessageBox.Show("Patient has been admitted..!!");
            
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int c = 0;
            conn.Open();
            cmd = new SqlCommand("select count(Admission_ID) from InPatient where Admission_Date='" + dateTimePicker1.Value + "'", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox5.Text = "Admit_0" + c.ToString() + dateTimePicker1.Value;
            if (textBox1.Text=="")
            {
                textBox5.Text = "";
            }

            conn.Close();
        }

        
        public void display_data()
        {
            conn.Open();
            cmd = new SqlCommand("select *from InPatient", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

                DataGridViewRow row = dataGridView1.Rows[indexROw];
                row.Cells[0].Value = textBox2.Text;
                row.Cells[1].Value = textBox1.Text;
                row.Cells[2].Value = comboBox1.Text;
                row.Cells[3].Value = textBox3.Text;
                row.Cells[4].Value = textBox4.Text;
                row.Cells[5].Value = textBox5.Text;
                row.Cells[6].Value = dateTimePicker1.Text;
                row.Cells[7].Value = textBox6.Text;
                row.Cells[8].Value = comboBox2.Text;
                row.Cells[9].Value = comboBox4.Text;
                row.Cells[10].Value = textBox8.Text;
                row.Cells[11].Value = comboBox3.Text;
                row.Cells[12].Value = textBox10.Text;

               SqlCommandBuilder ccb = new SqlCommandBuilder(sda);
                sda.Update(dt);
                MessageBox.Show("Record Updated....!!");
               
        
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            indexROw = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexROw];
            textBox2.Text = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            comboBox1.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox4.Text = row.Cells[4].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
            dateTimePicker1.Text = row.Cells[6].Value.ToString();
            textBox6.Text = row.Cells[7].Value.ToString();
            comboBox2.Text = row.Cells[8].Value.ToString();
            comboBox4.Text = row.Cells[9].Value.ToString();
           textBox8.Text = row.Cells[10].Value.ToString();
           comboBox3.Text = row.Cells[11].Value.ToString();
           textBox10.Text = row.Cells[12].Value.ToString();
          
          
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
            cmd = new SqlCommand("select *from InPatient where Name='" + textBox9.Text + "'", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }


}
