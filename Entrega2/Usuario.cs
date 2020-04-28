using System;
using System.Collections.Generic;
using System.Text;

namespace Entrega2
{
    public abstract class Usuario
    {
        //Parametros base de un usuario.

        public int idUsuario; public int metodoPago; public string nombre; public string apellido;
        public string claveUsuario; public string mail; public string descripcion; public bool privado;
        public bool premium;

        //Playlists de cualquier usuario.

        List<Playlist> Playlists;
        List<PlaylistCancion> CancionesPublicas;
        List<PlaylistCancion> CancionesPrivadas;
        List<PlaylistVideo> VideosPublicos;
        List<PlaylistVideo> VideosPrivados;

        //Cola de canciones y videos.

        List<Cancion> ColaCanciones;
        List<Video> ColaVideos;

    }
}
