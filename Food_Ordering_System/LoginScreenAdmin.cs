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
                SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
                new SqlDataAdapter($"SELECT * FROM adminLogin WHERE name = '{name}' AND password = '{password}'", connect).Fill(dataTable);

                if (dataTable.Rows.Count == 1)
                {
                    Hide();
                    new AdminView().Show();
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
            Hide();
            new LoginScreen().Show();
        }
    }
}
