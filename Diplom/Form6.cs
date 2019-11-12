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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        static string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        SqlConnection conn = new SqlConnection(ConnString);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Doctor] (DName, Login, Password, Number) VALUES (N'" + comboBox1.Text + "', '" + textBox1.Text + "', N'" + textBox2.Text + "', N'" + textBox3.Text + "')", conn);
                com.ExecuteNonQuery();
                MessageBox.Show("Сотрудник добавлен");
                this.Close();
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand com1 = new SqlCommand("UPDATE [dbo].[Doctor] SET " +
                "[Login] = '" + textBox1.Text + "', " +
                "[Password] = '" + textBox2.Text + "', " +
                "[Number] = N'" + textBox2.Text + "' WHERE [DName] = N'" + comboBox1.Text + "'", conn);
                com1.ExecuteNonQuery();
                MessageBox.Show("Изменения сохраненны");
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand com = new SqlCommand("SELECT [Login] FROM [dbo].[Doctor] WHERE [DName] = N'" + comboBox1.Text + "'", conn);
                textBox1.Text = com.ExecuteScalar().ToString();
                com = new SqlCommand("SELECT [Password] FROM [dbo].[Doctor] WHERE [DName] = N'" + comboBox1.Text + "'", conn);
                textBox2.Text = com.ExecuteScalar().ToString();
                com = new SqlCommand("SELECT [Number] FROM [dbo].[Doctor] WHERE [DName] = N'" + comboBox1.Text + "'", conn);
                textBox3.Text = com.ExecuteScalar().ToString();
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
        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Doctor". При необходимости она может быть перемещена или удалена.
            this.doctorTableAdapter.Fill(this.database1DataSet.Doctor);

        }
    }
}
