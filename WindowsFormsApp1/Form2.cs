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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-N2LO0FB;Initial Catalog=ToughputTest2;Integrated Security=True");

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM User_Table WHERE username = '" + tbUsername.Text.Trim() + "' AND password = '" + tbPassword.Text.Trim() + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
            
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            
            if(dataTable.Rows.Count == 1)
            {
                
            }

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void TbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Table_1 Values (@username, HASHBYTES('SHA_256', @password))", con);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@username", tbUsername.Text);
            sqlCommand.Parameters.AddWithValue("@password", tbPassword.Text);

            con.Open();
            sqlCommand.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Your Regristration is complete, Please Login again", "Success Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbUsername.Clear();
            tbUsername.Clear();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
