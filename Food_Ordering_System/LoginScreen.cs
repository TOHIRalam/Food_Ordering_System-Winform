using System;
using System.Drawing;
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
                    SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
                    new SqlDataAdapter($"SELECT email, password, user_type FROM UserInfo WHERE email = '{email}' AND password = '{password.GetHashCode()}';", connect).Fill(searchedData);
                    if (searchedData.Rows.Count == 1) {
                        Hide();
                        if (searchedData.Rows[0][2].ToString() == "User") {
                            new HomeScreenUser().Show();
                        } else if(searchedData.Rows[0][2].ToString() == "Delivery") {
                            new HomeScreenDelivery().Show();
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

        private void label8_Click(object sender, EventArgs e) { Hide(); new RegistrationScreenBusiness().Show(); }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Hide();
            new RegistrationScreenDelivery().Show();
        }

        private void textBoxHover(object sender, EventArgs e)
        {
            registerLabel.ForeColor = Color.DarkBlue;
        }

        private void textBoxLeave(object sender, EventArgs e)
        {
            registerLabel.ForeColor = Color.SteelBlue;
        }

        private void businessRegisterHover(object sender, EventArgs e)
        {
            label8.ForeColor = Color.DarkBlue;
        }

        private void businessRegisterLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.SteelBlue;
        }

        private void deliveryHover(object sender, EventArgs e)
        {
            label9.ForeColor = Color.DarkBlue;
        }

        private void deliveryLeave(object sender, EventArgs e)
        {
            label9.ForeColor = Color.SlateBlue;
        }

        private void adminLabelHover(object sender, EventArgs e)
        {
            adminLabel.ForeColor = Color.Black;
        }

        private void adminLabelLeave(object sender, EventArgs e)
        {
            adminLabel.ForeColor = Color.Gray;
        }

        private void adminLabel_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginScreenAdmin().Show();
        }
    }
}
