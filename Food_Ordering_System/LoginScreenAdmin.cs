using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class LoginScreenAdmin : Form
    {
        public LoginScreenAdmin()
        {
            InitializeComponent();
            passwordBox.PasswordChar = '*';
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text.Trim();
            string password = passwordBox.Text.Trim();

            try
            {
                DataTable dataTable = new DataTable();
                new SqlDataAdapter($"SELECT * FROM adminLogin WHERE name = '{name}' AND password = '{password}'", DATABASE.connect).Fill(dataTable);

                if (dataTable.Rows.Count == 1)
                {
                    new AdminView().Show(); Close();
                }
                else
                {
                    MessageBox.Show("Invalid Input\nNo user found!");
                }
            } 
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void loginLabel_Click(object sender, EventArgs e)
        {
            new LoginScreen().Show(); Close();
        }
    }
}
