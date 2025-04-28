namespace DeskApp
{
    partial class Login
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
            label1 = new Label();
            label2 = new Label();
            InputEmail = new TextBox();
            InputPass = new TextBox();
            label3 = new Label();
            LoginBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(242, 48);
            label1.Name = "label1";
            label1.Size = new Size(82, 21);
            label1.TabIndex = 0;
            label1.Text = "Welcome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(201, 110);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Email:";
            // 
            // InputEmail
            // 
            InputEmail.Location = new Point(201, 128);
            InputEmail.Name = "InputEmail";
            InputEmail.Size = new Size(166, 23);
            InputEmail.TabIndex = 2;
            // 
            // InputPass
            // 
            InputPass.Location = new Point(201, 200);
            InputPass.Name = "InputPass";
            InputPass.PasswordChar = '*';
            InputPass.Size = new Size(166, 23);
            InputPass.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(201, 182);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 3;
            label3.Text = "Password:";
            // 
            // LoginBtn
            // 
            LoginBtn.Location = new Point(201, 253);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(166, 23);
            LoginBtn.TabIndex = 4;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 350);
            Controls.Add(LoginBtn);
            Controls.Add(label3);
            Controls.Add(InputPass);
            Controls.Add(InputEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox InputEmail;
        private TextBox InputPass;
        private Label label3;
        private Button LoginBtn;
    }
}