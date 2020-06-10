using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3Netify
{
    public partial class ImageMenu : Form
    {
        //Todo esto toma como parametro el ID del contenido. 
        int contentID;

        public ImageMenu(int contentID)
        {
            InitializeComponent();
            this.contentID = contentID;
        }

        private void ImageLoaderDialog_FileOk(object sender, CancelEventArgs e)
        {
            return;
        }

        //Todo esto para cargar una imagen. 
        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            //Fijo directorio inicial en disco C y filtros de tipo de archivo. 
            ImageLoaderDialog.InitialDirectory = @"C:\";
            ImageLoaderDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            ImageLoaderDialog.ShowDialog();

            //Cuando selecciono una imagen, guardo como Bitmap. 
            if (ImageLoaderDialog.ShowDialog() == DialogResult.OK)
            {
                //Genero nombre de archivo en el que guardare el bitmap.
                string fileName = "img" + Convert.ToString(contentID);
                string filePath =  Application.StartupPath + @"\" + fileName; 

                //Checkeo si existe. Si existe, borro el archivo anterior y lo reemplazo con el nuevo.


                //Declaro nuevo Bitmap con imagen seleccionada. 
                Bitmap savedImage = new Bitmap(ImageLoaderDialog.FileName);

                //Serializo esto. Nombre del archivo dependera del ContentID (Ej. Si contentID = 1, nombre 
                //de archivo serializado sera img1, si ContentID = 10, nombre sera img10, etc.

                //Primero lo paso a Array de Bytes.

                MemoryStream stream1 = new MemoryStream();
                savedImage.Save(stream1, System.Drawing.Imaging.ImageFormat.Png);
                Byte[] imageBytes = stream1.ToArray();

                        //Debug.WriteLine(filePath);
                        //Debug.WriteLine(File.Exists(filePath));

                //. . en caso de que foto exista, borro archivo anterior. 
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                            //Debug.WriteLine(File.Exists(filePath));
                }

                //. . luego serializo y guardo. 

                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                IFormatter form = new BinaryFormatter();
                form.Serialize(stream, imageBytes);
                stream.Close();

            }
        }

        private void ImageLoaderExitButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }


        //Esto para eliminar una imagen. 
        private void deleteImageButton_Click(object sender, EventArgs e)
        {
            string fileName = "img" + Convert.ToString(contentID);
            string filePath = Application.StartupPath + @"\" + fileName;

            try
            {
                File.Delete(filePath);
                MessageBox.Show("Imagen eliminada con exito.");
            }
            catch (Exception)
            {
                return;
                throw;
            }


        }

        //Codigo para mostrar una imagen. 
        private void viewImageButton_Click(object sender, EventArgs e)
        {
            
            string fileName = "img" + Convert.ToString(contentID);
            string filePath = Application.StartupPath + @"\" + fileName;

            //Primero checkeo si el contentID dado tiene una imagen asociada. 
            if (File.Exists(filePath))
            {
                ImageViewer verImagen = new ImageViewer(contentID);
                verImagen.Show();
            }
            //Si no tiene, le pido al usuario que cargue una.
            else
            {
                MessageBox.Show("Error: Contenido no tiene imagen asociada.");
            }


        }
    }
}
