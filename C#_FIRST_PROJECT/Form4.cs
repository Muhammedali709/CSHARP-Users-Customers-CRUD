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
    public partial class Form4 : Form
    {
        Form3 parentForm;

        // 2. Меняем конструктор: теперь он требует передать ему Form3
        public Form4(Form3 incomingForm)
        {
            InitializeComponent();
            parentForm = incomingForm; // Запоминаем открытую Form3
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string company = textBox3.Text;
            string country = textBox4.Text;
            string prefix = textBox5.Text;
            string number = textBox6.Text;

            // Собираем все текстовые поля в один массив
            string[] fields = { name, surname, company, country, prefix, number };

            // Проверяем: если ХОТЯ БЫ ОДНО поле пустое или в пробелах, то ругаемся
            if (fields.Any(string.IsNullOrWhiteSpace))
            {
                MessageBox.Show("Please fill every TextBox!", "Warning");
                return;
            }

            using (SqlConnection con = new SqlConnection(DALC.GetConnectionString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CUSTOMERS (NAME, SURNAME, COMPANY, COUNTRY, PREFIX, NUMBER, INSERT_USER) " + "VALUES (@NAME,@SURNAME,@COMPANY,@COUNTRY,@PREFIX,@NUMBER,@USER_ID)",con);
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@SURNAME", surname);
                cmd.Parameters.AddWithValue("@COMPANY", company);
                cmd.Parameters.AddWithValue("@COUNTRY", country);
                cmd.Parameters.AddWithValue("@PREFIX", prefix);
                cmd.Parameters.AddWithValue("@NUMBER", number);

                cmd.Parameters.AddWithValue("@USER_ID", Form1.CurrentUserId);

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
}
}
