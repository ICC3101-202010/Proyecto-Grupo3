namespace Entrega3Netify
{
    partial class MainLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainLoginForm));
            this.ChangeDataButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.FollowUsersButton = new System.Windows.Forms.Button();
            this.FollowArtistsButton = new System.Windows.Forms.Button();
            this.followSingersButton = new System.Windows.Forms.Button();
            this.SongMenuBotton = new System.Windows.Forms.Button();
            this.VideoMenuBotton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangeDataButton
            // 
            this.ChangeDataButton.Location = new System.Drawing.Point(82, 112);
            this.ChangeDataButton.Margin = new System.Windows.Forms.Padding(2);
            this.ChangeDataButton.Name = "ChangeDataButton";
            this.ChangeDataButton.Size = new System.Drawing.Size(103, 42);
            this.ChangeDataButton.TabIndex = 2;
            this.ChangeDataButton.Text = "Cambiar Datos";
            this.ChangeDataButton.UseVisualStyleBackColor = true;
            this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(254, 227);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(103, 42);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Salir";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // FollowUsersButton
            // 
            this.FollowUsersButton.Location = new System.Drawing.Point(254, 112);
            this.FollowUsersButton.Margin = new System.Windows.Forms.Padding(2);
            this.FollowUsersButton.Name = "FollowUsersButton";
            this.FollowUsersButton.Size = new System.Drawing.Size(103, 42);
            this.FollowUsersButton.TabIndex = 3;
            this.FollowUsersButton.Text = "Seguir Usuarios";
            this.FollowUsersButton.UseVisualStyleBackColor = true;
            this.FollowUsersButton.Click += new System.EventHandler(this.FollowUsersButton_Click);
            // 
            // FollowArtistsButton
            // 
            this.FollowArtistsButton.Location = new System.Drawing.Point(82, 170);
            this.FollowArtistsButton.Margin = new System.Windows.Forms.Padding(2);
            this.FollowArtistsButton.Name = "FollowArtistsButton";
            this.FollowArtistsButton.Size = new System.Drawing.Size(103, 42);
            this.FollowArtistsButton.TabIndex = 4;
            this.FollowArtistsButton.Text = "Seguir Actores";
            this.FollowArtistsButton.UseVisualStyleBackColor = true;
            this.FollowArtistsButton.Click += new System.EventHandler(this.FollowArtistsButton_Click);
            // 
            // followSingersButton
            // 
            this.followSingersButton.Location = new System.Drawing.Point(254, 170);
            this.followSingersButton.Margin = new System.Windows.Forms.Padding(2);
            this.followSingersButton.Name = "followSingersButton";
            this.followSingersButton.Size = new System.Drawing.Size(103, 42);
            this.followSingersButton.TabIndex = 5;
            this.followSingersButton.Text = "Seguir Cantantes";
            this.followSingersButton.UseVisualStyleBackColor = true;
            this.followSingersButton.Click += new System.EventHandler(this.followSingersButton_Click);
            // 
            // SongMenuBotton
            // 
            this.SongMenuBotton.Location = new System.Drawing.Point(82, 54);
            this.SongMenuBotton.Margin = new System.Windows.Forms.Padding(2);
            this.SongMenuBotton.Name = "SongMenuBotton";
            this.SongMenuBotton.Size = new System.Drawing.Size(103, 42);
            this.SongMenuBotton.TabIndex = 0;
            this.SongMenuBotton.Text = "Menu Canciones";
            this.SongMenuBotton.UseVisualStyleBackColor = true;
            this.SongMenuBotton.Click += new System.EventHandler(this.SongMenuBotton_Click);
            // 
            // VideoMenuBotton
            // 
            this.VideoMenuBotton.Location = new System.Drawing.Point(254, 54);
            this.VideoMenuBotton.Margin = new System.Windows.Forms.Padding(2);
            this.VideoMenuBotton.Name = "VideoMenuBotton";
            this.VideoMenuBotton.Size = new System.Drawing.Size(103, 42);
            this.VideoMenuBotton.TabIndex = 1;
            this.VideoMenuBotton.Text = "Menu Videos";
            this.VideoMenuBotton.UseVisualStyleBackColor = true;
            this.VideoMenuBotton.Click += new System.EventHandler(this.VideoMenuBotton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 227);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Extras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 339);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.VideoMenuBotton);
            this.Controls.Add(this.SongMenuBotton);
            this.Controls.Add(this.followSingersButton);
            this.Controls.Add(this.FollowArtistsButton);
            this.Controls.Add(this.FollowUsersButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.ChangeDataButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.MainLoginForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChangeDataButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button FollowUsersButton;
        private System.Windows.Forms.Button FollowArtistsButton;
        private System.Windows.Forms.Button followSingersButton;
        private System.Windows.Forms.Button SongMenuBotton;
        private System.Windows.Forms.Button VideoMenuBotton;
        private System.Windows.Forms.Button button1;
    }
}