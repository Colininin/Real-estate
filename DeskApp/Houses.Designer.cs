namespace DeskApp
{
    partial class Houses
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
            filterBox = new GroupBox();
            InputAddress = new TextBox();
            label2 = new Label();
            InputID = new TextBox();
            label1 = new Label();
            AllhousesContainer = new FlowLayoutPanel();
            filterBox.SuspendLayout();
            SuspendLayout();
            // 
            // filterBox
            // 
            filterBox.BackColor = SystemColors.ActiveCaption;
            filterBox.Controls.Add(InputAddress);
            filterBox.Controls.Add(label2);
            filterBox.Controls.Add(InputID);
            filterBox.Controls.Add(label1);
            filterBox.Location = new Point(22, 26);
            filterBox.Margin = new Padding(6, 6, 6, 6);
            filterBox.Name = "filterBox";
            filterBox.Padding = new Padding(6, 6, 6, 6);
            filterBox.Size = new Size(266, 1067);
            filterBox.TabIndex = 0;
            filterBox.TabStop = false;
            // 
            // InputAddress
            // 
            InputAddress.Location = new Point(11, 580);
            InputAddress.Margin = new Padding(6, 6, 6, 6);
            InputAddress.Name = "InputAddress";
            InputAddress.Size = new Size(216, 39);
            InputAddress.TabIndex = 3;
            InputAddress.TextChanged += InputAddress_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 542);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(173, 32);
            label2.TabIndex = 2;
            label2.Text = "House Address";
            // 
            // InputID
            // 
            InputID.Location = new Point(11, 390);
            InputID.Margin = new Padding(6, 6, 6, 6);
            InputID.Name = "InputID";
            InputID.Size = new Size(216, 39);
            InputID.TabIndex = 1;
            InputID.TextChanged += InputID_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 352);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(112, 32);
            label1.TabIndex = 0;
            label1.Text = "House ID";
            // 
            // AllhousesContainer
            // 
            AllhousesContainer.AutoScroll = true;
            AllhousesContainer.Location = new Point(299, 26);
            AllhousesContainer.Margin = new Padding(6, 6, 6, 6);
            AllhousesContainer.Name = "AllhousesContainer";
            AllhousesContainer.Size = new Size(1098, 1067);
            AllhousesContainer.TabIndex = 1;
            // 
            // Houses
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1419, 1118);
            Controls.Add(AllhousesContainer);
            Controls.Add(filterBox);
            Margin = new Padding(6, 6, 6, 6);
            Name = "Houses";
            Text = "Houses";
            filterBox.ResumeLayout(false);
            filterBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox filterBox;
        private TextBox InputAddress;
        private Label label2;
        private TextBox InputID;
        private Label label1;
        private FlowLayoutPanel AllhousesContainer;
    }
}