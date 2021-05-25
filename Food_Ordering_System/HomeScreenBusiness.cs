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
            customProfile1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void addMenuItemButton_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            ProfileButton.BackColor = Color.FromArgb(42, 42, 42);
            requestButton.BackColor = Color.FromArgb(42, 42, 42);
            addMenuItemButton.BackColor = Color.Crimson;
            customUpdateMenu1.BringToFront();
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            requestButton.BackColor = Color.FromArgb(42, 42, 42);
            ProfileButton.BackColor = Color.FromArgb(42, 42, 42);
            addMenuItemButton.BackColor = Color.FromArgb(42, 42, 42);
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            requestButton.BackColor = Color.FromArgb(42, 42, 42);
            ProfileButton.BackColor = Color.Crimson;
            addMenuItemButton.BackColor = Color.FromArgb(42, 42, 42);
            customProfile1.BringToFront();
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            requestButton.BackColor = Color.Crimson;
            ProfileButton.BackColor = Color.FromArgb(42, 42, 42);
            addMenuItemButton.BackColor = Color.FromArgb(42, 42, 42);
            customOrderRequests1.BringToFront();
        }

        private void customUpdateMenu1_Load(object sender, EventArgs e)
        {

        }

        private void sidePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
