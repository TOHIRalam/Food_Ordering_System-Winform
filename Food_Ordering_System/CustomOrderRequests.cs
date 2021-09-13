using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class CustomOrderRequests : UserControl
    {
        public CustomOrderRequests()
        {
            InitializeComponent();
        }

        private void pageLoad(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(), dt2 = new DataTable();
            new SqlDataAdapter($"SELECT delivery.delivery_man_name, delivery.user_email, cartItems.food_name, cartItems.quantity, " +
                 $"cartItems.price FROM cartItems INNER JOIN delivery ON delivery.restaurant_name = cartItems.restaurant_name WHERE delivery.status = 'Request' AND " +
                 $"cartItems.manager_email = '{LogInfo.session_user_email}'", DATABASE.connect).Fill(dt);
            orderItemGrid.DataSource = dt;
            new SqlDataAdapter($"SELECT delivery.delivery_man_name, delivery.user_email, cartItems.food_name, cartItems.quantity, " +
                 $"cartItems.price FROM cartItems INNER JOIN delivery ON delivery.restaurant_name = cartItems.restaurant_name WHERE delivery.status = 'Accepted' AND " +
                 $"cartItems.manager_email = '{LogInfo.session_user_email}' AND cartItems.status != 'Delivering'", DATABASE.connect).Fill(dt2);
            finishedGridView.DataSource = dt2;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if(emailBox.Text.Trim() != "")
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
                        new SqlDataAdapter($"SELECT delivery.delivery_man_name AS Delivery, delivery.user_email AS Email, cartItems.food_name AS Item, cartItems.quantity AS Quantity, " +
                            $"cartItems.price AS Price FROM delivery INNER JOIN cartItems ON delivery.user_name = cartItems.user_name WHERE delivery.status = 'Request'", DATABASE.connect).Fill(dt);
                        orderItemGrid.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Invalid email!!");
                    } 
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void confirmOrder_Click(object sender, EventArgs e)
        {
            if(emailBox.Text.Trim() != "")
            {
                try
                {
                    DataTable dt = new DataTable(), dt2 = new DataTable();
                    new SqlDataAdapter($"SELECT delivery.user_name, delivery.user_email FROM delivery INNER JOIN cartItems ON " +
                        $"delivery.user_name = cartItems.user_name WHERE delivery.user_email = '{emailBox.Text.Trim()}' AND delivery.status != 'Accepted'", DATABASE.connect).Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        new SqlDataAdapter($"UPDATE cartItems SET status = 'Waiting' WHERE user_name = '{dt.Rows[0][0]}'", DATABASE.connect).Fill(dt2);
                        dt2.Clear();
                        new SqlDataAdapter($"UPDATE delivery SET status = 'Waiting' WHERE user_name = '{dt.Rows[0][0]}'", DATABASE.connect).Fill(dt2);
                        dt.Clear(); dt2.Clear();
                        new SqlDataAdapter($"SELECT delivery.delivery_man_name AS Delivery, delivery.user_email AS Email, cartItems.food_name AS Item, cartItems.quantity AS Quantity, " +
                            $"cartItems.price AS Price FROM delivery INNER JOIN cartItems ON delivery.user_name = cartItems.user_name WHERE delivery.status = 'Request'", DATABASE.connect).Fill(dt);
                        orderItemGrid.DataSource = dt; dt.Clear();
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

        private void finishedButton_Click(object sender, EventArgs e)
        {
            if (emailBox.Text.Trim() != "")
            {
                try
                {
                    DataTable dataTable = new DataTable(), dt = new DataTable(), dt2 = new DataTable();
                    new SqlDataAdapter($"SELECT UserInfo.name, UserInfo.email FROM UserInfo INNER JOIN cartItems ON UserInfo.name = cartItems.user_name " +
                        $"WHERE cartItems.status = 'Processing' AND UserInfo.email = '{emailBox.Text.Trim()}'", DATABASE.connect).Fill(dt);
                    if(dt.Rows.Count == 0) { MessageBox.Show("Invalid Input"); }
                    else
                    {
                        emailBox.Text = "";
                        new SqlDataAdapter($"UPDATE cartItems SET status = 'Delivering' WHERE user_name = '{dt.Rows[0][0]}' AND status = 'Processing'", DATABASE.connect).Fill(dataTable);
                        new SqlDataAdapter($"SELECT delivery.delivery_man_name, delivery.user_email, cartItems.food_name, cartItems.quantity, " +
                            $"cartItems.price FROM cartItems INNER JOIN delivery ON delivery.restaurant_name = cartItems.restaurant_name WHERE delivery.status = 'Accepted' AND " +
                            $"cartItems.manager_email = '{LogInfo.session_user_email}' AND cartItems.status != 'Delivering'", DATABASE.connect).Fill(dt2);
                        finishedGridView.DataSource = dt2; MessageBox.Show("The product will be delivered to the user's address");
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
