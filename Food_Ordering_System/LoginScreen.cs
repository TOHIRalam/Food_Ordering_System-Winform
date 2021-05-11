using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            passwordBox.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text.Trim();
            string password = passwordBox.Text.Trim();
            if (email == "" || password == "") {
                MessageBox.Show("Any field should not be empty!");
            } else {
                try {
                    DataTable searchedData = new DataTable();
                    SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-V8VBVOH\SQLEXPRESS;Initial Catalog=FoodOrderingSystemDB_;Integrated Security=True;Pooling=False");
                    new SqlDataAdapter($"SELECT email, password, user_type FROM UserInfo WHERE email = '{email}' AND password = '{password.GetHashCode()}';", connect).Fill(searchedData);
                    if (searchedData.Rows.Count == 1) {
                        Hide();
                        if (searchedData.Rows[0][2].ToString() == "User") {
                            new HomeScreenUser().Show();
                        } else {
                            new HomeScreenBusiness().Show();
                        }
                    } else {
                        MessageBox.Show("User do not exist!");
                    }
                } catch (Exception exc) {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e) { Hide(); new RegistrationScreenUser().Show(); }
    }
}
