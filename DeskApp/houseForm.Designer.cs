namespace DeskApp
{
    partial class houseForm
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
            lblID = new Label();
            label1 = new Label();
            txtAddress = new TextBox();
            txtPrice = new TextBox();
            label2 = new Label();
            txtSML = new TextBox();
            label3 = new Label();
            txtSMP = new TextBox();
            label4 = new Label();
            txtFloor = new TextBox();
            label5 = new Label();
            txtVol = new TextBox();
            label6 = new Label();
            txtBed = new TextBox();
            label7 = new Label();
            txtBath = new TextBox();
            label8 = new Label();
            txtCity = new TextBox();
            label9 = new Label();
            label10 = new Label();
            txtCY = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            txtDesc = new RichTextBox();
            btnSave = new Button();
            btnDel = new Button();
            soldBox = new ComboBox();
            energySelect = new ComboBox();
            SuspendLayout();
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(6, 4);
            lblID.Margin = new Padding(2, 0, 2, 0);
            lblID.Name = "lblID";
            lblID.Size = new Size(38, 15);
            lblID.TabIndex = 0;
            lblID.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 54);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 1;
            label1.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(66, 76);
            txtAddress.Margin = new Padding(2, 1, 2, 1);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(204, 23);
            txtAddress.TabIndex = 2;
            txtAddress.TextChanged += txtAddress_TextChanged;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(66, 142);
            txtPrice.Margin = new Padding(2, 1, 2, 1);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(204, 23);
            txtPrice.TabIndex = 4;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 120);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 3;
            label2.Text = "Price:";
            // 
            // txtSML
            // 
            txtSML.Location = new Point(356, 142);
            txtSML.Margin = new Padding(2, 1, 2, 1);
            txtSML.Name = "txtSML";
            txtSML.Size = new Size(204, 23);
            txtSML.TabIndex = 6;
            txtSML.TextChanged += txtSML_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(356, 120);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 5;
            label3.Text = "Square Meter Living:";
            // 
            // txtSMP
            // 
            txtSMP.Location = new Point(66, 216);
            txtSMP.Margin = new Padding(2, 1, 2, 1);
            txtSMP.Name = "txtSMP";
            txtSMP.Size = new Size(204, 23);
            txtSMP.TabIndex = 8;
            txtSMP.TextChanged += txtSMP_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 194);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(128, 15);
            label4.TabIndex = 7;
            label4.Text = "Square Meter Property:";
            // 
            // txtFloor
            // 
            txtFloor.Location = new Point(66, 366);
            txtFloor.Margin = new Padding(2, 1, 2, 1);
            txtFloor.Name = "txtFloor";
            txtFloor.Size = new Size(204, 23);
            txtFloor.TabIndex = 16;
            txtFloor.TextChanged += txtFloor_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(66, 344);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 15;
            label5.Text = "Floors:";
            // 
            // txtVol
            // 
            txtVol.Location = new Point(356, 290);
            txtVol.Margin = new Padding(2, 1, 2, 1);
            txtVol.Name = "txtVol";
            txtVol.Size = new Size(204, 23);
            txtVol.TabIndex = 14;
            txtVol.TextChanged += txtVol_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(356, 268);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 13;
            label6.Text = "Volume:";
            // 
            // txtBed
            // 
            txtBed.Location = new Point(66, 290);
            txtBed.Margin = new Padding(2, 1, 2, 1);
            txtBed.Name = "txtBed";
            txtBed.Size = new Size(204, 23);
            txtBed.TabIndex = 12;
            txtBed.TextChanged += txtBed_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(66, 268);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 11;
            label7.Text = "Bedrooms";
            // 
            // txtBath
            // 
            txtBath.Location = new Point(356, 216);
            txtBath.Margin = new Padding(2, 1, 2, 1);
            txtBath.Name = "txtBath";
            txtBath.Size = new Size(204, 23);
            txtBath.TabIndex = 10;
            txtBath.TextChanged += txtBath_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(356, 194);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 9;
            label8.Text = "Bathrooms";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(356, 76);
            txtCity.Margin = new Padding(2, 1, 2, 1);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(204, 23);
            txtCity.TabIndex = 18;
            txtCity.TextChanged += txtCity_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(356, 54);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 17;
            label9.Text = "City:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(356, 344);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(74, 15);
            label10.TabIndex = 19;
            label10.Text = "EnergyLabel:";
            // 
            // txtCY
            // 
            txtCY.Location = new Point(66, 440);
            txtCY.Margin = new Padding(2, 1, 2, 1);
            txtCY.Name = "txtCY";
            txtCY.Size = new Size(204, 23);
            txtCY.TabIndex = 22;
            txtCY.TextChanged += txtCY_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(66, 419);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(104, 15);
            label11.TabIndex = 21;
            label11.Text = "Construction Year:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(356, 419);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(44, 15);
            label12.TabIndex = 23;
            label12.Text = "Is Sold:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(66, 503);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(70, 15);
            label13.TabIndex = 25;
            label13.Text = "Description:";
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(66, 532);
            txtDesc.Margin = new Padding(2, 1, 2, 1);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(495, 92);
            txtDesc.TabIndex = 26;
            txtDesc.Text = "";
            txtDesc.TextChanged += txtDesc_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(66, 654);
            btnSave.Margin = new Padding(2, 1, 2, 1);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 22);
            btnSave.TabIndex = 27;
            btnSave.Text = "Save changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.Firebrick;
            btnDel.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDel.ForeColor = Color.White;
            btnDel.Location = new Point(478, 654);
            btnDel.Margin = new Padding(2, 1, 2, 1);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(81, 22);
            btnDel.TabIndex = 28;
            btnDel.Text = "Delete";
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // soldBox
            // 
            soldBox.DropDownStyle = ComboBoxStyle.DropDownList;
            soldBox.FormattingEnabled = true;
            soldBox.Items.AddRange(new object[] { "Sold" });
            soldBox.Location = new Point(356, 440);
            soldBox.Margin = new Padding(2, 1, 2, 1);
            soldBox.Name = "soldBox";
            soldBox.Size = new Size(204, 23);
            soldBox.TabIndex = 29;
            soldBox.SelectedIndexChanged += soldBox_SelectedIndexChanged;
            // 
            // energySelect
            // 
            energySelect.DropDownStyle = ComboBoxStyle.DropDownList;
            energySelect.FormattingEnabled = true;
            energySelect.Location = new Point(357, 366);
            energySelect.Margin = new Padding(2, 1, 2, 1);
            energySelect.Name = "energySelect";
            energySelect.Size = new Size(204, 23);
            energySelect.TabIndex = 30;
            // 
            // houseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 700);
            Controls.Add(energySelect);
            Controls.Add(soldBox);
            Controls.Add(btnDel);
            Controls.Add(btnSave);
            Controls.Add(txtDesc);
            Controls.Add(label13);
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
            Controls.Add(lblID);
            Margin = new Padding(2, 1, 2, 1);
            Name = "houseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "houseForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblID;
        private Label label1;
        private TextBox txtAddress;
        private TextBox txtPrice;
        private Label label2;
        private TextBox txtSML;
        private Label label3;
        private TextBox txtSMP;
        private Label label4;
        private TextBox txtFloor;
        private Label label5;
        private TextBox txtVol;
        private Label label6;
        private TextBox txtBed;
        private Label label7;
        private TextBox txtBath;
        private Label label8;
        private TextBox txtCity;
        private Label label9;
        private Label label10;
        private TextBox txtCY;
        private Label label11;
        private Label label12;
        private Label label13;
        private RichTextBox txtDesc;
        private Button btnSave;
        private Button btnDel;
        private ComboBox soldBox;
        private ComboBox energySelect;
    }
}