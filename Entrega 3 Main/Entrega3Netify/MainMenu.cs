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
    public partial class MainMenu : Form
    {
        //Trabajo todo esto con la lista de usuarios.

        public List<NPerson> users;
        public MainMenu(List<NPerson> users)
        {
            InitializeComponent();
            this.users = users; 
        }

        //Click opcion registrarse. 
        private void MenuRegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm(users);
            regForm.Show();
        }

        //Click opcion login. 
        private void MenuLoginButton_Click(object sender, EventArgs e)
        {
            //Si hago click, me abre un forms de login. 
            LoginChallenge loginChallenge = new LoginChallenge(users);
            loginChallenge.Show();

        }

        //Menu de escape. 
        private void MenuExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
