using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega3Netify
{
    [Serializable]
    public class SongPlaylist
    {
        public string Name { get; set; }

        public bool Private { get; set; }

        public List<Song> ActualPlaylist = new List<Song>();

        public SongPlaylist(string Name, bool Private)
        {
            this.Name = Name;
            this.Private = Private;
        }

        public void AddToThisPlaylist(Song song)
        {
            ActualPlaylist.Add(song);
        }

        public void RemoveFromPlaylist(Song song)
        {
            ActualPlaylist.Remove(song);
        }
    }
}
