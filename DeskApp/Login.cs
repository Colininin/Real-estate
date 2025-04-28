using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLib.Classes;
using ClassLib.Interfaces;
using DAL.Classes;
using Handlers.Classes;
namespace DeskApp
{
    public partial class Login : Form
    {
        private UserManager userHandler;
        public Login()
        {
            userHandler = new UserManager();
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (InputEmail.Text != "" && InputPass.Text != "")
            {
                User loggedInUser = userHandler.TryLogin(InputEmail.Text, InputPass.Text);

                if (loggedInUser != null)
                {
                    if (loggedInUser is Admin)
                    {
                        Form home = new Home(loggedInUser);
                        this.Hide();
                        home.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Only admins can log in");
                    }
                }
                else
                {
                    MessageBox.Show("Sorry something went wrong, try again");
                }
            }
        }
    }
}
