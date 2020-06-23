using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Mail;


namespace Entrega3Netify
{
        [Serializable]
        public abstract class User
        {
            //Parametros base de un usuario.
            public int idUsuario;
            public int metodoPago;
            public string nombre;
            public string apellido;
            public string claveUsuario;
            public string mail;
            public string descripcion;
            public bool privado;
            public bool premium;
        }
}
