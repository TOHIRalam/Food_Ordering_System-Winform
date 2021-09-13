using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace Food_Ordering_System
{
    public partial class RegistrationScreenBusiness : Form
    {
        public bool logoAdded = false;
        public bool profilePicAdded = false;
        string logoLocation = "", propicLocation = "";
        public RegistrationScreenBusiness()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginScreen().Show();
        }

        private void registerBox_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text.Trim(), email = emailBox.Text.Trim(), contact = contactBox.Text.Trim();
            string password = passwordBox.Text.Trim(), confirmPass = confirmPassBox.Text.Trim();
            string address = addressBox.Text.Trim(); int emailLength = email.Length;
            string restaurantName = restaurantNameBox.Text.Trim(), officialEmail = officialEmailBox.Text.Trim();
            string officialContact = officialContactBox.Text.Trim(), restaurantLocation = restaurantLocationBox.Text.Trim();

            if (name == "" || email == "" || confirmPass == "" || address == "" || contact == "" || restaurantName == "" || officialEmail == "" || officialContact == "" || restaurantLocation == "")
            {
                MessageBox.Show("Any field should not be empty!");
            }
            else if (name.Length < 3)
            {
                MessageBox.Show("Name should be at least three characters long!");
            }
            else if (password.Length < 5)
            {
                MessageBox.Show("Password should be at least five characters long!");
            }
            else if (password != confirmPass)
            {
                MessageBox.Show("Password Unmatched!");
            }
            else if (contact.Length < 14 || contact.Length > 14 || officialContact.Length < 14 || officialContact.Length > 14)
            {
                MessageBox.Show("Invalid contact\nPlesase insert a valid Bangladeshi contact number!\nUse +880 before your contact number!");
            }
            else
            {
                int firstCond = email.IndexOf('@'), secondCond = -1;
                if (firstCond == -1)
                {
                    MessageBox.Show("Invalid email!");
                }
                else
                {
                    if (email[firstCond + 1] == '.')
                    {
                        MessageBox.Show("Invalid email!");
                    }
                    else
                    {
                        for (int i = firstCond + 1; i < emailLength; i++)
                        {
                            if (email[i] == '.') { secondCond = i; break; }
                        }
                        if (secondCond == -1)
                        {
                            MessageBox.Show("Invalid email!");
                        }
                        else
                        {
                            if (secondCond == emailLength - 1)
                            {
                                MessageBox.Show("Invalid email!");
                            }
                            else
                            {
                                if (contact[0] != '+' || contact[1] != '8' || contact[2] != '8' || contact[3] != '0')
                                {
                                    MessageBox.Show("Invalid contact\nPlesase insert a valid Bangladeshi contact number!\nUse +880 before your contact number!");
                                }
                                else if(!logoAdded || !profilePicAdded)
                                {
                                    MessageBox.Show("Please upload required picture and logo");
                                }
                                else
                                {
                                    int i;
                                    for (i = 4; i < contact.Length; i++)
                                    {
                                        if (contact[i] < '0' || contact[i] > '9')
                                        {
                                            MessageBox.Show("Invalid contact\nPlesase insert a valid Bangladeshi contact number!\nUse +880 before your contact number!");
                                            break;
                                        }
                                    }
                                    if (i == contact.Length)
                                    {
                                        try
                                        {
                                            DataTable insertData = new DataTable();
                                            // DataTable insertDataRestaurant = new DataTable();

                                            // Convert logo to binary
                                            byte[] logo = null;
                                            FileStream logoStream = new FileStream(logoLocation, FileMode.Open, FileAccess.Read);
                                            BinaryReader logoBinary = new BinaryReader(logoStream);
                                            logo = logoBinary.ReadBytes((int)logoStream.Length);

                                            // Convert propic to binary
                                            byte[] propic = null;
                                            FileStream propicStream = new FileStream(propicLocation, FileMode.Open, FileAccess.Read);
                                            BinaryReader propicBinary = new BinaryReader(propicStream);
                                            propic = propicBinary.ReadBytes((int)propicStream.Length);
                                            
                                            string SqlQueryInsert = $"INSERT INTO RestaurantInformation VALUES('{email}', '{restaurantName}', '{officialEmail}', '{officialContact}', '{restaurantLocation}', @logo, @propic)";
                                            DATABASE.connect.Open();
                                            SqlCommand cmd = new SqlCommand(SqlQueryInsert, DATABASE.connect);
                                            cmd.Parameters.Add(new SqlParameter("@logo", logo));
                                            cmd.Parameters.Add(new SqlParameter("@propic", propic));
                                            int n = cmd.ExecuteNonQuery();

                                            // new SqlDataAdapter(SqlQueryInsert, connect).Fill(insertDataRestaurant);
                                            new SqlDataAdapter($"INSERT INTO UserInfo VALUES ('{name}', '{email}', '{password.GetHashCode()}', '{contact}', '{address}', 'Business', '{DateTime.Now.ToString()}')", DATABASE.connect).Fill(insertData);
                                            MessageBox.Show("Registration Successful!");
                                            DATABASE.connect.Close();
                                            new LoginScreen().Show(); Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message + "\nRegistration Failed!");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog profilePicture = new OpenFileDialog();
            profilePicture.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            profilePicture.Title = "Select admin's picture";
            if (profilePicture.ShowDialog() == DialogResult.OK)
            {
                profilePicUploadBox.Image = new Bitmap(profilePicture.FileName);
                propicLocation = profilePicture.FileName.ToString();
            }
            profilePicAdded = true;
        }

        private void logoUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog logo = new OpenFileDialog();
            logo.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            logo.Title = "Insert your restaurant's logo";
            if (logo.ShowDialog() == DialogResult.OK)
            {
                logoUploadBox.Image = new Bitmap(logo.FileName);
                logoLocation = logo.FileName.ToString();
            }
            logoAdded = true;
        }
    }
}
