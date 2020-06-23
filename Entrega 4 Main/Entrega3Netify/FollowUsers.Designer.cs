namespace Entrega3Netify
{
    partial class FollowUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FollowUsers));
            this.FollowedUsersListView = new System.Windows.Forms.ListView();
            this.followSelected = new System.Windows.Forms.Button();
            this.unfollowSelected = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FollowedUsersListView
            // 
            this.FollowedUsersListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.FollowedUsersListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FollowedUsersListView.ForeColor = System.Drawing.Color.White;
            this.FollowedUsersListView.HideSelection = false;
            this.FollowedUsersListView.Location = new System.Drawing.Point(15, 8);
            this.FollowedUsersListView.Margin = new System.Windows.Forms.Padding(2);
            this.FollowedUsersListView.Name = "FollowedUsersListView";
            this.FollowedUsersListView.Size = new System.Drawing.Size(391, 274);
            this.FollowedUsersListView.TabIndex = 0;
            this.FollowedUsersListView.UseCompatibleStateImageBehavior = false;
            this.FollowedUsersListView.SelectedIndexChanged += new System.EventHandler(this.FollowedUsersListView_SelectedIndexChanged);
            // 
            // followSelected
            // 
            this.followSelected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("followSelected.BackgroundImage")));
            this.followSelected.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.followSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.followSelected.Location = new System.Drawing.Point(423, 17);
            this.followSelected.Margin = new System.Windows.Forms.Padding(2);
            this.followSelected.Name = "followSelected";
            this.followSelected.Size = new System.Drawing.Size(79, 38);
            this.followSelected.TabIndex = 1;
            this.followSelected.Text = "Seguir";
            this.followSelected.UseVisualStyleBackColor = true;
            this.followSelected.Click += new System.EventHandler(this.followSelected_Click);
            // 
            // unfollowSelected
            // 
            this.unfollowSelected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("unfollowSelected.BackgroundImage")));
            this.unfollowSelected.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.unfollowSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unfollowSelected.Location = new System.Drawing.Point(423, 69);
            this.unfollowSelected.Margin = new System.Windows.Forms.Padding(2);
            this.unfollowSelected.Name = "unfollowSelected";
            this.unfollowSelected.Size = new System.Drawing.Size(79, 38);
            this.unfollowSelected.TabIndex = 2;
            this.unfollowSelected.Text = "Dejar de seguir";
            this.unfollowSelected.UseVisualStyleBackColor = true;
            this.unfollowSelected.Click += new System.EventHandler(this.unfollowSelected_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitButton.BackgroundImage")));
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(423, 240);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(79, 40);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Salir";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // FollowUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(533, 326);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.unfollowSelected);
            this.Controls.Add(this.followSelected);
            this.Controls.Add(this.FollowedUsersListView);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FollowUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguir Usuarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FollowUsers_FormClosed);
            this.Load += new System.EventHandler(this.FollowUsers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView FollowedUsersListView;
        private System.Windows.Forms.Button followSelected;
        private System.Windows.Forms.Button unfollowSelected;
        private System.Windows.Forms.Button exitButton;
    }
}