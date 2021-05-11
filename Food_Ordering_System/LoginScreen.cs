using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            passwordBox.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text.Trim();
            string password = passwordBox.Text.Trim();

        }

        private void label7_Click(object sender, EventArgs e) { Hide(); new RegistrationScreen().Show(); }
    }
}
