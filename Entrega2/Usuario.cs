using System;
using System.Collections.Generic;
using System.Text;

namespace Entrega2
{
    abstract class Usuario
    {
        //Parametros base de un usuario.

        int idUsuario; int metodoPago; string nombre; string apellido;
        string claveUsuario; string mail; string descripcion; bool privado;
        bool premium;

        public Usuario(int idUsuario, int metodoPago, string nombre, string apellido, string claveUsuario, string mail, string descripcion, bool privado, bool premium)
        {
            this.idUsuario = idUsuario; this.metodoPago = metodoPago; this.nombre = nombre; this.apellido = apellido;
            this.claveUsuario = claveUsuario; this.mail = mail; this.descripcion = descripcion; this.privado = privado;
            this.premium = premium;
        }

        //Playlists de Usuario.

        //List<Playlist> Playlists;
        //List<PlaylistCancion> CancionesPublicas;
        //List<PlaylistCancion> CancionesPrivadas;
        //List<PlaylistVideo> VideosPublicos;
        //List<PlaylistVideo> VideosPrivados;

        //Cola de canciones y videos.

        //List<Cancion> ColaCanciones;
        //List<Video> ColaVideos;

    }


    class Actor : Usuario
    {
        //List<Videos> Peliculas;
        List<String> Premios;

    }
}
