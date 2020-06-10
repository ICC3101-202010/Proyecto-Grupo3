using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NAudio.Wave;
using System.Windows.Forms;

namespace Entrega3Netify
{
    public class SongsController
    {
        List<Song> Songs = new List<Song>();

        List<Song> Otherplaylist = null;

        SongMenuForm songplayer;

        WaveOutEvent pc = new WaveOutEvent();

        AudioFileReader currentsongfile;

        Song currentsong, previousong;

        public SongsController(SongMenuForm songplayer)
        {
            Init();
            this.songplayer = songplayer as SongMenuForm;
            foreach (Song impsong in songplayer.CurrentUser.Importedsongs) 
            {
                Songs.Add(impsong);
            }
            this.songplayer.PlayButtonClicked += OnPlayButtonClicked;
            this.songplayer.StopButtonClicked += OnStopButtonClicked;
            this.songplayer.NextSongButtonClicked += OnNextSongButtonClicked;
            this.songplayer.PreviousSongButtonClicked += OnPreviousSongButtonClicked;
            this.songplayer.SearchButtonClicked += OnSearchButtonClicked;
            this.songplayer.VolumeTrackBarUsed += OnVolumeTrackBarUsed;
            this.songplayer.SongTimeTrackBarClicked += OnSongTimeTrackBarClicked;
            this.songplayer.ImportedButtonClicked += OnImportedButtonClicked;
            this.songplayer.FormClosedd += OnFormClosed;
            this.songplayer.PlaylistButtonClicked += OnPlaylistButtonClicked;
        }

        public void Init()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream des = new FileStream("Songs.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Songs = (List<Song>)formatter.Deserialize(des);
            des.Close();
        }

        public List<Song> actualplaylist(List<Song> songs)
        {
            return songs;
        }

        public void OnPlayButtonClicked(object source, SongPlayerEventArgs e)
        {
            if (previousong != null)
            {
                try
                {
                    currentsongfile = new AudioFileReader(e.Actualsong.Path);
                    if ((previousong.Name == e.Actualsong.Name) && (previousong.Artists == e.Actualsong.Artists) && (previousong.Album == e.Actualsong.Album) && (previousong.Year == e.Actualsong.Year))
                        e.Actualsong.PlaySong(pc, currentsongfile, 2, e.Songtimer, e.Songprogressbar, e.HidenTrackbar);
                    else
                        e.Actualsong.PlaySong(pc, currentsongfile, 1, e.Songtimer, e.Songprogressbar, e.HidenTrackbar);
                    currentsong = e.Actualsong;
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("Ha ocurrido un error , porfavor vuelva a intentarlo");
                }
            }
            else
            {
                try
                {
                    currentsongfile = new AudioFileReader(e.Actualsong.Path);
                    e.Actualsong.PlaySong(pc, currentsongfile, 1, e.Songtimer, e.Songprogressbar, e.HidenTrackbar);
                    currentsong = e.Actualsong;
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("Ha ocurrido un error , porfavor vuelva a intentarlo");
                }
            }
        }

        public void OnStopButtonClicked(object source, SongPlayerEventArgs a)
        {
            if (currentsong != null)
            {
                currentsong.StopSong(pc);
                previousong = currentsong;
                a.Songtimer.Stop();
            }
        }

        public void OnNextSongButtonClicked(object source, SongPlayerEventArgs i)
        {

            int siguiente;
            List<Song> playlist = actualplaylist(Otherplaylist);
            if (playlist == null)
                playlist = Songs;
            if (currentsong != null)
            {
                foreach (Song s in playlist)
                {
                    if (currentsong.Name == s.Name)
                    {
                        siguiente = playlist.IndexOf(s) + 1;
                        try
                        {
                            currentsong = playlist[siguiente];
                            try
                            {
                                currentsongfile = new AudioFileReader(currentsong.Path);
                                playlist[siguiente].PlaySong(pc, currentsongfile, 1, i.Songtimer, i.Songprogressbar, i.HidenTrackbar);
                            }
                            catch (System.IO.FileNotFoundException) 
                            {
                                MessageBox.Show("Ha ocurrido un error, porfavor vuelva a intentarlo");
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            currentsong = playlist[0];
                            currentsongfile = new AudioFileReader(currentsong.Path);
                            playlist[0].PlaySong(pc, currentsongfile, 1, i.Songtimer, i.Songprogressbar, i.HidenTrackbar);
                        }
                        break;
                    }
                }
            }
        }

        public void OnPreviousSongButtonClicked(object source, SongPlayerEventArgs o)
        {
            int anterior;
            List<Song> playlist = actualplaylist(Otherplaylist);
            if (playlist == null)
                playlist = Songs;
            if (currentsong != null)
            {
                foreach (Song s in playlist)
                {
                    if (currentsong.Name == s.Name)
                    {
                        anterior = playlist.IndexOf(s) - 1;
                        try
                        {
                            currentsong = playlist[anterior];
                            try
                            {
                                currentsongfile = new AudioFileReader(currentsong.Path);
                                playlist[anterior].PlaySong(pc, currentsongfile, 1, o.Songtimer, o.Songprogressbar, o.HidenTrackbar);
                            }
                            catch (System.IO.FileNotFoundException) 
                            {
                                MessageBox.Show("Ha ocurrido un error, profsvor vuelva a intentarlo");
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            currentsong = playlist[0];
                            currentsongfile = new AudioFileReader(currentsong.Path);
                            playlist[0].PlaySong(pc, currentsongfile, 1, o.Songtimer, o.Songprogressbar, o.HidenTrackbar);
                        }
                        break;
                    }
                }
            }
        }

        public void OnSearchButtonClicked(object source, SearcherPlayerEventArgs e)
        {
            List<Song> matchingsongs = new List<Song>();
            string smartsearch = "";
            if (e.input != "")
            {
                foreach (Song song in Songs)
                {
                    if (e.input.Length == song.Name.Length)
                    {
                        if (e.input.ToUpper() == song.Name.ToUpper())
                        {
                            matchingsongs.Add(song);
                            continue;
                        }
                    }
                    else if (e.input.Length <= song.Name.Length)
                    {
                        for (int i = 0; i < e.input.Length; i++)
                        {
                            smartsearch += song.Name[i];
                        }
                        if (e.input.ToUpper() == smartsearch.ToUpper())
                        {
                            matchingsongs.Add(song);
                            smartsearch = "";
                            continue;
                        }
                        else
                        {
                            smartsearch = "";
                        }
                    }
                    if (e.input.Length == song.Album.Length)
                    {
                        if (e.input.ToUpper() == song.Album.ToUpper())
                        {
                            matchingsongs.Add(song);
                            continue;
                        }
                    }
                    else if (e.input.Length <= song.Album.Length)
                    {
                        for (int i = 0; i < e.input.Length; i++)
                        {
                            smartsearch += song.Album[i];
                        }
                        if (e.input.ToUpper() == smartsearch.ToUpper())
                        {
                            matchingsongs.Add(song);
                            smartsearch = "";
                            continue;
                        }
                        else
                        {
                            smartsearch = "";
                        }
                    }
                    if (e.input.Length == song.Artists.Length)
                    {
                        if (e.input.ToUpper() == song.Artists.ToUpper())
                        {
                            matchingsongs.Add(song);
                            continue;
                        }
                    }
                    else if (e.input.Length <= song.Artists.Length)
                    {
                        for (int i = 0; i < e.input.Length; i++)
                        {
                            smartsearch += song.Artists[i];
                        }
                        if (e.input.ToUpper() == smartsearch.ToUpper())
                        {
                            matchingsongs.Add(song);
                            smartsearch = "";
                            continue;
                        }
                        else
                        {
                            smartsearch = "";
                        }
                    }
                    if (e.input.Length == song.Genre.Length)
                    {
                        if (e.input.ToUpper() == song.Genre.ToUpper())
                        {
                            matchingsongs.Add(song);
                            continue;
                        }
                    }
                    else if (e.input.Length <= song.Genre.Length)
                    {
                        for (int i = 0; i < e.input.Length; i++)
                        {
                            smartsearch += song.Genre[i];
                        }
                        if (e.input.ToUpper() == smartsearch.ToUpper())
                        {
                            matchingsongs.Add(song);
                            smartsearch = "";
                            continue;
                        }
                        else
                        {
                            smartsearch = "";
                        }
                    }
                    if (e.input.Length == song.Year.Length)
                    {
                        if (e.input.ToUpper() == song.Year.ToUpper())
                        {
                            matchingsongs.Add(song);
                            continue;
                        }
                    }
                    else if (e.input.Length <= song.Year.Length)
                    {
                        for (int i = 0; i < e.input.Length; i++)
                        {
                            smartsearch += song.Year[i];
                        }
                        if (e.input.ToUpper() == smartsearch.ToUpper())
                        {
                            matchingsongs.Add(song);
                            smartsearch = "";
                            continue;
                        }
                        else
                        {
                            smartsearch = "";
                        }
                    }
                }
                if (matchingsongs.Count() != 0)
                {
                    if (Otherplaylist != null)
                    {
                        Otherplaylist.Clear();
                        Otherplaylist = matchingsongs;
                    }
                    else
                    {
                        Otherplaylist = matchingsongs;
                    }
                    songplayer.ShowThisSongs(matchingsongs);
                }
                else
                    MessageBox.Show("No se han encontrado resultados");
            }
        }

        public void OnVolumeTrackBarUsed(object source, SongPlayerEventArgs u)
        {
            if (currentsong != null)
            {
                currentsong.SongVolume(u.Volume, pc);
            }
        }

        public void OnSongTimeTrackBarClicked(object source, SongPlayerEventArgs c)
        {
            if (currentsong != null)
            {
                c.Songprogressbar.Increment(c.HidenTrackbar.Value - c.Songprogressbar.Value);
                currentsong.NewTime(c.Time, currentsongfile, pc, c.Songtimer);

            }
        }

        public void OnImportedButtonClicked(object source, SongPlayerEventArgs e)
        {
            Songs.Add(e.Actualsong);
        }

        public void OnFormClosed(object source, SongPlayerEventArgs e)
        {
            pc.Stop();
            pc.Dispose();
        }

        public void OnPlaylistButtonClicked(object source , SongPlayerEventArgs e)
        {
            Otherplaylist = e.Actualplaylist;
        }
    }
}
