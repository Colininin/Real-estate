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
    public partial class houseForm : Form
    {
        private readonly House thisHouse;
        private readonly HouseManager houseHandler;
        public houseForm(House house)
        {
            this.houseHandler = new HouseManager();
            this.thisHouse = house;
            InitializeComponent();
            SetInfo();
            btnSave.Enabled = false;
        }

        private void SetInfo()
        {
            lblID.Text = $"ID:{thisHouse.GetHouseId()}";
            txtAddress.Text = thisHouse.GetAddress();
            txtCity.Text = thisHouse.GetCity();
            txtPrice.Text = thisHouse.GetPrice().ToString();
            txtSML.Text = thisHouse.GetSqMLiving().ToString();
            txtSMP.Text = thisHouse.GetSqMProperty().ToString();
            txtBath.Text = thisHouse.GetBathrooms().ToString();
            txtBed.Text = thisHouse.GetBedrooms().ToString();
            txtVol.Text = thisHouse.GetVolume().ToString();
            txtFloor.Text = thisHouse.GetFloors().ToString();
            energySelect.Items.Add(thisHouse.GetEnergyLabel().ToString());
            txtCY.Text = thisHouse.GetConstructionYear().ToString();
            soldBox.Items.Add(thisHouse.IsSold());
            txtDesc.Text = thisHouse.GetDescription();

            soldBox.SelectedIndex = 1;
            foreach (var energyLabel in Enum.GetValues(typeof(EnergyLabel)))
            {
                energySelect.Items.Add(energyLabel);
            }
            energySelect.SelectedIndex = 1;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void txtSML_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void txtSMP_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void txtBath_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void txtBed_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void txtVol_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void txtFloor_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void txtEL_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void txtCY_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void soldBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            OpenButton();
        }

        private void OpenButton()
        {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int soldInt = 0;

            if (soldBox.SelectedIndex == 0)
            {
                soldInt = 1;
            }
            else if (soldBox.SelectedIndex == 1)
            {
                soldInt = 0;
            }

            var selectedEnergyValue = energySelect.SelectedItem;
            string selectedEnergyLabel = "";
            if (selectedEnergyValue != null)
            {
                selectedEnergyLabel = selectedEnergyValue.ToString();
            }

            object[] houseData = new object[]
            {
                thisHouse.GetHouseId(),
                txtAddress.Text,
                txtCity.Text,
                txtPrice.Text,
                txtSML.Text,
                txtSMP.Text,
                txtBath.Text,
                txtBed.Text,
                txtVol.Text,
                txtFloor.Text,
                selectedEnergyLabel,
                txtCY.Text,
                soldInt,
                txtDesc.Text,
            };

            if (houseHandler.UpdateHouse(houseData))
            {
                MessageBox.Show("House updated successfully!");
                //reload overview form
                this.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong, try again");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ConfirmDelete confirmDelete = new ConfirmDelete(thisHouse.GetHouseId());
            confirmDelete.ShowDialog();
            this.Close();
        }
    }
}
