using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq.Expressions;

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
                Console.Write("Ingrese 1 para crear otro usuario, 2 para salir: ");
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
                    data.Users.Add(createdUser);
                    //serializacion de usuarios
                    UsersSave(data.Users);
                    Console.Clear();
                    Console.WriteLine("Usuario creado con exito. ");
                    Thread.Sleep(2000);
                }

                else if (choicenu == 2)
                {
                    creatinguser = false;
                }
                else
                    Console.WriteLine("comando ingresado incorrecto porfavor vuelva a intentarlo!");
            }
        }

        public Tuple<string, bool> Login(DataBase data,ref int loginidd)
        {
            string candidatemail, candidatepassword;
            bool validmail = false, succesful_login1 = true;
            int intentos = 0, loginid = 0;
            Console.Clear();

            //Login funciona asi: usuario ingresa mail y gestor busca mails de todos los usuarios hasta encontrar
            //el mail que corresponde. luego pide contraseña y deja a usuario acceder si contraseña ingresada 
            //es igual a la guardada para aquel mail.

            //Primero pido mail usuario.

            //Pido los mails, cuando el que ingreso calza con alguno en la base de datos del gestor
            //guardo la contraseña de aquel usuario para ver que calce con la que ingreso.
            string asdf = "";
            while (succesful_login1)
            {
                while (true)
                {
                    if (intentos == 3)
                    {
                        Console.WriteLine("Alcanzo {0} intentos.", intentos);
                        Console.WriteLine("Volviendo al menu principal...");
                        Thread.Sleep(1000);
                        succesful_login1 = false;
                        break;
                    }
                    Console.Write("Ingrese Mail: "); candidatemail = Console.ReadLine();
                    foreach (NPerson us in data.Users)
                    {
                        if (us.Email == candidatemail)
                        {
                            Console.Write("Mail Valido."); Console.Clear();
                            loginid = us.IDUser;
                            loginidd = us.IDUser;
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
                while (succesful_login1)
                {
                    if (intentos == 3)
                    {
                        Console.WriteLine("Alcanzo {0} intentos.", intentos);
                        Console.WriteLine("Volviendo al menu principal...");
                        Thread.Sleep(1000);
                        succesful_login1 = false;
                        
                        break;
                    }
                    Console.Write("Ingrese Clave: "); candidatepassword = Console.ReadLine();
                    if (data.Users[loginid].Password == candidatepassword)
                    {
                        Console.WriteLine("Contraseña Valida."); Console.Clear();
                        asdf = data.Users[loginid].Email;
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
            
            Tuple < string, bool > succesful_login = new Tuple<string, bool>(asdf, succesful_login1);
            return succesful_login;
        }

        public bool Menu(DataBase data, WaveOutEvent outputdevice, string userpath, string songpath , string playlistpath, string mailuser , int id)//agregue como parametro mailuser para saber en que usuario estamos
        {

            string candidatemail, candidatepassword, datatochange, retry , deletechoice;
            string playlistname , playlistdate , searchsong , actualgenre = "" , s;
            int logchoice, input, i = 0, nextsong , songplayeroption , songplayeroption2 , searchoice , j = 0;
            int toplaylist, songplayeroption3;
            bool access = false , privateplaylist = false;
            AudioFileReader songfile;
            SongPlaylist pl;
            List<Song> searchcriteria = new List<Song>();
            List<string> info = new List<string>();

            Console.Clear();

            ///FUNCIONALIDADES DENTRO DE LOGIN:

            Console.WriteLine("1. Ver datos de todos los usuarios: ");
            Console.WriteLine("2. Actualizar Datos: ");
            Console.WriteLine("3. Menu Canciones: ");
            Console.WriteLine("4. Menu Videos: ");
            Console.WriteLine("5. Ver Usuarios Seguidos");
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
                    Console.Clear();
                    Console.WriteLine("                                      Bienvenido al reproductor de musica                                       ");
                    Console.WriteLine("Seleccione un tipo de busqueda de cancion para continuar:");
                    while (true)
                    {
                        criterio:
                        Console.WriteLine("1. Nombre de la cancion.");
                        Console.WriteLine("2. Album.");
                        Console.WriteLine("3. Artist.");
                        Console.WriteLine("4. Genre.");
                        Console.WriteLine("5. Year published.");
                        Console.Write("Seleccione un criterio de busqueda:"); searchoice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ingrese info:");searchsong = Console.ReadLine();
                        switch(searchoice)
                        {
                            case 1:
                                j = 0;
                                foreach (Song sg in data.Song)
                                {
                                    if (((searchsong + ".mp3") == sg.Name) || ((searchsong + ".mp4") == sg.Name) || ((searchsong + ".wav") == sg.Name))
                                    {
                                        Console.WriteLine("Resultado de busqueda:");
                                        Console.WriteLine("Nombre: {0}", sg.Name);
                                        Console.WriteLine("Album: {0}", sg.Album);
                                        Console.WriteLine("Artista: {0}", sg.Artists);
                                        Console.WriteLine("Year: {0}", sg.Year);
                                        Console.WriteLine("Desea reproducir la cancion?");
                                        Console.WriteLine("1. Reproducir");
                                        //Console.WriteLine("2. Agregar a playlist");
                                        Console.WriteLine("2. Salir");
                                        Console.Write("Ingrese opcion:"); songplayeroption = Convert.ToInt32(Console.ReadLine());
                                        switch (songplayeroption)
                                        {
                                            case 1:
                                                if (outputdevice.PlaybackState == PlaybackState.Playing)
                                                {
                                                    songfile = new AudioFileReader(songpath + data.Song[j].Name);
                                                    data.Song[j].SkiptoSong(outputdevice, songfile);
                                                }
                                                else
                                                {
                                                    songfile = new AudioFileReader(songpath + data.Song[j].Name);
                                                    outputdevice.Init(songfile);
                                                    data.Song[j].PlaySong(outputdevice);
                                                }
                                                while (true)
                                                {
                                                    Console.WriteLine("Que desea hacer?");
                                                    Console.WriteLine("1. Pausa.");
                                                    Console.WriteLine("2. Play another song.");
                                                    Console.WriteLine("3. Adelantar/Retroceder.");
                                                    Console.WriteLine("4. Play.");
                                                    Console.WriteLine("5. Restart Song.");
                                                    Console.WriteLine("6. Create PlayList");
                                                    Console.WriteLine("7. Mis Playlists");
                                                    Console.WriteLine("8. Busqueda de Cancion.");
                                                    Console.WriteLine("9. Close Program.");
                                                    Console.Write("Ingrese opcion:"); songplayeroption2 = Convert.ToInt32(Console.ReadLine());
                                                    switch (songplayeroption2)
                                                    {
                                                        case 1:
                                                            data.Song[0].PauseSong(outputdevice);
                                                            break;
                                                        case 2:
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
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("Ingrese el tiempo en segundos:");
                                                            double seconds = Convert.ToDouble(Console.ReadLine());
                                                            data.Song[0].Forwards_Backwards(songfile, seconds);
                                                            break;
                                                        case 4:
                                                            data.Song[0].PlaySong(outputdevice);
                                                            break;
                                                        case 5:
                                                            data.Song[0].Forwards_Backwards(songfile, 0);
                                                            break;
                                                        case 6:
                                                            Console.Write("Ingrese el nombre de la playlist:"); playlistname = Console.ReadLine();
                                                            Console.Write("Playlist privada? true/false:"); privateplaylist = Convert.ToBoolean(Console.ReadLine());
                                                            Console.Write("Fecha de creacion:"); playlistdate = Console.ReadLine();
                                                            pl = new SongPlaylist(playlistname, privateplaylist, playlistdate);
                                                            j = 1;
                                                        another_song:
                                                            foreach (Song sgg in data.Song)
                                                            {
                                                                Console.WriteLine("{0}. Nombre: {1}", j, sgg.Name);
                                                                Console.WriteLine("Album: {0}", sgg.Album);
                                                                Console.WriteLine("Artista: {0}", sgg.Artists);
                                                                Console.WriteLine("Year: {0}", sgg.Year);
                                                                Console.WriteLine("Genero:{0}", sgg.Genre);
                                                                Console.WriteLine("\n");
                                                                j++;
                                                            }
                                                            Console.Write("Elija la canciones a agregar:"); toplaylist = Convert.ToInt32(Console.ReadLine());
                                                            pl.AddToThisPlaylist(new Song(data.Song[toplaylist - 1].Name, data.Song[toplaylist - 1].Album, data.Song[toplaylist - 1].Artists, data.Song[toplaylist - 1].Genre, data.Song[toplaylist - 1].Year, data.Song[toplaylist - 1].Lyrics));
                                                            Console.WriteLine("Desea agregar otra cancion?\n1. Si\n2. No"); toplaylist = Convert.ToInt32(Console.ReadLine());
                                                            j = 1;
                                                            if (toplaylist == 1) goto another_song;
                                                            else
                                                                data.AddPlaylist(pl, playlistpath.Replace("num", Convert.ToString(id)));
                                                            j = 0;
                                                            break;
                                                        case 7:
                                                            if (File.Exists(playlistpath.Replace("num", Convert.ToString(id))))
                                                            {

                                                                using (StreamReader sr = File.OpenText(playlistpath.Replace("num", Convert.ToString(id))))
                                                                {
                                                                    while ((s = sr.ReadLine()) != null)
                                                                    {
                                                                        info.Add(s);
                                                                        i++;
                                                                        if (i == 3)
                                                                        {
                                                                            pl = new SongPlaylist(info[0], Convert.ToBoolean(info[1]), info[2]);
                                                                            info.Clear();
                                                                            i = 0;
                                                                            while ((s = sr.ReadLine()) != "/-*")
                                                                            {
                                                                                info.Add(s);
                                                                                i++;
                                                                                if (i == 6)
                                                                                {
                                                                                    pl.AddToThisPlaylist(new Song(info[0], info[1], info[2], info[3], info[4], info[5]));
                                                                                    i = 0;
                                                                                    info.Clear();
                                                                                }
                                                                            }
                                                                            data.thisuserplaylist.Add(pl);
                                                                        }
                                                                    }
                                                                }
                                                                foreach (SongPlaylist sp in data.thisuserplaylist)
                                                                {
                                                                    Console.WriteLine("               {0}                  ", sp.Name);
                                                                    j = 1;
                                                                    foreach (Song sgg in sp.ActualPlaylist)
                                                                    {
                                                                        Console.WriteLine("{0}. Nombre: {1}", j, sgg.Name);
                                                                        Console.WriteLine("Album: {0}", sgg.Album);
                                                                        Console.WriteLine("Artista: {0}", sgg.Artists);
                                                                        Console.WriteLine("Year: {0}", sgg.Year);
                                                                        Console.WriteLine("Genero:{0}", sgg.Genre);
                                                                        Console.WriteLine("\n");
                                                                        j++;
                                                                    }
                                                                    Console.WriteLine("Desea reproducir alguna cancion?\n1. Si\n2. No");
                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                another:
                                                                    if (songplayeroption3 == 1)
                                                                    {
                                                                        Console.Write("Ingrese el nombre de la cancion:");
                                                                        searchsong = Console.ReadLine();
                                                                        foreach (Song ssg in data.Song)
                                                                        {
                                                                            if (((searchsong + ".mp3") == ssg.Name) || ((searchsong + ".mp4") == ssg.Name) || ((searchsong + ".wav") == ssg.Name))
                                                                            {
                                                                                if (outputdevice.PlaybackState == PlaybackState.Playing)
                                                                                {
                                                                                    songfile = new AudioFileReader(songpath + ssg.Name);
                                                                                    data.Song[j].SkiptoSong(outputdevice, songfile);
                                                                                    Console.WriteLine("Desea reproducir otra cancion de la playlist actuañ?\n1. Si\n2. No");
                                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                                    if (songplayeroption3 == 1) goto another;
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Siguiente Playlist");
                                                                                        Thread.Sleep(1000);
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    songfile = new AudioFileReader(songpath + ssg.Name);
                                                                                    outputdevice.Init(songfile);
                                                                                    data.Song[j].PlaySong(outputdevice);
                                                                                    Console.WriteLine("Desea reproducir otra cancion de la playlist actual?\n1. Si\n2. No");
                                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                                    if (songplayeroption3 == 1) goto another;
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Siguiente Playlist");
                                                                                        Thread.Sleep(1000);
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                data.thisuserplaylist.Clear();
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Aun no has creado ninguna playlist!!!");
                                                            }
                                                            break;
                                                        case 8:
                                                            goto criterio;
                                                        case 9:
                                                            outputdevice.Stop();
                                                            outputdevice.Dispose();
                                                            Console.WriteLine("Cerrando reproductor de musica...");
                                                            Thread.Sleep(1000);
                                                            break;
                                                    }
                                                    if (songplayeroption2 == 9)
                                                        break;
                                                }
                                                break;
                                            /*case 2:
                                                break;*/
                                            case 2:
                                                outputdevice.Stop();
                                                outputdevice.Dispose();
                                                Console.WriteLine("Cerrando reproductor de musica...");
                                                Thread.Sleep(1000);
                                                break;
                                        }
                                    }
                                    j++;
                                }
                                break;
                            case 2:
                                foreach (Song sg in data.Song)
                                {
                                    if (searchsong == sg.Album)
                                    {
                                        searchcriteria.Add(sg);
                                    }
                                }
                                foreach (Song sg in searchcriteria)
                                {
                                    Console.WriteLine("Resultado de busqueda:");
                                    Console.WriteLine("Nombre: {0}", sg.Name);
                                    Console.WriteLine("Album: {0}", sg.Album);
                                    Console.WriteLine("Year: {0}", sg.Year);
                                }
                                searchcriteria.Clear();
                                Console.Write("Elija una cancion:"); searchsong = Console.ReadLine();
                                j = 0;
                                foreach (Song sg in data.Song)
                                {
                                    if (((searchsong + ".mp3") == sg.Name) || ((searchsong + ".mp4") == sg.Name) || ((searchsong + ".wav") == sg.Name))
                                    {
                                        Console.WriteLine("Desea reproducir la cancion?");
                                        Console.WriteLine("1. Reproducir");
                                        //Console.WriteLine("2. Agregar a playlist");
                                        Console.WriteLine("2. Salir");
                                        Console.Write("Ingrese opcion:"); songplayeroption = Convert.ToInt32(Console.ReadLine());
                                        switch (songplayeroption)
                                        {
                                            case 1:
                                                if (outputdevice.PlaybackState == PlaybackState.Playing)
                                                {
                                                    songfile = new AudioFileReader(songpath + data.Song[j].Name);
                                                    data.Song[j].SkiptoSong(outputdevice, songfile);
                                                }
                                                else
                                                {
                                                    songfile = new AudioFileReader(songpath + data.Song[j].Name);
                                                    outputdevice.Init(songfile);
                                                    data.Song[j].PlaySong(outputdevice);
                                                }
                                                while (true)
                                                {
                                                    Console.WriteLine("Que desea hacer?");
                                                    Console.WriteLine("1. Pausa.");
                                                    Console.WriteLine("2. Play another song.");
                                                    Console.WriteLine("3. Adelantar/Retroceder.");
                                                    Console.WriteLine("4. Play.");
                                                    Console.WriteLine("5. Restart Song.");
                                                    Console.WriteLine("6. Create PlayList");
                                                    Console.WriteLine("7. Mis Playlists");
                                                    Console.WriteLine("8. Busqueda de Cancion.");
                                                    Console.WriteLine("9. Close Program.");
                                                    Console.Write("Ingrese opcion:"); songplayeroption2 = Convert.ToInt32(Console.ReadLine());
                                                    switch (songplayeroption2)
                                                    {
                                                        case 1:
                                                            data.Song[0].PauseSong(outputdevice);
                                                            break;
                                                        case 2:
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
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("Ingrese el tiempo en segundos:");
                                                            double seconds = Convert.ToDouble(Console.ReadLine());
                                                            data.Song[0].Forwards_Backwards(songfile, seconds);
                                                            break;
                                                        case 4:
                                                            data.Song[0].PlaySong(outputdevice);
                                                            break;
                                                        case 5:
                                                            data.Song[0].Forwards_Backwards(songfile, 0);
                                                            break;
                                                        case 6:
                                                            Console.Write("Ingrese el nombre de la playlist:"); playlistname = Console.ReadLine();
                                                            Console.Write("Playlist privada? true/false:"); privateplaylist = Convert.ToBoolean(Console.ReadLine());
                                                            Console.Write("Fecha de creacion:"); playlistdate = Console.ReadLine();
                                                            pl = new SongPlaylist(playlistname, privateplaylist, playlistdate);
                                                            j = 1;
                                                        another_song:
                                                            foreach (Song sgg in data.Song)
                                                            {
                                                                Console.WriteLine("{0}. Nombre: {1}", j, sgg.Name);
                                                                Console.WriteLine("Album: {0}", sgg.Album);
                                                                Console.WriteLine("Artista: {0}", sgg.Artists);
                                                                Console.WriteLine("Year: {0}", sgg.Year);
                                                                Console.WriteLine("Genero:{0}", sgg.Genre);
                                                                Console.WriteLine("\n");
                                                                j++;
                                                            }
                                                            Console.Write("Elija la canciones a agregar:"); toplaylist = Convert.ToInt32(Console.ReadLine());
                                                            pl.AddToThisPlaylist(new Song(data.Song[toplaylist - 1].Name, data.Song[toplaylist - 1].Album, data.Song[toplaylist - 1].Artists, data.Song[toplaylist - 1].Genre, data.Song[toplaylist - 1].Year, data.Song[toplaylist - 1].Lyrics));
                                                            Console.WriteLine("Desea agregar otra cancion?\n1. Si\n2. No"); toplaylist = Convert.ToInt32(Console.ReadLine());
                                                            j = 1;
                                                            if (toplaylist == 1) goto another_song;
                                                            else
                                                                data.AddPlaylist(pl, playlistpath.Replace("num", Convert.ToString(id)));
                                                            j = 0;
                                                            break;
                                                        case 7:
                                                            if (File.Exists(playlistpath.Replace("num", Convert.ToString(id))))
                                                            {

                                                                using (StreamReader sr = File.OpenText(playlistpath.Replace("num", Convert.ToString(id))))
                                                                {
                                                                    while ((s = sr.ReadLine()) != null)
                                                                    {
                                                                        info.Add(s);
                                                                        i++;
                                                                        if (i == 3)
                                                                        {
                                                                            pl = new SongPlaylist(info[0], Convert.ToBoolean(info[1]), info[2]);
                                                                            info.Clear();
                                                                            i = 0;
                                                                            while ((s = sr.ReadLine()) != "/-*")
                                                                            {
                                                                                info.Add(s);
                                                                                i++;
                                                                                if (i == 6)
                                                                                {
                                                                                    pl.AddToThisPlaylist(new Song(info[0], info[1], info[2], info[3], info[4], info[5]));
                                                                                    i = 0;
                                                                                    info.Clear();
                                                                                }
                                                                            }
                                                                            data.thisuserplaylist.Add(pl);
                                                                        }
                                                                    }
                                                                }
                                                                foreach (SongPlaylist sp in data.thisuserplaylist)
                                                                {
                                                                    Console.WriteLine("               {0}                  ", sp.Name);
                                                                    j = 1;
                                                                    foreach (Song sgg in sp.ActualPlaylist)
                                                                    {
                                                                        Console.WriteLine("{0}. Nombre: {1}", j, sgg.Name);
                                                                        Console.WriteLine("Album: {0}", sgg.Album);
                                                                        Console.WriteLine("Artista: {0}", sgg.Artists);
                                                                        Console.WriteLine("Year: {0}", sgg.Year);
                                                                        Console.WriteLine("Genero:{0}", sgg.Genre);
                                                                        Console.WriteLine("\n");
                                                                        j++;
                                                                    }
                                                                    Console.WriteLine("Desea reproducir alguna cancion?\n1. Si\n2. No");
                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                another:
                                                                    if (songplayeroption3 == 1)
                                                                    {
                                                                        Console.Write("Ingrese el nombre de la cancion:");
                                                                        searchsong = Console.ReadLine();
                                                                        foreach (Song ssg in data.Song)
                                                                        {
                                                                            if (((searchsong + ".mp3") == ssg.Name) || ((searchsong + ".mp4") == ssg.Name) || ((searchsong + ".wav") == ssg.Name))
                                                                            {
                                                                                if (outputdevice.PlaybackState == PlaybackState.Playing)
                                                                                {
                                                                                    songfile = new AudioFileReader(songpath + ssg.Name);
                                                                                    data.Song[j].SkiptoSong(outputdevice, songfile);
                                                                                    Console.WriteLine("Desea reproducir otra cancion de la playlist actuañ?\n1. Si\n2. No");
                                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                                    if (songplayeroption3 == 1) goto another;
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Siguiente Playlist");
                                                                                        Thread.Sleep(1000);
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    songfile = new AudioFileReader(songpath + ssg.Name);
                                                                                    outputdevice.Init(songfile);
                                                                                    data.Song[j].PlaySong(outputdevice);
                                                                                    Console.WriteLine("Desea reproducir otra cancion de la playlist actual?\n1. Si\n2. No");
                                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                                    if (songplayeroption3 == 1) goto another;
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Siguiente Playlist");
                                                                                        Thread.Sleep(1000);
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                data.thisuserplaylist.Clear();
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Aun no has creado ninguna playlist!!!");
                                                            }
                                                            break;
                                                        case 8:
                                                            goto criterio;
                                                        case 9:
                                                            outputdevice.Stop();
                                                            outputdevice.Dispose();
                                                            Console.WriteLine("Cerrando reproductor de musica...");
                                                            Thread.Sleep(1000);
                                                            break;
                                                    }
                                                    if (songplayeroption2 == 9)
                                                        break;
                                                }
                                                break;
                                            /*case 2:
                                                break;*/
                                            case 2:
                                                outputdevice.Stop();
                                                outputdevice.Dispose();
                                                Console.WriteLine("Cerrando reproductor de musica...");
                                                Thread.Sleep(1000);
                                                break;
                                        }
                                    }
                                    j++;
                                }
                                break;
                            case 3:
                                foreach (Song sg in data.Song)
                                {
                                    if (searchsong == sg.Artists)
                                    {
                                        searchcriteria.Add(sg);
                                    }
                                }
                                foreach (Song sg in searchcriteria)
                                {
                                    Console.WriteLine("Resultado de busqueda:");
                                    Console.WriteLine("Nombre: {0}", sg.Name);
                                    Console.WriteLine("Album: {0}", sg.Album);
                                    Console.WriteLine("Year: {0}", sg.Year);
                                }
                                searchcriteria.Clear();
                                Console.Write("Elija una cancion:"); searchsong = Console.ReadLine();
                                j = 0;
                                foreach (Song sg in data.Song)
                                {
                                    if (((searchsong + ".mp3") == sg.Name) || ((searchsong + ".mp4") == sg.Name) || ((searchsong + ".wav") == sg.Name))
                                    {
                                        Console.WriteLine("Desea reproducir la cancion?");
                                        Console.WriteLine("1. Reproducir");
                                        //Console.WriteLine("2. Agregar a playlist");
                                        Console.WriteLine("2. Salir");
                                        Console.Write("Ingrese opcion:"); songplayeroption = Convert.ToInt32(Console.ReadLine());
                                        switch (songplayeroption)
                                        {
                                            case 1:
                                                if (outputdevice.PlaybackState == PlaybackState.Playing)
                                                {
                                                    songfile = new AudioFileReader(songpath + data.Song[j].Name);
                                                    data.Song[j].SkiptoSong(outputdevice, songfile);
                                                }
                                                else
                                                {
                                                    songfile = new AudioFileReader(songpath + data.Song[j].Name);
                                                    outputdevice.Init(songfile);
                                                    data.Song[j].PlaySong(outputdevice);
                                                }
                                                while (true)
                                                {
                                                    Console.WriteLine("Que desea hacer?");
                                                    Console.WriteLine("1. Pausa.");
                                                    Console.WriteLine("2. Play another song.");
                                                    Console.WriteLine("3. Adelantar/Retroceder.");
                                                    Console.WriteLine("4. Play.");
                                                    Console.WriteLine("5. Restart Song.");
                                                    Console.WriteLine("6. Create PlayList");
                                                    Console.WriteLine("7. Mis Playlists");
                                                    Console.WriteLine("8. Busqueda de Cancion.");
                                                    Console.WriteLine("9. Close Program.");
                                                    Console.Write("Ingrese opcion:"); songplayeroption2 = Convert.ToInt32(Console.ReadLine());
                                                    switch (songplayeroption2)
                                                    {
                                                        case 1:
                                                            data.Song[0].PauseSong(outputdevice);
                                                            break;
                                                        case 2:
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
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("Ingrese el tiempo en segundos:");
                                                            double seconds = Convert.ToDouble(Console.ReadLine());
                                                            data.Song[0].Forwards_Backwards(songfile, seconds);
                                                            break;
                                                        case 4:
                                                            data.Song[0].PlaySong(outputdevice);
                                                            break;
                                                        case 5:
                                                            data.Song[0].Forwards_Backwards(songfile, 0);
                                                            break;
                                                        case 6:
                                                            Console.Write("Ingrese el nombre de la playlist:"); playlistname = Console.ReadLine();
                                                            Console.Write("Playlist privada? true/false:"); privateplaylist = Convert.ToBoolean(Console.ReadLine());
                                                            Console.Write("Fecha de creacion:"); playlistdate = Console.ReadLine();
                                                            pl = new SongPlaylist(playlistname, privateplaylist, playlistdate);
                                                            j = 1;
                                                        another_song:
                                                            foreach (Song sgg in data.Song)
                                                            {
                                                                Console.WriteLine("{0}. Nombre: {1}", j, sgg.Name);
                                                                Console.WriteLine("Album: {0}", sgg.Album);
                                                                Console.WriteLine("Artista: {0}", sgg.Artists);
                                                                Console.WriteLine("Year: {0}", sgg.Year);
                                                                Console.WriteLine("Genero:{0}", sgg.Genre);
                                                                Console.WriteLine("\n");
                                                                j++;
                                                            }
                                                            Console.Write("Elija la canciones a agregar:"); toplaylist = Convert.ToInt32(Console.ReadLine());
                                                            pl.AddToThisPlaylist(new Song(data.Song[toplaylist - 1].Name, data.Song[toplaylist - 1].Album, data.Song[toplaylist - 1].Artists, data.Song[toplaylist - 1].Genre, data.Song[toplaylist - 1].Year, data.Song[toplaylist - 1].Lyrics));
                                                            Console.WriteLine("Desea agregar otra cancion?\n1. Si\n2. No"); toplaylist = Convert.ToInt32(Console.ReadLine());
                                                            j = 1;
                                                            if (toplaylist == 1) goto another_song;
                                                            else
                                                                data.AddPlaylist(pl, playlistpath.Replace("num", Convert.ToString(id)));
                                                            j = 0;
                                                            break;
                                                        case 7:
                                                            if (File.Exists(playlistpath.Replace("num", Convert.ToString(id))))
                                                            {

                                                                using (StreamReader sr = File.OpenText(playlistpath.Replace("num", Convert.ToString(id))))
                                                                {
                                                                    while ((s = sr.ReadLine()) != null)
                                                                    {
                                                                        info.Add(s);
                                                                        i++;
                                                                        if (i == 3)
                                                                        {
                                                                            pl = new SongPlaylist(info[0], Convert.ToBoolean(info[1]), info[2]);
                                                                            info.Clear();
                                                                            i = 0;
                                                                            while ((s = sr.ReadLine()) != "/-*")
                                                                            {
                                                                                info.Add(s);
                                                                                i++;
                                                                                if (i == 6)
                                                                                {
                                                                                    pl.AddToThisPlaylist(new Song(info[0], info[1], info[2], info[3], info[4], info[5]));
                                                                                    i = 0;
                                                                                    info.Clear();
                                                                                }
                                                                            }
                                                                            data.thisuserplaylist.Add(pl);
                                                                        }
                                                                    }
                                                                }
                                                                foreach (SongPlaylist sp in data.thisuserplaylist)
                                                                {
                                                                    Console.WriteLine("               {0}                  ", sp.Name);
                                                                    j = 1;
                                                                    foreach (Song sgg in sp.ActualPlaylist)
                                                                    {
                                                                        Console.WriteLine("{0}. Nombre: {1}", j, sgg.Name);
                                                                        Console.WriteLine("Album: {0}", sgg.Album);
                                                                        Console.WriteLine("Artista: {0}", sgg.Artists);
                                                                        Console.WriteLine("Year: {0}", sgg.Year);
                                                                        Console.WriteLine("Genero:{0}", sgg.Genre);
                                                                        Console.WriteLine("\n");
                                                                        j++;
                                                                    }
                                                                    Console.WriteLine("Desea reproducir alguna cancion?\n1. Si\n2. No");
                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                another:
                                                                    if (songplayeroption3 == 1)
                                                                    {
                                                                        Console.Write("Ingrese el nombre de la cancion:");
                                                                        searchsong = Console.ReadLine();
                                                                        foreach (Song ssg in data.Song)
                                                                        {
                                                                            if (((searchsong + ".mp3") == ssg.Name) || ((searchsong + ".mp4") == ssg.Name) || ((searchsong + ".wav") == ssg.Name))
                                                                            {
                                                                                if (outputdevice.PlaybackState == PlaybackState.Playing)
                                                                                {
                                                                                    songfile = new AudioFileReader(songpath + ssg.Name);
                                                                                    data.Song[j].SkiptoSong(outputdevice, songfile);
                                                                                    Console.WriteLine("Desea reproducir otra cancion de la playlist actuañ?\n1. Si\n2. No");
                                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                                    if (songplayeroption3 == 1) goto another;
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Siguiente Playlist");
                                                                                        Thread.Sleep(1000);
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    songfile = new AudioFileReader(songpath + ssg.Name);
                                                                                    outputdevice.Init(songfile);
                                                                                    data.Song[j].PlaySong(outputdevice);
                                                                                    Console.WriteLine("Desea reproducir otra cancion de la playlist actual?\n1. Si\n2. No");
                                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                                    if (songplayeroption3 == 1) goto another;
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Siguiente Playlist");
                                                                                        Thread.Sleep(1000);
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                data.thisuserplaylist.Clear();
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Aun no has creado ninguna playlist!!!");
                                                            }
                                                            break;
                                                        case 8:
                                                            goto criterio;
                                                        case 9:
                                                            outputdevice.Stop();
                                                            outputdevice.Dispose();
                                                            Console.WriteLine("Cerrando reproductor de musica...");
                                                            Thread.Sleep(1000);
                                                            break;
                                                    }
                                                    if (songplayeroption2 == 9)
                                                        break;
                                                }
                                                break;
                                            /*case 2:
                                                break;*/
                                            case 3:
                                                outputdevice.Stop();
                                                outputdevice.Dispose();
                                                Console.WriteLine("Cerrando reproductor de musica...");
                                                Thread.Sleep(1000);
                                                break;
                                        }
                                    }
                                    j++;
                                }
                                searchcriteria.Clear();
                                break;
                            case 4:
                                foreach (Song sg in data.Song)
                                {
                                    foreach (char ch in sg.Genre)
                                    {

                                        if (ch != ' ')
                                        {
                                            actualgenre += ch;
                                            if (actualgenre == searchsong)
                                            {
                                                searchcriteria.Add(sg);
                                                actualgenre = "";
                                            }
                                        }
                                        else
                                            actualgenre = "";


                                    }
                                    actualgenre = "";
                                }
                                foreach (Song sg in searchcriteria)
                                {
                                    Console.WriteLine("Resultado de busqueda:");
                                    Console.WriteLine("Nombre: {0}", sg.Name);
                                    Console.WriteLine("Album: {0}", sg.Album);
                                    Console.WriteLine("Artists: {0}", sg.Artists);
                                    Console.WriteLine("Year: {0}", sg.Year);
                                }
                                searchcriteria.Clear();
                                Console.Write("Elija una cancion:"); searchsong = Console.ReadLine();
                                j = 0;
                                foreach (Song sg in data.Song)
                                {
                                    if (((searchsong + ".mp3") == sg.Name) || ((searchsong + ".mp4") == sg.Name) || ((searchsong + ".wav") == sg.Name))
                                    {
                                        Console.WriteLine("Desea reproducir la cancion?");
                                        Console.WriteLine("1. Reproducir");
                                        //Console.WriteLine("2. Agregar a playlist");
                                        Console.WriteLine("2. Salir");
                                        Console.Write("Ingrese opcion:"); songplayeroption = Convert.ToInt32(Console.ReadLine());
                                        switch (songplayeroption)
                                        {
                                            case 1:
                                                if (outputdevice.PlaybackState == PlaybackState.Playing)
                                                {
                                                    songfile = new AudioFileReader(songpath + data.Song[j].Name);
                                                    data.Song[j].SkiptoSong(outputdevice, songfile);
                                                }
                                                else
                                                {
                                                    songfile = new AudioFileReader(songpath + data.Song[j].Name);
                                                    outputdevice.Init(songfile);
                                                    data.Song[j].PlaySong(outputdevice);
                                                }
                                                while (true)
                                                {
                                                    Console.WriteLine("Que desea hacer?");
                                                    Console.WriteLine("1. Pausa.");
                                                    Console.WriteLine("2. Play another song.");
                                                    Console.WriteLine("3. Adelantar/Retroceder.");
                                                    Console.WriteLine("4. Play.");
                                                    Console.WriteLine("5. Restart Song.");
                                                    Console.WriteLine("6. Create PlayList");
                                                    Console.WriteLine("7. Mis Playlists");
                                                    Console.WriteLine("8. Busqueda de Cancion.");
                                                    Console.WriteLine("9. Close Program.");
                                                    Console.Write("Ingrese opcion:"); songplayeroption2 = Convert.ToInt32(Console.ReadLine());
                                                    switch (songplayeroption2)
                                                    {
                                                        case 1:
                                                            data.Song[0].PauseSong(outputdevice);
                                                            break;
                                                        case 2:
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
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("Ingrese el tiempo en segundos:");
                                                            double seconds = Convert.ToDouble(Console.ReadLine());
                                                            data.Song[0].Forwards_Backwards(songfile, seconds);
                                                            break;
                                                        case 4:
                                                            data.Song[0].PlaySong(outputdevice);
                                                            break;
                                                        case 5:
                                                            data.Song[0].Forwards_Backwards(songfile, 0);
                                                            break;
                                                        case 6:
                                                            Console.Write("Ingrese el nombre de la playlist:"); playlistname = Console.ReadLine();
                                                            Console.Write("Playlist privada? true/false:"); privateplaylist = Convert.ToBoolean(Console.ReadLine());
                                                            Console.Write("Fecha de creacion:"); playlistdate = Console.ReadLine();
                                                            pl = new SongPlaylist(playlistname, privateplaylist, playlistdate);
                                                            j = 1;
                                                        another_song:
                                                            foreach (Song sgg in data.Song)
                                                            {
                                                                Console.WriteLine("{0}. Nombre: {1}", j, sgg.Name);
                                                                Console.WriteLine("Album: {0}", sgg.Album);
                                                                Console.WriteLine("Artista: {0}", sgg.Artists);
                                                                Console.WriteLine("Year: {0}", sgg.Year);
                                                                Console.WriteLine("Genero:{0}", sgg.Genre);
                                                                Console.WriteLine("\n");
                                                                j++;
                                                            }
                                                            Console.Write("Elija la canciones a agregar:"); toplaylist = Convert.ToInt32(Console.ReadLine());
                                                            pl.AddToThisPlaylist(new Song(data.Song[toplaylist - 1].Name, data.Song[toplaylist - 1].Album, data.Song[toplaylist - 1].Artists, data.Song[toplaylist - 1].Genre, data.Song[toplaylist - 1].Year, data.Song[toplaylist - 1].Lyrics));
                                                            Console.WriteLine("Desea agregar otra cancion?\n1. Si\n2. No"); toplaylist = Convert.ToInt32(Console.ReadLine());
                                                            j = 1;
                                                            if (toplaylist == 1) goto another_song;
                                                            else
                                                                data.AddPlaylist(pl, playlistpath.Replace("num", Convert.ToString(id)));
                                                            j = 0;
                                                            break;
                                                        case 7:
                                                            if (File.Exists(playlistpath.Replace("num", Convert.ToString(id))))
                                                            {

                                                                using (StreamReader sr = File.OpenText(playlistpath.Replace("num", Convert.ToString(id))))
                                                                {
                                                                    while ((s = sr.ReadLine()) != null)
                                                                    {
                                                                        info.Add(s);
                                                                        i++;
                                                                        if (i == 3)
                                                                        {
                                                                            pl = new SongPlaylist(info[0], Convert.ToBoolean(info[1]), info[2]);
                                                                            info.Clear();
                                                                            i = 0;
                                                                            while ((s = sr.ReadLine()) != "/-*")
                                                                            {
                                                                                info.Add(s);
                                                                                i++;
                                                                                if (i == 6)
                                                                                {
                                                                                    pl.AddToThisPlaylist(new Song(info[0], info[1], info[2], info[3], info[4], info[5]));
                                                                                    i = 0;
                                                                                    info.Clear();
                                                                                }
                                                                            }
                                                                            data.thisuserplaylist.Add(pl);
                                                                        }
                                                                    }
                                                                }
                                                                foreach (SongPlaylist sp in data.thisuserplaylist)
                                                                {
                                                                    Console.WriteLine("               {0}                  ", sp.Name);
                                                                    j = 1;
                                                                    foreach (Song sgg in sp.ActualPlaylist)
                                                                    {
                                                                        Console.WriteLine("{0}. Nombre: {1}", j, sgg.Name);
                                                                        Console.WriteLine("Album: {0}", sgg.Album);
                                                                        Console.WriteLine("Artista: {0}", sgg.Artists);
                                                                        Console.WriteLine("Year: {0}", sgg.Year);
                                                                        Console.WriteLine("Genero:{0}", sgg.Genre);
                                                                        Console.WriteLine("\n");
                                                                        j++;
                                                                    }
                                                                    Console.WriteLine("Desea reproducir alguna cancion?\n1. Si\n2. No");
                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                another:
                                                                    if (songplayeroption3 == 1)
                                                                    {
                                                                        Console.Write("Ingrese el nombre de la cancion:");
                                                                        searchsong = Console.ReadLine();
                                                                        foreach (Song ssg in data.Song)
                                                                        {
                                                                            if (((searchsong + ".mp3") == ssg.Name) || ((searchsong + ".mp4") == ssg.Name) || ((searchsong + ".wav") == ssg.Name))
                                                                            {
                                                                                if (outputdevice.PlaybackState == PlaybackState.Playing)
                                                                                {
                                                                                    songfile = new AudioFileReader(songpath + ssg.Name);
                                                                                    data.Song[j].SkiptoSong(outputdevice, songfile);
                                                                                    Console.WriteLine("Desea reproducir otra cancion de la playlist actuañ?\n1. Si\n2. No");
                                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                                    if (songplayeroption3 == 1) goto another;
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Siguiente Playlist");
                                                                                        Thread.Sleep(1000);
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    songfile = new AudioFileReader(songpath + ssg.Name);
                                                                                    outputdevice.Init(songfile);
                                                                                    data.Song[j].PlaySong(outputdevice);
                                                                                    Console.WriteLine("Desea reproducir otra cancion de la playlist actual?\n1. Si\n2. No");
                                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                                    if (songplayeroption3 == 1) goto another;
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Siguiente Playlist");
                                                                                        Thread.Sleep(1000);
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                data.thisuserplaylist.Clear();
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Aun no has creado ninguna playlist!!!");
                                                            }
                                                            break;
                                                        case 8:
                                                            goto criterio;
                                                        case 9:
                                                            outputdevice.Stop();
                                                            outputdevice.Dispose();
                                                            Console.WriteLine("Cerrando reproductor de musica...");
                                                            Thread.Sleep(1000);
                                                            break;
                                                    }
                                                    if (songplayeroption2 == 9)
                                                        break;
                                                }
                                                break;
                                            /* case 2:
                                                 break;*/
                                            case 2:
                                                outputdevice.Stop();
                                                outputdevice.Dispose();
                                                Console.WriteLine("Cerrando reproductor de musica...");
                                                Thread.Sleep(1000);
                                                break;
                                        }
                                    }
                                    j++;
                                }
                                searchcriteria.Clear();
                                break;
                            case 5:
                                foreach (Song sg in data.Song)
                                {
                                    if (searchsong == sg.Year)
                                    {
                                        searchcriteria.Add(sg);
                                    }
                                }
                                foreach (Song sg in searchcriteria)
                                {
                                    Console.WriteLine("Resultado de busqueda:");
                                    Console.WriteLine("Nombre: {0}", sg.Name);
                                    Console.WriteLine("Album: {0}", sg.Album);
                                    Console.WriteLine("Artista: {0}", sg.Artists);
                                }
                                searchcriteria.Clear();
                                Console.Write("Elija una cancion:"); searchsong = Console.ReadLine();
                                j = 0;
                                foreach (Song sg in data.Song)
                                {
                                    if (((searchsong + ".mp3") == sg.Name) || ((searchsong + ".mp4") == sg.Name) || ((searchsong + ".wav") == sg.Name))
                                    {
                                        Console.WriteLine("Desea reproducir la cancion?");
                                        Console.WriteLine("1. Reproducir");
                                        //Console.WriteLine("2. Agregar a playlist");
                                        Console.WriteLine("2. Salir");
                                        Console.Write("Ingrese opcion:"); songplayeroption = Convert.ToInt32(Console.ReadLine());
                                        switch (songplayeroption)
                                        {
                                            case 1:
                                                if (outputdevice.PlaybackState == PlaybackState.Playing)
                                                {
                                                    songfile = new AudioFileReader(songpath + data.Song[j].Name);
                                                    data.Song[j].SkiptoSong(outputdevice, songfile);
                                                }
                                                else
                                                {
                                                    songfile = new AudioFileReader(songpath + data.Song[j].Name);
                                                    outputdevice.Init(songfile);
                                                    data.Song[j].PlaySong(outputdevice);
                                                }
                                                while (true)
                                                {
                                                    Console.WriteLine("Que desea hacer?");
                                                    Console.WriteLine("1. Pausa.");
                                                    Console.WriteLine("2. Play another song.");
                                                    Console.WriteLine("3. Adelantar/Retroceder.");
                                                    Console.WriteLine("4. Play.");
                                                    Console.WriteLine("5. Restart Song.");
                                                    Console.WriteLine("6. Create PlayList");
                                                    Console.WriteLine("7. Mis Playlists");
                                                    Console.WriteLine("8. Busqueda de Cancion.");
                                                    Console.WriteLine("9. Close Program.");
                                                    Console.Write("Ingrese opcion:"); songplayeroption2 = Convert.ToInt32(Console.ReadLine());
                                                    switch (songplayeroption2)
                                                    {
                                                        case 1:
                                                            data.Song[0].PauseSong(outputdevice);
                                                            break;
                                                        case 2:
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
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("Ingrese el tiempo en segundos:");
                                                            double seconds = Convert.ToDouble(Console.ReadLine());
                                                            data.Song[0].Forwards_Backwards(songfile, seconds);
                                                            break;
                                                        case 4:
                                                            data.Song[0].PlaySong(outputdevice);
                                                            break;
                                                        case 5:
                                                            data.Song[0].Forwards_Backwards(songfile, 0);
                                                            break;
                                                        case 6:
                                                            Console.Write("Ingrese el nombre de la playlist:"); playlistname = Console.ReadLine();
                                                            Console.Write("Playlist privada? true/false:"); privateplaylist = Convert.ToBoolean(Console.ReadLine());
                                                            Console.Write("Fecha de creacion:"); playlistdate = Console.ReadLine();
                                                            pl = new SongPlaylist(playlistname, privateplaylist, playlistdate);
                                                            j = 1;
                                                        another_song:
                                                            foreach (Song sgg in data.Song)
                                                            {
                                                                Console.WriteLine("{0}. Nombre: {1}", j, sgg.Name);
                                                                Console.WriteLine("Album: {0}", sgg.Album);
                                                                Console.WriteLine("Artista: {0}", sgg.Artists);
                                                                Console.WriteLine("Year: {0}", sgg.Year);
                                                                Console.WriteLine("Genero:{0}", sgg.Genre);
                                                                Console.WriteLine("\n");
                                                                j++;
                                                            }
                                                            Console.Write("Elija la canciones a agregar:"); toplaylist = Convert.ToInt32(Console.ReadLine());
                                                            pl.AddToThisPlaylist(new Song(data.Song[toplaylist - 1].Name, data.Song[toplaylist - 1].Album, data.Song[toplaylist - 1].Artists, data.Song[toplaylist - 1].Genre, data.Song[toplaylist - 1].Year, data.Song[toplaylist - 1].Lyrics));
                                                            Console.WriteLine("Desea agregar otra cancion?\n1. Si\n2. No"); toplaylist = Convert.ToInt32(Console.ReadLine());
                                                            j = 1;
                                                            if (toplaylist == 1) goto another_song;
                                                            else
                                                                data.AddPlaylist(pl, playlistpath.Replace("num", Convert.ToString(id)));
                                                            j = 0;
                                                            break;
                                                        case 7:
                                                            if (File.Exists(playlistpath.Replace("num", Convert.ToString(id))))
                                                            {

                                                                using (StreamReader sr = File.OpenText(playlistpath.Replace("num", Convert.ToString(id))))
                                                                {
                                                                    while ((s = sr.ReadLine()) != null)
                                                                    {
                                                                        info.Add(s);
                                                                        i++;
                                                                        if (i == 3)
                                                                        {
                                                                            pl = new SongPlaylist(info[0], Convert.ToBoolean(info[1]), info[2]);
                                                                            info.Clear();
                                                                            i = 0;
                                                                            while ((s = sr.ReadLine()) != "/-*")
                                                                            {
                                                                                info.Add(s);
                                                                                i++;
                                                                                if (i == 6)
                                                                                {
                                                                                    pl.AddToThisPlaylist(new Song(info[0], info[1], info[2], info[3], info[4], info[5]));
                                                                                    i = 0;
                                                                                    info.Clear();
                                                                                }
                                                                            }
                                                                            data.thisuserplaylist.Add(pl);
                                                                        }
                                                                    }
                                                                }
                                                                foreach (SongPlaylist sp in data.thisuserplaylist)
                                                                {
                                                                    Console.WriteLine("               {0}                  ", sp.Name);
                                                                    j = 1;
                                                                    foreach (Song sgg in sp.ActualPlaylist)
                                                                    {
                                                                        Console.WriteLine("{0}. Nombre: {1}", j, sgg.Name);
                                                                        Console.WriteLine("Album: {0}", sgg.Album);
                                                                        Console.WriteLine("Artista: {0}", sgg.Artists);
                                                                        Console.WriteLine("Year: {0}", sgg.Year);
                                                                        Console.WriteLine("Genero:{0}", sgg.Genre);
                                                                        Console.WriteLine("\n");
                                                                        j++;
                                                                    }
                                                                    Console.WriteLine("Desea reproducir alguna cancion?\n1. Si\n2. No");
                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                another:
                                                                    if (songplayeroption3 == 1)
                                                                    {
                                                                        Console.Write("Ingrese el nombre de la cancion:");
                                                                        searchsong = Console.ReadLine();
                                                                        foreach (Song ssg in data.Song)
                                                                        {
                                                                            if (((searchsong + ".mp3") == ssg.Name) || ((searchsong + ".mp4") == ssg.Name) || ((searchsong + ".wav") == ssg.Name))
                                                                            {
                                                                                if (outputdevice.PlaybackState == PlaybackState.Playing)
                                                                                {
                                                                                    songfile = new AudioFileReader(songpath + ssg.Name);
                                                                                    data.Song[j].SkiptoSong(outputdevice, songfile);
                                                                                    Console.WriteLine("Desea reproducir otra cancion de la playlist actuañ?\n1. Si\n2. No");
                                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                                    if (songplayeroption3 == 1) goto another;
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Siguiente Playlist");
                                                                                        Thread.Sleep(1000);
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    songfile = new AudioFileReader(songpath + ssg.Name);
                                                                                    outputdevice.Init(songfile);
                                                                                    data.Song[j].PlaySong(outputdevice);
                                                                                    Console.WriteLine("Desea reproducir otra cancion de la playlist actual?\n1. Si\n2. No");
                                                                                    songplayeroption3 = Convert.ToInt32(Console.ReadLine());
                                                                                    if (songplayeroption3 == 1) goto another;
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Siguiente Playlist");
                                                                                        Thread.Sleep(1000);
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                data.thisuserplaylist.Clear();
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Aun no has creado ninguna playlist!!!");
                                                            }
                                                            break;
                                                        case 8:
                                                            goto criterio;
                                                        case 9:
                                                            outputdevice.Stop();
                                                            outputdevice.Dispose();
                                                            Console.WriteLine("Cerrando reproductor de musica...");
                                                            Thread.Sleep(1000);
                                                            break;
                                                    }
                                                    if (songplayeroption2 == 9)
                                                        break;
                                                }
                                                break;
                                            /*case 2:
                                                break;*/
                                            case 3:
                                                outputdevice.Stop();
                                                outputdevice.Dispose();
                                                Console.WriteLine("Cerrando reproductor de musica...");
                                                Thread.Sleep(1000);
                                                break;
                                        }
                                    }
                                    j++;
                                }
                                searchcriteria.Clear();
                                break;
                                //**************************************************************************************************
                        }
                        break;
                    }
                    break;
                    
                case 4:

                    Console.Clear();
                    //Cargo archivo para Videos ya importados
                    try
                    {
                        data.Videos = VideosLoad();
                    }
                    catch
                    {
                        Console.WriteLine("No hay videos importados porfavor importe algun video antes de seleccionar otra opcion");
                    }
                    //Menu Videos

                    Console.WriteLine("1. Importar video: ");
                    Console.WriteLine("2. Listado de videos ");
                    Console.WriteLine("3. Listado de playlists ");
                    Console.WriteLine("4. Buscar video ");
                    Console.WriteLine("5. Mostrar videos seguidos ");
                    Console.WriteLine("6. Regresar ");

                    int videochoice = Convert.ToInt32(Console.ReadLine());

                    switch (videochoice)
                    {
                        case 1:

                            Console.Clear();
                            Console.WriteLine("Ingrese nombre: "); string name = Console.ReadLine(); Console.Clear();
                            Console.WriteLine("Ingrese extencion de archivo: (ej: .mp4) "); string extention = Console.ReadLine(); Console.Clear();
                            Console.WriteLine("Ingrese genero "); string genre = Console.ReadLine(); Console.Clear();
                            Console.WriteLine("Ingrese categoria: "); string category = Console.ReadLine(); Console.Clear();
                            Console.WriteLine("Ingrese director: "); string director = Console.ReadLine(); Console.Clear();
                            Console.WriteLine("Ingrese descripcion "); string description = Console.ReadLine(); Console.Clear();
                            //Console.WriteLine("Ingrese actores: "); string actor = Console.ReadLine(); Console.Clear();
                            Console.WriteLine("Ingrese resolucion: "); int resolution = Convert.ToInt32(Console.ReadLine()); Console.Clear();

                            data.addVideo(new Video(name, genre, category, director, description, resolution, extention));
                            VideosSave(data.Videos);
                            Console.WriteLine("Video importado con exito");
                            Thread.Sleep(2000);
                            break;

                        case 2:

                            Console.Clear();
                            Console.WriteLine("0. Regresar");
                            Console.WriteLine();
                            Console.WriteLine("Seleccione un video");

                            i = 0;
                            foreach (Video video in data.Videos)
                            {
                                i++;
                                Console.WriteLine("{0}. {1}", i, video.name);
                            }

                            int vid = Convert.ToInt32(Console.ReadLine());

                            if (vid != 0)
                            {
                                vid--;
                                Video videoescogido = data.Videos[vid]; 
                                
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("Escoge que hacer con el video:");
                                Console.WriteLine("1. Reproducir:");
                                Console.WriteLine("2. Agregar a Playlist:");
                                Console.WriteLine("3. Regresar:");

                                var choice = Convert.ToInt32(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:

                                        videoescogido.Play();

                                        break;

                                    case 2:
                                        Console.WriteLine("1. Agregar a nueva playlist");
                                        Console.WriteLine("2. Agregar a playlist");
                                        Console.WriteLine("3. Regresar");
                                        var us_plist1 = data.Users.First(m => m.Email == mailuser);//con esto tenemos el objeto usuario en el que estamos logeados
                                        
                                        int choice2 = Convert.ToInt32(Console.ReadLine());

                                        switch (choice2)
                                        {
                                            case 1:

                                                break;

                                            case 2:

                                                break;

                                                //us_plist1.VideosPublicos.
                                        }
                                                            
                                        break;

                                    case 3:

                                        Console.Clear();
                                        break;

                                }


                            }

                            break;

                        case 3:

                            var us_plist2 = data.Users.First(m => m.Email == mailuser);//con esto tenemos el objeto usuario en el que estamos logeados
                            Console.Clear();
                            Console.WriteLine("0. Regresar");
                            Console.WriteLine();
                            Console.WriteLine("Seleccione una playlist para reproducir");

                            i = 0;
                            foreach (VideoPlaylist playlist in us_plist2.VideosPublicos)
                            {
                                i++;
                                Console.WriteLine("{0}. {1}", i, playlist.name);
                            }

                            int plst = Convert.ToInt32(Console.ReadLine());
                            if (plst != 0)
                            {
                                plst--;
                                //us_plist.VideosPublicos[plst].;
                            }
                            break;

                        case 4:

                            break;

                        case 5:

                            break;

                        case 6:

                            Console.Clear();
                            break;

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
                                    data.Users.RemoveAll(x => x.Email == candidatemail);
                                    //data.UserDelete(us, userpath);
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
            try
            {
                data.Users = UsersLoad();
            }

            catch
            {
                Console.WriteLine("No hay videos importados porfavor importe algun video antes de seleccionar otra opcion");
            }

            //data.Song = SongsLoad();para despues
            
            string s;
            int i = 0 , j = 0;
            List<string> info = new List<string>();
            SongPlaylist playlist;

            /*using (StreamReader sr = File.OpenText(userspath))
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
            }*/
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
            foreach (NPerson us in data.Users)
            {
                if (File.Exists(playlistspath.Replace("num", Convert.ToString(us.IDUser))))
                {
                    using (StreamReader sr = File.OpenText(playlistspath.Replace("num", Convert.ToString(us.IDUser))))
                    {
                        while ((s = sr.ReadLine()) != null)
                        {
                            info.Add(s);
                            i++;
                            if (i == 3)
                            {
                                playlist = new SongPlaylist(info[0], Convert.ToBoolean(info[1]), info[2]);
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
        //Funciones de guardado y lectura de videos y playlist videos
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

        static private void UsersSave(List<NPerson> UsersList)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Users.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, UsersList);

            stream.Close();
        }

        static private List<NPerson> UsersLoad()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Users.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<NPerson> UsersList = (List<NPerson>)formatter.Deserialize(stream);

            stream.Close();
            return UsersList;
        }

        static private void SongsSave(List<Song> UsersList)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Songs.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, UsersList);

            stream.Close();
        }
        static private List<Song> SongsLoad()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Songs.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Song> SongList = (List<Song>)formatter.Deserialize(stream);

            stream.Close();
            return SongList;
        }

    }
}
