using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3Netify
{
     static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
         static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);




            //Cargo Usuarios.
            List<NPerson> users = Gestor.UsersLoad();
            




            //Cargo matriz de seguidores.

            MainMenu mainMenu = new MainMenu(users);
            Application.Run(mainMenu);
            
        }
    }
}


