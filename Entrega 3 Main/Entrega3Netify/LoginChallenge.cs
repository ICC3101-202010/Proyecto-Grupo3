using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3Netify
{
    public partial class LoginChallenge : Form
    {
        //Le paso al login lista de usuarios que se carga en program. 
        public List<NPerson> users;
        public string candMail;
        public string candPassword;

        public LoginChallenge(List<NPerson> users)
        {
            InitializeComponent();
            this.users = users;
        }


        private void EnterMailTextBox_TextChanged(object sender, EventArgs e)
        {
            this.candMail = EnterMailTextBox.Text;
            candMail = Convert.ToString(candMail);
        }

        private void EnterPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            this.candPassword = EnterPasswordTextBox.Text;
            candPassword = Convert.ToString(candPassword);
        }

        private void AcceptLoginButton_Click(object sender, EventArgs e)
        {
            //Checkeo todos los usuarios hasta que encuentro el que corresponde.
            for (int i = 0; i < users.Count(); i++)
            {
                string userMail = users[i].Email;
                string userPassword = users[i].Password;

                if (userMail == candMail && userPassword == candPassword)
                {
                    MessageBox.Show("Login exitoso.");
                    int currentUserID = users[i].IDUser;

                    //INSTANCIO E INICIO APP PARA USUARIO I ACA. 
                    // (CREO FORM DE LOGIN PRINCIPAL Y LE PASO COMO PARAM. EL USUARIO
                    // QUE ESTA ENTRANDO AL SIST.)


                    MainLoginForm mainLogin = new MainLoginForm(users, users[i]);
                    mainLogin.ShowDialog();
                    this.Close();
                    return;
                }
            } 


            MessageBox.Show("Login incorrecto, intente de nuevo.");
            return; 



            
        }

        //FUNCION DE ESCAPE. 
        private void CancelLoginButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }












        //IGNORAR ESTO.
        private void LoginChallenge_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
