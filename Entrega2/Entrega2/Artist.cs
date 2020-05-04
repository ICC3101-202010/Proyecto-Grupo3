using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega2
{
    class Artist : User
    {
        public List<string> Albums;
        public List<Song> CancionesAlbum;
        public List<string> Generos;
        public List<string> Albumes;
        public List<string> Premios;

        public Artist(int idUsuario, int metodoPago, string nombre, string apellido, string claveUsuario, string mail, string descripcion, bool privado, bool premium)

        {
            //Params. de Usuario.
            this.idUsuario = idUsuario;
            this.metodoPago = metodoPago;
            this.nombre = nombre;
            this.apellido = apellido;
            this.claveUsuario = claveUsuario;
            this.mail = mail;
            this.descripcion = descripcion;
            this.privado = privado;
            this.premium = premium;

            //Playlists correspondientes.

            List<Playlist> Playlists = new List<Playlist>();
            List<SongPlaylist> CancionesPublicas = new List<SongPlaylist>();
            List<SongPlaylist> CancionesPrivadas = new List<SongPlaylist>();
            List<VideoPlaylist> VideosPublicos = new List<VideoPlaylist>();
            List<VideoPlaylist> VideosPrivados = new List<VideoPlaylist>();

            //Atributos unicos al musico, que parten como listas vacias. 

            List<string> Generos = new List<string>();
            List<string> Albumes = new List<string>();
            List<string> Premios = new List<string>();
            List<string> Albums = new List<string>();
            List<Song> CancionesAlbum = new List<Song>();

        }
    }
}
