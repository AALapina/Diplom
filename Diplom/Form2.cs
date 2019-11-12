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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        SqlConnection conn = new SqlConnection(ConnString);
        private void Form2_Load(object sender, EventArgs e)
        {
            this.doctorTableAdapter.Fill(this.database1DataSet.Doctor);
            this.medicineTableAdapter.Fill(this.database1DataSet.Medicine);
            this.patientTableAdapter.Fill(this.database1DataSet.Patient);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand prov = new SqlCommand("SELECT [Quantity] FROM [dbo].[Medicine] WHERE [MName] = N'" + comboBox2.Text + "'", conn);
                int i = Convert.ToInt32(prov.ExecuteScalar());
                int j = Convert.ToInt32(textBox1.Text);
                if (i > j)
                {
                    SqlCommand com1 = new SqlCommand("UPDATE [dbo].[Medicine] SET [Quantity] = [Quantity] - '" + j + "' WHERE [MName] = N'" + comboBox2.Text + "'", conn);
                    com1.ExecuteNonQuery();
                    string aDateTime = DateTime.Now.ToString("dd/MM/yy");
                    SqlCommand com2 = new SqlCommand("INSERT INTO [dbo].[Use] (MName, PName, Quantity, Date, Doctor) Values (N'" + comboBox1.Text + "', N'" + comboBox2.Text + "', '" + textBox1.Text + "','" + aDateTime + "', N'" + comboBox3.Text + "')", conn);
                    com2.ExecuteNonQuery();
                    MessageBox.Show("Назначение создано");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такого лекарства нет в наличии, либо недостаточно");
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
    }
}
