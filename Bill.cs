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
    public partial class Bill : Form
    {
        SqlDataAdapter sda;
        SqlCommand cmd;
        //  MyConnection mc;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
       // int indexROw;
        int c;
        int visit;
        int amount;
        
     
        public Bill()
        {
            InitializeComponent();
            
        }

        private void Bill_Load(object sender, EventArgs e)
        {
          
            int c = 0;
            conn.Open();
            cmd = new SqlCommand("select count(B_id) from Bill", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;
                
            }
            textBox10.Text = "Bill_000" + c.ToString();


            conn.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select P_ID from InPatient where Name='" + textBox1.Text + "'", conn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                comboBox1.Items.Add(dr["P_ID"].ToString());

            }
            conn.Close();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();


            cmd = new SqlCommand("select * from InPatient where P_ID='" + comboBox1.SelectedItem + "' ;", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               
                textBox5.Text = dr["Admission_ID"].ToString();
                textBox2.Text = dr["Admission_Date"].ToString();
                textBox8.Text = dr["Departement"].ToString();
                
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();


            cmd = new SqlCommand("select * from Pharmacy where P_ID='" + comboBox1.SelectedItem + "' ;", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox3.Text = dr["Amount"].ToString();
                
            }
            conn.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        
          
           /* try
            {
                amount = Convert.ToInt32(textBox9.Text);
               
            }
            catch (Exception ex)
            {
                textBox9.Text += amount + (1000);
                
            }
        */

            int count = 0;
            if (checkBox1.Checked)
                count++;
            if (checkBox2.Checked)
                count++;
            if (checkBox3.Checked)
                count++;
            textBox9.Text = (1000 * count).ToString();

           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
          
            /*
            try
            {
                amount = Convert.ToInt32(textBox9.Text);
              
            }
            catch (Exception ex)
            {
                textBox9.Text += amount + (1500);
                
            } */

            int count = 0;
            if (checkBox1.Checked)
                count++;
            if (checkBox2.Checked)
                count++;
            if (checkBox3.Checked)
                count++;
            textBox9.Text = (1000 * count).ToString();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
            /*
            try
            {
                amount = Convert.ToInt32(textBox9.Text);
               
            }
            catch (Exception ex)
            {
                textBox9.Text += amount + (2000);
               
            }*/
            int count = 0;
            if (checkBox1.Checked)
                count++;
            if (checkBox2.Checked)
                count++;
            if (checkBox3.Checked)
                count++;
            textBox9.Text = (1000 * count).ToString();
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

           
            /*
                try
                {
                    visit = Convert.ToInt32(textBox4.Text);

                }

                catch (Exception ex)
                {
                    textBox6.Text += visit * (500);

                }*/

            textBox6.Text += Convert.ToInt32(textBox4.Text) * 500;
            try
            {

                if
                    (textBox4.Text == "")
                {
                }
               
            }
            catch (Exception ex)
            {
                textBox6.ReadOnly = false;
            }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Text += Convert.ToInt32(textBox6.Text) + Convert.ToInt32(textBox9.Text) + Convert.ToInt32(textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string status="Paid";
            conn.Open();

            cmd = new SqlCommand("Insert into Bill(B_id,Name,P_id,Department,Admission_ID,Admission_Date,Total_Amount,Status)values(@B_id,@Name,@P_id,@Department,@Admission_ID,@Admission_Date,@Total_Amount,@Status);", conn);
            cmd.Parameters.AddWithValue("@B_id", textBox10.Text);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@P_id", comboBox1.Text);
            
            cmd.Parameters.AddWithValue("@Department", textBox8.Text);
            cmd.Parameters.AddWithValue("@Admission_ID", textBox5.Text);
            cmd.Parameters.AddWithValue("@Admission_Date", textBox2.Text);
            cmd.Parameters.AddWithValue("@Total_Amount", textBox2.Text);
            cmd.Parameters.AddWithValue("@Status", status);


            cmd.ExecuteNonQuery();
            conn.Close();
           

            MessageBox.Show("Bill has been Paid.....!!");

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
