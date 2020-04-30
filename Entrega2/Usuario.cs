using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

        //Metodo para cambiar alguno de los parametros base. 
        public void cambiarDato(string tipoDato, string nuevoDato)
        {
    
            //Funcion local que muestra parametros a usuario. 

            void showData() {
                Console.WriteLine("Datos de Usuario: \n");
                Console.WriteLine("1. Nombre: "); Console.WriteLine(this.nombre);
                Console.WriteLine("2. Apellido: "); Console.WriteLine(this.apellido);
                Console.WriteLine("3. Clave: "); Console.WriteLine(this.claveUsuario);
                Console.WriteLine("4. Mail: "); Console.WriteLine(this.mail);
                Console.WriteLine("5. Descripcion: "); Console.WriteLine(this.descripcion);
                Console.WriteLine("6. Privado: "); Console.WriteLine(this.privado);
                Console.WriteLine("7. Premium: "); Console.WriteLine(this.premium);
                }


            //Voy viendo por casos. 

            bool changeData = true;
            while (changeData) {
                
                showData();

                Console.WriteLine("Ingrese numero de parametro a modificar, ingrese 7 para salir: ");
                int input = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Ingrese nuevo nombre: "); this.nombre = Console.ReadLine();
                        Console.Clear(); showData();
                        break;
                    case 2:
                        Console.WriteLine("Ingrese nuevo apellido: "); this.apellido = Console.ReadLine();
                        Console.Clear(); showData();
                        break;
                    case 3:
                        Console.WriteLine("Ingrese nueva clave: "); this.claveUsuario = Console.ReadLine();
                        Console.Clear(); showData();
                        break;
                    case 4:
                        Console.WriteLine("Ingrese nuevo mail: "); this.mail = Console.ReadLine();
                        Console.Clear(); showData();
                        break;
                    case 5:
                        Console.WriteLine("Ingrese nueva descripcion: "); this.descripcion = Console.ReadLine();
                        Console.Clear(); showData();
                        break;
                    case 6:
                        Console.WriteLine("Ingrese 1 para ser Privado, 2 para ser publico: ");
                        int privChoice = Convert.ToInt32(Console.ReadLine());
                        if (privChoice == 1) { this.privado = true; }
                        if (privChoice == 2) { this.privado = false; }
                        else { Console.WriteLine("Opcion invalida"); }
                        Console.Clear(); showData(); Thread.Sleep(5000); break;
                    case 7:
                        changeData = false;
                        break;
                }
            }
            
        }
    }
}
