namespace DeskApp
{
    partial class ConfirmDelete
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
            confirmCheck = new CheckBox();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(272, 76);
            label1.Name = "label1";
            label1.Size = new Size(233, 45);
            label1.TabIndex = 0;
            label1.Text = "Are you sure?";
            // 
            // confirmCheck
            // 
            confirmCheck.AutoSize = true;
            confirmCheck.Location = new Point(75, 223);
            confirmCheck.Name = "confirmCheck";
            confirmCheck.Size = new Size(235, 36);
            confirmCheck.TabIndex = 1;
            confirmCheck.Text = "Confirm to delete";
            confirmCheck.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Firebrick;
            btnDelete.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(533, 217);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 47);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // ConfirmDelete
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 323);
            Controls.Add(btnDelete);
            Controls.Add(confirmCheck);
            Controls.Add(label1);
            Name = "ConfirmDelete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConfirmDelete";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckBox confirmCheck;
        private Button btnDelete;
    }
}