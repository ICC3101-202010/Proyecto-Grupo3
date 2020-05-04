using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using NAudio;
using LibVLCSharp.Shared;


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
            Video video1 = new Video("Circles", "Post Malone", "Video de la cancion Cirlces", "Post Malone", 1080);
            System.Diagnostics.Process.Start(pathVideos + "1080.mp4");
            

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



            /*//MANUEL
            //Primero, creo instancia de gestor. 
            Gestor GestorReprod = new Gestor();

            //Creo algunos usuarios de prueba. 
            NPerson Usuario1 = new NPerson(0, 0, "Pepito", "Perez", "claveChanta", "pepito@gmail.com", "Soy pepito", false, false);
            NPerson Usuario2 = new NPerson(0, 0, "Juan", "Perez", "claveChanta2", "juan@gmail.com", "Soy juan", true, true);

            //Los agrego al gestor. 
            GestorReprod.Usuarios.Add(Usuario1); GestorReprod.Usuarios.Add(Usuario2);

            //MENU PROGRAMA GENERAL.

            bool runningProgram = true;

            while (runningProgram)
            {
                Console.WriteLine("Bienvenido a Netify.");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Registrarse.");
                Console.WriteLine("3. Modo Admin.");
                Console.WriteLine("4. Salir.");

                int mainChoice = Convert.ToInt32(Console.ReadLine());

                switch (mainChoice)
                {
                    case 1:

                        Console.Clear();

                        //Login funciona asi: Usuario ingresa mail y gestor busca mails de todos los usuarios hasta encontrar
                        //el mail que corresponde. Luego pide contraseña y deja a usuario acceder si contraseña ingresada 
                        //es igual a la guardada para aquel mail.

                        //Primero pido mail usuario.

                        bool checkingMail = true; bool validMail = false;

                        //Pido los mails, cuando el que ingreso calza con alguno en la base de datos del gestor
                        //guardo la contraseña de aquel usuario para ver que calce con la que ingreso.

                        int loginID = 0;

                        while (checkingMail)
                        {
                            Console.WriteLine("Ingrese mail: ");
                            string candidateMail = Console.ReadLine();

                            for (int i = 0; i < GestorReprod.Usuarios.Count(); i++)
                            {
                                if (GestorReprod.Usuarios[i].mail == candidateMail)
                                {
                                    Console.WriteLine("Mail Valido."); Console.Clear();
                                    string loginPassword = GestorReprod.Usuarios[i].claveUsuario;
                                    loginID = GestorReprod.Usuarios[i].idUsuario;
                                    validMail = true;  checkingMail = false;
                                }
                            }
                            //Sist. pide mail a usuario hasta que ingresa uno veridico. 
                            if (validMail == false) { Console.WriteLine("Correo Erroneo."); }
                        }


                        //Ahora checkeo contraseña.

                        bool checkingPassword = true; bool validPassword = false;


                        while (checkingPassword)
                        {
                            Console.WriteLine("Ingrese Clave: ");
                            string candidatePassword = Console.ReadLine();

                            if (GestorReprod.Usuarios[loginID].claveUsuario == candidatePassword)
                            {
                                Console.WriteLine("Contraseña Valida."); Console.Clear();
                                validPassword = true; checkingPassword = false;
                            }

                            //Sist. pide password a usuario hasta que ingrese la que corresponde.
                            if (validPassword == false) { Console.WriteLine("Contraseña invalida."); }
                        }

                        Console.Clear();

                        //AHORA QUE ESTOY DENTRO DEL SISTEMA, HAGO LO QUE TENGA QUE HACER.

                        break;

                    case 2:

                        Console.Clear();

                        bool creatingUser = true;
                        while (creatingUser)
                        {
                            Console.WriteLine("Ingrese 1 para crear otro usuario, 2 para salir: ");
                            int choice = Convert.ToInt32(Console.ReadLine());

                            if (choice == 1)
                            {
                                GestorReprod.NuevoUsuario();
                            }

                            if (choice == 2)
                            {
                                creatingUser = false; 
                            }

                        }

                        break;


                }




            }*/







            ////Imprimo datos de todos los usuarios en sistema. 

            //for (int i = 0; i < GestorReprod.Usuarios.Count(); i++)
            //{
            //    GestorReprod.Usuarios[i].userData();
            //    Console.WriteLine("\n");

            //}


        }
    }
}
