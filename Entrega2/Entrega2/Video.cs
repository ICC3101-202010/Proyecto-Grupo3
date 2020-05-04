using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entrega2
{
    class Video
    {
        public string name;
        public string director;
        public string description;
        public string actors;
        public int resolution;
        public double score = 0.0;

        public Video(string name, string director, string description, string actors, int resolution)
        {
            this.name = name;
            this.director = director;
            this.description = description;
            this.actors = actors;
            this.resolution = resolution;

        }
        public void Play()
        {
            System.Diagnostics.Process.Start(@"");
            
            /*var curDir = Directory.GetCurrentDirectory();
            Video video1 = new Video("Circles", "Post Malone", "Video de la cancion Cirlces", "Post Malone", 1080);
            video1.Play(curDir + @"\" + "Post Malone - Circles 1080p.mp4");
            */
        }

        public void Next()
        {

        }

        public void Pause()
        {

        }

        public void AddImage()
        {

        }
    }
}
