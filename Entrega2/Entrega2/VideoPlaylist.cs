using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega2
{
    [Serializable]
    public class VideoPlaylist
    {
        public string name;
        public List<Video> ActualPlaylist = new List<Video>();

        public VideoPlaylist(string name, bool Private)
        {
            this.name = name;
        }

        public void AddToPlaylist(Video video)
        {
            ActualPlaylist.Add(video);
        }

        public void RemoveFromPlaylist(Video video)
        {
            ActualPlaylist.Remove(video);
        }


    }
}
