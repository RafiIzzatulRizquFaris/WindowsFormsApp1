using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudents();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=ToughputTest2;Integrated Security=True");
        int id;

        private void GetStudents()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM siswa", con);
            DataTable dataTable = new DataTable();

            con.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            dataTable.Load(sqlDataReader);
            con.Close();

            dataGridView1.DataSource = dataTable;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO siswa VALUES (@name, @telepon, @alamat, @ttl)", con);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@name", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@telepon", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@alamat", textBox4.Text);
                sqlCommand.Parameters.AddWithValue("@ttl", textBox3.Text);

                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);

                GetStudents();
            }
        }

        private bool isValid()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Student Name is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE siswa SET name=@name, alamat=@alamat, telepon=@telepon, ttl=@ttl WHERE id=@id", con);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@id", this.id);
            sqlCommand.Parameters.AddWithValue("@name", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@telepon", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@alamat", textBox4.Text);
            sqlCommand.Parameters.AddWithValue("@ttl", textBox3.Text);

            con.Open();
            sqlCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);

            GetStudents();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE siswa WHERE id=@id", con);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@id", this.id);

            con.Open();
            sqlCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);

            GetStudents();
        }
    }
}
