using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega3Netify
{

    [Serializable]
    public class Actor : User
    {
        //public List<Video> Peliculas;
        public List<string> Premios { get; set; }
        public int IDUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool Private { get; set; }
        public bool Premium { get; set; }




        public Actor(int IDUser, string Name, string LastName, string Password, string Email, string Description, bool Private, bool Premium, List<string> Premios)

        {
            //Params. de actor. 

            this.IDUser = IDUser; this.Name = Name; this.LastName = LastName; this.Email = Email; this.Description = Description;
            this.Private = Private; this.Premium = Premium;
            this.Premios = Premios;

        }
    }
}
