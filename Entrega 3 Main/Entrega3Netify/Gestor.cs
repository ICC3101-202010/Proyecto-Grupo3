using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3Netify
{
    [Serializable]
    public class Gestor 
    {

        //HERRAMIENTAS PARA GUARDAR Y CARGAR USUARIOS.
        public static void UsersSave(List<NPerson> UsersList)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Users.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            formatter.Serialize(stream, UsersList);
            stream.Close();
        }

        public static List<NPerson> UsersLoad()
        {
            IFormatter formatter2 = new BinaryFormatter();
            Stream stream2 = new FileStream("Users.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            try
            {
                List<NPerson> UsersList = (List<NPerson>)formatter2.Deserialize(stream2);
                stream2.Close();
                return UsersList;
            }
            catch (SerializationException)
            {
                List<NPerson> UsersList = new List<NPerson>();
                formatter2.Serialize(stream2, UsersList);
                stream2.Close();
                return UsersList;
                throw;
            }   
        }

        //HERRAMIENTAS PARA GUARDAR Y CARGAR ACTORES. 
        public static void ActorsSave(List<Actor> ActorsList)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Actors.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            formatter.Serialize(stream, ActorsList);
            stream.Close();
        }


        public static List<Actor> ActorsLoad()
        {
            IFormatter formatter2 = new BinaryFormatter();
            Stream stream2 = new FileStream("Actors.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            try
            {
                List<Actor> ActorsList = (List<Actor>)formatter2.Deserialize(stream2);
                stream2.Close();
                return ActorsList;
            }
            catch (SerializationException)
            {
                List<Actor> ActorsList = new List<Actor>();
                formatter2.Serialize(stream2, ActorsList);
                stream2.Close();
                return ActorsList;
                throw;
            }
        }

        //HERRAMIENTAS PARA GUARDAR Y CARGAR CANTANTES. 

        public static void SingersSave(List<Singer> SingersList)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Singers.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            formatter.Serialize(stream, SingersList);
            stream.Close();
        }


        public static List<Singer> SingersLoad()
        {
            IFormatter formatter2 = new BinaryFormatter();
            Stream stream2 = new FileStream("Singers.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            try
            {
                List<Singer> SingersList = (List<Singer>)formatter2.Deserialize(stream2);
                stream2.Close();
                return SingersList;
            }
            catch (SerializationException)
            {
                List<Singer> SingersList = new List<Singer>();
                formatter2.Serialize(stream2, SingersList);
                stream2.Close();
                return SingersList;
                throw;
            }
        }

        //HERRAMIENTAS PARA AGREGAR VIDEOS Y AAGREGAR VIDEO A UNA PLAYLIST
        /*public void addVideo(Video video)// Agrega un video a la lista de videos y la ordena por orden alfabetico por el atributo nombre
        {
            Videos.Add(video);
            Videos.Sort((x, y) => x.name.CompareTo(y.name));

        }

        public void addVideoPlaylist(VideoPlaylist playlist, string user)// Agrega un video a la lista de videos y la ordena por orden alfabetico por el atributo nombre
        {
            var us_plist = Users.First(m => m.Email == user);
            //us_plist.VideosPublicos.Add
            //us_plist.Sort((x, y) => x.name.CompareTo(y.name));

        }*/

        public static void SaveVideoOnUser(List<NPerson> users, NPerson current, string name, string genre, string category, string director, string description, string resolution, string path)
        {
            Video video = new Video(name, genre, category, director, description, resolution, path);
            current.VideosImportados.Add(video);
            
            int index = current.IDUser;
            for (int i = 0; i < users.Count(); i++)
            {
                int cand = users[i].IDUser;


                if (index == cand)
                {
                    Gestor.UsersSave(users);
                }
            }
        }

        public static void SaveVideoOnPlaylistAndUser(List<NPerson> users, NPerson current, Video video, string name, bool privado)
        {
            VideoPlaylist playlist = new VideoPlaylist(name, privado);
            playlist.AddToPlaylist(video);

            if (privado)
            {
                current.VideosPrivados.Add(playlist);
            }
            else if(privado == false)
            {
                current.VideosPublicos.Add(playlist);
            }

            int index = current.IDUser;
            for (int i = 0; i < users.Count(); i++)
            {
                int cand = users[i].IDUser;


                if (index == cand)
                {
                    Gestor.UsersSave(users);
                }
            }
        }
        public static void CreateSaveVideoOnPlaylistAndUser(List<NPerson> users, NPerson current, Video video, string name)
        {
            if (current.VideosPrivados.Count() != 0)
            {
                foreach (VideoPlaylist plst in current.VideosPrivados)
                {
                    if (name == plst.name)
                    {
                        plst.AddToPlaylist(video);
                    }
                }
            }
            if (current.VideosPublicos.Count() != 0)
            {
                foreach (VideoPlaylist plst in current.VideosPublicos)
                {
                    if (name == plst.name)
                    {
                        plst.AddToPlaylist(video);
                    }
                }
            }


            int index = current.IDUser;
            for (int i = 0; i < users.Count(); i++)
            {
                int cand = users[i].IDUser;


                if (index == cand)
                {
                    Gestor.UsersSave(users);
                }
            }
        }

        public static void SaveFavoriteUser(List<NPerson> users, NPerson current)
        {
            int index = current.IDUser;
            for (int i = 0; i < users.Count(); i++)
            {
                int cand = users[i].IDUser;


                if (index == cand)
                {
                    Gestor.UsersSave(users);
                }
            }
        }

        public static void SaveSongOnUser(List<NPerson> users, NPerson current, string name, string album, string artist, string genre, string year, string format)
        {
            Song song = new Song(name, album, artist, genre, year, format);
            current.Importedsongs.Add(song);
            int index = current.IDUser;
            for (int i = 0; i < users.Count(); i++)
            {
                int cand = users[i].IDUser;


                if (index == cand)
                {
                    Gestor.UsersSave(users);
                }
            }
        }

        public static void SaveSongOnPlaylistAndUser(List<NPerson> users, NPerson current, List<Song> nplaylist,string name ,bool privado)
        {
            SongPlaylist playlist = new SongPlaylist(name, privado);
            foreach(Song s in nplaylist)
            {
                playlist.AddToThisPlaylist(s);
            }
            if (privado)
            {
                current.CancionesPrivadas.Add(playlist);
            }
            else if (privado == false)
            {
                current.CancionesPublicas.Add(playlist);
            }

            int index = current.IDUser;
            for (int i = 0; i < users.Count(); i++)
            {
                int cand = users[i].IDUser;


                if (index == cand)
                {
                    Gestor.UsersSave(users);
                }
            }
        }
    }
}
