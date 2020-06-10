namespace Entrega3Netify
{
    partial class ImageMenu
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
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.ImageLoaderDialog = new System.Windows.Forms.OpenFileDialog();
            this.ImageLoaderExitButton = new System.Windows.Forms.Button();
            this.deleteImageButton = new System.Windows.Forms.Button();
            this.viewImageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(12, 38);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(211, 103);
            this.LoadImageButton.TabIndex = 0;
            this.LoadImageButton.Text = "Cargar Imagen";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
            // 
            // ImageLoaderDialog
            // 
            this.ImageLoaderDialog.FileName = "ImageLoaderDialog";
            this.ImageLoaderDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ImageLoaderDialog_FileOk);
            // 
            // ImageLoaderExitButton
            // 
            this.ImageLoaderExitButton.Location = new System.Drawing.Point(740, 38);
            this.ImageLoaderExitButton.Name = "ImageLoaderExitButton";
            this.ImageLoaderExitButton.Size = new System.Drawing.Size(211, 103);
            this.ImageLoaderExitButton.TabIndex = 1;
            this.ImageLoaderExitButton.Text = "Salir";
            this.ImageLoaderExitButton.UseVisualStyleBackColor = true;
            this.ImageLoaderExitButton.Click += new System.EventHandler(this.ImageLoaderExitButton_Click);
            // 
            // deleteImageButton
            // 
            this.deleteImageButton.Location = new System.Drawing.Point(496, 38);
            this.deleteImageButton.Name = "deleteImageButton";
            this.deleteImageButton.Size = new System.Drawing.Size(211, 103);
            this.deleteImageButton.TabIndex = 2;
            this.deleteImageButton.Text = "Eliminar Imagen";
            this.deleteImageButton.UseVisualStyleBackColor = true;
            this.deleteImageButton.Click += new System.EventHandler(this.deleteImageButton_Click);
            // 
            // viewImageButton
            // 
            this.viewImageButton.Location = new System.Drawing.Point(259, 38);
            this.viewImageButton.Name = "viewImageButton";
            this.viewImageButton.Size = new System.Drawing.Size(211, 103);
            this.viewImageButton.TabIndex = 3;
            this.viewImageButton.Text = "Ver Imagen";
            this.viewImageButton.UseVisualStyleBackColor = true;
            this.viewImageButton.Click += new System.EventHandler(this.viewImageButton_Click);
            // 
            // ImageMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 198);
            this.Controls.Add(this.viewImageButton);
            this.Controls.Add(this.deleteImageButton);
            this.Controls.Add(this.ImageLoaderExitButton);
            this.Controls.Add(this.LoadImageButton);
            this.Name = "ImageMenu";
            this.Text = "Menu Imagenes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.OpenFileDialog ImageLoaderDialog;
        private System.Windows.Forms.Button ImageLoaderExitButton;
        private System.Windows.Forms.Button deleteImageButton;
        private System.Windows.Forms.Button viewImageButton;
    }
}