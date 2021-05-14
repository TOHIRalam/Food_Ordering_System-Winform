using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class CustomProfile : UserControl
    {
        public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
        public CustomProfile()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (recaptchaNumber.Text != recaptchaValueBox.Text)
            {
                MessageBox.Show("Captcha failed!");
            }
            else if (fieldComboBox.SelectedItem == null || valueBox.Text == "")
            {
                MessageBox.Show("Emtpy Field!\nUpdate information operation failed!");
            }
            else
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    string field = fieldComboBox.SelectedItem.ToString().Trim();
                    string value = valueBox.Text.Trim();
                    new SqlDataAdapter($"UPDATE RestaurantInformation SET {field} = '{value}' WHERE manager_email = '{userEmailText.Text.Trim()}'", connect).Fill(dataTable);
                    Hide(); new HomeScreenBusiness().Show(); 
                    dataTable.Clear();
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
            recaptchaValueBox.Text = "";
            recaptchaNumber.Text = new Random().Next(1000, 10000).ToString();
        }

        private void pageLoad(object sender, EventArgs e)
        {
            try
            {
                DataTable restaurant_data = new DataTable();
                new SqlDataAdapter($"SELECT * FROM RestaurantInformation INNER JOIN activeUsers ON RestaurantInformation.manager_email = activeUsers.user_email;", connect).Fill(restaurant_data);

                // Retrieve logo from database
                byte[] restaurant_logo = (byte[])(restaurant_data.Rows[0][5]);
                MemoryStream logoStream = new MemoryStream(restaurant_logo);
                logoBox.Image = Image.FromStream(logoStream);

                restaurantName.Text = restaurant_data.Rows[0][1].ToString();
                officialEmailText.Text = restaurant_data.Rows[0][2].ToString();
                officialContactText.Text = restaurant_data.Rows[0][3].ToString();
                locationText.Text = restaurant_data.Rows[0][4].ToString();


                DataTable user_data = new DataTable();
                new SqlDataAdapter($"SELECT * FROM UserInfo INNER JOIN activeUsers ON UserInfo.email = activeUsers.user_email;", connect).Fill(user_data);

                // Retrieve propic from database
                byte[] propicManager = (byte[])(restaurant_data.Rows[0][6]);
                MemoryStream propicStream = new MemoryStream(propicManager);
                propicBox.Image = Image.FromStream(propicStream);

                userNameText.Text = user_data.Rows[0][0].ToString();
                userEmailText.Text = user_data.Rows[0][1].ToString();
                userContactText.Text = user_data.Rows[0][3].ToString();
                userAddressText.Text = user_data.Rows[0][4].ToString();
                userTypeText.Text = user_data.Rows[0][5].ToString();
                registrationDateTimeText.Text = user_data.Rows[0][6].ToString();

                // Recaptcha
                recaptchaNumber.Text = new Random().Next(1000, 10000).ToString();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
