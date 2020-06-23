namespace Entrega3Netify
{
    partial class AlarmForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmForm));
            this.AlarmPanel = new System.Windows.Forms.Panel();
            this.BackButton = new System.Windows.Forms.Button();
            this.StartAlarmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MinuteComboBox = new System.Windows.Forms.ComboBox();
            this.HourComboBox = new System.Windows.Forms.ComboBox();
            this.AlarmTimer = new System.Windows.Forms.Timer(this.components);
            this.AlarmPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AlarmPanel
            // 
            this.AlarmPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AlarmPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.AlarmPanel.Controls.Add(this.BackButton);
            this.AlarmPanel.Controls.Add(this.StartAlarmButton);
            this.AlarmPanel.Controls.Add(this.label1);
            this.AlarmPanel.Controls.Add(this.MinuteComboBox);
            this.AlarmPanel.Controls.Add(this.HourComboBox);
            this.AlarmPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlarmPanel.Location = new System.Drawing.Point(0, 0);
            this.AlarmPanel.Name = "AlarmPanel";
            this.AlarmPanel.Size = new System.Drawing.Size(275, 252);
            this.AlarmPanel.TabIndex = 0;
            // 
            // BackButton
            // 
            this.BackButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackButton.BackgroundImage")));
            this.BackButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(87, 181);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(105, 45);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Salir";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // StartAlarmButton
            // 
            this.StartAlarmButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartAlarmButton.BackgroundImage")));
            this.StartAlarmButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.StartAlarmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartAlarmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartAlarmButton.ForeColor = System.Drawing.Color.White;
            this.StartAlarmButton.Location = new System.Drawing.Point(87, 113);
            this.StartAlarmButton.Name = "StartAlarmButton";
            this.StartAlarmButton.Size = new System.Drawing.Size(105, 45);
            this.StartAlarmButton.TabIndex = 1;
            this.StartAlarmButton.Text = "Iniciar";
            this.StartAlarmButton.UseVisualStyleBackColor = true;
            this.StartAlarmButton.Click += new System.EventHandler(this.StartAlarmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(132, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = ":";
            // 
            // MinuteComboBox
            // 
            this.MinuteComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.MinuteComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinuteComboBox.ForeColor = System.Drawing.Color.White;
            this.MinuteComboBox.FormattingEnabled = true;
            this.MinuteComboBox.IntegralHeight = false;
            this.MinuteComboBox.Location = new System.Drawing.Point(152, 61);
            this.MinuteComboBox.MaxDropDownItems = 10;
            this.MinuteComboBox.Name = "MinuteComboBox";
            this.MinuteComboBox.Size = new System.Drawing.Size(63, 21);
            this.MinuteComboBox.TabIndex = 1;
            // 
            // HourComboBox
            // 
            this.HourComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.HourComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HourComboBox.ForeColor = System.Drawing.Color.White;
            this.HourComboBox.FormattingEnabled = true;
            this.HourComboBox.IntegralHeight = false;
            this.HourComboBox.Location = new System.Drawing.Point(62, 61);
            this.HourComboBox.MaxDropDownItems = 10;
            this.HourComboBox.Name = "HourComboBox";
            this.HourComboBox.Size = new System.Drawing.Size(64, 21);
            this.HourComboBox.TabIndex = 0;
            // 
            // AlarmTimer
            // 
            this.AlarmTimer.Interval = 1000;
            this.AlarmTimer.Tick += new System.EventHandler(this.AlarmTimer_Tick);
            // 
            // AlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 252);
            this.Controls.Add(this.AlarmPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlarmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alarma";
            this.AlarmPanel.ResumeLayout(false);
            this.AlarmPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AlarmPanel;
        private System.Windows.Forms.ComboBox MinuteComboBox;
        private System.Windows.Forms.ComboBox HourComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button StartAlarmButton;
        private System.Windows.Forms.Timer AlarmTimer;
    }
}