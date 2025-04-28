namespace DeskApp
{
    partial class Home
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
            pnlForms = new Panel();
            btnHome = new Button();
            btnHouses = new Button();
            btnCreate = new Button();
            btnLogOut = new Button();
            SuspendLayout();
            // 
            // pnlForms
            // 
            pnlForms.Location = new Point(165, -2);
            pnlForms.Name = "pnlForms";
            pnlForms.Size = new Size(780, 563);
            pnlForms.TabIndex = 0;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(12, 38);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(139, 51);
            btnHome.TabIndex = 1;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnHouses
            // 
            btnHouses.Location = new Point(12, 119);
            btnHouses.Name = "btnHouses";
            btnHouses.Size = new Size(139, 51);
            btnHouses.TabIndex = 2;
            btnHouses.Text = "Houses for sale";
            btnHouses.UseVisualStyleBackColor = true;
            btnHouses.Click += btnHouses_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(12, 204);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(139, 51);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "Create house";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(12, 284);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(139, 51);
            btnLogOut.TabIndex = 4;
            btnLogOut.Text = "Log Out";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 557);
            Controls.Add(btnLogOut);
            Controls.Add(btnCreate);
            Controls.Add(btnHouses);
            Controls.Add(btnHome);
            Controls.Add(pnlForms);
            Name = "Home";
            Text = "Home";
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlForms;
        private Button btnHome;
        private Button btnHouses;
        private Button btnCreate;
        private Button btnLogOut;
    }
}