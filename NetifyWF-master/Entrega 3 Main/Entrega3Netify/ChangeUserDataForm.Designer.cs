namespace Entrega3Netify
{
    partial class ChangeUserDataForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.MailBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DescBox = new System.Windows.Forms.TextBox();
            this.PrivateCheck = new System.Windows.Forms.CheckBox();
            this.PremiumCheck = new System.Windows.Forms.CheckBox();
            this.CommitChangesButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mail:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MailBox
            // 
            this.MailBox.Location = new System.Drawing.Point(113, 28);
            this.MailBox.Margin = new System.Windows.Forms.Padding(2);
            this.MailBox.Name = "MailBox";
            this.MailBox.Size = new System.Drawing.Size(267, 20);
            this.MailBox.TabIndex = 1;
            this.MailBox.TextChanged += new System.EventHandler(this.MailBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(113, 55);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(267, 20);
            this.PasswordBox.TabIndex = 3;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(113, 79);
            this.nameBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(267, 20);
            this.nameBox.TabIndex = 4;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(113, 109);
            this.lastNameBox.Margin = new System.Windows.Forms.Padding(2);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(267, 20);
            this.lastNameBox.TabIndex = 6;
            this.lastNameBox.TextChanged += new System.EventHandler(this.lastNameBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Apellido:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 139);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Descripcion:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DescBox
            // 
            this.DescBox.Location = new System.Drawing.Point(113, 135);
            this.DescBox.Margin = new System.Windows.Forms.Padding(2);
            this.DescBox.Name = "DescBox";
            this.DescBox.Size = new System.Drawing.Size(267, 20);
            this.DescBox.TabIndex = 9;
            this.DescBox.TextChanged += new System.EventHandler(this.DescBox_TextChanged);
            // 
            // PrivateCheck
            // 
            this.PrivateCheck.AutoSize = true;
            this.PrivateCheck.Location = new System.Drawing.Point(113, 180);
            this.PrivateCheck.Margin = new System.Windows.Forms.Padding(2);
            this.PrivateCheck.Name = "PrivateCheck";
            this.PrivateCheck.Size = new System.Drawing.Size(101, 17);
            this.PrivateCheck.TabIndex = 10;
            this.PrivateCheck.Text = "Usuario Privado";
            this.PrivateCheck.UseVisualStyleBackColor = true;
            this.PrivateCheck.CheckedChanged += new System.EventHandler(this.PrivateCheck_CheckedChanged);
            // 
            // PremiumCheck
            // 
            this.PremiumCheck.AutoSize = true;
            this.PremiumCheck.Location = new System.Drawing.Point(220, 180);
            this.PremiumCheck.Margin = new System.Windows.Forms.Padding(2);
            this.PremiumCheck.Name = "PremiumCheck";
            this.PremiumCheck.Size = new System.Drawing.Size(105, 17);
            this.PremiumCheck.TabIndex = 11;
            this.PremiumCheck.Text = "Usuario Premium";
            this.PremiumCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PremiumCheck.UseVisualStyleBackColor = true;
            this.PremiumCheck.CheckedChanged += new System.EventHandler(this.PremiumCheck_CheckedChanged);
            // 
            // CommitChangesButton
            // 
            this.CommitChangesButton.Location = new System.Drawing.Point(147, 220);
            this.CommitChangesButton.Margin = new System.Windows.Forms.Padding(2);
            this.CommitChangesButton.Name = "CommitChangesButton";
            this.CommitChangesButton.Size = new System.Drawing.Size(93, 38);
            this.CommitChangesButton.TabIndex = 12;
            this.CommitChangesButton.Text = "Aceptar Cambios";
            this.CommitChangesButton.UseVisualStyleBackColor = true;
            this.CommitChangesButton.Click += new System.EventHandler(this.CommitChangesButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(252, 220);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(93, 38);
            this.ExitButton.TabIndex = 13;
            this.ExitButton.Text = "Cancelar";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ChangeUserDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 289);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CommitChangesButton);
            this.Controls.Add(this.PremiumCheck);
            this.Controls.Add(this.PrivateCheck);
            this.Controls.Add(this.DescBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MailBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChangeUserDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Usuario";
            this.Load += new System.EventHandler(this.ChangeUserDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MailBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DescBox;
        private System.Windows.Forms.CheckBox PrivateCheck;
        private System.Windows.Forms.CheckBox PremiumCheck;
        private System.Windows.Forms.Button CommitChangesButton;
        private System.Windows.Forms.Button ExitButton;
    }
}