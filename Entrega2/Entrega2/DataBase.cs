using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega2
{
    public class DataBase
    {
        public List<Song> Song = new List<Song>();
        public List<Playlist> playlists = new List<Playlist>();
        public List<NPerson> Users = new List<NPerson>();
        public List<Video> Videos = new List<Video>();
        public List<VideoPlaylist> videoPlaylists = new List<VideoPlaylist>();

        public void AddSongData(Song song, string path) //adds the new song to the data base and to the songs.txt file
        {
            Song.Add(song);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Seek(0, SeekOrigin.End);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    // To append, update the stream's position to the end of the file
                    sw.WriteLine(song.Name);
                    sw.WriteLine(song.Album);
                    sw.WriteLine(song.Artists);
                    sw.WriteLine(song.Genre);
                    sw.WriteLine(song.Year);
                    sw.WriteLine(song.Lyrics);
                }
            }
        }
        public void AddToPlaylist(Song sg ,Playlist playlist , string path)//adds the recently created playlist to the database
        {                                                         //and creates a new file.txt for it
            playlist.ActualPlaylist.Add(sg);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Seek(-3, SeekOrigin.End);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(sg.Name);
                    sw.WriteLine(sg.Album);
                    sw.WriteLine(sg.Artists);
                    sw.WriteLine(sg.Genre);
                    sw.WriteLine(sg.Year);
                    sw.WriteLine(sg.Lyrics);
                    sw.WriteLine("/-*");
                }
            }
        }
        public void AddPlaylist(Playlist playlist , string path)
        {
            playlists.Add(playlist);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                if (new FileInfo(path).Length == 0)// first users playlist
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(playlist.Name);
                        sw.WriteLine(playlist.Private);
                        sw.WriteLine(playlist.Date);
                        foreach (Song sg in playlist.ActualPlaylist)
                        {
                            sw.WriteLine(sg.Name);
                            sw.WriteLine(sg.Album);
                            sw.WriteLine(sg.Artists);
                            sw.WriteLine(sg.Genre);
                            sw.WriteLine(sg.Year);
                            sw.WriteLine(sg.Lyrics);
                        }
                        sw.WriteLine("/-*");
                    }
                }
                else                             //new playlist
                {
                    fs.Seek(0, SeekOrigin.End);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(playlist.Name);
                        sw.WriteLine(playlist.Private);
                        sw.WriteLine(playlist.Date);
                        foreach (Song sg in playlist.ActualPlaylist)
                        {
                            sw.WriteLine(sg.Name);
                            sw.WriteLine(sg.Album);
                            sw.WriteLine(sg.Artists);
                            sw.WriteLine(sg.Genre);
                            sw.WriteLine(sg.Year);
                            sw.WriteLine(sg.Lyrics);
                        }
                        sw.WriteLine("/-*");
                    }
                }
            }
        }
        public void AddUserData(NPerson user , string path)//adds the new user to the data base and to the users.txt file
        {
            Users.Add(user);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                if (new FileInfo(path).Length == 0)
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(user.IDUser);
                        sw.WriteLine(user.Name);
                        sw.WriteLine(user.LastName);
                        sw.WriteLine(user.Password);
                        sw.WriteLine(user.Email);
                        sw.WriteLine(user.Description);
                        sw.WriteLine(user.Private);
                        sw.WriteLine(user.Premium);
                    }
                }
                else
                {
                    fs.Seek(0, SeekOrigin.End);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(user.IDUser);
                        sw.WriteLine(user.Name);
                        sw.WriteLine(user.LastName);
                        sw.WriteLine(user.Password);
                        sw.WriteLine(user.Email);
                        sw.WriteLine(user.Description);
                        sw.WriteLine(user.Private);
                        sw.WriteLine(user.Premium);
                    }
                }
            }
        }
        public void UserDataChange(NPerson user, int datapos, string newdata, string path)//replaces the desired data in the database and in the user.txt file
        {
            string text = File.ReadAllText(path);
            foreach (NPerson us in Users)
            {
                if (user.IDUser == us.IDUser)
                {
                    switch (datapos)
                    {
                        case 1:
                            text = text.Replace(us.Name, newdata);
                            File.WriteAllText(path, text);
                            us.Name = newdata;
                            break;
                        case 2:
                            text = text.Replace(us.LastName, newdata);
                            File.WriteAllText(path, text);
                            us.LastName = newdata;
                            break;
                        case 3:
                            text = text.Replace(us.Password, newdata);
                            File.WriteAllText(path, text);
                            us.Password = newdata;
                            break;
                        case 4:
                            text = text.Replace(us.Email, newdata);
                            File.WriteAllText(path, text);
                            us.Email = newdata;
                            break;
                        case 5:
                            text = text.Replace(us.Description, newdata);
                            File.WriteAllText(path, text);
                            us.Description = newdata;
                            break;
                        case 6:
                            text = text.Replace(Convert.ToString(us.Private), newdata);
                            File.WriteAllText(path, text);
                            us.Private = Convert.ToBoolean(newdata);
                            break;
                        case 7:
                            text = text.Replace(Convert.ToString(us.Premium), newdata);
                            File.WriteAllText(path, text);
                            us.Premium = Convert.ToBoolean(newdata);
                            break;
                    }
                }
            }
        }
        public void UserDelete(NPerson user, string path)//deletes data from the database, eliminates previous file , creates a new one, write data on it.
        {
            Users.Remove(user);
            File.Delete(path);//delete the file
            using (FileStream fs = File.Create(path)) { };//recreate the file empty
            using (StreamWriter sw = new StreamWriter(path))//write data to the file
            {
                foreach (NPerson registered in Users)
                {
                    sw.WriteLine(registered.IDUser);
                    sw.WriteLine(registered.Name);
                    sw.WriteLine(registered.LastName);
                    sw.WriteLine(registered.Password);
                    sw.WriteLine(registered.Email);
                    sw.WriteLine(registered.Description);
                    sw.WriteLine(registered.Private);
                    sw.WriteLine(registered.Premium);
                }
            }

        }

        public void addVideo(Video video)// Agrega un video a la lista de videos y la ordena por orden alfabetico por el atributo nombre
        {
            Videos.Add(video);
            Videos.Sort((x, y) => x.name.CompareTo(y.name));

        }
    }
}
