using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Pharmacy
{
    public partial class Form5 : Form
    {
        private string password1;
        public Form5(string password)
        {
            InitializeComponent();

            this.password1 = password;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           string newPassword = textBox1.Text;
            if (password1 == newPassword)
            {
                MessageBox.Show(
                "Пароль не может быть такой же как старый",
                "Ошибка");
            }
            else
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        MessageBox.Show(
                            "Ответ на вопрос не верен",
                            "Ошибка");
                        break;

                    case 1:
                        MessageBox.Show(
                            "Пароль изменён",
                            "Успешно");
                        password1 = newPassword;

                        Form1 form1 = new Form1(password1);
                        form1.Show();

                        break;

                    case 2:

                        MessageBox.Show(
                        "Ответ на вопрос не верен",
                        "Успешно");
                        break;

                    case 3:
                        MessageBox.Show(
                        "Ответ на вопрос не верен",
                        "Ошибка");
                        break;
                }
            }
        }
    }
}
