using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3Netify
{
    public partial class AddVideoToForm : Form
    {
        List<NPerson> Users;
        NPerson Current;
        Video Video;

        public AddVideoToForm(List<NPerson> users, NPerson current, Video video)
        {
            InitializeComponent();
            this.Users = users;
            this.Current = current;
            this.Video = video;
        }

        private void atrasbtn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newplstbtn_Click(object sender, EventArgs e)
        { 
            comboBox1.Visible = false;
            label1.Visible = true;
            textBox1.Clear();
            textBox1.Visible = true;
            checkBox1.Visible = true;
        }

        private void playlistexistentebtn_Click(object sender, EventArgs e)
        {
            checkBox1.Visible = false;
            textBox1.Visible = false;
            label1.Visible = true;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox1.Visible = true;
            if (Current.VideosPublicos.Count != 0)
            {
                foreach (VideoPlaylist playlist in Current.VideosPublicos)
                {
                    comboBox1.Items.Add(playlist.name);
                }
            }
            if (Current.VideosPrivados.Count != 0)
            {
                foreach (VideoPlaylist playlist in Current.VideosPrivados)
                {
                    comboBox1.Items.Add(playlist.name);
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textnombreplst = textBox1.Text;
            string combonombreplst = comboBox1.Text;
            bool check = checkBox1.Checked;

            if (textBox1.Text.Count() != 0)
            {
                Gestor.SaveVideoOnPlaylistAndUser(Users, Current, Video, textnombreplst , check);
                MessageBox.Show("Playlist creada exitosamente");
                this.Close();
            }
            else if (comboBox1.Text.Count() != 0)
            {
                Gestor.CreateSaveVideoOnPlaylistAndUser(Users, Current, Video, combonombreplst);
                MessageBox.Show("Video agregado exitosamente");
                this.Close();
            }
        }

        private void AddVideoToForm_Load(object sender, EventArgs e)
        {

        }
    }
}
