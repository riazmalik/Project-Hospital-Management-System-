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
    public partial class Pharmacy : Form
    {
        SqlDataAdapter sda;
        SqlCommand cmd;
        //  MyConnection mc;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LP4MQGC;Initial Catalog=Hospital_Management_System;Integrated Security=True");
        //  int indexROw;
        string Medicine;
        public Pharmacy()
        {
            InitializeComponent();
        }

        private void Pharmacy_Load(object sender, EventArgs e)
        {
            //display_data();












        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            conn.Open();

            cmd = new SqlCommand("Insert into Pharmacy(Name,P_ID,PType,Departement,Medicines,Quantity,Amount)values(@Name,@P_ID,@PType,@Departement,@Medicines,@Quantity,@Amount);", conn);

            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@P_ID", comboBox4.Text);
            cmd.Parameters.AddWithValue("@Ptype", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Departement", textBox3.Text);
            cmd.Parameters.AddWithValue("@Medicines",Medicine);
            cmd.Parameters.AddWithValue("@Quantity", textBox7.Text);
            cmd.Parameters.AddWithValue("@Amount", textBox2.Text);


            cmd.ExecuteNonQuery();
            conn.Close();
            display_data();

            MessageBox.Show("Medicine has been given..!!");

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from InPatient where P_ID='" + comboBox4.SelectedItem + "';", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr["Departement"].ToString();
               
            }
            conn.Close();
        }
        public void display_data()
        {
            conn.Open();
            cmd = new SqlCommand("select *from Pharmacy", conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();

            cmd = new SqlCommand("select P_ID from InPatient where Status='Admit' and Name='" + textBox1.Text + "'", conn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                comboBox4.Items.Add(dr["P_ID"].ToString());

            }

            conn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(textBox7.Text) * Convert.ToInt32(textBox4.Text);
            textBox2.Text = amount.ToString();


            try
            {
                if (textBox2.Text == "")
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Quantity did not show");
            }
            
            }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Medicine = "Tablet";
            this.textBox4.Clear();
            textBox4.Text += (10).ToString();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Medicine = "Capsules";
            this.textBox4.Clear();
            textBox4.Text += (20).ToString();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Medicine = "Syrups";
            this.textBox4.Clear();
            textBox4.Text += (50).ToString();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Medicine = "Ointment"; 
            this.textBox4.Clear();
            textBox4.Text += (35).ToString();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Medicine = "Drops";
            this.textBox4.Clear();
            textBox4.Text += (40).ToString();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            Medicine = "Injection";
            this.textBox4.Clear();
            textBox4.Text += (100).ToString();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            Medicine = "Inhaler";
            this.textBox4.Clear();
            textBox4.Text += (75).ToString();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            Medicine = "Powder";
            this.textBox4.Clear();
            textBox4.Text += (55).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* int Amount = Convert.ToInt32(textBox2.Text);
            int quantity = Convert.ToInt32(textBox7.Text);
            int price = Convert.ToInt32(textBox4.Text);


            Amount += price * quantity;
            textBox2.Text = Amount.ToString();*/


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        }
    }

