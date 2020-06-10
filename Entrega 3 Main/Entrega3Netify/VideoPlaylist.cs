using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega3Netify
{
    [Serializable]
    public class VideoPlaylist
    {
        public string name;
        bool privado;
        public List<Video> ActualPlaylist = new List<Video>();

        public VideoPlaylist(string name, bool privado)
        {
            this.name = name;
            this.privado = privado;
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
