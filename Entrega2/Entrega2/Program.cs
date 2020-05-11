using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using NAudio.Wave;
using System.Security.Cryptography.X509Certificates;

namespace Entrega2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //MANUEL
            //Creo algunos usuarios de prueba. 
            NPerson user;
            Gestor gestor = new Gestor();
            Song song;
            DataBase data = new DataBase();
            List<string> info = new List<string>();
            WaveOutEvent outputdevice = new WaveOutEvent(); 
            var enviroment = System.Environment.CurrentDirectory;
            bool runningprogram = true , firstcase;//changed case1 to first case beccause case 1 is kinda reserved.
            bool loggedin , loginresult , menuresult;
            int mainchoice, i = 0;//choicenu == choice new user;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            string txt_songsinfo_path = projectDirectory + @"\Songsinfo.txt";
            string txt_users_path = projectDirectory + @"\Users.txt";
            string txt_songs_path = projectDirectory + @"\Songs\";

            //                                    ****************USERS DATA BASE CREATION*********************
            gestor.FilesReader(data, txt_users_path, txt_songsinfo_path);
            /*using (StreamReader sr = File.OpenText(txt_users_path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    info.Add(s);
                    i++;
                    if (i == 8)
                    {
                        user = new NPerson(Convert.ToInt32(info[0]), info[1], info[2], info[3], info[4], info[5], Convert.ToBoolean(info[6]), Convert.ToBoolean(info[7]));
                        data.Users.Add(user);
                        i = 0;
                        info.Clear();
                    }
                }
            }
            using (StreamReader sr = File.OpenText(txt_songsinfo_path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    info.Add(s);
                    i++;
                    if (i == 6)
                    {
                        song = new Song(info[0], info[1], info[2], info[3], info[4], info[5]);
                        data.Song.Add(song);
                        i = 0;
                        info.Clear();
                    }
                }
            }*/

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
                            loginresult = gestor.Login(data);
                            if (loginresult == false)
                                break;
                            //Dado que pase filtro del login, puedo hacer lo que quiera. 
                            loggedin = true;
                            while (loggedin)
                            {
                                menuresult = gestor.Menu(data,outputdevice,txt_users_path,txt_songs_path);
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
