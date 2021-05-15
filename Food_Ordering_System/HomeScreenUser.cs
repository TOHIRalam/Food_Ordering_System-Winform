using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class HomeScreenUser : Form
    {
        public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
        public HomeScreenUser()
        {
            InitializeComponent();
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {

        }

        private void pageLoad(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            new SqlDataAdapter($"SELECT name FROM activeUsers", connect).Fill(dataTable);
            UsernameLabel.Text = dataTable.Rows[0][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable deleteData = new DataTable();
                new SqlDataAdapter($"DELETE FROM activeUsers;", connect).Fill(deleteData);
                new LoginScreen().Show(); Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
