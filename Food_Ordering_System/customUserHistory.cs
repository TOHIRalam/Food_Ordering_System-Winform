using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class customUserHistory : UserControl
    {
        public customUserHistory()
        {
            InitializeComponent();
        }

        private void onlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (onlyCheckBox.Checked)
            {
                try
                {
                    DataTable dt = new DataTable();
                    new SqlDataAdapter($"SELECT restaurant_name as Restaurant, food_name as Item, quantity as Quantity, price as Price, " +
                    $"dateTime as DateTime FROM cartItems WHERE user_name = '{LogInfo.session_user_name}' AND " +
                    $" status = 'Delivering'", DATABASE.connect).Fill(dt);
                    historyItemGrid.DataSource = dt;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    new SqlDataAdapter($"SELECT TOP 1 delivery.delivery_man_name AS Delivered_By, delivery.delivery_man_email AS Email, " +
                        $"delivery.restaurant_name AS Restaurant, delivery.total_price as Price, cartItems.dateTime AS DateTime FROM delivery INNER JOIN cartItems ON " +
                        $"delivery.restaurant_name = cartItems.restaurant_name WHERE cartItems.user_name = '{LogInfo.session_user_name}' " +
                        $"AND cartItems.status = 'Delivering'", DATABASE.connect).Fill(dt);
                    historyItemGrid.DataSource = dt;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void customUserHistory_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                new SqlDataAdapter($"SELECT TOP 1 delivery.delivery_man_name AS Delivered_By, delivery.delivery_man_email AS Email, " +
                    $"delivery.restaurant_name AS Restaurant, delivery.total_price as Price, cartItems.dateTime AS DateTime FROM delivery INNER JOIN cartItems ON " +
                    $"delivery.restaurant_name = cartItems.restaurant_name WHERE cartItems.user_name = '{LogInfo.session_user_name}' " +
                    $"AND cartItems.status = 'Delivering'", DATABASE.connect).Fill(dt);
                historyItemGrid.DataSource = dt;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
