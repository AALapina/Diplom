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
    public partial class Form1 : Form
    {
        static string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        SqlConnection conn = new SqlConnection(ConnString);
        int grid = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public void Search_Medicine()
        {
            try
            {
                conn.Open();
                SqlCommand com;
                com = new SqlCommand("SELECT * FROM [dbo].[Medicine] WHERE " +
                   "[MID] LIKE N'" + textBox1.Text + "' OR " +
                   "[MName] LIKE N'%" + textBox1.Text + "%' OR " +
                   "[Substance] LIKE N'%" + textBox1.Text + "%' OR " +
                   "[Dose] LIKE N'" + textBox1.Text + "'OR " +
                   "[Coast] LIKE N'" + textBox1.Text + "'OR " +
                   "[Indication] LIKE N'%" + textBox1.Text + "%'OR " +
                   "[Contr] LIKE N'%" + textBox1.Text + "%'OR " +
                   "[Type] LIKE N'%" + textBox1.Text + "%'OR " +
                   "[Quantity] LIKE N'" + textBox1.Text + "'", conn);
                SqlDataReader sqlR = com.ExecuteReader();
                List<string[]> data = new List<string[]>();
                dataGridView1.Rows.Clear();
                while (sqlR.Read())
                {
                    data.Add(new string[9]);
                    data[data.Count - 1][0] = sqlR[0].ToString();
                    data[data.Count - 1][1] = sqlR[1].ToString();
                    data[data.Count - 1][2] = sqlR[2].ToString();
                    data[data.Count - 1][3] = sqlR[3].ToString();
                    data[data.Count - 1][4] = sqlR[4].ToString();
                    data[data.Count - 1][5] = sqlR[5].ToString();
                    data[data.Count - 1][6] = sqlR[6].ToString();
                    data[data.Count - 1][7] = sqlR[7].ToString();
                    data[data.Count - 1][8] = sqlR[8].ToString();
                }
                sqlR.Close();
                foreach (string[] s in data)
                {
                    dataGridView1.Rows.Add(s);
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
        public void Search_Patient()
        {
            try
            {
                conn.Open();
                SqlCommand com;
                com = new SqlCommand("SELECT * FROM [dbo].[Patient] WHERE " +
                   "[PID] LIKE N'" + textBox1.Text + "' OR " +
                   "[PName] LIKE N'%" + textBox1.Text + "%' OR " +
                   "[Birthday] LIKE N'%" + textBox1.Text + "%'OR " +
                   "[Arrival] LIKE N'%" + textBox1.Text + "%'OR " +
                   "[Passport] LIKE N'%" + textBox1.Text + "%'OR " +
                   "[Policy] LIKE N'%" + textBox1.Text + "%'OR " +
                   "[Sick] LIKE N'%" + textBox1.Text + "%'", conn);
                SqlDataReader sqlR = com.ExecuteReader();
                List<string[]> data = new List<string[]>();
                dataGridView2.Rows.Clear();
                while (sqlR.Read())
                {
                    data.Add(new string[7]);
                    data[data.Count - 1][0] = sqlR[0].ToString();
                    data[data.Count - 1][1] = sqlR[1].ToString();
                    data[data.Count - 1][2] = sqlR[2].ToString();
                    data[data.Count - 1][3] = sqlR[3].ToString();
                    data[data.Count - 1][4] = sqlR[4].ToString();
                    data[data.Count - 1][5] = sqlR[5].ToString();
                    data[data.Count - 1][6] = sqlR[6].ToString();
                }
                sqlR.Close();
                foreach (string[] s in data)
                {
                    dataGridView2.Rows.Add(s);
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
        public void Search_Use()
        {
            try
            {
                conn.Open();
                SqlCommand com;
                com = new SqlCommand("SELECT * FROM [dbo].[Use] WHERE " +
                   "[UID] LIKE N'" + textBox1.Text + "' OR " +
                   "[MName] LIKE N'%" + textBox1.Text + "%' OR " +
                   "[PName] LIKE N'%" + textBox1.Text + "%' OR " +
                   "[Quantity] LIKE N'" + textBox1.Text + "' OR " +
                   "[Date] LIKE N'%" + textBox1.Text + "%' OR " +
                   "[Doctor] LIKE N'%" + textBox1.Text + "%' OR " +
                   "[Status] LIKE N'%" + textBox1.Text + "%'", conn);
                SqlDataReader sqlR = com.ExecuteReader();
                List<string[]> data = new List<string[]>();
                dataGridView3.Rows.Clear();
                while (sqlR.Read())
                {
                    data.Add(new string[7]);
                    data[data.Count - 1][0] = sqlR[0].ToString();
                    data[data.Count - 1][1] = sqlR[1].ToString();
                    data[data.Count - 1][2] = sqlR[2].ToString();
                    data[data.Count - 1][3] = sqlR[3].ToString();
                    data[data.Count - 1][4] = sqlR[4].ToString();
                    data[data.Count - 1][5] = sqlR[5].ToString();
                    data[data.Count - 1][6] = sqlR[6].ToString();
                }
                sqlR.Close();
                foreach (string[] s in data)
                {
                    dataGridView3.Rows.Add(s);
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
        public void Search_Doctor()
        {
            try
            {
                conn.Open();
                SqlCommand com;
                com = new SqlCommand("SELECT * FROM [dbo].[Doctor] WHERE " +
                    "[DName] LIKE N'%" + textBox1.Text + "%' OR " +
                    "[Login] LIKE N'%" + textBox1.Text + "%' OR " +
                    "[Password] LIKE N'%" + textBox1.Text + "%' OR " +
                    "[Number] LIKE N'%" + textBox1.Text + "%'", conn);
                SqlDataReader sqlR = com.ExecuteReader();
                List<string[]> data = new List<string[]>();
                dataGridView4.Rows.Clear();
                while (sqlR.Read())
                {
                    data.Add(new string[5]);
                    data[data.Count - 1][0] = sqlR[0].ToString();
                    data[data.Count - 1][1] = sqlR[1].ToString();
                    data[data.Count - 1][2] = sqlR[2].ToString();
                    data[data.Count - 1][3] = sqlR[3].ToString();
                    data[data.Count - 1][4] = sqlR[4].ToString();
                }
                sqlR.Close();
                foreach (string[] s in data)
                {
                    dataGridView4.Rows.Add(s);
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
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            grid = 0;
            Search_Medicine();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            grid = 1;
            Search_Patient();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            dataGridView4.Visible = false;
            grid = 2;
            Search_Use();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = true;
            grid = 3;
            Search_Doctor();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (grid == 0)
            {
                Search_Medicine();
            }
            else
            {
                if (grid == 1)
                {
                    Search_Patient();
                }
                else
                {
                    if (grid == 2)
                    {
                        Search_Use();
                    }
                    else
                    {
                        if (grid == 3)
                        {
                            Search_Doctor();
                        }
                    }
                }
            }
        }
        private void назначитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            Search_Medicine();
        }
        Point point = new Point();
        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            point.X = e.ColumnIndex;
            point.Y = e.RowIndex;
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                DialogResult result = MessageBox.Show("Вы точно хотите удалить лекарство?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SqlCommand com = new SqlCommand("DELETE FROM [dbo].[Medicine] WHERE [MID] = '" + dataGridView1[0, point.Y].Value.ToString() + "'", conn);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Лекарство удалено.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                Search_Medicine();
            }
        }
        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog();
            Search_Medicine();
        }
        private void назначитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                DialogResult result = MessageBox.Show("Вы точно хотите удалить пациента?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SqlCommand com = new SqlCommand("DELETE FROM [dbo].[Patient] WHERE [PID] = '" + dataGridView2[0, point.Y].Value.ToString() + "'", conn);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Пациент удален.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                Search_Patient();
            }
        }
        private void изменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
            Search_Patient();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            Search_Medicine();
            Form5 fr = new Form5();
            fr.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand com;
                string query = "";
                if (trackBar1.Value == 0 && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox4.Text))
                {
                    query = String.Format("SELECT * FROM [dbo].[Medicine] WHERE ([MID] LIKE N'%{0}' OR " +
                   "[MName] LIKE N'%{0}%' OR " +
                   "[Type] LIKE N'%{0}%' OR " +
                   "[Indication] LIKE N'%{0}%' OR " +
                   "[Substance] LIKE N'%{0}%') AND " +
                   "[Contr] NOT LIKE N'%{1}%'",
                   textBox2.Text,
                   textBox4.Text
                   );
                }
                if (trackBar1.Value == 0 && !String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox4.Text))
                {
                    query = String.Format("SELECT * FROM [dbo].[Medicine] WHERE " +
                   "[MID] LIKE N'%{0}' OR " +
                   "[MName] LIKE N'%{0}%' OR " +
                   "[Type] LIKE N'%{0}%' OR " +
                   "[Indication] LIKE N'%{0}%' OR " +
                   "[Substance] LIKE N'%{0}%'",
                   textBox2.Text
                   );
                }
                if (trackBar1.Value == 0 && !String.IsNullOrEmpty(textBox4.Text) && String.IsNullOrEmpty(textBox2.Text))
                {
                    query = String.Format("SELECT * FROM [dbo].[Medicine] WHERE " +
                   "[Contr] NOT LIKE N'%{0}%'",
                   textBox4.Text
                   );
                }
                if (trackBar1.Value != 0 && String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox4.Text))
                {
                    query = String.Format("SELECT * FROM [dbo].[Medicine] WHERE " +
                   "[Coast] BETWEEN 0 AND {0}",

                   trackBar1.Value

                   );
                }
                if (trackBar1.Value != 0 && String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox4.Text))
                {
                    query = String.Format("SELECT * FROM [dbo].[Medicine] WHERE ([Coast] BETWEEN 0 AND {0})" +
                        " AND " +
                   "[Contr] NOT LIKE N'%{1}%'",
                   trackBar1.Value,
                   textBox4.Text
                   );
                }
                if (trackBar1.Value != 0 && !String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox4.Text))
                {
                    query = String.Format("SELECT * FROM [dbo].[Medicine] WHERE ([MID] LIKE N'%{0}' OR " +
                   "[MName] LIKE N'%{0}%' OR " +
                   "[Type] LIKE N'%{0}%' OR " +
                   "[Indication] LIKE N'%{0}%' OR " +
                   "[Substance] LIKE N'%{0}%') AND " +
                   "[Coast] BETWEEN 0 AND {1} ",

                   textBox2.Text,
                   trackBar1.Value
                   );
                }
                if (trackBar1.Value != 0 && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox4.Text))
                {
                    query = String.Format("SELECT * FROM [dbo].[Medicine] WHERE ([MID] LIKE N'%{0}' OR " +
                   "[MName] LIKE N'%{0}%' OR " +
                   "[Type] LIKE N'%{0}%' OR " +
                   "[Indication] LIKE N'%{0}%' OR " +
                   "[Substance] LIKE N'%{0}%') AND ([Coast] BETWEEN 0 AND {1})" +
                   " AND " +
                   "[Contr] NOT LIKE N'%{2}%'",
                   textBox2.Text,
                   trackBar1.Value,
                   textBox4.Text
                   );
                }
                com = new SqlCommand(query, conn);
                SqlDataReader sqlR = com.ExecuteReader();
                List<string[]> data = new List<string[]>();
                dataGridView1.Rows.Clear();
                while (sqlR.Read())
                {
                    data.Add(new string[9]);
                    data[data.Count - 1][0] = sqlR[0].ToString();
                    data[data.Count - 1][1] = sqlR[1].ToString();
                    data[data.Count - 1][2] = sqlR[2].ToString();
                    data[data.Count - 1][3] = sqlR[3].ToString();
                    data[data.Count - 1][4] = sqlR[4].ToString();
                    data[data.Count - 1][5] = sqlR[5].ToString();
                    data[data.Count - 1][6] = sqlR[6].ToString();
                    data[data.Count - 1][7] = sqlR[7].ToString();
                    data[data.Count - 1][8] = sqlR[8].ToString();
                }
                sqlR.Close();
                foreach (string[] s in data)
                {
                    dataGridView1.Rows.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                panel1.Hide();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            Search_Medicine();
        }
        private void выполненоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand com1 = new SqlCommand("UPDATE [dbo].[Use] SET [Status] = N'Выполнено' WHERE [UID] = N'" + dataGridView3[0, point.Y].Value.ToString() + "'", conn);
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
                Search_Use();
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int t = trackBar1.Value;
            string s = t.ToString();
            toolTip1.SetToolTip(trackBar1, s);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы точно хотите сменить пользователя?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Form5 fr = new Form5();
                fr.Show();
                this.Hide();
            }
        }
        private void назначитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            Search_Doctor();
        }
        private void изменитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.ShowDialog();
            Search_Doctor();
        }
        private void удалитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                DialogResult result = MessageBox.Show("Вы точно хотите удалить сотрудника?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SqlCommand com = new SqlCommand("DELETE FROM [dbo].[Doctor] WHERE [DID] = '" + dataGridView4[0, point.Y].Value.ToString() + "'", conn);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Сотрудник удален.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                Search_Doctor();
            }
        }
    }
}
