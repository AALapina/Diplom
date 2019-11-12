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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        static string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        SqlConnection conn = new SqlConnection(ConnString);
        private void button1_Click(object sender, EventArgs e)
        {
            if ((!(string.IsNullOrEmpty(comboBox1.Text)) && !(string.IsNullOrWhiteSpace(comboBox1.Text))) 
                && (!(string.IsNullOrEmpty(textBox2.Text)) && !(string.IsNullOrWhiteSpace(textBox2.Text))) 
                && (!(string.IsNullOrEmpty(textBox3.Text)) && !(string.IsNullOrWhiteSpace(textBox3.Text))) 
                && (!(string.IsNullOrEmpty(textBox4.Text)) && !(string.IsNullOrWhiteSpace(textBox4.Text))) 
                && (!(string.IsNullOrEmpty(textBox5.Text)) && !(string.IsNullOrWhiteSpace(textBox5.Text))) 
                && (!(string.IsNullOrEmpty(textBox6.Text)) && !(string.IsNullOrWhiteSpace(textBox6.Text))) 
                && (!(string.IsNullOrEmpty(richTextBox1.Text)) && !(string.IsNullOrWhiteSpace(richTextBox1.Text))) 
                && (!(string.IsNullOrEmpty(richTextBox2.Text)) && !(string.IsNullOrWhiteSpace(richTextBox2.Text))))
            {
                try
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Medicine] (MName, Substance, Dose, Coast, Indication, Contr, Type, Quantity) VALUES (N'" + comboBox1.Text + "',N'" + textBox2.Text + "', '" + textBox3.Text + "','" + textBox4.Text + "',N'" + richTextBox1.Text + "',N'" + richTextBox2.Text + "',N'" + textBox5.Text + "','" + textBox6.Text + "')", conn);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Препарат добавлен");
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
            else
            {
                MessageBox.Show("Все поля обязательно должны быть заполнены");
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            this.medicineTableAdapter.Fill(this.database1DataSet.Medicine);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand com1 = new SqlCommand("UPDATE [dbo].[Medicine] SET " +
                "[Substance] = N'" + textBox2.Text + "', " +
                "[Dose] = '" + textBox3.Text + "', " +
                "[Coast] = '" + textBox4.Text + "', " +
                "[Indication] = N'" + richTextBox1.Text + "', " +
                "[Contr] = N'" + richTextBox2.Text + "', " +
                "[Type] = N'" + textBox5.Text + "', " +
                "[Quantity] = '" + textBox6.Text + "' WHERE [MName] = N'" + comboBox1.Text + "'", conn);
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
                SqlCommand com = new SqlCommand("SELECT [Substance] FROM [dbo].[Medicine] WHERE [MName] = N'" + comboBox1.Text + "'", conn);
                textBox2.Text = com.ExecuteScalar().ToString();
                com = new SqlCommand("SELECT [Dose] FROM [dbo].[Medicine] WHERE [MName] = N'" + comboBox1.Text + "'", conn);
                textBox3.Text = com.ExecuteScalar().ToString();
                com = new SqlCommand("SELECT [Coast] FROM [dbo].[Medicine] WHERE [MName] = N'" + comboBox1.Text + "'", conn);
                textBox4.Text = com.ExecuteScalar().ToString();
                com = new SqlCommand("SELECT [Indication] FROM [dbo].[Medicine] WHERE [MName] = N'" + comboBox1.Text + "'", conn);
                richTextBox1.Text = com.ExecuteScalar().ToString();
                com = new SqlCommand("SELECT [Contr] FROM [dbo].[Medicine] WHERE [MName] = N'" + comboBox1.Text + "'", conn);
                richTextBox2.Text = com.ExecuteScalar().ToString();
                com = new SqlCommand("SELECT [Type] FROM [dbo].[Medicine] WHERE [MName] = N'" + comboBox1.Text + "'", conn);
                textBox5.Text = com.ExecuteScalar().ToString();
                com = new SqlCommand("SELECT [Quantity] FROM [dbo].[Medicine] WHERE [MName] = N'" + comboBox1.Text + "'", conn);
                textBox6.Text = com.ExecuteScalar().ToString();
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
    }
}
