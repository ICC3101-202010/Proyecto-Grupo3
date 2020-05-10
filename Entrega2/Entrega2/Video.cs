using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;

namespace Entrega2
{
    [Serializable]
    class Video
    {
        public string name;
        public string genre;
        public string category;
        public string director;
        public string description;
        public List<Actor> actors = new List<Actor>();
        public int resolution;
        public double score = 0.0;
        int followers = 0;
        public string extention;

        public Video(string name, string genre, string category, string director, string description, List<Actor> actors, int resolution, string extention)
        {
            this.name = name;
            this.genre = genre;
            this.category = category;
            this.director = director;
            this.description = description;
            this.actors = actors;
            this.resolution = resolution;
            this.extention = extention;

        }

        
        public void DisplayData()
        {

            Console.WriteLine("Nombre: {0}", name);
            Console.WriteLine("Genero: {0}", genre);
            Console.WriteLine("Categoria: {0}", category);
            Console.WriteLine("Director: {0}", director);
            Console.WriteLine("Descripcion: {0}", description);
            Console.WriteLine("Actores:");
            foreach (Actor actor in actors)
            {
                Console.WriteLine(actor);
            }
            Console.WriteLine("Resolucion: {0}", resolution);
            Console.WriteLine("Calificacion: {0}", score);
            Console.WriteLine("Seguidores: {0}", followers);
            
            
        }


        public void Play()
        {
            var curDir = Directory.GetCurrentDirectory();
            string pathVideos = curDir + @"\Videos";
            Process.Start(pathVideos + name + extention);
        }

        public void Next()
        {
            Console.WriteLine("Cambiando a Siguiente video");
            //este metodo solo imprime ya que al usar process start se puede usar el mismo reproductor para cambiar, se espera que con windows form se pueda editar esto
        }

        public void Pause()
        {
            Console.WriteLine("Pausando video");
            //este metodo solo imprime ya que al usar process start se puede usar el mismo reproductor para cambiar, se espera que con windows form se pueda editar esto
        }

        public void Stop()
        {
            Console.WriteLine("Deteniendo el video");
            //este metodo solo imprime ya que al usar process start se puede usar el mismo reproductor para cambiar, se espera que con windows form se pueda editar esto
        }

        public void AddImage()
        {

        }
        
    }
}
