using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using NAudio.Wave;

namespace Entrega2
{

    class Program
    { //Parte Main, aca se ejecuta todo lo que tenga que ver con interaccion con usuario.
        
        public static void Main(string[] args)
        {
            Song cancion = new Song("Circles","Post Malone","pp","disc","","turururu");
            int choice = Convert.ToInt32(Console.ReadLine());
            //cancion.Menu(eleccion);
            double for_backwards;
            string op;
            string generic_path = @"C:\Users\userprofile\source\repos\Netify\Songs\name.mp3";
            string username = Environment.UserName;
            string path_v1 = generic_path.Replace("name", cancion.Name);
            string path = path_v1.Replace("userprofile", username);
            Console.WriteLine(path);
            using var audioFile = new AudioFileReader(path);
            using var outputDevice = new WaveOutEvent();
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

           /* string name = "Circles.mp3";
            string fullpath = Path.GetFullPath(name);
            Console.WriteLine(fullpath);*/

                /*
                //Primero, creo instancia de gestor. 
                Gestor GestorReprod = new Gestor();

                //Creo algunos usuarios de prueba. 
                PersonaN Usuario1 = new PersonaN(0, 0, "Pepito", "Perez", "claveChanta", "pepito@gmail.com", "Soy pepito", false, false);
                PersonaN Usuario2 = new PersonaN(0, 0, "Juan", "Perez", "claveChanta2", "juan@gmail.com", "Soy juan", true, true);

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




                }







                ////Imprimo datos de todos los usuarios en sistema. 

                //for (int i = 0; i < GestorReprod.Usuarios.Count(); i++)
                //{
                //    GestorReprod.Usuarios[i].userData();
                //    Console.WriteLine("\n");

                //}

                */
            }
        }



    /*class Gestor
    {
        //Parametros de gestor. 

        public List<Usuario> Usuarios;

        //Constructor de gestor. 
        public Gestor()
        {
            this.Usuarios = new List<Usuario>();
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

                PersonaN createdUser = new PersonaN(newUserID, 0, newName, newLastName, newPassword, newMail, newDesc, newPriv, newIsPremium);
                this.Usuarios.Add(createdUser);

                Console.Clear();
                Console.WriteLine("Usuario creado con exito. ");
                creatingUser = false;
            }

        }



    }*/

   
}
