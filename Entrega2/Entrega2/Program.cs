using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using NAudio;



namespace Entrega2
{
    class Program
    {
        static void Main(string[] args)
        {
            //en esta variable esta el directorio actual en donde esta ejecutandose el progrma asi cuando cambie de pc siempre van a tener el directorio mismo directorio si lo usan y le agregan el nombre del archivo
            var curDir = Directory.GetCurrentDirectory();
            string pathSongs = curDir + @"\Songs\";
            string pathVideos = curDir + @"\Videos\";


            //NICO
            //Prueba
            //Video video1 = new Video("Circles", "Post Malone", "Video de la cancion Cirlces", "Post Malone", 1080);
            //System.Diagnostics.Process.Start(pathVideos + "1080.mp4");
            

            //MIGUEL
            /*Song cancion = new Song("Circles","Post Malone","pp","disc","","turururu");
            int choice = Convert.ToInt32(Console.ReadLine());
            cancion.Menu(choice);
            double for_backwards;
            string op;
            string generic_path = @"C:\Users\userprofile\source\repos\Netify\Songs\name.mp3";
            string username = Environment.UserName;
            string path_v1 = generic_path.Replace("name", cancion.Name);
            string path = path_v1.Replace("userprofile", username);
            Console.WriteLine(path);
            var audioFile = new AudioFileReader(path);
            var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            while (choice != 0)
            {
                if (choice == 1)
                {
                    //outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Console.WriteLine("Opciones:\n" + "1 Stop\n" + "2 forward or backward\n" + "3 Replay\n");
                        op = Console.ReadLine();
                        if (op == "1")
                        {
                            outputDevice.Pause();
                            choice = -1;
                            break;
                        }
                        else if (op == "2")
                        {
                            for_backwards = Convert.ToDouble(Convert.ToInt32(Console.ReadLine()));
                            audioFile.CurrentTime = TimeSpan.FromSeconds(for_backwards);
                        }
                        else if (op == "3")
                        {
                            for_backwards = 0;
                            audioFile.CurrentTime = TimeSpan.FromSeconds(for_backwards);
                        }
                    }
                }
                else if (choice == -1)
                {
                    Console.WriteLine("Desea hace algo mas? ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
            }
            outputDevice.Stop();
            outputDevice.Dispose();
            */


            /*string name = "Circles.mp3";
            string fullpath = Path.GetFullPath(name);
            Console.WriteLine(fullpath);
            */



            //MANUEL
            //Primero, creo instancia de gestor. 
            Gestor GestorReprod = new Gestor();

            //Creo algunos usuarios de prueba. 
            NPerson Usuario1 = new NPerson(0, 0, "Pepito", "Perez", "123", "maserra@miuandes.com", "Soy pepito", false, false);
            NPerson Usuario2 = new NPerson(1, 0, "Juan", "Perez", "123", "juan@gmail.com", "Soy juan", true, true);
            NPerson Usuario3 = new NPerson(2, 0, "Pedro", "Saez", "123", "pedro@gmail.com", "Soy pedro", true, true);

            //Los agrego al gestor. 
            GestorReprod.Usuarios.Add(Usuario1); GestorReprod.Usuarios.Add(Usuario2);
            GestorReprod.Usuarios.Add(Usuario3);

            //menu programa general.

            bool runningprogram = true;

            while (runningprogram)
            {
                Console.WriteLine("Bienvenido a Netify.");
                Console.WriteLine("1. Login: ");
                Console.WriteLine("2. Registrarse: ");
                Console.WriteLine("3. Salir: ");

                int mainchoice = Convert.ToInt32(Console.ReadLine());

                switch (mainchoice)
                {
                    case 1:
                        bool case1 = true;
                        while (case1)
                        {
                            Console.Clear();

                            //Login funciona asi: usuario ingresa mail y gestor busca mails de todos los usuarios hasta encontrar
                            //el mail que corresponde. luego pide contraseña y deja a usuario acceder si contraseña ingresada 
                            //es igual a la guardada para aquel mail.

                            //Primero pido mail usuario.

                            bool checkingmail = true; bool validmail = false;

                            //Pido los mails, cuando el que ingreso calza con alguno en la base de datos del gestor
                            //guardo la contraseña de aquel usuario para ver que calce con la que ingreso.

                            int loginid = 0;

                            while (checkingmail)
                            {
                                Console.WriteLine("Ingrese Mail: ");
                                string candidatemail = Console.ReadLine();


                                for (int i = 0; i < GestorReprod.Usuarios.Count(); i++)
                                {
                                    if (GestorReprod.Usuarios[i].mail == candidatemail)
                                    {
                                        Console.Write("Mail Valido."); Console.Clear();
                                        string loginpassword = GestorReprod.Usuarios[i].claveUsuario;
                                        loginid = GestorReprod.Usuarios[i].idUsuario;
                                        validmail = true; checkingmail = false;
              
                                    }
                                }
                                //Sist. pide mail a usuario hasta que ingresa uno veridico. 
                                if (validmail == false) { Console.WriteLine("Correo Erroneo."); }
                            }


                            //Ahora checkeo contraseña.

                            bool checkingpassword = true; bool validpassword = false;


                            while (checkingpassword)
                            {
                                Console.WriteLine("Ingrese Clave: ");
                                string candidatepassword = Console.ReadLine();

                                if (GestorReprod.Usuarios[loginid].claveUsuario == candidatepassword)
                                {
                                    Console.WriteLine("Contraseña Valida."); Console.Clear();
                                    validpassword = true; checkingpassword = false;
                                }

                                //Sist. pide password a usuario hasta que ingrese la que corresponde.
                                if (validpassword == false) { Console.WriteLine("Contraseña Invalida."); }
                            }

                            Console.Clear();

                            //Dado que pase filtro del login, puedo hacer lo que quiera. 

                            bool loggedIn = true;
                            while (loggedIn)
                            {

                                Console.Clear();

                                ///FUNCIONALIDADES DENTRO DE LOGIN:

                                Console.WriteLine("1. Ver datos de todos los usuarios: ");
                                Console.WriteLine("2. Actualizar Datos: ");
                                Console.WriteLine("3. Buscar Contenido: ");
                                Console.WriteLine("4. Ver Seguidos: ");
                                Console.WriteLine("5. Ver Seguidores: ");
                                Console.WriteLine("6. Seguir a otros usuarios: ");
                                Console.WriteLine("7. Eliminar Perfil: ");
                                Console.WriteLine("8. Volver a Menu Principal: ");

                                int locChoice = Convert.ToInt32(Console.ReadLine());

                                switch (locChoice)
                                {
                                    //Ver datos de todos los usuarios: 

                                    case 1:

                                        Console.Clear();
                                        Console.WriteLine("Datos de todos los usuarios existentes: ");

                                        for (int i = 0; i < GestorReprod.Usuarios.Count(); i++)
                                        {
                                            GestorReprod.Usuarios[i].userData();
                                            Console.WriteLine("\n");
                                            Thread.Sleep(500);
                                        }
                                        Thread.Sleep(2000);

                                        break;


                                    //Actualizar datos, que llama a metodo propio de usuario que permite hacer esto.

                                    case 2:

                                        GestorReprod.Usuarios[loginid].cambiarDato();
                                        break;

                                    //Buscar contenido, que permite al usuario buscar algun contenido en el gestor.

                                    case 3:

                                    //IMPLEMENTAR BUSQUEDA DE CONTENIDO ACA.


                                    //Ver seguidos, que llama a metodo de usuario que permite hacer esto. 

                                    case 4:

                                        Console.WriteLine("Lista de Seguidos: ");
                                        Console.WriteLine("\n");

                                        for (int i = 0; i < GestorReprod.Usuarios[loginid].UsuariosSeguidos.Count(); i++)
                                        {

                                            string showInfo = Convert.ToString(i) + ". " + GestorReprod.Usuarios[loginid].UsuariosSeguidos[i].nombre + " " + GestorReprod.Usuarios[loginid].UsuariosSeguidos[i].apellido;
                                            Console.WriteLine(showInfo);
                                            Thread.Sleep(2000);
                                        }

                                        break;


                                    //Ver seguidores. 


                                    case 5:

                                        Console.WriteLine("Lista de Seguidores: ");
                                        Console.WriteLine("\n");

                                        for (int i = 0; i < GestorReprod.Usuarios[loginid].Seguidores.Count(); i++)
                                        {

                                            string showInfo = Convert.ToString(i) + ". " + GestorReprod.Usuarios[loginid].Seguidores[i].nombre + " " + GestorReprod.Usuarios[loginid].Seguidores[i].apellido;
                                            Console.WriteLine(showInfo);
                                            Thread.Sleep(2000);
                                        }

                                        break;



                                    //Seguir usuarios. Para este caso, decidi construir el metodo aca mismo. 

                                    case 6:

                                        bool following = true;
                                        while (following)

                                        {
                                            //Muestro nombre de todos los usuarios en sistema.
                                            
                                            Console.Clear();
                                            Console.WriteLine("Lista de Usuarios: ");

                                            for (int i = 0; i < GestorReprod.Usuarios.Count(); i++)
                                            {
                                                string show = Convert.ToString(i) + ". " + GestorReprod.Usuarios[i].nombre + " " + GestorReprod.Usuarios[i].apellido;
                                                Console.WriteLine(show);
                                            }

                                            //Pido cual quiero seguir. 

                                            Console.WriteLine("Ingrese numero de usuario a seguir: ");
                                            Console.WriteLine("Si desea salir, ingrese 0. ");


                                            int followID = Convert.ToInt32(Console.ReadLine());
                                            if (followID == 0)
                                            {
                                                following = false; break;
                                            }


                                            //Lo sigo. 

                                            GestorReprod.Usuarios[loginid].UsuariosSeguidos.Add(GestorReprod.Usuarios[followID]);
                                            Console.WriteLine("Usuario seguido con exito. ");

                                            //Agrego el usuario que opera como seguidor en el usuario al que segui. 

                                            GestorReprod.Usuarios[followID].Seguidores.Add(GestorReprod.Usuarios[loginid]);


                                            Thread.Sleep(1500);
                                        }

                                        break;



                                    //Opcion de eliminar perfil. 

                                    case 7:

                                        bool deletingProfile = true;

                                        while (deletingProfile)
                                        {
                                            Console.Clear();

                                            Console.WriteLine("1. Confirme eliminar perfil. ");
                                            Console.WriteLine("2. Cancelar. ");

                                            int deleteChoice = Convert.ToInt32(Console.ReadLine());

                                            if (deleteChoice == 1)
                                            {
                                                GestorReprod.Usuarios.RemoveAt(loginid);
                                                Console.WriteLine("Perfil eliminado con exito. ");
                                                Thread.Sleep(1500);
                                                case1 = false; loggedIn = false; deletingProfile = false;
                                                break;
                                            }

                                            if(deleteChoice == 2)
                                            {
                                                deletingProfile = false;
                                                break;
                                            }

                                            else { Console.WriteLine("Comando invalido."); break; }
                                        }

                                        break;
                                        

                                    //Opcion de escape. Me retorna a menu principal. 

                                    case 8:
                                        case1 = false; loggedIn = false;
                                        Console.Clear();
                                        break;

                                }
                            }




                            



                        }




                        






                        break;

                    case 2:

                        Console.Clear();

                        bool creatinguser = true;
                        while (creatinguser)
                        {
                            Console.Write("ingrese 1 para crear otro usuario, 2 para salir: ");
                            int choice = Convert.ToInt32(Console.ReadLine());

                            if (choice == 1)
                            {
                                GestorReprod.NuevoUsuario();
                            }

                            if (choice == 2)
                            {
                                creatinguser = false; 
                            }

                        }

                        break;


       


                }




            }







            ////Imprimo datos de todos los usuarios en sistema. 

            //for (int i = 0; i < GestorReprod.Usuarios.Count(); i++)
            //{
            //    GestorReprod.Usuarios[i].userData();
            //    Console.WriteLine("\n");

            //}


        }
    }
}
