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
    public partial class Form3 : Form
    {
        public Form3()
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
                string aDateTime = DateTime.Now.ToString("dd/MM/yy");
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Patient] (PName, Birthday, Arrival, Passport, Policy, Sick) VALUES (N'" + comboBox1.Text + "', '" + textBox1.Text + "', '" + aDateTime + "', N'" + textBox2.Text + "', N'" + textBox3.Text + "', N'" + richTextBox1.Text + "')", conn);
                com.ExecuteNonQuery();
                MessageBox.Show("Пациент добавлен");
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand com = new SqlCommand("SELECT [Birthday] FROM [dbo].[Patient] WHERE [PName] = N'" + comboBox1.Text + "'", conn);
                textBox1.Text = com.ExecuteScalar().ToString();
                com = new SqlCommand("SELECT [Passport] FROM [dbo].[Patient] WHERE [PName] = N'" + comboBox1.Text + "'", conn);
                textBox2.Text = com.ExecuteScalar().ToString();
                com = new SqlCommand("SELECT [Policy] FROM [dbo].[Patient] WHERE [PName] = N'" + comboBox1.Text + "'", conn);
                textBox3.Text = com.ExecuteScalar().ToString();
                com = new SqlCommand("SELECT [Sick] FROM [dbo].[Patient] WHERE [PName] = N'" + comboBox1.Text + "'", conn);
                richTextBox1.Text = com.ExecuteScalar().ToString();
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
                SqlCommand com1 = new SqlCommand("UPDATE [dbo].[Patient] SET " +
                "[Birthday] = N'" + textBox1.Text + "', " +
                "[Passport] = '" + textBox2.Text + "', " +
                "[Policy] = '" + textBox3.Text + "', " +
                "[Sick] = N'" + richTextBox1.Text + "' WHERE [PName] = N'" + comboBox1.Text + "'", conn);
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
        private void Form3_Load(object sender, EventArgs e)
        {
            this.patientTableAdapter.Fill(this.database1DataSet.Patient);
        }
    }
}
