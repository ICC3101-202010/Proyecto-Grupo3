namespace Entrega3Netify
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.inputMailBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputPasswordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.enterNameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.enterLastNameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.enterDescBox = new System.Windows.Forms.TextBox();
            this.acceptRegisterButton = new System.Windows.Forms.Button();
            this.cancelRegisterButton = new System.Windows.Forms.Button();
            this.privateCheckbox = new System.Windows.Forms.CheckBox();
            this.premiumCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // inputMailBox
            // 
            this.inputMailBox.Location = new System.Drawing.Point(92, 16);
            this.inputMailBox.Margin = new System.Windows.Forms.Padding(2);
            this.inputMailBox.Name = "inputMailBox";
            this.inputMailBox.Size = new System.Drawing.Size(272, 20);
            this.inputMailBox.TabIndex = 0;
            this.inputMailBox.TextChanged += new System.EventHandler(this.inputMailBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese Mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // inputPasswordBox
            // 
            this.inputPasswordBox.Location = new System.Drawing.Point(92, 49);
            this.inputPasswordBox.Margin = new System.Windows.Forms.Padding(2);
            this.inputPasswordBox.Name = "inputPasswordBox";
            this.inputPasswordBox.Size = new System.Drawing.Size(272, 20);
            this.inputPasswordBox.TabIndex = 2;
            this.inputPasswordBox.TextChanged += new System.EventHandler(this.inputPasswordBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre:";
            // 
            // enterNameBox
            // 
            this.enterNameBox.Location = new System.Drawing.Point(92, 82);
            this.enterNameBox.Margin = new System.Windows.Forms.Padding(2);
            this.enterNameBox.Name = "enterNameBox";
            this.enterNameBox.Size = new System.Drawing.Size(147, 20);
            this.enterNameBox.TabIndex = 4;
            this.enterNameBox.TextChanged += new System.EventHandler(this.enterNameBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Apellido:";
            // 
            // enterLastNameBox
            // 
            this.enterLastNameBox.Location = new System.Drawing.Point(92, 116);
            this.enterLastNameBox.Margin = new System.Windows.Forms.Padding(2);
            this.enterLastNameBox.Name = "enterLastNameBox";
            this.enterLastNameBox.Size = new System.Drawing.Size(147, 20);
            this.enterLastNameBox.TabIndex = 6;
            this.enterLastNameBox.TextChanged += new System.EventHandler(this.enterLastNameBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Descripcion:";
            // 
            // enterDescBox
            // 
            this.enterDescBox.Location = new System.Drawing.Point(92, 152);
            this.enterDescBox.Margin = new System.Windows.Forms.Padding(2);
            this.enterDescBox.Name = "enterDescBox";
            this.enterDescBox.Size = new System.Drawing.Size(147, 20);
            this.enterDescBox.TabIndex = 8;
            this.enterDescBox.TextChanged += new System.EventHandler(this.enterDescBox_TextChanged);
            // 
            // acceptRegisterButton
            // 
            this.acceptRegisterButton.Location = new System.Drawing.Point(77, 228);
            this.acceptRegisterButton.Margin = new System.Windows.Forms.Padding(2);
            this.acceptRegisterButton.Name = "acceptRegisterButton";
            this.acceptRegisterButton.Size = new System.Drawing.Size(121, 32);
            this.acceptRegisterButton.TabIndex = 10;
            this.acceptRegisterButton.Text = "Aceptar";
            this.acceptRegisterButton.UseVisualStyleBackColor = true;
            this.acceptRegisterButton.Click += new System.EventHandler(this.acceptRegisterButton_Click);
            // 
            // cancelRegisterButton
            // 
            this.cancelRegisterButton.Location = new System.Drawing.Point(211, 228);
            this.cancelRegisterButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelRegisterButton.Name = "cancelRegisterButton";
            this.cancelRegisterButton.Size = new System.Drawing.Size(121, 32);
            this.cancelRegisterButton.TabIndex = 11;
            this.cancelRegisterButton.Text = "Cancelar";
            this.cancelRegisterButton.UseVisualStyleBackColor = true;
            this.cancelRegisterButton.Click += new System.EventHandler(this.cancelRegisterButton_Click);
            // 
            // privateCheckbox
            // 
            this.privateCheckbox.AutoSize = true;
            this.privateCheckbox.Location = new System.Drawing.Point(92, 180);
            this.privateCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.privateCheckbox.Name = "privateCheckbox";
            this.privateCheckbox.Size = new System.Drawing.Size(88, 17);
            this.privateCheckbox.TabIndex = 12;
            this.privateCheckbox.Text = "Perfil Privado";
            this.privateCheckbox.UseVisualStyleBackColor = true;
            this.privateCheckbox.CheckedChanged += new System.EventHandler(this.privateCheckbox_CheckedChanged);
            // 
            // premiumCheckBox
            // 
            this.premiumCheckBox.AutoSize = true;
            this.premiumCheckBox.Location = new System.Drawing.Point(92, 200);
            this.premiumCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.premiumCheckBox.Name = "premiumCheckBox";
            this.premiumCheckBox.Size = new System.Drawing.Size(92, 17);
            this.premiumCheckBox.TabIndex = 13;
            this.premiumCheckBox.Text = "Perfil Premium";
            this.premiumCheckBox.UseVisualStyleBackColor = true;
            this.premiumCheckBox.CheckedChanged += new System.EventHandler(this.premiumCheckBox_CheckedChanged);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 276);
            this.Controls.Add(this.premiumCheckBox);
            this.Controls.Add(this.privateCheckbox);
            this.Controls.Add(this.cancelRegisterButton);
            this.Controls.Add(this.acceptRegisterButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.enterDescBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.enterLastNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.enterNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputPasswordBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputMailBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrarse a Netify";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputMailBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputPasswordBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox enterNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox enterLastNameBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox enterDescBox;
        private System.Windows.Forms.Button acceptRegisterButton;
        private System.Windows.Forms.Button cancelRegisterButton;
        private System.Windows.Forms.CheckBox privateCheckbox;
        private System.Windows.Forms.CheckBox premiumCheckBox;
    }
}