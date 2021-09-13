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
                    DataTable searchedData = new DataTable(); DataTable activeUser = new DataTable();
                    new SqlDataAdapter($"SELECT name, email, password, user_type, contact, address FROM UserInfo WHERE email = '{email}' AND password = '{password.GetHashCode()}'", DATABASE.connect).Fill(searchedData);
                    if (searchedData.Rows.Count == 1) {
                        LogInfo.set_user_data(searchedData.Rows[0][0].ToString(), email, searchedData.Rows[0][4].ToString(), searchedData.Rows[0][5].ToString()); Hide();
                        if (searchedData.Rows[0][3].ToString() == "User") {
                            new HomeScreenUser().Show();
                        } else if(searchedData.Rows[0][3].ToString() == "Delivery") {
                            new HomeScreenDelivery().Show();
                        } else {
                            searchedData.Clear();
                            try
                            {
                                new SqlDataAdapter($"SELECT restaurant_name, restaurant_email, official_contact, restaurant_location " +
                                $"FROM RestaurantInformation WHERE manager_email = '{LogInfo.session_user_email}'", DATABASE.connect).Fill(searchedData);
                                LogInfo.set_business_data(searchedData.Rows[0][0].ToString(), searchedData.Rows[0][1].ToString(), searchedData.Rows[0][2].ToString(), searchedData.Rows[0][3].ToString());
                                new HomeScreenBusiness().Show();
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show(exc.Message + "\nRestaurant Database error");
                            }
                        } 
                        new SqlDataAdapter($"INSERT INTO activeUsers VALUES ('{email}', '{LogInfo.session_user_name}')", DATABASE.connect).Fill(activeUser);
                    } else {
                        MessageBox.Show("Invalid email or password!!");
                        searchedData.Clear();
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

    public static class LogInfo
    {
        // Temporary user info
        public static string session_user_name;
        public static string session_user_email;
        public static string session_user_address;
        public static string session_user_contact;

        // Temporary business info
        public static string session_restaurant_name;
        public static string session_restaurant_email;
        public static string session_restaurant_contact;
        public static string session_restaurant_location;

        public static void set_user_data(string name, string email, string contact, string address) {
            session_user_name = name;
            session_user_email = email;
            session_user_contact = contact;
            session_user_address = address;
        }

        public static void set_business_data(string restName, string restEmail, string restContact, string restLocation)
        {
            session_restaurant_name = restName;
            session_restaurant_email = restEmail;
            session_restaurant_contact = restContact;
            session_restaurant_location = restLocation;
        }

        public static void delete_data()
        {
            session_user_name = ""; session_user_email = ""; session_user_contact = ""; session_user_address = "";
            session_restaurant_name = ""; session_restaurant_email = ""; session_restaurant_contact = ""; session_restaurant_location = "";
        }
    }

    public static class DATABASE
    {
        public static SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
    }
}
