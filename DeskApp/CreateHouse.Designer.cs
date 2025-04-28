namespace DeskApp
{
    partial class CreateHouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            soldBox = new ComboBox();
            label12 = new Label();
            txtCY = new TextBox();
            label11 = new Label();
            label10 = new Label();
            txtCity = new TextBox();
            label9 = new Label();
            txtFloor = new TextBox();
            label5 = new Label();
            txtVol = new TextBox();
            label6 = new Label();
            txtBed = new TextBox();
            label7 = new Label();
            txtBath = new TextBox();
            label8 = new Label();
            txtSMP = new TextBox();
            label4 = new Label();
            txtSML = new TextBox();
            label3 = new Label();
            txtPrice = new TextBox();
            label2 = new Label();
            txtAddress = new TextBox();
            label1 = new Label();
            txtDesc = new RichTextBox();
            label13 = new Label();
            btnSave = new Button();
            openFile = new OpenFileDialog();
            label14 = new Label();
            typeBox = new ComboBox();
            label15 = new Label();
            selectOwner = new ComboBox();
            selectEnergy = new ComboBox();
            SuspendLayout();
            // 
            // soldBox
            // 
            soldBox.DropDownStyle = ComboBoxStyle.DropDownList;
            soldBox.FormattingEnabled = true;
            soldBox.Items.AddRange(new object[] { "Available", "Sold" });
            soldBox.Location = new Point(330, 297);
            soldBox.Margin = new Padding(2, 1, 2, 1);
            soldBox.Name = "soldBox";
            soldBox.Size = new Size(204, 23);
            soldBox.TabIndex = 53;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(330, 276);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(44, 15);
            label12.TabIndex = 52;
            label12.Text = "Is Sold:";
            // 
            // txtCY
            // 
            txtCY.Location = new Point(39, 350);
            txtCY.Margin = new Padding(2, 1, 2, 1);
            txtCY.Name = "txtCY";
            txtCY.Size = new Size(204, 23);
            txtCY.TabIndex = 51;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(39, 329);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(104, 15);
            label11.TabIndex = 50;
            label11.Text = "Construction Year:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(330, 221);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(74, 15);
            label10.TabIndex = 48;
            label10.Text = "EnergyLabel:";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(330, 27);
            txtCity.Margin = new Padding(2, 1, 2, 1);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(204, 23);
            txtCity.TabIndex = 47;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(330, 5);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 46;
            label9.Text = "City:";
            // 
            // txtFloor
            // 
            txtFloor.Location = new Point(39, 297);
            txtFloor.Margin = new Padding(2, 1, 2, 1);
            txtFloor.Name = "txtFloor";
            txtFloor.Size = new Size(204, 23);
            txtFloor.TabIndex = 45;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 275);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 44;
            label5.Text = "Floors:";
            // 
            // txtVol
            // 
            txtVol.Location = new Point(330, 188);
            txtVol.Margin = new Padding(2, 1, 2, 1);
            txtVol.Name = "txtVol";
            txtVol.Size = new Size(204, 23);
            txtVol.TabIndex = 43;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(330, 166);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 42;
            label6.Text = "Volume:";
            // 
            // txtBed
            // 
            txtBed.Location = new Point(39, 243);
            txtBed.Margin = new Padding(2, 1, 2, 1);
            txtBed.Name = "txtBed";
            txtBed.Size = new Size(204, 23);
            txtBed.TabIndex = 41;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 221);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 40;
            label7.Text = "Bedrooms";
            // 
            // txtBath
            // 
            txtBath.Location = new Point(330, 133);
            txtBath.Margin = new Padding(2, 1, 2, 1);
            txtBath.Name = "txtBath";
            txtBath.Size = new Size(204, 23);
            txtBath.TabIndex = 39;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(330, 111);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 38;
            label8.Text = "Bathrooms";
            // 
            // txtSMP
            // 
            txtSMP.Location = new Point(39, 188);
            txtSMP.Margin = new Padding(2, 1, 2, 1);
            txtSMP.Name = "txtSMP";
            txtSMP.Size = new Size(204, 23);
            txtSMP.TabIndex = 37;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 166);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(128, 15);
            label4.TabIndex = 36;
            label4.Text = "Square Meter Property:";
            // 
            // txtSML
            // 
            txtSML.Location = new Point(330, 79);
            txtSML.Margin = new Padding(2, 1, 2, 1);
            txtSML.Name = "txtSML";
            txtSML.Size = new Size(204, 23);
            txtSML.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 57);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 34;
            label3.Text = "Square Meter Living:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(39, 133);
            txtPrice.Margin = new Padding(2, 1, 2, 1);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(204, 23);
            txtPrice.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 111);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 32;
            label2.Text = "Price:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(39, 79);
            txtAddress.Margin = new Padding(2, 1, 2, 1);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(204, 23);
            txtAddress.TabIndex = 31;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 57);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 30;
            label1.Text = "Address:";
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(39, 418);
            txtDesc.Margin = new Padding(2, 1, 2, 1);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(495, 92);
            txtDesc.TabIndex = 55;
            txtDesc.Text = "";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(39, 389);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(70, 15);
            label13.TabIndex = 54;
            label13.Text = "Description:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(580, 26);
            btnSave.Margin = new Padding(2, 1, 2, 1);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 345);
            btnSave.TabIndex = 56;
            btnSave.Text = "Create house";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // openFile
            // 
            openFile.FileName = "openFileDialog1";
            openFile.Multiselect = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(39, 5);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(45, 15);
            label14.TabIndex = 58;
            label14.Text = "Owner:";
            // 
            // typeBox
            // 
            typeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeBox.FormattingEnabled = true;
            typeBox.Items.AddRange(new object[] { "Villa", "Penthouse", "N/A" });
            typeBox.Location = new Point(330, 350);
            typeBox.Margin = new Padding(2, 1, 2, 1);
            typeBox.Name = "typeBox";
            typeBox.Size = new Size(204, 23);
            typeBox.TabIndex = 61;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(330, 329);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(34, 15);
            label15.TabIndex = 60;
            label15.Text = "Type:";
            // 
            // selectOwner
            // 
            selectOwner.DropDownStyle = ComboBoxStyle.DropDownList;
            selectOwner.FormattingEnabled = true;
            selectOwner.Location = new Point(39, 27);
            selectOwner.Margin = new Padding(2, 1, 2, 1);
            selectOwner.Name = "selectOwner";
            selectOwner.Size = new Size(204, 23);
            selectOwner.TabIndex = 62;
            // 
            // selectEnergy
            // 
            selectEnergy.DropDownStyle = ComboBoxStyle.DropDownList;
            selectEnergy.FormattingEnabled = true;
            selectEnergy.Location = new Point(330, 243);
            selectEnergy.Margin = new Padding(2, 1, 2, 1);
            selectEnergy.Name = "selectEnergy";
            selectEnergy.Size = new Size(204, 23);
            selectEnergy.TabIndex = 63;
            // 
            // CreateHouse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 524);
            Controls.Add(selectEnergy);
            Controls.Add(selectOwner);
            Controls.Add(typeBox);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(btnSave);
            Controls.Add(txtDesc);
            Controls.Add(label13);
            Controls.Add(soldBox);
            Controls.Add(label12);
            Controls.Add(txtCY);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(txtCity);
            Controls.Add(label9);
            Controls.Add(txtFloor);
            Controls.Add(label5);
            Controls.Add(txtVol);
            Controls.Add(label6);
            Controls.Add(txtBed);
            Controls.Add(label7);
            Controls.Add(txtBath);
            Controls.Add(label8);
            Controls.Add(txtSMP);
            Controls.Add(label4);
            Controls.Add(txtSML);
            Controls.Add(label3);
            Controls.Add(txtPrice);
            Controls.Add(label2);
            Controls.Add(txtAddress);
            Controls.Add(label1);
            Name = "CreateHouse";
            Text = "CreateHouse";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox soldBox;
        private Label label12;
        private TextBox txtCY;
        private Label label11;
        private Label label10;
        private TextBox txtCity;
        private Label label9;
        private TextBox txtFloor;
        private Label label5;
        private TextBox txtVol;
        private Label label6;
        private TextBox txtBed;
        private Label label7;
        private TextBox txtBath;
        private Label label8;
        private TextBox txtSMP;
        private Label label4;
        private TextBox txtSML;
        private Label label3;
        private TextBox txtPrice;
        private Label label2;
        private TextBox txtAddress;
        private Label label1;
        private RichTextBox txtDesc;
        private Label label13;
        private Button btnSave;
        private OpenFileDialog openFile;
        private Label label14;
        private ComboBox typeBox;
        private Label label15;
        private ComboBox selectOwner;
        private ComboBox selectEnergy;
    }
}