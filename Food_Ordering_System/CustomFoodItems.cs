using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class CustomFoodItems : UserControl
    {
        public static int totalPrice = 0;
        public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
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
                    DataTable innerJoinTable = new DataTable(); DataTable dataTable = new DataTable(); DataTable userName = new DataTable();
                    new SqlDataAdapter($"SELECT * FROM activeUsers", connect).Fill(userName);
                    new SqlDataAdapter($"SELECT food_menu.id, food_menu.manager_email, food_menu.food_name, food_menu.price, food_menu.food_quantity," +
                        $" RestaurantInformation.restaurant_name FROM food_menu INNER JOIN RestaurantInformation ON " +
                        $"food_menu.manager_email = RestaurantInformation.manager_email WHERE food_menu.id = {id}", connect).Fill(innerJoinTable);
                    new SqlDataAdapter($"INSERT INTO cartItems VALUES ({id}, '{userName.Rows[0][1]}', '{innerJoinTable.Rows[0][1]}', " +
                        $"'{innerJoinTable.Rows[0][5]}', '{innerJoinTable.Rows[0][2]}', '{innerJoinTable.Rows[0][4]} x {quantity}', " +
                        $"{Convert.ToInt16(innerJoinTable.Rows[0][3])*quantity}, 'Pending', '{DateTime.Now}')", connect).Fill(dataTable);
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
                new SqlDataAdapter($"SELECT id, food_name, food_picture, item_description, food_quantity, price FROM food_menu", connect).Fill(dataTable);
                foodItemGrid.DataSource = dataTable;
                foodItemGrid.Columns[0].Width = 20;
                foodItemGrid.Columns[1].Width = 160;
                foodItemGrid.Columns[2].Width = 120;
                foodItemGrid.Columns[3].Width = 420;
                foodItemGrid.Columns[4].Width = 180;
                foodItemGrid.Columns[5].Width = 80;
                for (int i = 0; i < foodItemGrid.Rows.Count; i++)
                {
                    foodItemGrid.Rows[i].Height = 450;
                }
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
                        new SqlDataAdapter($"SELECT id, food_name, food_picture, item_description, food_quantity, price FROM food_menu", connect).Fill(dataTable);
                    } else {
                        new SqlDataAdapter($"SELECT id, food_name, food_picture, item_description, food_quantity, price FROM food_menu WHERE catagory = '{catagory}'", connect).Fill(dataTable);
                    }
                    foodItemGrid.DataSource = dataTable;
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
            }
        }
    }
}
