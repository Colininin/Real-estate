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
    public partial class HousePanel : UserControl
    {
        private House house;
        public event EventHandler HouseChanged;
        public HousePanel(House house)
        {
            this.house = house;
            InitializeComponent();
            ShowInfo();
            lblAddress.MouseClick += HousePanel_MouseClick;
            lblPrice.MouseClick += HousePanel_MouseClick;
            lblID.MouseClick += HousePanel_MouseClick;
        }

        private void ShowInfo()
        {
            lblAddress.Text = house.GetAddress();
            lblPrice.Text = $"€{house.FormattedPrice()}";
            lblID.Text = house.GetHouseId().ToString();
        }

        private void HousePanel_MouseClick(object sender, MouseEventArgs e)
        {
            Form houseForm = new houseForm(house);
            houseForm.FormClosed += HouseForm_FormClosed;
            houseForm.ShowDialog();
        }

        private void HouseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HouseChanged?.Invoke(this,EventArgs.Empty);
        }
    }
}
