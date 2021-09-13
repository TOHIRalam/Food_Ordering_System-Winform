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
                    if(field == LogInfo.session_restaurant_email) { LogInfo.session_restaurant_email = value; }
                    else if (field == LogInfo.session_restaurant_contact) { LogInfo.session_restaurant_contact = value; }
                    else if (field == LogInfo.session_restaurant_name) { LogInfo.session_restaurant_name = value; }
                    else if (field == LogInfo.session_restaurant_location) { LogInfo.session_restaurant_location = value; }
                    new SqlDataAdapter($"UPDATE RestaurantInformation SET {field} = '{value}' WHERE manager_email = '{LogInfo.session_user_email}'", DATABASE.connect).Fill(dataTable);
                    dataTable.Clear();
                    Form.ActiveForm.Close();
                    new HomeScreenBusiness().Show();
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
                new SqlDataAdapter($"SELECT * FROM RestaurantInformation WHERE manager_email = '{LogInfo.session_user_email}'", DATABASE.connect).Fill(restaurant_data);

                // Retrieve logo from database
                byte[] restaurant_logo = (byte[])(restaurant_data.Rows[0][5]);
                MemoryStream logoStream = new MemoryStream(restaurant_logo);
                logoBox.Image = Image.FromStream(logoStream);

                restaurantName.Text = restaurant_data.Rows[0][1].ToString();
                officialEmailText.Text = restaurant_data.Rows[0][2].ToString();
                officialContactText.Text = restaurant_data.Rows[0][3].ToString();
                locationText.Text = restaurant_data.Rows[0][4].ToString();


                DataTable user_data = new DataTable();
                new SqlDataAdapter($"SELECT * FROM UserInfo WHERE email = '{LogInfo.session_user_email}'", DATABASE.connect).Fill(user_data);

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
