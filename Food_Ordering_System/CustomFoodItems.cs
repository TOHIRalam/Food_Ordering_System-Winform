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
        public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
        public CustomFoodItems()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void breakfastgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
