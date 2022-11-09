using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Home_Pharmacy
{
    public partial class Form4 : Form
    {
        private SqlConnection sqlConnection = null;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

            sqlConnection.Open();
            
            SqlDataAdapter  dataAdapter = new SqlDataAdapter("SELECT * FROM Medications", sqlConnection);

            DataSet db = new DataSet();

            dataAdapter.Fill(db);

            dataGridView1.DataSource = db.Tables[0];
        }
        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Disease LIKE '%{textBox1.Text}%'";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Symptom LIKE '%{textBox2.Text}%'";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Close();
        }
    }
}
