using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Food_Ordering_System
{
    public partial class HomeScreenBusiness : Form
    {
        public HomeScreenBusiness()
        {
            InitializeComponent();
        }

        private void pageLoad(object sender, EventArgs e)
        {
            try
            {
                DataTable restaurant_data = new DataTable();
                SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
                new SqlDataAdapter($"SELECT * FROM RestaurantInformation INNER JOIN activeUsers ON RestaurantInformation.manager_email = activeUsers.user_email;", connect).Fill(restaurant_data);
                restaurantNameDashboard.Text = restaurant_data.Rows[0][1].ToString() + " - Dashboard";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable deleteData = new DataTable();
                SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
                new SqlDataAdapter($"DELETE FROM activeUsers;", connect).Fill(deleteData);
                Hide(); new LoginScreen().Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
