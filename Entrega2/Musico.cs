using System.Collections.Generic;

namespace Entrega2
{
    class Musico : Usuario
    {

        public List<string> Albums; public List<Song> CancionesAlbum;
        public List<string> Generos; public List<string> Albumes; public List<string> Premios;

        public Musico(int idUsuario, int metodoPago, string nombre, string apellido, string claveUsuario, string mail, string descripcion, bool privado, bool premium)

        {
            //Params. de Usuario.
            this.idUsuario = idUsuario; this.metodoPago = metodoPago; this.nombre = nombre; this.apellido = apellido;
            this.claveUsuario = claveUsuario; this.mail = mail; this.descripcion = descripcion; this.privado = privado;
            this.premium = premium;

            //Playlists correspondientes.

            List<Playlist> Playlists = new List<Playlist>();
            List<PlaylistCancion> CancionesPublicas = new List<PlaylistCancion>();
            List<PlaylistCancion> CancionesPrivadas = new List<PlaylistCancion>();
            List<PlaylistVideo> VideosPublicos = new List<PlaylistVideo>();
            List<PlaylistVideo> VideosPrivados = new List<PlaylistVideo>();

            //Atributos unicos al musico, que parten como listas vacias. 

            List<string> Generos = new List<string>(); List<string> Albumes = new List<string>(); List<string> Premios = new List<string>();
            List<string> Albums = new List<string>(); List<Song> CancionesAlbum = new List<Song>();



        }


    }
}
