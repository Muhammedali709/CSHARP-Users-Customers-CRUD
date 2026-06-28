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
    public partial class Form1 : Form
    {
        public static int CurrentUserId;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string user_input = textBox1.Text;
            string user_password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(user_input) || string.IsNullOrWhiteSpace(user_password))
            {
                MessageBox.Show("Please enter both Username and Password!", "Warning");
                return; 
            }

            try
            {
                using (SqlConnection con = new SqlConnection(DALC.GetConnectionString()))
                {
                    con.Open();
                    // Запрашиваем ID!
                    SqlCommand cmd = new SqlCommand("Select ID From USERS WHERE USERNAME = @user AND PASSWORD=@pass", con);
                    cmd.Parameters.AddWithValue("@user", user_input);
                    cmd.Parameters.AddWithValue("@pass", user_password);

                    object result = cmd.ExecuteScalar();

                    if (result == null) // Если ничего не нашлось
                    {
                        MessageBox.Show("Username or Password is incorrect");
                    }
                    else
                    {
                        // Сохраняем ID!
                        CurrentUserId = Convert.ToInt32(result);

                        MessageBox.Show("Successfully logged in!");
                        Form3 frm3 = new Form3();
                        frm3.Show();
                        this.Hide();
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Could not connect to the database. Error details: " + ex.Message, "Database Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


}
