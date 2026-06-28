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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C__FIRST_PROJECT
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4(this);
            frm4.Show();

        }


        public void doldur()
        {
            using (SqlConnection con = new SqlConnection(DALC.GetConnectionString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * FROM CUSTOMERS", con);

                SqlDataReader dr = cmd.ExecuteReader();


                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }

        }
        private void getToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doldur();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow Row = dataGridView1.CurrentRow;
                if (Row.IsNewRow)
                {
                    MessageBox.Show("There is no data,select existing one!");
                    return;
                }
                int id = Convert.ToInt32(Row.Cells["ID"].Value);
                string name = Row.Cells["NAME"].Value.ToString();
                string surname = Row.Cells["SURNAME"].Value.ToString();
                string company = Row.Cells["COMPANY"].Value.ToString();
                string country = Row.Cells["COUNTRY"].Value.ToString();
                string prefix = Row.Cells["PREFIX"].Value.ToString();
                string number = Row.Cells["NUMBER"].Value.ToString();
                Form5 frm5 = new Form5(this, id, name, surname, company, country, prefix, number);
                frm5.Show();

            }
            else
            {
                MessageBox.Show("Please select an entire row first! (Click the empty header space on the left of the row)", "Warning");
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, не пустая ли строка (твой идеальный код)
            DataGridViewRow Row = dataGridView1.CurrentRow;
            if (Row == null || Row.IsNewRow) // Добавил проверку на null на всякий случай
            {
                MessageBox.Show("There is no data, select existing one!");
                return;
            }

            // 2. СПРАШИВАЕМ ЮЗЕРА: "Ты точно уверен?"
            DialogResult result = MessageBox.Show("Are you sure you want to delete this contact?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // 3. Если он нажал "Да", только тогда лезем в базу
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(DALC.GetConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM CUSTOMERS WHERE ID = @id", con);

                    // Микро-правка: ID в базе это число, так что лучше конвертировать в Int32, а не в строку
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Row.Cells["ID"].Value));

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success! Picked Customer is no more in DB");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    doldur(); 
                }
            }
        }
    }
}