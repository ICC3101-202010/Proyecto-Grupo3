using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Entrega2
{
    public class Song
    {
        public string Artists { get; set; }
        public string Lyrics { get; set; }
        public string Genre { get; set; }
        public string Album { get; set; }
        public string Name { get; set; }//will contain name and format.
        public string Year { get; set; }
        public Song(string Name, string Album, string Artists, string Genre, string Year, string Lyrics)
        {
            this.Name = Name;
            this.Album = Album;
            this.Artists = Artists;
            this.Genre = Genre;
            this.Year = Year;
            this.Lyrics = Lyrics;
        }

        public void PlaySong(WaveOutEvent pc)
        {
            pc.Play();
        }
        public void PauseSong(WaveOutEvent pc)
        {
            pc.Stop();
        }

        public void SkiptoSong(WaveOutEvent pc, AudioFileReader nextsong)
        {
            pc.Stop();
            pc.Init(nextsong);
            pc.Play();
        }
        public void Forwards_Backwards(AudioFileReader song, double seconds)
        {
            song.CurrentTime = TimeSpan.FromSeconds(seconds);
        }
        public double LastSesionTime(AudioFileReader song)
        {
            double finaltime = Convert.ToDouble(song.CurrentTime);
            return finaltime;
        }
    }
}
