using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__FIRST_PROJECT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user_name = textBox1.Text;
            string user_password = textBox2.Text;
            string user_mail = textBox3.Text;

            if ((string.IsNullOrWhiteSpace(user_name) || string.IsNullOrWhiteSpace(user_password))||string.IsNullOrWhiteSpace(user_mail))
            {
                MessageBox.Show("Please fill every TextBox!", "Warning");
                return;
            }
            try
            {
                using (SqlConnection con = new SqlConnection(DALC.GetConnectionString()))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO USERS (USERNAME,EMAIL,PASSWORD) " + "VALUES (@USERNAME,@EMAIL,@PASSWORD)", con);

                    cmd.Parameters.AddWithValue("@USERNAME", user_name);
                    cmd.Parameters.AddWithValue("@PASSWORD", user_password);
                    cmd.Parameters.AddWithValue("@EMAIL", user_mail);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registration successful! You can now log in.", "Success");

                        
                        Form1 frm1 = new Form1();
                        frm1.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Could not connect to the database. Error details: " + ex.Message, "Database Error");
            }

        }
    }
    
}
