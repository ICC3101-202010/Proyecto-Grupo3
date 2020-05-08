using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entrega2
{
    class Gestor
    {
        //Parametros de gestor. 

        public List<User> Usuarios;

        //Constructor de gestor. 
        public Gestor()
        {
            this.Usuarios = new List<User>();
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

                NPerson createdUser = new NPerson(newUserID, 0, newName, newLastName, newPassword, newMail, newDesc, newPriv, newIsPremium);
                this.Usuarios.Add(createdUser);

                Console.Clear();
                Console.WriteLine("Usuario creado con exito. ");
                creatingUser = false;
            }

        }
    }
}
