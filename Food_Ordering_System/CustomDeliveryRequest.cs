using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class CustomDeliveryRequest : UserControl
    {
        public CustomDeliveryRequest()
        {
            InitializeComponent();
        }

        private void pageLoad(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                new SqlDataAdapter($"SELECT user_name AS Customer, user_email AS Email, user_address AS Address, restaurant_name as Restaurant, " +
                    $"restaurant_address AS Location FROM delivery WHERE delivery.delivery_man_name = '{LogInfo.session_user_name}' " +
                    $"AND delivery.status = 'Waiting'", DATABASE.connect).Fill(dt);
                deliveryRequestGrid.DataSource = dt;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (emailBox.Text.Trim() != "")
            {
                try
                {
                    DataTable dt = new DataTable(), dt2 = new DataTable();
                    new SqlDataAdapter($"SELECT delivery.user_name, delivery.user_email FROM delivery INNER JOIN cartItems ON " +
                        $"delivery.user_name = cartItems.user_name WHERE delivery.user_email = '{emailBox.Text.Trim()}'", DATABASE.connect).Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        new SqlDataAdapter($"UPDATE cartItems SET status = 'Canceled' WHERE user_name = '{dt.Rows[0][0]}'", DATABASE.connect).Fill(dt2);
                        dt.Clear(); dt2.Clear();
                        new SqlDataAdapter($"SELECT restaurant_name AS Restaurant, restaurant_address AS Location, delivery.user_email AS Email, cartItems.food_name AS Item, cartItems.quantity AS Quantity, " +
                            $"cartItems.price AS Price FROM delivery INNER JOIN cartItems ON delivery.user_name = cartItems.user_name WHERE delivery.status = 'Waiting'", DATABASE.connect).Fill(dt);
                        deliveryRequestGrid.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Invalid email!!");
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void confirmOrder_Click(object sender, EventArgs e)
        {
            if (emailBox.Text.Trim() != "")
            {
                try
                {
                    DataTable dt = new DataTable(), dt2 = new DataTable();
                    new SqlDataAdapter($"SELECT delivery.user_name, delivery.user_email FROM delivery INNER JOIN cartItems ON " +
                        $"delivery.user_name = cartItems.user_name WHERE delivery.user_email = '{emailBox.Text.Trim()}'", DATABASE.connect).Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        new SqlDataAdapter($"UPDATE cartItems SET status = 'Processing' WHERE user_name = '{dt.Rows[0][0]}'", DATABASE.connect).Fill(dt2);
                        dt2.Clear();
                        new SqlDataAdapter($"UPDATE delivery SET status = 'Accepted' WHERE user_name = '{dt.Rows[0][0]}'", DATABASE.connect).Fill(dt2);
                        dt.Clear(); dt2.Clear();
                        new SqlDataAdapter($"SELECT delivery.user_name, delivery.user_email FROM delivery INNER JOIN cartItems ON " +
                        $"delivery.user_name = cartItems.user_name WHERE delivery.user_email = '{emailBox.Text.Trim()}' AND delivery.status != 'Accepted'", DATABASE.connect).Fill(dt);
                        deliveryRequestGrid.DataSource = dt; dt.Clear();
                        emailBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Invalid email!!");
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
    }
}
