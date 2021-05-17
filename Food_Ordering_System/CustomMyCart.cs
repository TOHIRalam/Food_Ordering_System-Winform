using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Food_Ordering_System
{
    public partial class CustomMyCart : UserControl {

        public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");

        public CustomMyCart() { InitializeComponent(); }

        private void cancelButton_Click(object sender, EventArgs e) {
            try
            {
                DataTable dataTable = new DataTable(), dataTable2 = new DataTable();
                new SqlDataAdapter($"SELECT name FROM activeUsers", connect).Fill(dataTable);
                new SqlDataAdapter($"DELETE FROM cartItems WHERE user_name = '{dataTable.Rows[0][0]}'", connect).Fill(dataTable2);
                dataTable.Clear(); dataTable2.Clear();
                cartItemGrid.DataSource = null;
                priceText.Text = "0 TK";
                numberOfItemText.Text = "There are_item(s) in your cart";
                confirmOrder.Enabled = false;
                cancelButton.Enabled = false;
                MessageBox.Show("Order canceled");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void pageLoad(object sender, EventArgs e) {
            try {
                DataTable dataTable = new DataTable();
                DataTable dataTable2 = new DataTable();
                new SqlDataAdapter($"SELECT name FROM activeUsers", connect).Fill(dataTable2);
                new SqlDataAdapter($"SELECT restaurant_name, food_name, quantity, price, " +
                    $"status, dateTime FROM cartItems WHERE user_name = '{dataTable2.Rows[0][0]}'", connect).Fill(dataTable);
                int numberOfRows = dataTable.Rows.Count, totalPrice = 0;
                cartItemGrid.DataSource = dataTable;
                if (numberOfRows != 0) {
                    confirmOrder.Enabled = true; cancelButton.Enabled = true;
                    numberOfItemText.Text = "There are " + numberOfRows + " item(s) in your cart";
                    for (int i = 0; i < numberOfRows; i++) { 
                        totalPrice += Convert.ToInt16(dataTable.Rows[i][3].ToString());
                    }
                    priceText.Text = totalPrice.ToString() + " TK";
                    if (dataTable.Rows[0][4].ToString() == "Searching Delivery Man")
                    {
                        progressPanel.Show();
                        waitingShow.ForeColor = Color.LimeGreen;
                    }
                    else if (dataTable.Rows[0][4].ToString() == "Processing")
                    {
                        progressPanel.Show();
                        waitingShow.ForeColor = Color.LimeGreen;
                        processingShow.ForeColor = Color.LimeGreen;
                    }
                    else if (dataTable.Rows[0][4].ToString() == "Delivering")
                    {
                        progressPanel.Show();
                        waitingShow.ForeColor = Color.LimeGreen;
                        processingShow.ForeColor = Color.LimeGreen;
                        deliveringShow.ForeColor = Color.LimeGreen;
                    }
                    else
                    {
                        progressPanel.Hide();
                    }
                } else { confirmOrder.Enabled = false; cancelButton.Enabled = false; progressPanel.Hide(); }
            } catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void confirmOrder_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                DataTable dataTable2 = new DataTable();
                new SqlDataAdapter($"SELECT name FROM activeUsers", connect).Fill(dataTable2);
                new SqlDataAdapter($"UPDATE cartItems SET status = 'Searching Delivery Man' WHERE user_name = '{dataTable2.Rows[0][0]}'", connect).Fill(dataTable);
                dataTable.Clear();

                new SqlDataAdapter($"SELECT restaurant_name, food_name, quantity, price, " +
                    $"status, dateTime FROM cartItems WHERE user_name = '{dataTable2.Rows[0][0]}'", connect).Fill(dataTable);
                int numberOfRows = dataTable.Rows.Count;
                cartItemGrid.DataSource = dataTable;
                numberOfItemText.Text = "There are " + numberOfRows + " item(s) in your cart";
                progressPanel.Show();
                waitingShow.ForeColor = Color.LimeGreen;
                DataTable deliverySearch = new DataTable();
                DataTable dt = new DataTable();
                new SqlDataAdapter($"SELECT cartItems.restaurantName, cartItems.manager_email, RestaurantInformation.restaurant_location FROM cartItems INNER JOIN RestaurantInformation ON cartItems.manager_email = RestaurantInformation.manager_email", connect).Fill(dt);
                new SqlDataAdapter($"SELECT name, email, contact, address FROM userInfo WHERE user_type = 'Delivery' AND address = '{dt.Rows[0][2]}'", connect).Fill(deliverySearch);
                if(deliverySearch.Rows.Count == 0 || deliverySearch.Rows.Count == 0) {
                    dt.Clear();
                    new SqlDataAdapter($"DELETE FROM cartItems WHERE user_name = '{dataTable2.Rows[0][0]}'", connect).Fill(dt);
                    MessageBox.Show("There is no delivery man in the restaurant area\nOrder canceled!");
                } else { 
                    
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }
    }
}