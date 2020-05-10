using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NAudio;

namespace Entrega2
{
    class Gestor
    {
        //Parametros de gestor. 

        public List<User> Usuarios;

        //Constructor de gestor. 
        public Gestor()
        {
            this.Usuarios = new List<User>();
        }

        public List<string> obtenerArchivosDirectorio(string rutaArchivo)
        {

            List<string> listaRuta = new List<string>();

            listaRuta = Directory.GetFiles(Path.GetDirectoryName(rutaArchivo), Path.GetFileName(rutaArchivo)).ToList();

            return listaRuta;
        }
        public void NuevoUsuario()
        {
            bool creatingUser = true;
            while (creatingUser)
            {

                //Para obtener ID de nuevo usuario, tomo lista de usuarios, cuento todos los que hay 
                // y el ID del usuario que estoy creando simplemente es este numero + 1. (Ej. Si hay 10 usuarios, el ID del nuevo 
                // valdra 11.) 
                int newUserID = this.Usuarios.Count() + 1;

                Console.WriteLine("Ingrese mail: "); string newMail = Console.ReadLine(); Console.Clear();
                Console.WriteLine("Ingrese clave: "); string newPassword = Console.ReadLine(); Console.Clear();
                Console.WriteLine("Ingrese nombre: "); string newName = Console.ReadLine();
                Console.WriteLine("Ingrese apellido: "); string newLastName = Console.ReadLine(); Console.Clear();
                Console.WriteLine("Ingrese descripcion: "); string newDesc = Console.ReadLine(); Console.Clear();


                //Fijo parametro privacidad de Usuario. Si vale true es privado, si vale false es publico. 

                bool settingPrivacy = true;

                bool newPriv = true;

                while (settingPrivacy)
                {
                    Console.WriteLine("Ingrese 1 para ser privado, 2 para ser publico: ");
                    int privChoice = Convert.ToInt32(Console.ReadLine());

                    if (privChoice == 1)
                    {
                        newPriv = true; Console.Clear();
                        settingPrivacy = false;
                    }
                    if (privChoice == 2)
                    {
                        newPriv = false; Console.Clear();
                        settingPrivacy = false;

                    }
                    else { Console.WriteLine("Parametro invalido, por favor ingresar de nuevo. "); }
                }

                //Fijo parametro tipo de cuenta de Usuario. Si vale true es Premium, si vale false es Normal. 


                bool newIsPremium = true;

                bool settingAccountType = true;
                while (settingAccountType)
                {
                    Console.WriteLine("Ingrese 1 para ser Premium, 2 para ser Normal: ");
                    int privChoice = Convert.ToInt32(Console.ReadLine());

                    if (privChoice == 1)
                    {
                        newIsPremium = true; Console.Clear();
                        settingAccountType = false;
                    }
                    if (privChoice == 2)
                    {
                        newIsPremium = false; Console.Clear();
                        settingAccountType = false;

                    }
                    else { Console.WriteLine("Parametro invalido, por favor ingresar de nuevo. "); }
                }

                NPerson createdUser = new NPerson(newUserID, 0, newName, newLastName, newPassword, newMail, newDesc, newPriv, newIsPremium);
                this.Usuarios.Add(createdUser);

                Console.Clear();
                Console.WriteLine("Usuario creado con exito. ");
                creatingUser = false;
            }

        }

        
        
        
        ///aca para abajo meti funciones (Nico)
        
        public void NewVideo()
        {
            
            Console.WriteLine("Ingrese nombre: "); string newName = Console.ReadLine(); Console.Clear();
            Console.WriteLine("Ingrese genero "); string newGenre = Console.ReadLine(); Console.Clear();
            Console.WriteLine("Ingrese categoria: "); string newCategory = Console.ReadLine();
            Console.WriteLine("Ingrese director: "); string newDirector = Console.ReadLine(); Console.Clear();
            Console.WriteLine("Ingrese descripcion "); string newDescription = Console.ReadLine(); Console.Clear();
            Console.WriteLine("Ingrese actores: "); string newActor = Console.ReadLine(); //agregar metodo de agregar actores
            List<Actor> newListActors = new List<Actor>();
            
            int confirm = 0;
            foreach (Actor ac in newListActors)
            {
                if (ac.nombre == newActor)
                {
                    Console.WriteLine("El Actor ya esta ingresado");
                    confirm = 1;
                    break;
                }
            }
            if (confirm == 0)
            {
                //en proceso
                newListActors.Add(new Actor());
            }
            
            Console.WriteLine("Ingrese resolucion: "); int newResolution = Convert.ToInt32(Console.ReadLine()); Console.Clear();
            Console.WriteLine("Ingrese extencion de archivo: (ej: .mp4) "); string newExtention = Console.ReadLine(); Console.Clear();

            Video video = new Video(newName, newGenre, newCategory, newDirector, newDescription, newListActors, newResolution, newExtention);
        }
        
        static private void VideosSave(List<Video> VideoList)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Videos.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, VideoList);
            
            stream.Close();
        }
        static private List<Video> VideosLoad()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Videos.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Video> VideoList = (List<Video>)formatter.Deserialize(stream);
            
            stream.Close();
            return VideoList;
        }
        static private void PlaylistVideosSave(List<VideoPlaylist> PlaylistsVideo)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("VideoPlaylist.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, PlaylistsVideo);
            stream.Close();
        }
        static private List<VideoPlaylist> PlaylistVideosLoad()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("VideoPlaylist.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<VideoPlaylist> PlaylistVideoList = (List<VideoPlaylist>)formatter.Deserialize(stream);
            stream.Close();
            return PlaylistVideoList;
        }
    }
}
