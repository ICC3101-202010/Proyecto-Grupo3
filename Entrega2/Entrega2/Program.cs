using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using NAudio.Wave;
using System.Security.Cryptography.X509Certificates;
using System.Net.Mail;

namespace Entrega2
{
    class Program
    {
        static void Main(string[] args)
        {

            //MANUEL
            Gestor gestor = new Gestor();
            DataBase data = new DataBase();
            //List<string> info = new List<string>();
            WaveOutEvent outputdevice = new WaveOutEvent(); 
            var enviroment = System.Environment.CurrentDirectory;
            bool runningprogram = true , firstcase;//changed case1 to first case beccause case 1 is kinda reserved.
            bool loggedin , loginresult1 , menuresult;
            int mainchoice,  loginidd = 0;//choicenu == choice new user;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            string txt_songsinfo_path = projectDirectory + @"\Songsinfo.txt";
            string txt_users_path = projectDirectory + @"\Users.txt";
            string txt_songs_path = projectDirectory + @"\Songs\";
            string txt_playlist_path = projectDirectory + @"\Playlistsnum.txt";
            
            

            //                                    ****************USERS DATA BASE CREATION*********************
            gestor.FilesReader(data, txt_users_path, txt_songsinfo_path,txt_playlist_path);
            //menu programa general.
            while (runningprogram)
            {
                Console.WriteLine("Bienvenido a Netify.");
                Console.WriteLine("1. Login: ");
                Console.WriteLine("2. Registrarse: ");
                Console.WriteLine("3. Salir: ");
                mainchoice = Convert.ToInt32(Console.ReadLine());
                switch (mainchoice)
                {
                    //                                    ****************LOGIN*********************
                    case 1:
                        firstcase = true;
                        while (firstcase)
                        {
                            Tuple<string, bool> loginresult = gestor.Login(data,ref loginidd);
                            string mailuser = loginresult.Item1;
                            
                            loginresult1 = loginresult.Item2;
                            if (loginresult1 == false)
                                break;
                            //Dado que pase filtro del login, puedo hacer lo que quiera. 
                            loggedin = true;
                            while (loggedin)
                            {
                                //user.First(m => m.name == stringToFind);
                                //string mailuser = 
                                menuresult = gestor.Menu(data, outputdevice, txt_users_path, txt_songs_path, txt_playlist_path, mailuser,loginidd);
                                if (!menuresult)
                                {
                                    firstcase = false;
                                    break;
                                }
                            }
                        }
                        break;
                    //                                            ****************NEW USER*********************    
                    case 2:
                        gestor.Register(data,txt_users_path);
                        break;
                    //                                           ****************ClOSE PROGRAM*********************    
                    case 3:
                        runningprogram = false;
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
