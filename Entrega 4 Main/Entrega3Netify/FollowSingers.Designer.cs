namespace Entrega3Netify
{
    partial class FollowSingers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FollowSingers));
            this.followSingersView = new System.Windows.Forms.ListView();
            this.followButton = new System.Windows.Forms.Button();
            this.unfollowButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // followSingersView
            // 
            this.followSingersView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.followSingersView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.followSingersView.ForeColor = System.Drawing.Color.White;
            this.followSingersView.HideSelection = false;
            this.followSingersView.Location = new System.Drawing.Point(20, 16);
            this.followSingersView.Margin = new System.Windows.Forms.Padding(2);
            this.followSingersView.Name = "followSingersView";
            this.followSingersView.Size = new System.Drawing.Size(415, 290);
            this.followSingersView.TabIndex = 0;
            this.followSingersView.UseCompatibleStateImageBehavior = false;
            this.followSingersView.SelectedIndexChanged += new System.EventHandler(this.followSingersView_SelectedIndexChanged);
            // 
            // followButton
            // 
            this.followButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("followButton.BackgroundImage")));
            this.followButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.followButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.followButton.ForeColor = System.Drawing.Color.White;
            this.followButton.Location = new System.Drawing.Point(461, 16);
            this.followButton.Margin = new System.Windows.Forms.Padding(2);
            this.followButton.Name = "followButton";
            this.followButton.Size = new System.Drawing.Size(99, 43);
            this.followButton.TabIndex = 1;
            this.followButton.Text = "Seguir";
            this.followButton.UseVisualStyleBackColor = true;
            this.followButton.Click += new System.EventHandler(this.followButton_Click);
            // 
            // unfollowButton
            // 
            this.unfollowButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("unfollowButton.BackgroundImage")));
            this.unfollowButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.unfollowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unfollowButton.ForeColor = System.Drawing.Color.White;
            this.unfollowButton.Location = new System.Drawing.Point(461, 79);
            this.unfollowButton.Margin = new System.Windows.Forms.Padding(2);
            this.unfollowButton.Name = "unfollowButton";
            this.unfollowButton.Size = new System.Drawing.Size(99, 45);
            this.unfollowButton.TabIndex = 2;
            this.unfollowButton.Text = "Dejar de Seguir";
            this.unfollowButton.UseVisualStyleBackColor = true;
            this.unfollowButton.Click += new System.EventHandler(this.unfollowButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitButton.BackgroundImage")));
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(461, 259);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(99, 44);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Salir";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // FollowSingers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(577, 324);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.unfollowButton);
            this.Controls.Add(this.followButton);
            this.Controls.Add(this.followSingersView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FollowSingers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguir Cantantes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FollowSingers_FormClosed);
            this.Load += new System.EventHandler(this.FollowSingers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView followSingersView;
        private System.Windows.Forms.Button followButton;
        private System.Windows.Forms.Button unfollowButton;
        private System.Windows.Forms.Button exitButton;
    }
}