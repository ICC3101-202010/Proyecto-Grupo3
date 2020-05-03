using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NAudio.Wave;

namespace Entrega2
{
    class Song
    {
        private string Artists;

        private string Composer;

        private string Discography;

        private string Album;

        private string Lyrics;

        public string Name;

        public Song(string Name , string Artists, string Composer , string Album , string Discography , string Lyrics) {
            this.Album = Album;
            this.Composer = Composer;
            this.Artists = Artists;
            this.Discography = Discography;
            this.Lyrics = Lyrics;
            this.Name = Name;
        }
        public void Menu(int choice)
        {
            double for_backwards;
            string op;
            string generic_path = @"C:\Users\userprofile\source\repos\Netify\Songs\name.mp3";
            string username = Environment.UserName;
            string path_v1 = generic_path.Replace("name", Name);
            string path = path_v1.Replace("userprofile", username);
            Console.WriteLine(path);
            using var audioFile = new AudioFileReader(path);
            using var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            while (choice!=0)
            {
                if (choice == 1)
                {
                    //outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Console.WriteLine("Opciones:\n" + "1 Stop\n" + "2 forward or backward\n" + "3 Replay");
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
                            Console.WriteLine(audioFile.CurrentTime);

                        }
                        else if (op == "3") 
                        {
                            choice = 3;
                            break;
                        }

                    }
                }
                else if (choice == -1)
                {
                    Console.WriteLine("Desea hace algo mas? ");
                    choice = Convert.ToInt32(Console.ReadLine());

                }
                //else if (choice == 3)

                    
            }
            
        }
        /*public void Play( AudioFileReader File , WaveOutEvent Device) 
        {
            Device.Init(File);
            Device.Play();
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(1000);
            }
            Thread.Sleep(1000);
            outputDevice.Stop();
            outputDevice.Dispose();
        }
        public void Pause() 
        {
            string generic_path = @"C:\Users\userprofile\source\repos\Netify\Songs\name.mp3";
            string username = Environment.UserName;
            string path_v1 = generic_path.Replace("name", Name);
            string path = path_v1.Replace("userprofile", username);
            Console.WriteLine(path);
            using var audioFile = new AudioFileReader(path);
            using var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Pause();
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(1000);
            }
        }*/
    }
}
