using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Pharmacy
{
    public partial class Form3 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

            sqlConnection.Open();


            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Medications", sqlConnection);

            DataSet db = new DataSet();

            dataAdapter.Fill(db);

            dataGridView1.DataSource = db.Tables[0];
            dataGridView2.DataSource = db.Tables[0];
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                
                SqlCommand command = new SqlCommand($"INSERT INTO [Medications] (Name, Disease, Symptom, Bestbeforedate, Description) VALUES(@Name, @Disease, @Symptom, @Bestbeforedate, @Description)", sqlConnection);

                DateTime date = DateTime.Parse(textBox4.Text);

                command.Parameters.AddWithValue("Name", textBox1.Text);
                command.Parameters.AddWithValue("Disease", textBox2.Text);
                command.Parameters.AddWithValue("Symptom", textBox3.Text);
                command.Parameters.AddWithValue("Bestbeforedate", $"{date.Month}/{date.Day}/{date.Year}");
                command.Parameters.AddWithValue("Description", textBox5.Text);

                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Заполние пожалуйста все поля", "Ошибка");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выделенную запись", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No) {
                return;
            }

            SqlCommand s_cmd = sqlConnection.CreateCommand();
            s_cmd.CommandText = $"DELETE FROM Medications WHERE id = '{textBox6.Text}'";
            s_cmd.ExecuteNonQuery();

            MessageBox.Show(s_cmd.ExecuteNonQuery().ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Close();
        }
    }
}
