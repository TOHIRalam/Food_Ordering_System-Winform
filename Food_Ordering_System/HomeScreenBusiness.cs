using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Food_Ordering_System
{
    public partial class HomeScreenBusiness : Form
    {
        public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
        public HomeScreenBusiness()
        {
            InitializeComponent();
        }

        private void pageLoad(object sender, EventArgs e)
        {
            customProfile1.BringToFront();
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

        private void addMenuItemButton_Click(object sender, EventArgs e)
        {
            ProfileButton.BackColor = Color.FromArgb(42, 42, 42);
            historyButton.BackColor = Color.FromArgb(42, 42, 42);
            addMenuItemButton.BackColor = Color.Crimson;
            customUpdateMenu1.BringToFront();
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            ProfileButton.BackColor = Color.FromArgb(42, 42, 42);
            historyButton.BackColor = Color.Crimson;
            addMenuItemButton.BackColor = Color.FromArgb(42, 42, 42);
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            ProfileButton.BackColor = Color.Crimson;
            historyButton.BackColor = Color.FromArgb(42, 42, 42);
            addMenuItemButton.BackColor = Color.FromArgb(42, 42, 42);
            customProfile1.BringToFront();
        }
    }
}
