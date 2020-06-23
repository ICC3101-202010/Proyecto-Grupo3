using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3Netify
{
    public class SongPlayerEventArgs : EventArgs
    {
        public List<Song> Actualplaylist { get; set; }
        public Song Actualsong { get; set; }

        public int Volume { get; set; }

        public double Time { get; set; } = 0;

        public System.Windows.Forms.Timer Songtimer { get; set; }

        public ProgressBar Songprogressbar { get; set; }

        public TrackBar HidenTrackbar { get; set; }
    }
}
