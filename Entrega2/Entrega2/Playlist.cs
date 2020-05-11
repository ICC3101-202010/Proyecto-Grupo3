﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega2
{
    public class Playlist
    {
        public string Name { get; set; }
        public bool Private { get; set; }

        public string Date { get; set; }

        public List<Song> ActualPlaylist = new List<Song>();

        public Playlist(string Name, bool Private, string Date)
        {
            this.Name = Name;
            this.Private = Private;
            this.Date = Date;
        }

        public void AddToPlaylist(Song song)
        {
            ActualPlaylist.Add(song);
        }

        public void RemoveFromPlaylist(Song song)
        {
            ActualPlaylist.Remove(song);
        }
    }
}
