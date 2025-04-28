using ClassLib.Classes;
using ClassLib.Interfaces;
using DAL.Classes;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
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
    public partial class CreateHouse : Form
    {
        private readonly HouseManager houseHandler;
        private readonly UserManager userHandler;
        private List<User> users;
        public CreateHouse()
        {
            houseHandler = new HouseManager();
            userHandler = new UserManager();
            InitializeComponent();
            users = new List<User>(userHandler.ReturnUsers());
            populateBoxes();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int soldInt = 0;

            if (soldBox.SelectedIndex == 0)
            {
                soldInt = 0;
            }
            else if (soldBox.SelectedIndex == 1)
            {
                soldInt = 1;
            }

            string selectedEmail = selectOwner.SelectedItem?.ToString();
            User selectedUser = null;
            if (selectedEmail != null)
            {
                selectedUser = users.Find(user => user.GetEmail() == selectedEmail);
            }

            if(selectedUser != null)
            {

                int userId = selectedUser.GetId();
                var selectedEnergyValue = selectEnergy.SelectedItem;
                string selectedEnergyLabel = "";
                if (selectedEnergyValue != null)
                {
                    selectedEnergyLabel = selectedEnergyValue.ToString();
                }

                if (txtPrice.Text != "" && txtAddress.Text != "" && txtCity.Text != "" &&
                    txtSML.Text != "" && txtSMP.Text != "" && txtVol.Text != "" && txtBed.Text != "" &&
                    txtBath.Text != "" && txtFloor.Text != "" && txtDesc.Text != "" && txtCY.Text != "")
                {
                    object[] houseData = new object[]
                    {
                        userId,
                        Convert.ToDouble(txtPrice.Text),
                        txtAddress.Text,
                        txtCity.Text,
                        Convert.ToInt32(txtSML.Text),
                        Convert.ToInt32(txtSMP.Text),
                        Convert.ToInt32(txtVol.Text),
                        Convert.ToInt32(txtBed.Text),
                        Convert.ToInt32(txtBath.Text),
                        Convert.ToInt32(txtFloor.Text),
                        selectedEnergyLabel,
                        txtDesc.Text,
                        Convert.ToInt32(txtCY.Text),
                        soldInt,
                        typeBox.Text
                    };

                    int houseId = houseHandler.InsertHouse(houseData);

                    if (houseId > 0)
                    {
                        MessageBox.Show("House created succesfully");
                        ClearBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create house. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Please make sure that every field is filled in!");
                }
            }
        }

        private void populateBoxes()
        {
            selectOwner.Items.Clear();
            selectEnergy.Items.Clear();
            foreach (User user in users)
            {
                selectOwner.Items.Add(user.GetEmail());
            }

            foreach (var energyLabel in Enum.GetValues(typeof(EnergyLabel)))
            {
                selectEnergy.Items.Add(energyLabel);
            }
        }

        private void ClearBoxes()
        {
            selectOwner.SelectedIndex = 0;
            txtPrice.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtSML.Clear();
            txtSMP.Clear();
            txtVol.Clear();
            txtBed.Clear();
            txtBath.Clear();
            txtFloor.Clear();
            txtDesc.Clear();
            txtCY.Clear();
            selectEnergy.SelectedIndex = 0;
            soldBox.SelectedIndex = 0;
        }

        
    }
}
