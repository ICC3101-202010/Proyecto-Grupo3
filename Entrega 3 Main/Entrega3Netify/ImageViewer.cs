using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3Netify
{
    public partial class ImageViewer : Form
    {
        int contentID;
        public ImageViewer(int contentID)
        {
            this.contentID = contentID;
            InitializeComponent();
        }

        //Todo esto para ver una imagen. 
        private void imageBox1_Click(object sender, EventArgs e)
        {
            //FileName depende del contentID. 
            string fileName = "img" + Convert.ToString(contentID);

            //Deserializo el archivo, este corresponde a un array de bits.

            FileStream stream = new FileStream(fileName, FileMode.Open);
            IFormatter form = new BinaryFormatter();

            //.. deserializo.
            Byte[] imageBytes = form.Deserialize(stream) as Byte[];

            //.. convierto a Bitmap y muestro. 
            Bitmap loadedImage = (Bitmap)((new ImageConverter()).ConvertFrom(imageBytes));
            imageBox1.Image = loadedImage;
            stream.Close();
        }
    }
}
