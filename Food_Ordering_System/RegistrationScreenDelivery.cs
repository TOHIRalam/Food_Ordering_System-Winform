using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class RegistrationScreenDelivery : Form
    {
        public RegistrationScreenDelivery()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Hide(); new LoginScreen().Show();
        }

        private void registerBox_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text.Trim(), email = emailBox.Text.Trim(), contact = contactBox.Text.Trim();
            string password = passwordBox.Text.Trim(), confirmPass = confirmPassBox.Text.Trim();
            string address = addressBox.Text.Trim(); int emailLength = email.Length;

            if (name == "" || email == "" || confirmPass == "" || address == "" || contact == "")
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
            else if (contact.Length < 14)
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
                                            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TOHIR\source\repos\Food_Ordering_System\Food_Ordering_System\Database\PaantaHaariDB.mdf;Integrated Security=True;Connect Timeout=30");
                                            new SqlDataAdapter($"INSERT INTO UserInfo VALUES ('{name}', '{email}', '{password.GetHashCode()}', '{contact}', '{address}', 'Delivery', '{DateTime.Now.ToString()}')", connect).Fill(insertData);
                                            MessageBox.Show("Registration Successful!");
                                            Hide(); new LoginScreen().Show();
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

        private void loginLabelHover(object sender, EventArgs e)
        {
            loginLabel.ForeColor = Color.DarkBlue;
        }

        private void loginLabelLeave(object sender, EventArgs e)
        {
            loginLabel.ForeColor = Color.SteelBlue;
        }
    }
}
