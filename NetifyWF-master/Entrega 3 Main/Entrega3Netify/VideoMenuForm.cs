using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MediaInfo;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text.RegularExpressions;

namespace Entrega3Netify
{
    public partial class VideoMenuForm : Form
    {
        NPerson CurrentUser;
        List<NPerson> Users;
        public VideoMenuForm(List<NPerson> users, NPerson currentUser)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            Users = users;
        }

        private void VideoMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainVideoPannel.Visible = false;
            ImportVideoPannel.Visible = true;
            Nametextbox.Clear();
            genretextBox.Clear();
            categorytextBox.Clear();
            directortextBox.Clear();
            descriptiontextBox.Clear();
            resolutiontextBox.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ImportVideoPannel.Visible = false;
            MainVideoPannel.Visible = true;
        }

        private void atrasbtn_Click(object sender, EventArgs e)
        {
            ImportVideoPannel.Visible = false;
            MainVideoPannel.Visible = true;
        }

        private void seleccionarvideobtn_Click(object sender, EventArgs e)
        {
            if (ImportarVideo.ShowDialog() == DialogResult.OK)
            {
                MediaInfo.MediaInfo mi = new MediaInfo.MediaInfo();
                mi.Open(ImportarVideo.FileName);
                var Width = int.Parse(mi.Get(StreamKind.Video, 0, "Width"));

                if (Width == 1920)
                {
                    resolutiontextBox.Text = "1080p";
                }
                else if (Width == 1280)
                {
                    resolutiontextBox.Text = "720p";
                }
                else if (Width == 640)
                {
                    resolutiontextBox.Text = "480p";
                }
                else if (Width == 2560)
                {
                    resolutiontextBox.Text = "1440p";
                }
                mi.Close();
                Nametextbox.Text = ImportarVideo.FileName.Split('\\').Last().Split('.').First();
            }
        }

        private void importfinishbtn_Click(object sender, EventArgs e)
        {
            string name = Nametextbox.Text;
            string genre = genretextBox.Text;
            string category = categorytextBox.Text;
            string director = directortextBox.Text;
            string description = descriptiontextBox.Text;
            string resolution = resolutiontextBox.Text;
            string path = ImportarVideo.FileName;

            Gestor.SaveVideoOnUser(Users, CurrentUser, name, genre, category, director, description, resolution, path);

            ImportVideoPannel.Visible = false;
            MainVideoPannel.Visible = true;

        }

        private void ListVideosbtn_Click(object sender, EventArgs e)
        {
            MainVideoPannel.Visible = false;
            ImportedListViewPannel.Visible = true;
            listView1.Items.Clear();

            if (CurrentUser.VideosImportados.Count != 0)
            {
                foreach (Video video in CurrentUser.VideosImportados)
                {
                    ListViewItem item = new ListViewItem(video.name);
                    item.SubItems.Add(video.genre);
                    item.SubItems.Add(video.category);
                    item.SubItems.Add(video.director);
                    item.SubItems.Add(video.resolution);
                    item.SubItems.Add(video.score.ToString());
                    listView1.Items.Add(item);

                }
            }
        }

        private void followedActorsView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void atrasbtn2_Click(object sender, EventArgs e)
        {
            ImportedListViewPannel.Visible = false;
            MainVideoPannel.Visible = true;
        }

        private void videoselectbtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string name = listView1.SelectedItems[0].Text;

                foreach (Video video in CurrentUser.VideosImportados)
                {
                    if (video.name == name)
                    {
                        Process.Start(video.path);
                        break;
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void playlistbtn_Click(object sender, EventArgs e)
        {
            MainVideoPannel.Visible = false;
            MisplaylistPannel.Visible = true;
            
            listView2.Items.Clear();
            listView2.Groups.Clear();

            if (CurrentUser.VideosPublicos.Count != 0)
            {
                foreach (VideoPlaylist playlist in CurrentUser.VideosPublicos)
                {
                    ListViewGroup group = new ListViewGroup(playlist.name, HorizontalAlignment.Center);
                    foreach (Video video in playlist.ActualPlaylist)
                    {
                        ListViewItem item = new ListViewItem(video.name, group);
                        item.SubItems.Add(video.genre);
                        item.SubItems.Add(video.category);
                        item.SubItems.Add(video.director);
                        item.SubItems.Add(video.resolution);
                        item.SubItems.Add(video.score.ToString());

                        listView2.Items.Add(item);
                    }
                    listView2.Groups.Add(group);
                }
            }
            if (CurrentUser.VideosPrivados.Count != 0)
            {
                foreach (VideoPlaylist playlist in CurrentUser.VideosPrivados)
                {
                    ListViewGroup group = new ListViewGroup(playlist.name, HorizontalAlignment.Center);
                    foreach (Video video in playlist.ActualPlaylist)
                    {
                        ListViewItem item = new ListViewItem(video.name, group);
                        item.SubItems.Add(video.genre);
                        item.SubItems.Add(video.category);
                        item.SubItems.Add(video.director);
                        item.SubItems.Add(video.resolution);
                        item.SubItems.Add(video.score.ToString());

                        listView2.Items.Add(item);
                    }
                    listView2.Groups.Add(group);
                }
            }
        }

        private void favoritevideobtn_Click(object sender, EventArgs e)
        {
            MainVideoPannel.Visible = false;
            favoritespannel.Visible = true;
            listView3.Items.Clear();
            
            foreach (Video video in CurrentUser.VideosFavoritos)
            {
                ListViewItem item = new ListViewItem(video.name);
                item.SubItems.Add(video.genre);
                item.SubItems.Add(video.category);
                item.SubItems.Add(video.director);
                item.SubItems.Add(video.resolution);
                item.SubItems.Add(video.score.ToString());
                listView3.Items.Add(item);
                
            }
        }

        private void searchvideobtn_Click(object sender, EventArgs e)
        {
            MainVideoPannel.Visible = false;
            searchpannel.Visible = true;
            listView4.Items.Clear();
        }

        private void addplaylistbtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string name = listView1.SelectedItems[0].Text;

                foreach (Video video in CurrentUser.VideosImportados)
                {
                    if (video.name == name)
                    {
                        AddVideoToForm add = new AddVideoToForm(Users,CurrentUser, video);
                        add.Show();
                        break;
                    }
                }
            }
        }

        private void atrasmisplaylistbtn_Click(object sender, EventArgs e)
        {
            MainVideoPannel.Visible = true;
            MisplaylistPannel.Visible = false;
        }

        private void atrassearchbtn_Click(object sender, EventArgs e)
        {
            MainVideoPannel.Visible = true;
            searchpannel.Visible = false;
        }

        private void atrasfavoritebtn_Click(object sender, EventArgs e)
        {
            MainVideoPannel.Visible = true;
            favoritespannel.Visible = false;
        }

        private void agregarfavoritebtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string name = listView1.SelectedItems[0].Text;

                foreach (Video video in CurrentUser.VideosImportados)
                {
                    if (video.name == name)
                    {
                        CurrentUser.VideosFavoritos.Add(video);
                        Gestor.SaveFavoriteUser(Users, CurrentUser);
                        MessageBox.Show("Video agregado a favorito con exito");
                        break;
                    }
                }
            }
        }

        private void Reproducirplstbtn_Click(object sender, EventArgs e)
        {
            
        }


        private void reproducirfavorite_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count != 0)
            {
                string name = listView3.SelectedItems[0].Text;
                foreach (Video video in CurrentUser.VideosFavoritos)
                {
                    if (name == video.name)
                    {
                        Process.Start(video.path);
                    }

                }
            }
        }

        private void eliminarfavbtn_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count != 0)
            {
                string name = listView3.SelectedItems[0].Text;
                foreach (Video video in CurrentUser.VideosFavoritos)
                {
                    if (name == video.name)
                    {
                        CurrentUser.VideosFavoritos.Remove(video);

                        Gestor.SaveFavoriteUser(Users, CurrentUser);
                        MessageBox.Show("Video Removido con Exito");
                        break;
                    }


                }
            }
            listView3.Items.Clear();

            foreach (Video video in CurrentUser.VideosFavoritos)
            {
                ListViewItem item = new ListViewItem(video.name);
                item.SubItems.Add(video.genre);
                item.SubItems.Add(video.category);
                item.SubItems.Add(video.director);
                item.SubItems.Add(video.resolution);
                item.SubItems.Add(video.score.ToString());
                listView3.Items.Add(item);
            }
        }

        private void eliminarimportbtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string name = listView1.SelectedItems[0].Text;
                foreach (Video video in CurrentUser.VideosImportados)
                {
                    if (name == video.name)
                    {
                        CurrentUser.VideosImportados.Remove(video);
                        foreach(Video video1 in CurrentUser.VideosFavoritos)
                        {
                            if(name == video.name)
                            {
                                CurrentUser.VideosFavoritos.Remove(video);
                                break;
                            }
                        }
                        foreach (VideoPlaylist plst in CurrentUser.VideosPublicos)
                        {
                            foreach (Video video2 in plst.ActualPlaylist)
                            {
                                if (video2.name == name)
                                {
                                    plst.ActualPlaylist.Remove(video2);
                                    break;
                                }
                            }
                        }
                        foreach (VideoPlaylist plst in CurrentUser.VideosPrivados)
                        {
                            foreach (Video video2 in plst.ActualPlaylist)
                            {
                                if (video2.name == name)
                                {
                                    plst.ActualPlaylist.Remove(video2);
                                    break;
                                }
                            }
                        }

                        Gestor.SaveFavoriteUser(Users, CurrentUser);
                        MessageBox.Show("Video Removido con Exito");
                        listView1.Items.Clear();
                        foreach (Video video4 in CurrentUser.VideosImportados)
                        {
                            ListViewItem item = new ListViewItem(video4.name);
                            item.SubItems.Add(video4.genre);
                            item.SubItems.Add(video4.category);
                            item.SubItems.Add(video4.director);
                            item.SubItems.Add(video4.resolution);
                            item.SubItems.Add(video4.score.ToString());
                            listView1.Items.Add(item);
                        }
                        break;
                    }
                }
            }
        }

        private void eliminarcancionplstbtn_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count != 0)
            {
                string name = listView2.SelectedItems[0].Text;
                string plstname = listView2.SelectedItems[0].Group.Header;
                
                foreach (VideoPlaylist plst in CurrentUser.VideosPublicos)
                {
                    if (plstname == plst.name)
                    {
                        foreach(Video video in plst.ActualPlaylist)
                        {
                            if (name == video.name)
                            {
                                plst.ActualPlaylist.Remove(video);
                                break;
                            }
                        }

                        Gestor.SaveFavoriteUser(Users, CurrentUser);
                        MessageBox.Show("Video Removido con Exito");
                        break;
                    }
                }
                foreach (VideoPlaylist plst in CurrentUser.VideosPrivados)
                {
                    if (plstname == plst.name)
                    {
                        foreach (Video video in plst.ActualPlaylist)
                        {
                            if (name == video.name)
                            {
                                plst.ActualPlaylist.Remove(video);
                                break;
                            }
                        }

                        Gestor.SaveFavoriteUser(Users, CurrentUser);
                        MessageBox.Show("Video Removido con Exito");
                        break;
                    }
                }

            }
            listView2.Items.Clear();

            if (CurrentUser.VideosPublicos.Count != 0)
            {
                foreach (VideoPlaylist playlist in CurrentUser.VideosPublicos)
                {
                    ListViewGroup group = new ListViewGroup(playlist.name, HorizontalAlignment.Center);
                    foreach (Video video in playlist.ActualPlaylist)
                    {
                        ListViewItem item = new ListViewItem(video.name, group);
                        item.SubItems.Add(video.genre);
                        item.SubItems.Add(video.category);
                        item.SubItems.Add(video.director);
                        item.SubItems.Add(video.resolution);
                        item.SubItems.Add(video.score.ToString());

                        listView2.Items.Add(item);
                    }
                    listView2.Groups.Add(group);
                }
            }
            if (CurrentUser.VideosPrivados.Count != 0)
            {
                foreach (VideoPlaylist playlist in CurrentUser.VideosPrivados)
                {
                    ListViewGroup group = new ListViewGroup(playlist.name, HorizontalAlignment.Center);
                    foreach (Video video in playlist.ActualPlaylist)
                    {
                        ListViewItem item = new ListViewItem(video.name, group);
                        item.SubItems.Add(video.genre);
                        item.SubItems.Add(video.category);
                        item.SubItems.Add(video.director);
                        item.SubItems.Add(video.resolution);
                        item.SubItems.Add(video.score.ToString());

                        listView2.Items.Add(item);
                    }
                    listView2.Groups.Add(group);
                }
            }
        }

        private void eliminarplstbtn_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count != 0)
            {
                string plstname = listView2.SelectedItems[0].Group.Header;

                foreach (VideoPlaylist plst in CurrentUser.VideosPublicos)
                {
                    if (plstname == plst.name)
                    {
                        CurrentUser.VideosPublicos.Remove(plst);

                        Gestor.SaveFavoriteUser(Users, CurrentUser);
                        MessageBox.Show("Playlist Removida con Exito");
                        break;
                    }
                }
                foreach (VideoPlaylist plst in CurrentUser.VideosPrivados)
                {
                    if (plstname == plst.name)
                    {
                        CurrentUser.VideosPrivados.Remove(plst);

                        Gestor.SaveFavoriteUser(Users, CurrentUser);
                        MessageBox.Show("Playlist Removida con Exito");
                        break;
                    }
                }

            }
            listView2.Items.Clear();

            if (CurrentUser.VideosPublicos.Count != 0)
            {
                foreach (VideoPlaylist playlist in CurrentUser.VideosPublicos)
                {
                    ListViewGroup group = new ListViewGroup(playlist.name, HorizontalAlignment.Center);
                    foreach (Video video in playlist.ActualPlaylist)
                    {
                        ListViewItem item = new ListViewItem(video.name, group);
                        item.SubItems.Add(video.genre);
                        item.SubItems.Add(video.category);
                        item.SubItems.Add(video.director);
                        item.SubItems.Add(video.resolution);
                        item.SubItems.Add(video.score.ToString());

                        listView2.Items.Add(item);
                    }
                    listView2.Groups.Add(group);
                }
            }
            if (CurrentUser.VideosPrivados.Count != 0)
            {
                foreach (VideoPlaylist playlist in CurrentUser.VideosPrivados)
                {
                    ListViewGroup group = new ListViewGroup(playlist.name, HorizontalAlignment.Center);
                    foreach (Video video in playlist.ActualPlaylist)
                    {
                        ListViewItem item = new ListViewItem(video.name, group);
                        item.SubItems.Add(video.genre);
                        item.SubItems.Add(video.category);
                        item.SubItems.Add(video.director);
                        item.SubItems.Add(video.resolution);
                        item.SubItems.Add(video.score.ToString());

                        listView2.Items.Add(item);
                    }
                    listView2.Groups.Add(group);
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void reproducirsearchbtn_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count != 0)
            {
                string name = listView4.SelectedItems[0].Text;

                foreach (Video video in CurrentUser.VideosImportados)
                {
                    if (name == video.name)
                    {
                        Process.Start(video.path);
                        break;
                    }
                }
            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            listView4.Items.Clear();
            string name1 = searchnametextbox.Text;
            string genre1 = searchgenretextbox.Text;
            string category1 = searchcategorytextbox.Text;
            string director1 = searchdirectortextbox.Text;

            if (String.IsNullOrEmpty(searchresolutiontextbox.Text) == false)
            {
                string resolution = searchresolutiontextbox.Text;
                if (resolution != "720p" && resolution != "480p" && resolution != "1080p" && resolution != "1440p")
                {
                    MessageBox.Show("Resolucion no valida (480p,720p, 1080p, 1440p)");
                    return;
                }
            }
            string resolution1 = searchresolutiontextbox.Text;
            string score1 = searchscoretextbox.Text;

            try
            {
                if (Convert.ToDouble(score1) > 5.0 | Convert.ToDouble(score1) < 0.0)
                {
                    MessageBox.Show("Puntaje no valido (numero entre 0.0 y 5.0)");
                    return;
                }
            }
            catch
            {

            }

            List<Video> listabuscada = new List<Video>();
            
            foreach (Video video in CurrentUser.VideosImportados)
            {
                if (String.IsNullOrEmpty(searchnametextbox.Text) == false)
                {
                    if (Regex.IsMatch(video.name, name1))
                    {
                        listabuscada.Add(video);
                    }
                }
                
                if (String.IsNullOrEmpty(searchgenretextbox.Text) == false)
                {
                    if (Regex.IsMatch(video.genre, genre1))
                    {
                        listabuscada.Add(video);
                    }
                }
               
                if (String.IsNullOrEmpty(searchcategorytextbox.Text) == false)
                {
                    if (Regex.IsMatch(video.category, category1))
                    {
                        listabuscada.Add(video);
                    }
                }
               
                if (String.IsNullOrEmpty(searchdirectortextbox.Text) == false)
                {
                    if (Regex.IsMatch(video.director, director1))
                    {
                        listabuscada.Add(video);
                    }
                }
               
                if (String.IsNullOrEmpty(searchresolutiontextbox.Text) == false)
                {
                    if (Regex.IsMatch(video.resolution, resolution1))
                    {
                        listabuscada.Add(video);
                    }
                }
                
                if (String.IsNullOrEmpty(searchscoretextbox.Text) == false)
                {
                    if (Regex.IsMatch(video.score.ToString(), score1))
                    {
                        listabuscada.Add(video);
                    }
                }

            }


            foreach (Video video in listabuscada)
            {
                ListViewItem item = new ListViewItem(video.name);
                item.SubItems.Add(video.genre);
                item.SubItems.Add(video.category);
                item.SubItems.Add(video.director);
                item.SubItems.Add(video.resolution);
                item.SubItems.Add(video.score.ToString());
                listView4.Items.Add(item);
            }

            listabuscada.Clear();

        }
    }
}
