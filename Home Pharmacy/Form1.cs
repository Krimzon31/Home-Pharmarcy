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
using System.Configuration;
using System.Data.Common;

namespace Home_Pharmacy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string password1)
        {
            InitializeComponent();
            this.password = password1;
        }

        string password = "1";

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(password);
            form5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string wweden = textBox1.Text;
            if (password == wweden)
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                MessageBox.Show(
                "Пароль не верен",
                "Ошибка");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
