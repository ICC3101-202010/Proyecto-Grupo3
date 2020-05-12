using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega2
{
    class Actor : User
    {
        public List<Video> Peliculas;
        public List<string> Premios;

        public Actor(int idUsuario, int metodoPago, string nombre, string apellido, string claveUsuario, string mail, string descripcion, bool privado, bool premium)

        {
            //Params. de Usuario.
            this.idUsuario = idUsuario; this.metodoPago = metodoPago; this.nombre = nombre; this.apellido = apellido;
            this.claveUsuario = claveUsuario; this.mail = mail; this.descripcion = descripcion; this.privado = privado;
            this.premium = premium;

            //Playlists correspondientes.

            List<SongPlaylist> CancionesPublicas = new List<SongPlaylist>();
            List<SongPlaylist> CancionesPrivadas = new List<SongPlaylist>();
            List<VideoPlaylist> VideosPublicos = new List<VideoPlaylist>();
            List<VideoPlaylist> VideosPrivados = new List<VideoPlaylist>();


        //Atributos unicos al actor, que parten como listas vacias. 

        Peliculas = new List<Video>(); Premios = new List<string>();
        }
    }
}
