using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Food_Ordering_System
{
    public partial class processingShow : UserControl {

        public static int totalPrice = 0;

        public processingShow() { InitializeComponent(); }

        private void cancelButton_Click(object sender, EventArgs e) {
            try
            {
                DataTable dataTable2 = new DataTable();
                new SqlDataAdapter($"DELETE FROM cartItems WHERE user_name = '{LogInfo.session_user_name}'", DATABASE.connect).Fill(dataTable2);
                dataTable2.Clear();
                cartItemGrid.DataSource = null;
                priceText.Text = "0 TK";
                numberOfItemText.Text = "Your cart is empty";
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
                new SqlDataAdapter($"SELECT restaurant_name as Restaurant, food_name as Item, quantity as Quantity, price as Price, " +
                    $"status as Status, dateTime as DateTime FROM cartItems WHERE user_name = '{LogInfo.session_user_name}' AND " +
                    $"status != 'Canceled' AND status != 'Delivering'", DATABASE.connect).Fill(dataTable);
                int numberOfRows = dataTable.Rows.Count;
                cartItemGrid.DataSource = dataTable;
                if (numberOfRows != 0) {
                    confirmOrder.Enabled = true; cancelButton.Enabled = true;
                    numberOfItemText.Text = "There are " + numberOfRows + " item(s) in your cart";
                    for (int i = 0; i < numberOfRows; i++) { 
                        totalPrice += Convert.ToInt16(dataTable.Rows[i][3].ToString());
                    }
                    priceText.Text = totalPrice.ToString() + " TK";
                    if (dataTable.Rows[0][4].ToString() == "On going")
                    {
                        progressPanel.Show();
                        confirmOrder.Enabled = false;
                        cancelButton.Enabled = false;
                        onGoingSignal.ForeColor = Color.LimeGreen;
                        waitingSignal.ForeColor = Color.Crimson;
                        processingSignal.ForeColor = Color.Crimson;
                        deliveringSignal.ForeColor = Color.Crimson;
                    }
                    else if (dataTable.Rows[0][4].ToString() == "Waiting")
                    {
                        progressPanel.Show();
                        confirmOrder.Enabled = false;
                        cancelButton.Enabled = false;
                        onGoingSignal.ForeColor = Color.LimeGreen;
                        waitingSignal.ForeColor = Color.LimeGreen;
                        processingSignal.ForeColor = Color.Crimson;
                        deliveringSignal.ForeColor = Color.Crimson;
                    }
                    else if (dataTable.Rows[0][4].ToString() == "Processing")
                    {
                        progressPanel.Show();
                        confirmOrder.Enabled = false;
                        cancelButton.Enabled = false;
                        onGoingSignal.ForeColor = Color.LimeGreen;
                        waitingSignal.ForeColor = Color.LimeGreen;
                        processingSignal.ForeColor = Color.LimeGreen;
                        deliveringSignal.ForeColor = Color.Crimson;
                    }
                    else
                    {
                        progressPanel.Hide();
                        confirmOrder.Enabled = true;
                        cancelButton.Enabled = true;
                    }
                } else { confirmOrder.Enabled = false; cancelButton.Enabled = false; progressPanel.Hide(); }
            } catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void confirmOrder_Click(object sender, EventArgs e)
        {
             try
             {
                DataTable dataTable = new DataTable(), dataTable2 = new DataTable();
                new SqlDataAdapter($"UPDATE cartItems SET status = 'On going' WHERE user_name = '{LogInfo.session_user_name}'", DATABASE.connect).Fill(dataTable);
                dataTable.Clear();
                new SqlDataAdapter($"SELECT restaurant_name as Restaurant, food_name as Item, quantity as Quantity, price as Price, " +
                    $"status as Status, dateTime as DateTime FROM cartItems WHERE user_name = '{LogInfo.session_user_name}' AND " +
                    $"status != 'Canceled' AND status != 'Delivering'", DATABASE.connect).Fill(dataTable);
                cartItemGrid.DataSource = dataTable;
                int numberOfRows = dataTable.Rows.Count;
                cartItemGrid.DataSource = dataTable;
                numberOfItemText.Text = "There are " + numberOfRows + " item(s) in your cart";
                progressPanel.Show();
                onGoingSignal.ForeColor = Color.LimeGreen;
                DataTable deliverySearch = new DataTable(), dt = new DataTable();
                new SqlDataAdapter($"SELECT cartItems.restaurant_name, cartItems.manager_email, RestaurantInformation.restaurant_location FROM cartItems " +
                    $"INNER JOIN RestaurantInformation ON cartItems.manager_email = RestaurantInformation.manager_email", DATABASE.connect).Fill(dt);
                new SqlDataAdapter($"SELECT name, email, contact, address FROM UserInfo WHERE user_type = 'Delivery' AND address = '{dt.Rows[0][2]}'", DATABASE.connect).Fill(deliverySearch);
                if(deliverySearch.Rows.Count == 0 || deliverySearch.Rows.Count == 0) {
                    dt.Clear();
                    new SqlDataAdapter($"DELETE FROM cartItems WHERE user_name = '{LogInfo.session_user_name}'", DATABASE.connect).Fill(dt);
                    MessageBox.Show("There is no delivery man in the restaurant area\nOrder canceled!");
                } else {
                    DataTable delieryInput = new DataTable();
                    waitingSignal.ForeColor = Color.LimeGreen;
                    new SqlDataAdapter($"INSERT INTO delivery VALUES ('{deliverySearch.Rows[0][0]}', '{deliverySearch.Rows[0][1]}', " +
                        $"'{dt.Rows[0][0]}', '{dt.Rows[0][2]}', '{LogInfo.session_user_name}', '{LogInfo.session_user_email}', '{LogInfo.session_user_address}', 'Request', {totalPrice})", DATABASE.connect).Fill(delieryInput);
                    cancelButton.Enabled = false; confirmOrder.Enabled = false;
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }
    }
}