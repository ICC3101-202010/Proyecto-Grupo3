namespace Entrega3Netify
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.MenuRegisterButton = new System.Windows.Forms.Button();
            this.MenuLoginButton = new System.Windows.Forms.Button();
            this.MenuExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MenuRegisterButton
            // 
            this.MenuRegisterButton.Location = new System.Drawing.Point(145, 18);
            this.MenuRegisterButton.Margin = new System.Windows.Forms.Padding(2);
            this.MenuRegisterButton.Name = "MenuRegisterButton";
            this.MenuRegisterButton.Size = new System.Drawing.Size(125, 66);
            this.MenuRegisterButton.TabIndex = 0;
            this.MenuRegisterButton.Text = "Registrarse";
            this.MenuRegisterButton.UseVisualStyleBackColor = true;
            this.MenuRegisterButton.Click += new System.EventHandler(this.MenuRegisterButton_Click);
            // 
            // MenuLoginButton
            // 
            this.MenuLoginButton.Location = new System.Drawing.Point(145, 99);
            this.MenuLoginButton.Margin = new System.Windows.Forms.Padding(2);
            this.MenuLoginButton.Name = "MenuLoginButton";
            this.MenuLoginButton.Size = new System.Drawing.Size(125, 66);
            this.MenuLoginButton.TabIndex = 1;
            this.MenuLoginButton.Text = "Login";
            this.MenuLoginButton.UseVisualStyleBackColor = true;
            this.MenuLoginButton.Click += new System.EventHandler(this.MenuLoginButton_Click);
            // 
            // MenuExitButton
            // 
            this.MenuExitButton.Location = new System.Drawing.Point(145, 180);
            this.MenuExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.MenuExitButton.Name = "MenuExitButton";
            this.MenuExitButton.Size = new System.Drawing.Size(125, 66);
            this.MenuExitButton.TabIndex = 2;
            this.MenuExitButton.Text = "Salir";
            this.MenuExitButton.UseVisualStyleBackColor = true;
            this.MenuExitButton.Click += new System.EventHandler(this.MenuExitButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 276);
            this.Controls.Add(this.MenuExitButton);
            this.Controls.Add(this.MenuLoginButton);
            this.Controls.Add(this.MenuRegisterButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Netify";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MenuRegisterButton;
        private System.Windows.Forms.Button MenuLoginButton;
        private System.Windows.Forms.Button MenuExitButton;
    }
}