using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;


namespace Entrega3Netify
{
    [Serializable]
    public class Video
    {
        public string name;
        public string genre;
        public string category;
        public string director;
        public string description;
        //public List<Actor> actors = new List<Actor>();
        public string resolution;
        public double score = 0.0;
        int followers = 0;
        public string path;

        public Video(string name, string genre, string category, string director, string description, string resolution, string path)
        {
            this.name = name;
            this.genre = genre;
            this.category = category;
            this.director = director;
            this.description = description;
            //this.actors = actors;
            this.resolution = resolution;
            this.path = path;

        }


        public void DisplayData()
        {

            Console.WriteLine("Nombre: {0}", name);
            Console.WriteLine("Genero: {0}", genre);
            Console.WriteLine("Categoria: {0}", category);
            Console.WriteLine("Director: {0}", director);
            Console.WriteLine("Descripcion: {0}", description);
            //Console.WriteLine("Actores:");
            //foreach (Actor actor in actors)
            //{
            //    Console.WriteLine(actor);
            //}
            Console.WriteLine("Resolucion: {0}", resolution);
            Console.WriteLine("Calificacion: {0}", score);
            //Console.WriteLine("Seguidores: {0}", followers);


        }


        public void Play()
        {
            Process.Start(path);
        }
    }
}
