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
using System.Xml.Linq;

namespace C__FIRST_PROJECT
{
    public partial class Form5 : Form
    {
        Form3 parentForm;
        public Form5(Form3 incomingForm, int id, string name, string surname, string company, string country, string prefix, string number)
        {
            InitializeComponent();
            parentForm = incomingForm;

            textBox1.Tag = id;
            // 2. Сразу заполняем TextBoxes прилетевшими данными!
            textBox1.Text = name;
            textBox2.Text = surname;
            textBox3.Text = company;
            textBox4.Text = country;
            textBox5.Text = prefix;
            textBox6.Text = number;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] fields = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text };
            if (fields.Any(string.IsNullOrWhiteSpace))
            {
                MessageBox.Show("Please fill every TextBox!", "Warning");
                return;
            }
            using (SqlConnection con = new SqlConnection(DALC.GetConnectionString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE CUSTOMERS SET NAME = @NAME,SURNAME=@SURNAME,COMPANY=@COMPANY,COUNTRY=@COUNTRY,PREFIX=@PREFIX,NUMBER=@NUMBER WHERE ID = @id", con);
                cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
                cmd.Parameters.AddWithValue("@SURNAME", textBox2.Text);
                cmd.Parameters.AddWithValue("@COMPANY", textBox3.Text);
                cmd.Parameters.AddWithValue("@COUNTRY", textBox4.Text);
                cmd.Parameters.AddWithValue("@PREFIX", textBox5.Text);
                cmd.Parameters.AddWithValue("@NUMBER", textBox6.Text);

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Tag));

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success!Entered informations are now in DB");
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                    return;
                }
                parentForm.doldur();
                this.Close();



            }
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {




            
        }
    }
}
