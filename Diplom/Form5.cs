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

namespace Diplom
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        static string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        SqlConnection conn = new SqlConnection(ConnString);
        private void Vhod()
        {
            try
            {
                if ((string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrWhiteSpace(textBox1.Text)) && (string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrWhiteSpace(textBox2.Text)))
                {
                    MessageBox.Show("Поля должны быть заполненны.");
                }
                else
                {
                    conn.Open();
                    SqlCommand Admin = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Doctor] WHERE [Login] = 'admin' AND [Password]= 'admin'", conn);
                    int i = Convert.ToInt32(Admin.ExecuteScalar());
                    if (i == 1)
                    {
                        Form1 form = new Form1();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        SqlCommand Doctor = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Doctor] WHERE [Login] = 'doctor' AND [Password] = 'doctor'", conn);

                        i = Convert.ToInt32(Doctor.ExecuteScalar());
                        if (i == 1)
                        {
                            Form1 form = new Form1();
                            form.Show();
                            this.Hide();
                            //TODO добавить сокрытие кнопок
                            form.button9.Visible = false;
                        }
                        else
                        {
                            SqlCommand Nurse = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Doctor] WHERE [Login] = 'nurse' AND [Password] = 'nurse'", conn);

                            i = Convert.ToInt32(Nurse.ExecuteScalar());
                            if (i == 1)
                            {
                                Form1 form = new Form1();
                                form.Show();
                                this.Hide();
                                //TODO добавить сокрытие кнопок
                                form.button9.Visible = false;
                                form.button2.Visible = false;
                                form.button3.Visible = false;
                                form.button6.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Логин или пароль введены неверно");

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Vhod();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vhod();
            }
        }
        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Close();
        }
    }
}
