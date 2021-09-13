using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class CustomFoodItems : UserControl
    {
        public static int totalPrice = 0;
        public CustomFoodItems()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(idBox.Text != "" || quantityBox.Text != "")
            {
                int id = Convert.ToInt16(idBox.Text.Trim());
                int quantity = Convert.ToInt16(quantityBox.Text.Trim());
                try
                {
                    DataTable innerJoinTable = new DataTable(); DataTable dataTable = new DataTable(); 
                    new SqlDataAdapter($"SELECT food_menu.id, food_menu.manager_email, food_menu.food_name, food_menu.price, food_menu.food_quantity," +
                        $" RestaurantInformation.restaurant_name FROM food_menu INNER JOIN RestaurantInformation ON " +
                        $"food_menu.manager_email = RestaurantInformation.manager_email WHERE food_menu.id = {id}", DATABASE.connect).Fill(innerJoinTable);
                    new SqlDataAdapter($"INSERT INTO cartItems VALUES ({id}, '{LogInfo.session_user_name}', '{innerJoinTable.Rows[0][1]}', " +
                        $"'{innerJoinTable.Rows[0][5]}', '{innerJoinTable.Rows[0][2]}', '{innerJoinTable.Rows[0][4]} x {quantity}', " +
                        $"{Convert.ToInt16(innerJoinTable.Rows[0][3])*quantity}, 'Pending', '{DateTime.Now}')", DATABASE.connect).Fill(dataTable);
                    MessageBox.Show("Item added to cart");
                    idBox.Text = ""; quantityBox.Text = "";
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
        }

        private void pageLoad(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                new SqlDataAdapter($"SELECT id as ID, food_name as Item, food_picture as Picture, item_description as Description, food_quantity as Quantity, price as Price FROM food_menu", DATABASE.connect).Fill(dataTable);
                foodItemGrid.DataSource = dataTable;
                foodItemGrid.Columns[0].Width = 40;
                foodItemGrid.Columns[1].Width = 160;
                foodItemGrid.Columns[2].Width = 170;
                foodItemGrid.Columns[3].Width = 370;
                foodItemGrid.Columns[4].Width = 160;
                foodItemGrid.Columns[5].Width = 80;
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void breakfastgrid_CellContentClick(object sender, DataGridViewCellEventArgs e) {}

        private void searchBox_Click(object sender, EventArgs e)
        {
            if(catagoryComboBox.SelectedItem != null)
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    string catagory = catagoryComboBox.SelectedItem.ToString();
                    if(catagory == "All") {
                        new SqlDataAdapter($"SELECT id, food_name, food_picture, item_description, food_quantity, price FROM food_menu", DATABASE.connect).Fill(dataTable);
                    } else {
                        new SqlDataAdapter($"SELECT id, food_name, food_picture, item_description, food_quantity, price FROM food_menu WHERE catagory = '{catagory}'", DATABASE.connect).Fill(dataTable);
                    }
                    foodItemGrid.DataSource = dataTable;
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
        }
    }
}
