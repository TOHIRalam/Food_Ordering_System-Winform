using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class CustomUpdateMenu : UserControl
    {
        public bool foodPicAdded = false;
        public string foodPictureLocation = "";
        public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
        public CustomUpdateMenu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = 0;
            string itemName = itemNameBox.Text.Trim();
            string catagory = addCatagoryBox.SelectedItem.ToString();
            string quantity = quantityBox.Text.Trim();
            string description = descriptionBox.Text.Trim();
            if(itemName == "" || catagory == "" || priceBox.Text.Trim() == "" || quantity == "" || description == "") {
                MessageBox.Show("Field can't be empty!!");
            } else {
                int price = Convert.ToInt16(priceBox.Text.Trim());
                try
                {
                    DataTable dataTable = new DataTable(); DataTable dt = new DataTable(); DataTable dt2 = new DataTable();
                    new SqlDataAdapter($"SELECT * FROM activeUsers", connect).Fill(dt);
                    new SqlDataAdapter($"SELECT id FROM food_menu", connect).Fill(dt2);
                    if(dt2.Rows.Count != 0) { id = Convert.ToInt16(dt2.Rows[0][0].ToString()) + 1; }

                    // Convert to binary
                    byte[] itemPicture = null;
                    FileStream itemPicStream = new FileStream(foodPictureLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader itemBinary = new BinaryReader(itemPicStream);
                    itemPicture = itemBinary.ReadBytes((int)itemPicStream.Length);

                    // Upload to database
                    string SqlQueryInsert = $"INSERT INTO food_menu VALUES({id}, '{dt.Rows[0][0].ToString()}', '{catagory}', '{itemName}', '{quantity}', {price}, @itemPic, '{description}')";
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(SqlQueryInsert, connect);
                    cmd.Parameters.Add(new SqlParameter("@itemPic", itemPicture));
                    int n = cmd.ExecuteNonQuery(); dt2.Clear();
                    
                    new SqlDataAdapter($"SELECT * FROM food_menu", connect).Fill(dt2);
                    fooItemListDataGrid.DataSource = dt2;
                    connect.Close();

                    itemNameBox.Text = ""; itemPicture = null; priceBox.Text = ""; descriptionBox.Text = "";
                }
                catch (Exception exc) { MessageBox.Show(exc.Message + "\nInsertion failed!"); }
            }
        }

        private void pageLoad(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                new SqlDataAdapter($"SELECT * FROM food_menu", connect).Fill(dataTable);
                fooItemListDataGrid.DataSource = dataTable;
            }
            catch(Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog foodPicture = new OpenFileDialog();
            foodPicture.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            foodPicture.Title = "Select food picture";
            if (foodPicture.ShowDialog() == DialogResult.OK)
            {
                itemPictureBox.Image = new Bitmap(foodPicture.FileName);
                foodPictureLocation = foodPicture.FileName.ToString();
            }
            foodPicAdded = true;
        }
    }
}
