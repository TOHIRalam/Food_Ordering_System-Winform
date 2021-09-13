using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class HomeScreenDelivery : Form
    {
        public HomeScreenDelivery()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable deleteData = new DataTable();
                new SqlDataAdapter($"DELETE FROM activeUsers WHERE user_email = '{LogInfo.session_user_email}'", DATABASE.connect).Fill(deleteData);
                LogInfo.delete_data(); new LoginScreen().Show(); Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
