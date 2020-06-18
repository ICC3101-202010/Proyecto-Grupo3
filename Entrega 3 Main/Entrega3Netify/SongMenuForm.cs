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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Entrega3Netify
{
    public partial class SongMenuForm : Form
    {
        int butonpos = 0 , buton2pos = 0;
        bool privlist = false;
        List<Song> nplaylist = new List<Song>();
        public NPerson CurrentUser { get; set; }
        List<NPerson> Users;
        List<Panel> stackpanels = new List<Panel>();        Dictionary<string, Panel> panels = new Dictionary<string, Panel>();
        List<Song> def = new List<Song> { new Song("Birds", "A Head Full of Dreams", "Coldplay", "Alternativa/Independiente", "2016", ".mp4"),
            new Song("Circles","Circles","Post Malone","Pop Hip-hop/rap","2019",".wav"),
            new Song("Entre Canibales","Cancion Animal","Soda Stereo","Rock","1990",".mp3"),
            new Song("Fans","Because of the Times","Kings of Leon","Alternativa/Independiente Hard Rock","2007",".mp4"),
            new Song("Salad Days","Salad Days","Mac Demarco","Soft Rock Lo-fi Indie","2014",".mp3")
            };
        public delegate void SongPlayerEventHandler(object source, SongPlayerEventArgs args);
        public delegate void SearcherEventHandler(object source, SearcherPlayerEventArgs args);
        public event SongPlayerEventHandler PlayButtonClicked;
        public event SearcherEventHandler SearchButtonClicked;
        public event EventHandler<SongPlayerEventArgs> StopButtonClicked;
        public event EventHandler<SongPlayerEventArgs> NextSongButtonClicked;
        public event EventHandler<SongPlayerEventArgs> PreviousSongButtonClicked;
        public event EventHandler<SongPlayerEventArgs> VolumeTrackBarUsed;
        public event EventHandler<SongPlayerEventArgs> SongTimeTrackBarClicked;
        public event EventHandler<SongPlayerEventArgs> ImportedButtonClicked;
        public event EventHandler<SongPlayerEventArgs> FormClosedd;
        public event EventHandler<SongPlayerEventArgs> PlaylistButtonClicked;

        public void ShowLastPanel()
        {
            foreach (Panel panel in panels.Values)
            {
                if (panel != stackpanels.Last())
                {
                    panel.Visible = false;
                }
                else
                {
                    panel.Visible = true;
                }
            }
        }

        private void CreateDynamicButton(int y, string text, string buttoname, Song song)
        {
            Button dynamicButton = new Button();
            dynamicButton.Height = 30;

            dynamicButton.Width = 88;

            dynamicButton.Location = new Point(3, y);

            dynamicButton.AutoSize = true;

            dynamicButton.Text = text;

            dynamicButton.Name = buttoname;

            dynamicButton.Font = new Font("Microsoft Sans Serif", 8);
            dynamicButton.Click += (sender, e) => DynamicButton_Click(song, sender, e);
            SSFLPanel.Controls.Add(dynamicButton);
        }

        private void CreateDynamicButtonpl(int y, string text, string buttoname, List<Song> playlist)
        {
            Button dynamicButtonpl = new Button();
            dynamicButtonpl.Height = 30;

            dynamicButtonpl.Width = 88;

            dynamicButtonpl.Location = new Point(3, y);

            dynamicButtonpl.AutoSize = true;

            dynamicButtonpl.Text = text;

            dynamicButtonpl.Name = buttoname;

            dynamicButtonpl.Font = new Font("Microsoft Sans Serif", 8);
            dynamicButtonpl.Click += (sender, e) => DynamicButtonpl_Click(playlist , sender, e);
            PlaylistsFlowLayoutPanel.Controls.Add(dynamicButtonpl);
        }

        public void ShowThisSongs(List<Song> songs)
        {
            SSFLPanel.Controls.Clear();
            int y = 3;
            foreach (Song s in songs)
            {
                CreateDynamicButton(y, s.Name + "-" + s.Album + "-" + s.Artists, s.Name + "Button", s);
                y += 69;
            }
        }

        public SongMenuForm(List<NPerson> users,NPerson currentUser)
        {
            InitializeComponent();
            panels.Add("SSFLPanel", SSFLPanel);
            panels.Add("ImportSongPanel", ImportSongPanel);
            panels.Add("PlaylistCreatorPanel",PlaylistCreatorPanel);
            panels.Add("DeleteSongPanel", DeleteSongPanel);
            panels.Add("DeletePlaylistPanel",DeletePlaylistPanel);
            panels.Add("RemoveFromPLPanel",RemoveFromPLPanel);
            panels.Add("FinalRemovePanel",FinalRemovePanel);
            panels.Add("AddSongPanel",AddSongPanel);
            panels.Add("FinalAddSongPanel",FinalAddSongPanel);
            stackpanels.Add(panels["SSFLPanel"]);
            ShowLastPanel();
            CurrentUser = currentUser;
            Users = users;
            VolumeTrackBar.Value = 5;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Songs.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, def);
            stream.Close();
            Stream des = new FileStream("Songs.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Song> titles = (List<Song>)formatter.Deserialize(des);
            des.Close();
            int y = 3, y2 = 3;
            foreach (Song s in titles)
            {
                CreateDynamicButton(y, s.Name + "-" + s.Album + "-" + s.Artists, s.Name + "Button", s);
                SongsComboBox.Items.Add(s.Name);
                y += 69;
            }
            foreach (Song s in CurrentUser.Importedsongs)
            {
                def.Add(s);
                CreateDynamicButton(y, s.Name + "-" + s.Album + "-" + s.Artists, s.Name + "Button", s);
                SongsComboBox.Items.Add(s.Name);
                y += 69;
            }
            CreateDynamicButtonpl(y2, "Favoritos", "Favoritos", CurrentUser.FavoriteSongs);
            y2 += 69;
            CreateDynamicButtonpl(y2, "Lista Canciones", "Lista Canciones", def);
            y2 += 69;
            foreach (SongPlaylist playlist in currentUser.CancionesPrivadas)
            {
                CreateDynamicButtonpl(y2,playlist.Name,playlist.Name,playlist.ActualPlaylist);
                y2 += 69;
            }
            foreach (SongPlaylist playlist in currentUser.CancionesPublicas)
            {
                CreateDynamicButtonpl(y2, playlist.Name, playlist.Name, playlist.ActualPlaylist);
                y2 += 69;
            }
            butonpos = y;
            buton2pos = y2;
        }

        private void DynamicButton_Click(Song song, object sender, EventArgs e)
        {
            OnPlayButtonClicked(song, SongTimeTimer, SongTimeProgressBar, SongTimeTrackBar);

        }

        private void DynamicButtonpl_Click(List<Song> playlist, object sender, EventArgs e)
        {
            SSFLPanel.Controls.Clear();
            int y = 3;
            if(playlist!=null)
            {
                foreach (Song song in playlist)
                {
                    CreateDynamicButton(y, song.Name + "-" + song.Album + "-" + song.Artists, song.Name + "Button", song);
                    y += 69;
                }
            }
            SSFLPanel.BringToFront();
            SSFLPanel.Show();
            OnPlaylistButtonClicked(playlist);
        }
        protected virtual void OnPlaylistButtonClicked(List<Song> playlist)
        {
            if (PlaylistButtonClicked != null)
            {
                PlaylistButtonClicked(this, new SongPlayerEventArgs { Actualplaylist = playlist });
            }
        }

        protected virtual void OnPlayButtonClicked(Song song, Timer timer, ProgressBar progressBar, TrackBar trackBar, double time = 0)
        {
            if (PlayButtonClicked != null)
            {
                PlayButtonClicked(this, new SongPlayerEventArgs() { Actualsong = song, Songtimer = timer, Songprogressbar = progressBar, HidenTrackbar = trackBar });
            }
        }
        
        private void SongMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            OnStopButtonClicked(SongTimeTimer);
        }

        protected virtual void OnStopButtonClicked(Timer timer)
        {
            if (StopButtonClicked != null)
            {
                StopButtonClicked(this, new SongPlayerEventArgs() { Songtimer = timer });
            }
        }

        private void NextSongButton_Click(object sender, EventArgs e)
        {
            OnNextSongClicked(SongTimeTimer, SongTimeProgressBar, SongTimeTrackBar);
        }

        protected virtual void OnNextSongClicked(Timer timer, ProgressBar progressBar, TrackBar trackBar)
        {
            if (NextSongButtonClicked != null)
            {
                NextSongButtonClicked(this, new SongPlayerEventArgs() { Songtimer = timer, Songprogressbar = progressBar, HidenTrackbar = trackBar });
            }
        }

        private void PreviouSongButton_Click(object sender, EventArgs e)
        {
            OnPreviousSongButtonClicked(SongTimeTimer, SongTimeProgressBar, SongTimeTrackBar);
        }
       
        protected virtual void OnPreviousSongButtonClicked(Timer timer, ProgressBar progressBar, TrackBar trackBar)
        {
            if (PreviousSongButtonClicked != null)
            {
                PreviousSongButtonClicked(this, new SongPlayerEventArgs() { Songtimer = timer, Songprogressbar = progressBar, HidenTrackbar = trackBar });
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string search = SearchTextBox.Text;
            OnSearchButtonClicked(search);
        }

        protected virtual void OnSearchButtonClicked(string input)
        {
            if (SearchButtonClicked != null)
            {
                SearchButtonClicked(this, new SearcherPlayerEventArgs() { input = input });
            }
        }

        private void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            int newvolume = VolumeTrackBar.Value;
            VolumeLabel.Text = Convert.ToString(newvolume);
            VolumeLabel.Visible = true;
            OnVolumeTrackBarUsed(newvolume);
        }

        protected virtual void OnVolumeTrackBarUsed(int volume)
        {
            if (VolumeTrackBarUsed != null)
            {
                VolumeTrackBarUsed(this, new SongPlayerEventArgs() { Volume = volume });
            }
        }

        private void SongTimeTimer_Tick(object sender, EventArgs e)
        {
            if (SongTimeProgressBar.Value == SongTimeProgressBar.Maximum)
                SongTimeTimer.Stop();
            int tiempo = SongTimeProgressBar.Value;
            TimeSpan time = TimeSpan.FromSeconds(tiempo);
            SongTimeProgressBar.Increment(1);
            SongTimeLabel.Text = time.ToString("mm':'ss");
        }

        private void SongTimeTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            double newtime = SongTimeTrackBar.Value;
            OnSongTimeTrackBarClicked(newtime, SongTimeTimer, SongTimeProgressBar, SongTimeTrackBar);
        }
        
        protected virtual void OnSongTimeTrackBarClicked(double time, Timer timer, ProgressBar progressBar, TrackBar trackbar)
        {
            if (SongTimeTrackBarClicked != null)
            {
                SongTimeTrackBarClicked(this, new SongPlayerEventArgs() { Time = time, Songtimer = timer, Songprogressbar = progressBar, HidenTrackbar = trackbar });
            }
        }

        private void UploadSongButton_Click(object sender, EventArgs e)
        {
            stackpanels.Add(panels["ImportSongPanel"]);
            ShowLastPanel();
            openFileDialog1.ShowDialog();
            string justname = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            NameTextBox.Text = justname;
        }

        private void ConfirmUploadButton_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(openFileDialog1.FileName);
            string mainsongfolder = Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName + @"\Songs\";
            if (File.Exists(mainsongfolder + Path.GetFileName(openFileDialog1.FileName))) 
            {
                bool inlist = false;
                foreach (Song song in CurrentUser.Importedsongs)
                {
                    if (NameTextBox.Text == song.Name)
                    {
                        inlist = true;
                        break;
                    }
                   
                }
                if (!inlist) 
                {
                    Song impsong = new Song(NameTextBox.Text, AlbumTextBox.Text, ArtistTextBox.Text, GenreTextBox.Text, YearTextBox.Text, ext);
                    Gestor.SaveSongOnUser(Users, CurrentUser, NameTextBox.Text, AlbumTextBox.Text, ArtistTextBox.Text, GenreTextBox.Text, YearTextBox.Text, ext);
                    CreateDynamicButton(butonpos, NameTextBox.Text + "-" + AlbumTextBox.Text + "-" + ArtistTextBox.Text, NameTextBox.Text + "Button", impsong);
                    butonpos += 69;
                    OnImportedButtonClicked(impsong);
                    def.Add(impsong);
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("Songs.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                    formatter.Serialize(stream, def);
                    stream.Close();
                }
            }
            else
            {
                try
                {
                    File.Copy(openFileDialog1.FileName, mainsongfolder + Path.GetFileName(openFileDialog1.FileName));
                    Song impsong = new Song(NameTextBox.Text, AlbumTextBox.Text, ArtistTextBox.Text, GenreTextBox.Text, YearTextBox.Text, ext);
                    Gestor.SaveSongOnUser(Users, CurrentUser, NameTextBox.Text, AlbumTextBox.Text, ArtistTextBox.Text, GenreTextBox.Text, YearTextBox.Text, ext);
                    CreateDynamicButton(butonpos, NameTextBox.Text + "-" + AlbumTextBox.Text + "-" + ArtistTextBox.Text, NameTextBox.Text + "Button", impsong);
                    butonpos += 69;
                    OnImportedButtonClicked(impsong);
                    def.Add(impsong);
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("Songs.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                    formatter.Serialize(stream, def);
                    stream.Close();
                }
                catch (System.IO.FileNotFoundException) 
                {
                    MessageBox.Show("No se ha encontrado el archivo");
                }
            }
            stackpanels.RemoveAt(stackpanels.Count - 1);
            ShowLastPanel();
        }

        protected virtual void OnImportedButtonClicked(Song importedsong)
        {
            if (ImportedButtonClicked != null)
            {
                ImportedButtonClicked(this, new SongPlayerEventArgs() { Actualsong = importedsong });
            }
        }

        private void SongMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed();
        }

        protected virtual void OnFormClosed()
        {
            if (FormClosedd != null)
            {
                FormClosedd(this, new SongPlayerEventArgs());
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            stackpanels.RemoveAt(stackpanels.Count - 1);
            ShowLastPanel();
        }

        private void NewPlaylistButton_Click(object sender, EventArgs e)
        {
            stackpanels.Add(panels["PlaylistCreatorPanel"]);
            ShowLastPanel();
        }

        private void SongsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PrivateCheckBox.Checked)
            {
                privlist = true;
            }
            else 
            {
                privlist = false;
            }
            foreach (Song song in def)
            {
                if (SongsComboBox.SelectedItem.ToString() == song.Name)
                {
                    nplaylist.Add(song);
                    MessageBox.Show("Cancion añadida");
                }
            }
        }

        private void BackcrButton_Click(object sender, EventArgs e)
        {
            stackpanels.RemoveAt(stackpanels.Count - 1);
            ShowLastPanel();
        }

        private void DeleteSongButton_Click(object sender, EventArgs e)
        {
            stackpanels.Add(panels["DeleteSongPanel"]);
            ShowLastPanel();
            foreach (Song s in CurrentUser.Importedsongs)
            {
                DeleteSongComboBox.Items.Add(s.Name);
            }
        }

        private void ConfirmDeleteButton_Click(object sender, EventArgs e)
        {
            if (DeleteSongComboBox.SelectedItem == null)
            {
                MessageBox.Show("No se ha podido borrar la cancion!, revise que no haya sido borrada previamente.");
                stackpanels.RemoveAt(stackpanels.Count - 1);
                ShowLastPanel();
            }
            else
            {
                foreach (Control b in SSFLPanel.Controls) 
                {
                    if (DeleteSongComboBox.SelectedItem.ToString()+"Button" == b.Name) 
                    {
                        SSFLPanel.Controls.Remove(b);
                    }
                }
                foreach (Song s in CurrentUser.Importedsongs)
                {
                    if (s.Name == DeleteSongComboBox.SelectedItem.ToString())
                    {
                        CurrentUser.Importedsongs.Remove(s);
                        break;
                    }
                }
                
                foreach (SongPlaylist playlist in CurrentUser.CancionesPrivadas)
                {
                    foreach (Song s in playlist.ActualPlaylist)
                    {
                        if (s.Name == DeleteSongComboBox.SelectedItem.ToString())
                        {
                            playlist.ActualPlaylist.Remove(s);
                            break;
                        }
                    }
                }
                foreach (SongPlaylist playlist in CurrentUser.CancionesPublicas)
                {
                    foreach (Song s in playlist.ActualPlaylist)
                    {
                        if (s.Name == DeleteSongComboBox.SelectedItem.ToString())
                        {
                            playlist.ActualPlaylist.Remove(s);
                            break;
                        }
                    }
                }
                foreach (Song s in def) 
                {
                    if (s.Name == DeleteSongComboBox.SelectedItem.ToString())
                    {
                        def.Remove(s);
                        break;
                    }
                }
                OnPlaylistButtonClicked(def);
                DeleteSongComboBox.Items.Clear();
                Gestor.SaveFavoriteUser(Users, CurrentUser);
                stackpanels.RemoveAt(stackpanels.Count - 1);
                ShowLastPanel();
            }
        }

        private void DeleteBackButton_Click(object sender, EventArgs e)
        {
            stackpanels.RemoveAt(stackpanels.Count - 1);
            ShowLastPanel();

        }

        private void DeletePlaylistBackButton_Click(object sender, EventArgs e)
        {
            stackpanels.RemoveAt(stackpanels.Count - 1);
            ShowLastPanel();
        }

        private void DefDeletePlaylistButton_Click(object sender, EventArgs e)
        {
            if (DeletePlaylistComboBox.SelectedItem == null)
            {
                MessageBox.Show("No se pudo borrar la playlist, revise que no haya sido borrada previamente.");
                stackpanels.RemoveAt(stackpanels.Count - 1);
                ShowLastPanel();
            }
            else
            {
                foreach (Control b in PlaylistsFlowLayoutPanel.Controls)
                {
                    if (DeletePlaylistComboBox.SelectedItem.ToString()  == b.Name)
                    {
                        PlaylistsFlowLayoutPanel.Controls.Remove(b);
                    }
                }

                foreach (SongPlaylist playlist in CurrentUser.CancionesPrivadas)
                {
                    if (playlist.Name == DeletePlaylistComboBox.SelectedItem.ToString())
                    {
                        CurrentUser.CancionesPrivadas.Remove(playlist);
                        break;
                    }
                }
                foreach (SongPlaylist playlist in CurrentUser.CancionesPublicas)
                {
                    if (playlist.Name == DeletePlaylistComboBox.SelectedItem.ToString())
                    {
                        CurrentUser.CancionesPublicas.Remove(playlist);
                        break;
                    }
                }
                DeletePlaylistComboBox.Items.Clear();
                Gestor.SaveFavoriteUser(Users, CurrentUser);
                stackpanels.RemoveAt(stackpanels.Count - 1);
                ShowLastPanel();
            }
        }

        private void DeletePlaylistButton_Click(object sender, EventArgs e)
        {
            stackpanels.Add(panels["DeletePlaylistPanel"]);
            ShowLastPanel();
            foreach (SongPlaylist playlist in CurrentUser.CancionesPrivadas)
            {
                DeletePlaylistComboBox.Items.Add(playlist.Name);
            }
            foreach (SongPlaylist playlist in CurrentUser.CancionesPublicas)
            {
                DeletePlaylistComboBox.Items.Add(playlist.Name);
            }
        }

        private void RemoveSongButton_Click(object sender, EventArgs e)
        {
            RPlaylistComboBox.Items.Clear();
            stackpanels.Add(panels["RemoveFromPLPanel"]);
            ShowLastPanel();
            RPlaylistComboBox.Items.Add("Favoritos");
            foreach(SongPlaylist pl in CurrentUser.CancionesPrivadas) 
            {
                RPlaylistComboBox.Items.Add(pl.Name);
            }
            foreach (SongPlaylist pl in CurrentUser.CancionesPublicas)
            {
                RPlaylistComboBox.Items.Add(pl.Name);
            }

        }

        private void RSongBackButton_Click(object sender, EventArgs e)
        {
            stackpanels.RemoveAt(stackpanels.Count-1);
            ShowLastPanel();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            SRComboBox.Items.Clear();
            stackpanels.Add(panels["FinalRemovePanel"]);
            ShowLastPanel();
            if (RPlaylistComboBox.SelectedItem.ToString() == "Favoritos")
            {
                if (CurrentUser.FavoriteSongs != null)
                {
                    foreach (Song s in CurrentUser.FavoriteSongs)
                    {
                        SRComboBox.Items.Add(s);
                    }
                }
            }
            else 
            {
                foreach (SongPlaylist pl in CurrentUser.CancionesPrivadas)
                {
                    if (pl.Name == RPlaylistComboBox.SelectedItem.ToString()) 
                    {
                        foreach(Song s in pl.ActualPlaylist)
                        {
                            SRComboBox.Items.Add(s.Name);
                        }
                        break;
                    }
                }
                foreach (SongPlaylist pl in CurrentUser.CancionesPublicas)
                {
                    if (pl.Name == RPlaylistComboBox.SelectedItem.ToString())
                    {
                        foreach (Song s in pl.ActualPlaylist)
                        {
                            SRComboBox.Items.Add(s.Name);
                        }
                        break;
                    }
                }
            }
        }

        private void SRRBackButton_Click(object sender, EventArgs e)
        {
            stackpanels.RemoveAt(stackpanels.Count-1);
            ShowLastPanel();
        }

        private void SDeleteButton_Click(object sender, EventArgs e)
        {
            if (RPlaylistComboBox.SelectedItem.ToString() == "Favoritos")
            {
                if (CurrentUser.FavoriteSongs != null)
                {
                    foreach (Song s in CurrentUser.FavoriteSongs)
                    {
                        if (SRComboBox.SelectedItem.ToString() == s.Name)
                        {
                            CurrentUser.FavoriteSongs.Remove(s);
                            Gestor.SaveFavoriteUser(Users, CurrentUser);
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (SongPlaylist pl in CurrentUser.CancionesPrivadas)
                {
                    if (pl.Name == RPlaylistComboBox.SelectedItem.ToString())
                    {
                        foreach (Song s in pl.ActualPlaylist)
                        {
                            if (SRComboBox.SelectedItem.ToString() == s.Name)
                            {
                                pl.ActualPlaylist.Remove(s);
                                Gestor.SaveFavoriteUser(Users, CurrentUser);
                                break;
                            }
                        }
                        break;
                    }
                }
                foreach (SongPlaylist pl in CurrentUser.CancionesPublicas)
                {
                    if (pl.Name == RPlaylistComboBox.SelectedItem.ToString())
                    {
                        foreach (Song s in pl.ActualPlaylist)
                        {
                            if (SRComboBox.SelectedItem.ToString() == s.Name)
                            {
                                pl.ActualPlaylist.Remove(s);
                                Gestor.SaveFavoriteUser(Users, CurrentUser);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            stackpanels.RemoveAt(stackpanels.Count - 1);
            stackpanels.RemoveAt(stackpanels.Count - 1);
            ShowLastPanel();
        }

        private void ASBackButton_Click(object sender, EventArgs e)
        {
            stackpanels.RemoveAt(stackpanels.Count - 1);
            ShowLastPanel();
        }

        private void AddSongPlaylist_Click(object sender, EventArgs e)
        {
            ASPlaylistComboBox.Items.Clear();
            stackpanels.Add(panels["AddSongPanel"]);
            ShowLastPanel();
            ASPlaylistComboBox.Items.Add("Favoritos");
            foreach (SongPlaylist pl in CurrentUser.CancionesPrivadas)
            {
                ASPlaylistComboBox.Items.Add(pl.Name);
            }
            foreach (SongPlaylist pl in CurrentUser.CancionesPublicas)
            {
                ASPlaylistComboBox.Items.Add(pl.Name);
            }
        }

        private void ASSBackButton_Click(object sender, EventArgs e)
        {
            stackpanels.RemoveAt(stackpanels.Count - 1);
            ShowLastPanel();
        }

        private void ASSButton_Click(object sender, EventArgs e)
        {
            if (ASPlaylistComboBox.SelectedItem.ToString() == "Favoritos")
            {
                foreach (Song s in def)
                {
                    if (ASSComboBox.SelectedItem.ToString() == s.Name)
                    {
                        if (CurrentUser.FavoriteSongs != null)
                        {
                            CurrentUser.FavoriteSongs.Add(s);
                        }
                        else
                        {
                            CurrentUser.FavoriteSongs = new List<Song>();
                            CurrentUser.FavoriteSongs.Add(s);
                        }
                        Gestor.SaveFavoriteUser(Users, CurrentUser);
                    }
                }
            }
            else
            {
                foreach (SongPlaylist pl in CurrentUser.CancionesPrivadas)
                {
                    if (pl.Name == ASPlaylistComboBox.SelectedItem.ToString())
                    {
                        foreach (Song s in def)
                        {
                            if (ASSComboBox.SelectedItem.ToString() == s.Name)
                            {
                                pl.ActualPlaylist.Add(s);
                                Gestor.SaveFavoriteUser(Users, CurrentUser);
                                break;
                            }
                        }
                        break;
                    }
                }
                foreach (SongPlaylist pl in CurrentUser.CancionesPublicas)
                {
                    if (pl.Name == ASPlaylistComboBox.SelectedItem.ToString())
                    {
                        foreach (Song s in def)
                        {
                            if (ASSComboBox.SelectedItem.ToString() == s.Name)
                            {
                                pl.ActualPlaylist.Add(s);
                                Gestor.SaveFavoriteUser(Users, CurrentUser);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            stackpanels.RemoveAt(stackpanels.Count - 1);
            stackpanels.RemoveAt(stackpanels.Count - 1);
            ShowLastPanel();
        }

        private void ASSelectButton_Click(object sender, EventArgs e)
        {
            SRComboBox.Items.Clear();
            stackpanels.Add(panels["FinalAddSongPanel"]);
            ShowLastPanel();
            foreach (Song s in def)
            {
                ASSComboBox.Items.Add(s.Name);
            }
        }

        private void AddSongPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeleteSongPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CreatePlaylistButton_Click(object sender, EventArgs e)
        {
            Gestor.SaveSongOnPlaylistAndUser(Users,CurrentUser,nplaylist,PlaylistNameTextBox.Text,privlist);
            nplaylist.Clear();
            PlaylistNameTextBox.Clear();
            PrivateCheckBox.Checked = false;
            MessageBox.Show("Playlist creada, cierre la pestaña y vuelva al menu de canciones para disfrutar de su playlist");
        }
    }
}
