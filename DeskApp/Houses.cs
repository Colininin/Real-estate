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
    public partial class Houses : Form
    {
        private HouseManager houseHand;
        private Dictionary<int, House> houses;
        public Houses()
        {
            houseHand = new HouseManager();
            houses = houseHand.ReturnHouses().ToDictionary(h => h.GetHouseId());
            InitializeComponent();

            DisplayHouses();
        }

        public void DisplayHouses()
        {
            this.Refresh();
            AllhousesContainer.Controls.Clear();

            houses = houseHand.ReturnHouses().ToDictionary(h => h.GetHouseId());
            foreach (var house in houses.Values)
            {
                HousePanel housePan = new HousePanel(house);
                housePan.HouseChanged += HousePan_EditFormClosed;
                AllhousesContainer.Controls.Add(housePan);
            }
        }

        private void InputID_TextChanged(object sender, EventArgs e)
        {
            FilterHouses();
        }

        private void InputAddress_TextChanged(object sender, EventArgs e)
        {
            FilterHouses();
        }

        private void HousePan_EditFormClosed(object sender, EventArgs e)
        {
            DisplayHouses();
        }

        private void FilterHouses()
        {
            AllhousesContainer.Controls.Clear();

            string IdInput = InputID.Text;
            string AddressInput = InputAddress.Text.ToLower();

            IEnumerable<House> filteredHouses = houses.Values;

            if (IdInput != "")
            {
                if (int.TryParse(IdInput, out int houseId) && houses.TryGetValue(houseId, out House house))
                {
                    filteredHouses = new[] { house }; 
                }
                else
                {
                    filteredHouses = Enumerable.Empty<House>();
                }
            }

            if (AddressInput != "")
            {
                filteredHouses = filteredHouses.Where(house => house.GetAddress().ToLower().Contains(AddressInput));
            }

            foreach (var house in filteredHouses)
            {
                HousePanel housePan = new HousePanel(house);
                housePan.HouseChanged += HousePan_EditFormClosed;
                AllhousesContainer.Controls.Add(housePan);
            }

        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            DisplayHouses();
        }
    }
}
