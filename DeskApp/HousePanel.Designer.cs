namespace DeskApp
{
    partial class HousePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblAddress = new Label();
            lblPrice = new Label();
            lblID = new Label();
            SuspendLayout();
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddress.ForeColor = Color.White;
            lblAddress.Location = new Point(201, 53);
            lblAddress.Margin = new Padding(6, 0, 6, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(141, 45);
            lblAddress.TabIndex = 0;
            lblAddress.Text = "Address";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.White;
            lblPrice.Location = new Point(201, 141);
            lblPrice.Margin = new Padding(6, 0, 6, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(94, 45);
            lblPrice.TabIndex = 1;
            lblPrice.Text = "Price";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(9, 11);
            lblID.Margin = new Padding(6, 0, 6, 0);
            lblID.Name = "lblID";
            lblID.Size = new Size(34, 32);
            lblID.TabIndex = 2;
            lblID.Text = "id";
            // 
            // HousePanel
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            Controls.Add(lblID);
            Controls.Add(lblPrice);
            Controls.Add(lblAddress);
            Margin = new Padding(6, 6, 6, 6);
            Name = "HousePanel";
            Size = new Size(1085, 254);
            MouseClick += HousePanel_MouseClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAddress;
        private Label lblPrice;
        private Label lblID;
    }
}
