using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega2
{
    [Serializable]
    public class NPerson
    {
        public List<User> usuariosSeguidos;
        public List<User> Seguidores = new List<User>();
        public List<SongPlaylist> CancionesPublicas = new List<SongPlaylist>();
        public List<SongPlaylist> CancionesPrivadas = new List<SongPlaylist>();
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
            IDUser = idUsuario;
            Name = nombre;
            LastName = apellido;
            Password = claveUsuario;
            Email = mail;
            Description = descripcion;
            Private = privado;
            Premium = premium;

            //Playlists correspondientes.

            

            this.usuariosSeguidos = new List<User>();
            this.Seguidores = new List<User>();
        }
    }
}
