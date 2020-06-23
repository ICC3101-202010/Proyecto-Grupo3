using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega3Netify
{
    [Serializable]
    public class NPerson : User
    {
        public List<User> usuariosSeguidos = new List<User>();
        public List<User> Seguidores = new List<User>();
        public List<Video> VideosImportados = new List<Video>();
        public List<Song> Importedsongs = new List<Song>();
        public List<SongPlaylist> CancionesPublicas = new List<SongPlaylist>();
        public List<SongPlaylist> CancionesPrivadas = new List<SongPlaylist>();
        public List<Video> VideosFavoritos = new List<Video>();
        public List<Song> FavoriteSongs = new List<Song>();
        public List<VideoPlaylist> VideosPublicos = new List<VideoPlaylist>();
        public List<VideoPlaylist> VideosPrivados = new List<VideoPlaylist>();

        public int IDUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool Private { get; set; }
        public bool Premium { get; set; }

        public NPerson(int idUsuario, string nombre, string apellido, string claveUsuario, string mail, string descripcion, bool privado, bool premium)
        {
            //Params. de Usuario.
            this.IDUser = idUsuario;
            this.Name = nombre;
            this.LastName = apellido;
            this.Password = claveUsuario;
            this.Email = mail;
            this.Description = descripcion;
            this.Private = privado;
            this.Premium = premium;

            //Playlists correspondientes.

            //this.usuariosSeguidos = new List<User>();
            //this.Seguidores = new List<User>();
        }
    }
}
