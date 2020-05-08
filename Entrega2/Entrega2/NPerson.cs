using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega2
{
    public class NPerson : User
    {

        public List<User> usuariosSeguidos;

        public NPerson(int idUsuario, int metodoPago, string nombre, string apellido, string claveUsuario, string mail, string descripcion, bool privado, bool premium)
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

            this.usuariosSeguidos = new List<User>();
            this.Seguidores = new List<User>();

    }
    }
}
