using ClassLib.Classes;
using ClassLib.Interfaces;
using DAL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Handlers.Classes;

namespace DeskApp
{
    public partial class ConfirmDelete : Form
    {
        private int houseId;
        private HouseManager houseHandler;
        public ConfirmDelete(int houseId)
        {
            this.houseId = houseId;
            houseHandler = new HouseManager();
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(confirmCheck.Checked)
            {
                if (houseHandler.DeleteHouse(houseId))
                {
                    MessageBox.Show("House deleted succesfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong, please try again");
                }
            }
            else
            {
                MessageBox.Show("Please confirm with the checkbox first!");
            }
        }
    }
}
