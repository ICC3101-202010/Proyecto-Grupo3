using System;
using System.Collections.Generic;
using System.Text;

namespace Entrega2
{
    class PersonaN : Usuario
    {
        public PersonaN(int idUsuario, int metodoPago, string nombre, string apellido, string claveUsuario, string mail, string descripcion, bool privado, bool premium)
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
        }
    }
}
