using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace Entrega2
{
    public class Gestor
    {

        public void Register(DataBase data, string txtpath)
        {
            bool creatinguser = true, newpriv, newispremium;
            int choicenu, newuserid;
            string newmail, newpassword, newname, newlastname, newdesc;
            Console.Clear();
            while (creatinguser)
            {
                Console.Write("ingrese 1 para crear otro usuario, 2 para salir: ");
                choicenu = Convert.ToInt32(Console.ReadLine());

                if (choicenu == 1)
                {
                    //Para obtener ID de nuevo usuario, tomo lista de usuarios, cuento todos los que hay 
                    // y el ID del usuario que estoy creando simplemente es este numero + 1. (Ej. Si hay 10 usuarios, el ID del nuevo 
                    // valdra 11.) 
                    if (data.Users.Count == 0)
                        newuserid = 0;
                    else
                        newuserid = data.Users[data.Users.Count - 1].IDUser + 1;
                    Console.Write("Ingrese mail: "); newmail = Console.ReadLine(); Console.Clear();
                    Console.Write("Ingrese clave: "); newpassword = Console.ReadLine(); Console.Clear();
                    Console.Write("Ingrese nombre: "); newname = Console.ReadLine();
                    Console.Write("Ingrese apellido: "); newlastname = Console.ReadLine(); Console.Clear();
                    Console.Write("Ingrese descripcion: "); newdesc = Console.ReadLine(); Console.Clear();

                    //Fijo parametro privacidad de Usuario. Si vale true es privado, si vale false es publico. 

                    while (true)
                    {
                        Console.WriteLine("Ingrese 1 para ser privado, 2 para ser publico: ");
                        int privChoice = Convert.ToInt32(Console.ReadLine());

                        if (privChoice == 1)
                        {
                            newpriv = true; Console.Clear();
                            break;
                        }
                        if (privChoice == 2)
                        {
                            newpriv = false; Console.Clear();
                            break;

                        }
                        else { Console.WriteLine("Parametro invalido, por favor ingresar de nuevo. "); }
                    }

                    //Fijo parametro tipo de cuenta de Usuario. Si vale true es Premium, si vale false es Normal. 
                    while (true)
                    {
                        Console.WriteLine("Ingrese 1 para ser Premium, 2 para ser Normal: ");
                        int privChoice = Convert.ToInt32(Console.ReadLine());

                        if (privChoice == 1)
                        {
                            newispremium = true; Console.Clear();
                            break;
                        }
                        if (privChoice == 2)
                        {
                            newispremium = false; Console.Clear();
                            break;

                        }
                        else { Console.WriteLine("Parametro invalido, por favor ingresar de nuevo. "); }
                    }

                    NPerson createdUser = new NPerson(newuserid, newname, newlastname, newpassword, newmail, newdesc, newpriv, newispremium);
                    data.AddUserData(createdUser, txtpath);
                    Console.Clear();
                    Console.WriteLine("Usuario creado con exito. ");
                }

                else if (choicenu == 2)
                {
                    creatinguser = false;
                }
                else
                    Console.WriteLine("comando ingresado incorrecto porfavor vuelva a intentarlo!");
            }
        }

        public bool Login(DataBase data)
        {
            string candidatemail, candidatepassword;
            bool validmail = false, succesful_login = true;
            int intentos = 0, loginid = 0;
            Console.Clear();

            //Login funciona asi: usuario ingresa mail y gestor busca mails de todos los usuarios hasta encontrar
            //el mail que corresponde. luego pide contraseña y deja a usuario acceder si contraseña ingresada 
            //es igual a la guardada para aquel mail.

            //Primero pido mail usuario.

            //Pido los mails, cuando el que ingreso calza con alguno en la base de datos del gestor
            //guardo la contraseña de aquel usuario para ver que calce con la que ingreso.
            while (succesful_login)
            {
                while (true)
                {
                    if (intentos == 3)
                    {
                        Console.WriteLine("Alcanzo {0} intentos.", intentos);
                        Console.WriteLine("Volviendo al menu principal...");
                        Thread.Sleep(1000);
                        succesful_login = false;
                        break;
                    }
                    Console.Write("Ingrese Mail: "); candidatemail = Console.ReadLine();
                    foreach (NPerson us in data.Users)
                    {
                        if (us.Email == candidatemail)
                        {
                            Console.Write("Mail Valido."); Console.Clear();
                            loginid = us.IDUser;
                            validmail = true;
                            break;

                        }
                    }
                    //Sist. pide mail a usuario hasta que ingresa uno veridico. 
                    if (validmail == false)
                    {
                        Console.WriteLine("Correo Erroneo.");
                        intentos++;
                    }
                    else
                        break;
                }

                //Ahora checkeo contraseña.
                intentos = 0;
                while (succesful_login)
                {
                    if (intentos == 3)
                    {
                        Console.WriteLine("Alcanzo {0} intentos.", intentos);
                        Console.WriteLine("Volviendo al menu principal...");
                        Thread.Sleep(1000);
                        succesful_login = false;
                        break;
                    }
                    Console.Write("Ingrese Clave: "); candidatepassword = Console.ReadLine();
                    if (data.Users[loginid].Password == candidatepassword)
                    {
                        Console.WriteLine("Contraseña Valida."); Console.Clear();
                        break;
                    }

                    //Sist. pide password a usuario hasta que ingrese la que corresponde.

                    else
                    {
                        Console.WriteLine("Contraseña Invalida.");
                        intentos++;
                    }
                }
                Console.Clear();
                break;
            }
            return succesful_login;
        }

        public bool Menu(DataBase data, WaveOutEvent outputdevice, string userpath, string songpath)
        {
            string candidatemail, candidatepassword, datatochange, retry, songchoice, songplayeroption, deletechoice;
            int logchoice, input, i = 0, nextsong;
            AudioFileReader songfile;
            bool access = false;

            Console.Clear();

            ///FUNCIONALIDADES DENTRO DE LOGIN:

            Console.WriteLine("1. Ver datos de todos los usuarios: ");
            Console.WriteLine("2. Actualizar Datos: ");
            Console.WriteLine("3. Su rollita?: ");
            Console.WriteLine("4. trae cabritas: ");
            Console.WriteLine("5. Ver Seguidos: ");
            Console.WriteLine("6. Ver Seguidores: ");
            Console.WriteLine("7. Seguir a otros usuarios: ");
            Console.WriteLine("8. Eliminar Perfil: ");
            Console.WriteLine("9. Volver a Menu Principal: ");

            logchoice = Convert.ToInt32(Console.ReadLine());

            switch (logchoice)
            {
                //Ver datos de todos los usuarios: 

                case 1:

                    Console.Clear();
                    Console.WriteLine("Datos de todos los perfiles publicos existentes: ");

                    foreach (NPerson us in data.Users)
                    {
                        if (!us.Private)
                            Console.WriteLine("Name:{0}\nLast Name:{1}\nEmail:{2}\nDescription:{3}\nAccount upgrade status:{4}\n", us.Name, us.LastName, us.Email, us.Description, us.Premium);
                        Thread.Sleep(500);
                    }
                    Thread.Sleep(2000);
                    Console.WriteLine("Presione enter para continuar."); ; Console.ReadKey();
                    break;


                //Actualizar datos, que llama a metodo propio de usuario que permite hacer esto.

                case 2:

                    bool changeData = true;
                    while (changeData)
                    {
                    wrong_input:
                        Console.WriteLine("porfavor ingrese sus datos para continuar:");
                        Console.Write("Correo:"); candidatemail = Console.ReadLine();
                        Console.Write("Contraseña:"); candidatepassword = Console.ReadLine();
                        foreach (NPerson us in data.Users)
                        {

                            if ((candidatemail == us.Email) && (candidatepassword == us.Password))
                            {
                            wrong_input1:
                                access = true;
                                Console.WriteLine("Ingrese numero de parametro a modificar, ingrese 8 para salir: ");
                                Console.WriteLine("[1]Name:{0}\n[2]Last Name:{1}\n[3]Password:{2}\n[4]Email:{3}\n[5]Description:{4}\n[6]Account privacy status:{5}\n[7]Account upgrade status:{6}\n", us.Name, us.LastName, us.Password, us.Email, us.Description, us.Private, us.Premium);
                                input = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                if ((input < 1) && (input > 8))
                                {
                                    Console.WriteLine("Dato Ingresado erroneo, porfavor vuelva a intentarlo");
                                    goto wrong_input1;
                                }
                                else if (input == 8)
                                    break;

                                else
                                {
                                    Console.Write("Ingrese la nueva informacion:"); datatochange = Console.ReadLine();
                                    data.UserDataChange(us, input, datatochange, userpath);
                                    Console.WriteLine("Name:{0}\nLast Name:{1}\nPassword:{2}\nEmail:{3}\nDescription:{4}\nAccount privacy status:{5}\nAccount upgrade status:{6}\n", us.Name, us.LastName, us.Password, us.Email, us.Description, us.Private, us.Premium);
                                wrong_input2:
                                    Console.WriteLine("Desea cambiar algo mas?\nSi\nNo");
                                    retry = Console.ReadLine();
                                    if ((retry == "SI") || (retry == "Si") || (retry == "sI") || (retry == "Sí") || (retry == "si"))
                                        goto wrong_input1;
                                    else if ((retry == "NO") || (retry == "No") || (retry == "nO") || (retry == "no"))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("La opcion elegida no existe! vuelva a intentarlo");
                                        goto wrong_input2;
                                    }
                                }
                            }
                        }
                        if (access == false)
                        {
                        wrong_input3:
                            Console.WriteLine("Correo o Contraseña invalidos!");
                            Console.WriteLine("Desea volver a intentarlo?\nSi\nNo");
                            retry = Console.ReadLine();
                            if ((retry == "SI") || (retry == "Si") || (retry == "sI") || (retry == "Sí"))
                                goto wrong_input;
                            else if ((retry == "NO") || (retry == "No") || (retry == "nO"))
                                break;
                            else
                            {
                                Console.WriteLine("La opcion elegida no existe! vuelva a intentarlo");
                                goto wrong_input3;
                            }
                        }
                        else
                            break;

                    }
                    break;

                //Buscar contenido, que permite al usuario buscar algun contenido en el gestor.

                case 3:

                    foreach (Song sonG in data.Song)
                    {
                        i++;
                        Console.WriteLine("[{0}] {1}", i, sonG.Name);

                    }
                song_choice:
                    Console.WriteLine("Seleccione una cancion para reproducirla."); songchoice = Console.ReadLine();
                    if (songchoice == "1")
                    {
                        songfile = new AudioFileReader(songpath + data.Song[0].Name);
                        outputdevice.Init(songfile);
                        data.Song[0].PlaySong(outputdevice);
                    }
                    else if (songchoice == "2")
                    {
                        songfile = new AudioFileReader(songpath + data.Song[1].Name);
                        outputdevice.Init(songfile);
                        data.Song[0].PlaySong(outputdevice);
                    }
                    else if (songchoice == "3")
                    {
                        songfile = new AudioFileReader(songpath + data.Song[2].Name);
                        outputdevice.Init(songfile);
                        data.Song[0].PlaySong(outputdevice);
                    }
                    else
                    {
                        Console.WriteLine("No existe esa cancion , vuelva a intentarlo");
                        goto song_choice;
                    }
                    //song_choice1:
                    while (songchoice != "4")
                    {
                        Console.WriteLine("Opciones\n[1]Pausa.\n[2]Play another song\n[3]Adelantar/retroceder\n[4]Play\n[5]Restart\n[6]Close program");
                        songplayeroption = Console.ReadLine();
                        if (songplayeroption == "1")
                        {
                            data.Song[0].PauseSong(outputdevice);
                        }
                        else if (songplayeroption == "2")
                        {
                            i = 0;
                            foreach (Song sonG in data.Song)
                            {
                                i++;
                                Console.WriteLine("[{0}] {1}", i, sonG.Name);

                            }
                            Console.WriteLine("Seleccione una cancion para reproducirla.");
                            nextsong = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(data.Song.Count);
                            Console.WriteLine(nextsong - 1);
                            songfile = new AudioFileReader(songpath + data.Song[nextsong - 1].Name);
                            data.Song[nextsong - 1].SkiptoSong(outputdevice, songfile);
                        }
                        else if (songplayeroption == "3")
                        {
                            double seconds = Convert.ToDouble(Console.ReadLine());
                            data.Song[0].Forwards_Backwards(songfile, seconds);
                        }
                        else if (songplayeroption == "4")
                        {
                            data.Song[0].PlaySong(outputdevice);
                        }
                        else if (songplayeroption == "5")
                        {
                            data.Song[0].Forwards_Backwards(songfile, 0);
                        }
                        else if (songplayeroption == "6")
                        {
                            outputdevice.Stop();
                            outputdevice.Dispose();
                            Console.WriteLine("Cerrando reproductor de musica...");
                            Thread.Sleep(1000);
                            break;
                        }
                    }
                    break;
                //IMPLEMENTAR BUSQUEDA DE CONTENIDO ACA.


                //Ver seguidos, que llama a metodo de usuario que permite hacer esto. 

                /*
                case 5:

                    Console.WriteLine("Lista de Seguidos: ");
                    Console.WriteLine("\n");

                    for (int i = 0; i < GestorReprod.Usuarios[loginid].UsuariosSeguidos.Count(); i++)
                    {
                        Console.WriteLine(Convert.ToString(i) + ". " + GestorReprod.Usuarios[loginid].UsuariosSeguidos[i].nombre + " " + GestorReprod.Usuarios[loginid].UsuariosSeguidos[i].apellido);//Show info.
                        Thread.Sleep(2000);
                    }

                    break;


                //Ver seguidores. 


                case 6:

                    Console.WriteLine("Lista de Seguidores: ");
                    Console.WriteLine("\n");

                    for (int i = 0; i < GestorReprod.Usuarios[loginid].Seguidores.Count(); i++)
                    {
                        Console.WriteLine(Convert.ToString(i) + ". " + GestorReprod.Usuarios[loginid].Seguidores[i].nombre + " " + GestorReprod.Usuarios[loginid].Seguidores[i].apellido);
                        Thread.Sleep(2000);
                    }

                    break;



                //Seguir usuarios. Para este caso, decidi construir el metodo aca mismo. 

                case 7:

                    following = true;
                    while (following)

                    {
                        //Muestro nombre de todos los usuarios en sistema.

                        Console.Clear();
                        Console.WriteLine("Lista de Usuarios: ");

                        for (int i = 0; i < GestorReprod.Usuarios.Count(); i++)
                        {
                            Console.WriteLine(Convert.ToString(i) + ". " + GestorReprod.Usuarios[i].nombre + " " + GestorReprod.Usuarios[i].apellido);
                        }

                        //Pido cual quiero seguir. 

                        Console.WriteLine("Ingrese numero de usuario a seguir: ");
                        Console.WriteLine("Si desea salir, ingrese 0. ");


                        followid = Convert.ToInt32(Console.ReadLine());
                        if (followid == 0)
                        {
                            following = false;
                            break;
                        }


                        //Lo sigo. 

                        Console.WriteLine("Usuario seguido con exito. ");

                        //Agrego el usuario que opera como seguidor en el usuario al que segui. 



                        Thread.Sleep(1500);
                    }

                    break;
                    */


                //Opcion de eliminar perfil. 

                case 8:
                    while (true)
                    {
                        Console.Clear();
                        access = false;
                        Console.WriteLine("1. Confirme eliminar perfil. ");
                        Console.WriteLine("2. Cancelar. ");
                        deletechoice = Console.ReadLine();

                        if (Convert.ToInt32(deletechoice) == 1)
                        {
                        wrong_input4:
                            Console.WriteLine("porfavor ingrese sus datos para continuar:");
                            Console.Write("Correo:"); candidatemail = Console.ReadLine();
                            Console.Write("Contraseña:"); candidatepassword = Console.ReadLine();
                            foreach (NPerson us in data.Users)
                            {
                                if ((candidatemail == us.Email) && (candidatepassword == us.Password))
                                {
                                    data.UserDelete(us, userpath);
                                    access = true;
                                    Thread.Sleep(1500);
                                    Console.WriteLine("Perfil eliminado con exito. ");
                                    Thread.Sleep(1000);
                                    return false;
                                }
                            }
                            if (access == false)
                            {
                            wrong_input5:
                                Console.WriteLine("Correo o Contraseña invalidos!");
                                Console.WriteLine("Desea volver a intentarlo?\nSi\nNo");
                                retry = Console.ReadLine();
                                if ((retry == "SI") || (retry == "Si") || (retry == "sI") || (retry == "Sí") || (retry == "si"))
                                    goto wrong_input4;
                                else if ((retry == "NO") || (retry == "No") || (retry == "nO") || (retry == "no"))
                                    return true;
                                else
                                {
                                    Console.WriteLine("La opcion elegida no existe! vuelva a intentarlo");
                                    goto wrong_input5;
                                }
                            }
                        }
                        if (Convert.ToInt32(deletechoice) == 2)
                        {
                            return true;
                        }
                        else
                            Console.WriteLine("Comando invalido.");
                    }

                //Opcion de escape. Me retorna a menu principal. 

                case 9:
                    Console.Clear();
                    return false;
            }
            return true;
        }

        public void FilesReader(DataBase data, string userspath, string songspath , string playlistspath)
        {
            string s;
            int i = 0 , j = 0;
            List<string> info = new List<string>();
            Playlist playlist;
            using (StreamReader sr = File.OpenText(userspath))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    info.Add(s);
                    i++;
                    if (i == 8)
                    {
                        data.Users.Add(new NPerson(Convert.ToInt32(info[0]), info[1], info[2], info[3], info[4], info[5], Convert.ToBoolean(info[6]), Convert.ToBoolean(info[7])));
                        i = 0;
                        info.Clear();
                    }
                }
            }
            using (StreamReader sr = File.OpenText(songspath))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    info.Add(s);
                    i++;
                    if (i == 6)
                    {
                        data.Song.Add(new Song(info[0], info[1], info[2], info[3], info[4], info[5]));
                        i = 0;
                        info.Clear();
                    }
                }
            }
            foreach(NPerson us in data.Users){
                if(File.Exists(playlistspath.Replace("num",Convert.ToString(j)))){
                    using (StreamReader sr = File.OpenText(playlistspath.Replace("num","0")))
                    {
                        while ((s = sr.ReadLine()) != null)
                        {
                            info.Add(s);
                            if (i == 2)
                            {
                                playlist = new Playlist(info[0], Convert.ToBoolean(info[1]), info[2]);
                                info.Clear();
                                i = 0;
                                while ((s = sr.ReadLine()) != "/-*")
                                {
                                    info.Add(s);
                                    i++;
                                    if (i == 6)
                                    {
                                        playlist.AddToThisPlaylist(new Song(info[0], info[1], info[2], info[3], info[4], info[5]));
                                        i = 0;
                                        info.Clear();
                                    }
                                }
                                data.playlists.Add(playlist);
                            }
                            i++;
                        }
                    }
                }
                j++;
            }
        }
        public List<string> obtenerArchivosDirectorio(string rutaArchivo)
        {

            List<string> listaRuta = new List<string>();

            listaRuta = Directory.GetFiles(Path.GetDirectoryName(rutaArchivo), Path.GetFileName(rutaArchivo)).ToList();

            return listaRuta;
        }
        ///aca para abajo meti funciones (Nico)
        /*public void NewVideo()
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
        }*/
    }
}
