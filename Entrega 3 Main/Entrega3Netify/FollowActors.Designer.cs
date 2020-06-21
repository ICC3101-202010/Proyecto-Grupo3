namespace Entrega3Netify
{
    partial class FollowActors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FollowActors));
            this.followedActorsView = new System.Windows.Forms.ListView();
            this.followActor = new System.Windows.Forms.Button();
            this.unfollowActor = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // followedActorsView
            // 
            this.followedActorsView.HideSelection = false;
            this.followedActorsView.Location = new System.Drawing.Point(20, 14);
            this.followedActorsView.Margin = new System.Windows.Forms.Padding(2);
            this.followedActorsView.Name = "followedActorsView";
            this.followedActorsView.Size = new System.Drawing.Size(417, 303);
            this.followedActorsView.TabIndex = 0;
            this.followedActorsView.UseCompatibleStateImageBehavior = false;
            this.followedActorsView.SelectedIndexChanged += new System.EventHandler(this.followedActorsView_SelectedIndexChanged);
            // 
            // followActor
            // 
            this.followActor.Location = new System.Drawing.Point(455, 14);
            this.followActor.Margin = new System.Windows.Forms.Padding(2);
            this.followActor.Name = "followActor";
            this.followActor.Size = new System.Drawing.Size(97, 42);
            this.followActor.TabIndex = 1;
            this.followActor.Text = "Seguir";
            this.followActor.UseVisualStyleBackColor = true;
            this.followActor.Click += new System.EventHandler(this.followActor_Click);
            // 
            // unfollowActor
            // 
            this.unfollowActor.Location = new System.Drawing.Point(455, 67);
            this.unfollowActor.Margin = new System.Windows.Forms.Padding(2);
            this.unfollowActor.Name = "unfollowActor";
            this.unfollowActor.Size = new System.Drawing.Size(97, 44);
            this.unfollowActor.TabIndex = 2;
            this.unfollowActor.Text = "Dejar de Seguir";
            this.unfollowActor.UseVisualStyleBackColor = true;
            this.unfollowActor.Click += new System.EventHandler(this.unfollowActor_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(455, 272);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(97, 44);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Salir";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // FollowActors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 336);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.unfollowActor);
            this.Controls.Add(this.followActor);
            this.Controls.Add(this.followedActorsView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FollowActors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguir Actores";
            this.Load += new System.EventHandler(this.FollowActors_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView followedActorsView;
        private System.Windows.Forms.Button followActor;
        private System.Windows.Forms.Button unfollowActor;
        private System.Windows.Forms.Button exitButton;
    }
}