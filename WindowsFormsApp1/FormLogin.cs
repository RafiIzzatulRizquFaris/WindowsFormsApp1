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
    public partial class FormLogin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=ToughputTest2;Integrated Security=True");
        public FormLogin()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '*';
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            getLogin();
        }

        private void getLogin()
        {
            string query = "SELECT * FROM Login_Tabel WHERE username = '" + tbUsername.Text.Trim() + "' AND password = '" + tbPassword.Text.Trim() + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if(dataTable.Rows.Count == 1)
            {
                Form1 form1 = new Form1();
                this.Hide();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Cannot Find Username or Password like that", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (tbPassword.TextLength >= 5)
            {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Login_Tabel Values (@username, @password)", con);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@username", tbUsername.Text);
                sqlCommand.Parameters.AddWithValue("@password", tbUsername.Text);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Your Regristration is complete, Please Login again", "Success Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbUsername.Clear();
                tbUsername.Clear();
            }
            else
            {
                MessageBox.Show("Password must be 5 or more character", "Cannot Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
