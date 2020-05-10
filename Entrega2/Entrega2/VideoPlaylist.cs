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
    class VideoPlaylist
    {
        public string name;
        public List<Video> playlistvideo = new List<Video>();

        public VideoPlaylist(string name, List<Video> Listvideos)
        {
            this.name = name;
            this.playlistvideo = Listvideos;
        }

        public void DisplayPlaylist()
        {
            int count = playlistvideo.Count();
            Console.WriteLine("La playlist {0} contiene {1} elementos", name , count);
            
            foreach (Video video in playlistvideo)
            {
                Console.WriteLine(video.name);
            }
        }


    }
}
