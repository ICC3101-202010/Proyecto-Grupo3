using System;
using System.Collections.Generic;
using System.Text;

namespace Entrega2
{
    class Gestor
    {
        public static void Main(string[] args)
        {
            //Creo algunos usuarios de prueba. 

            PersonaN Usuario1 = new PersonaN(0, 0, "Pepito", "Perez", "claveChanta", "pepito@gmail.com", "Soy pepito", false, false);
            PersonaN Usuario2 = new PersonaN(0, 0, "Juan", "Perez", "claveChanta2", "juan@gmail.com", "Soy juan", true, true);

            Usuario1.cambiarDato("","");
        }
    }
}
