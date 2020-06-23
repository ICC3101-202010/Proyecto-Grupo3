namespace Entrega3Netify
{
    partial class LoginChallenge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginChallenge));
            this.EnterMailTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EnterPasswordTextBox = new System.Windows.Forms.TextBox();
            this.AcceptLoginButton = new System.Windows.Forms.Button();
            this.CancelLoginButton = new System.Windows.Forms.Button();
            this.AdminCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // EnterMailTextBox
            // 
            this.EnterMailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.EnterMailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterMailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterMailTextBox.ForeColor = System.Drawing.Color.White;
            this.EnterMailTextBox.Location = new System.Drawing.Point(107, 24);
            this.EnterMailTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EnterMailTextBox.Name = "EnterMailTextBox";
            this.EnterMailTextBox.Size = new System.Drawing.Size(279, 21);
            this.EnterMailTextBox.TabIndex = 0;
            this.EnterMailTextBox.TextChanged += new System.EventHandler(this.EnterMailTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese Mail:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese Password";
            // 
            // EnterPasswordTextBox
            // 
            this.EnterPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.EnterPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterPasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.EnterPasswordTextBox.Location = new System.Drawing.Point(107, 56);
            this.EnterPasswordTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EnterPasswordTextBox.Name = "EnterPasswordTextBox";
            this.EnterPasswordTextBox.PasswordChar = '*';
            this.EnterPasswordTextBox.Size = new System.Drawing.Size(279, 21);
            this.EnterPasswordTextBox.TabIndex = 3;
            this.EnterPasswordTextBox.TextChanged += new System.EventHandler(this.EnterPasswordTextBox_TextChanged);
            // 
            // AcceptLoginButton
            // 
            this.AcceptLoginButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AcceptLoginButton.BackgroundImage")));
            this.AcceptLoginButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AcceptLoginButton.FlatAppearance.BorderSize = 0;
            this.AcceptLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptLoginButton.Location = new System.Drawing.Point(116, 101);
            this.AcceptLoginButton.Margin = new System.Windows.Forms.Padding(2);
            this.AcceptLoginButton.Name = "AcceptLoginButton";
            this.AcceptLoginButton.Size = new System.Drawing.Size(111, 29);
            this.AcceptLoginButton.TabIndex = 4;
            this.AcceptLoginButton.Text = "Aceptar";
            this.AcceptLoginButton.UseVisualStyleBackColor = true;
            this.AcceptLoginButton.Click += new System.EventHandler(this.AcceptLoginButton_Click);
            // 
            // CancelLoginButton
            // 
            this.CancelLoginButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelLoginButton.BackgroundImage")));
            this.CancelLoginButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CancelLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelLoginButton.Location = new System.Drawing.Point(275, 101);
            this.CancelLoginButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelLoginButton.Name = "CancelLoginButton";
            this.CancelLoginButton.Size = new System.Drawing.Size(111, 29);
            this.CancelLoginButton.TabIndex = 5;
            this.CancelLoginButton.Text = "Cancelar";
            this.CancelLoginButton.UseVisualStyleBackColor = true;
            this.CancelLoginButton.Click += new System.EventHandler(this.CancelLoginButton_Click);
            // 
            // AdminCheckBox
            // 
            this.AdminCheckBox.AutoSize = true;
            this.AdminCheckBox.Location = new System.Drawing.Point(13, 88);
            this.AdminCheckBox.Name = "AdminCheckBox";
            this.AdminCheckBox.Size = new System.Drawing.Size(89, 17);
            this.AdminCheckBox.TabIndex = 6;
            this.AdminCheckBox.Text = "Administrador";
            this.AdminCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginChallenge
            // 
            this.AcceptButton = this.AcceptLoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(412, 146);
            this.Controls.Add(this.AdminCheckBox);
            this.Controls.Add(this.CancelLoginButton);
            this.Controls.Add(this.AcceptLoginButton);
            this.Controls.Add(this.EnterPasswordTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnterMailTextBox);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginChallenge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginChallenge_FormClosed);
            this.Load += new System.EventHandler(this.LoginChallenge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EnterMailTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EnterPasswordTextBox;
        private System.Windows.Forms.Button AcceptLoginButton;
        private System.Windows.Forms.Button CancelLoginButton;
        private System.Windows.Forms.CheckBox AdminCheckBox;
    }
}