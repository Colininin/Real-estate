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

namespace DeskApp
{
    public partial class Home : Form
    {
        private User loggedInUser;
        private Form? currentForm = null;
        public Home(User user)
        {
            loggedInUser = user;
            InitializeComponent();
            ShowForm(new Landingform());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowForm(new Landingform());
        }

        private void ShowForm(Form form)
        {
            if (currentForm is not null)
            {
                currentForm.Hide();
            }

            pnlForms.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.AutoScroll = true;
            form.Size = pnlForms.Size;
            pnlForms.Controls.Add(form);
            form.Show();
            currentForm = form;
        }

        private void btnHouses_Click(object sender, EventArgs e)
        {
            ShowForm(new Houses());
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ShowForm(new CreateHouse());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }
    }
}
