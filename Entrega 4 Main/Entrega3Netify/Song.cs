using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using NAudio.Wave;

namespace Entrega3Netify
{
    [Serializable]
    public class Song
    {
        public string Artists { get; set; }
        public string Genre { get; set; }
        public string Album { get; set; }
        public string Name { get; set; }//will contain name and format.
        public string Year { get; set; }
       
        public string Path = Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName + @"\Songs\";
        public Song(string Name, string Album, string Artists, string Genre, string Year, string format)
        {
            this.Name = Name;
            this.Album = Album;
            this.Artists = Artists;
            this.Genre = Genre;
            this.Year = Year;
            Path += Name + format;
        }
        public void PlaySong(WaveOutEvent pc, AudioFileReader audiofile, int cases, System.Windows.Forms.Timer SongTimeTimer, System.Windows.Forms.ProgressBar SongTimeProgressBar, System.Windows.Forms.TrackBar SongTimeTrackBar)
        {
            if (pc.PlaybackState == PlaybackState.Stopped)
            {
                switch (cases)
                {
                    case 1:
                        pc.Dispose();
                        pc.Init(audiofile);
                        pc.Play();
                        SongTimeProgressBar.Maximum = Convert.ToInt32(audiofile.TotalTime.TotalMinutes * 60);
                        SongTimeProgressBar.Value = 0;
                        SongTimeTimer.Start();
                        SongTimeTimer.Interval = 1000;
                        SongTimeTrackBar.Maximum = Convert.ToInt32(audiofile.TotalTime.TotalMinutes * 60) - 1;
                        SongTimeTrackBar.Value = 0;
                        break;
                    case 2:
                        pc.Play();
                        SongTimeTimer.Start();
                        break;
                }
            }
            else
            {
                pc.Stop();
                pc.Dispose();
                pc.Init(audiofile);
                pc.Play();
                pc.Dispose();
                pc.Init(audiofile);
                pc.Play();
                SongTimeProgressBar.Maximum = Convert.ToInt32(audiofile.TotalTime.TotalMinutes * 60);
                SongTimeProgressBar.Value = 0;
                SongTimeTimer.Start();
                SongTimeTimer.Interval = 1000;
                SongTimeTrackBar.Maximum = Convert.ToInt32(audiofile.TotalTime.TotalMinutes * 60) - 1;
                SongTimeTrackBar.Value = 0;
            }
        }
        public void StopSong(WaveOutEvent pc)
        {
            pc.Stop();
        }

        public void SongVolume(int newvol, WaveOutEvent pc)
        {
            pc.Volume = newvol / 100f;
        }

        public void NewTime(double newtime, AudioFileReader audiofile, WaveOutEvent pc, System.Windows.Forms.Timer timer)
        {
            double max = Convert.ToDouble(audiofile.TotalTime.TotalMinutes * 60);
            if (newtime > max) { }
            else
            {
            repl:
                audiofile.CurrentTime = TimeSpan.FromSeconds(newtime);
                if (pc.PlaybackState == PlaybackState.Stopped)
                {
                    pc.Play();
                    timer.Start();
                    goto repl;
                }
            }
        }
    }
}
