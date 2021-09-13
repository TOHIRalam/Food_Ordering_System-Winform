using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class HomeScreenUser : Form
    {
        public HomeScreenUser() { InitializeComponent(); }

        private void pageLoad(object sender, EventArgs e)
        {
            HomeButton.BackColor = Color.Crimson;
            orderHistoryButton.BackColor = Color.FromArgb(42, 42, 42);
            myCart.BackColor = Color.FromArgb(42, 42, 42);
            customFoodItems1.BringToFront();
            UsernameLabel.Text = LogInfo.session_user_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable deleteData = new DataTable();
                new SqlDataAdapter($"DELETE FROM activeUsers WHERE user_email = '{LogInfo.session_user_email}'", DATABASE.connect).Fill(deleteData);
                LogInfo.delete_data();
                new LoginScreen().Show(); Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void HomeButtonClick(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            orderHistoryButton.BackColor = Color.FromArgb(42, 42, 42);
            HomeButton.BackColor = Color.Crimson;
            myCart.BackColor = Color.FromArgb(42, 42, 42);
            customFoodItems1.BringToFront();
        }

        private void myCart_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            myCart.BackColor = Color.Crimson;
            orderHistoryButton.BackColor = Color.FromArgb(42, 42, 42);
            HomeButton.BackColor = Color.FromArgb(42, 42, 42);
            customMyCart1.BringToFront();
        }

        private void orderHistoryButton_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            myCart.BackColor = Color.FromArgb(42, 42, 42);
            orderHistoryButton.BackColor = Color.Crimson;
            HomeButton.BackColor = Color.FromArgb(42, 42, 42);
        }
    }
}
