using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Entrega3Netify
{
    public partial class RegisterForm : Form
    {
        string regMail;
        string regPassword;
        string regName;
        string regLastName;
        string regDescription;

        bool regPrivate;
        bool regPremium;


        public List<NPerson> users;
        MainMenu main;
        public RegisterForm(List<NPerson> users, MainMenu main
            )
        {
            InitializeComponent();
            this.users = users ;
            this.regMail = "";
            this.regPassword = "";
            this.regName = "";
            this.regLastName = "";
            this.regDescription = "";
            this.main = main;
   
        }

        //Cada textBox me guarda el param. del usuario. 
       
        private void inputMailBox_TextChanged(object sender, EventArgs e)
        {
            this.regMail = inputMailBox.Text;

        }

        private void inputPasswordBox_TextChanged(object sender, EventArgs e)
        {
            this.regPassword = inputPasswordBox.Text;
        }

        private void enterNameBox_TextChanged(object sender, EventArgs e)
        {
            this.regName = enterNameBox.Text;
        }

        private void enterLastNameBox_TextChanged(object sender, EventArgs e)
        {
            this.regLastName = enterLastNameBox.Text;
        }

        private void enterDescBox_TextChanged(object sender, EventArgs e)
        {
            this.regDescription = enterDescBox.Text;
        }

        //Checkbox de privacidad y si es premium o no.
        private void privateCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (privateCheckbox.Checked)
            {
                this.regPrivate = true;
            }
            else
            {
                this.regPrivate = false;
            }
        }

        private void premiumCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (premiumCheckBox.Checked)
            {
                this.regPremium = true;
            }

            else
            {
                this.regPremium = false;
            }
        }



        //Opcion de escape. 
        private void cancelRegisterButton_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }


        //Acepto y registro. 
        private void acceptRegisterButton_Click(object sender, EventArgs e)
        {

            bool critOk = true;

            //Message boxs de error. 
            if (regMail.Length == 0 | (Regex.IsMatch(regMail, @"[.\w]*[@]\w+[.]\w{2,3}") == false))
            {
                MessageBox.Show("Por favor, ingrese un mail.");
                critOk = false;
            }

            if (regPassword.Length == 0)
            {
                MessageBox.Show("Por favor, ingrese una contraseña.");
                critOk = false;
            }

            if (regName.Length == 0)
            {
                MessageBox.Show("Por favor, ingrese su nombre.");
                critOk = false;
            }

            if (regLastName.Length == 0)
            {
                MessageBox.Show("Por favor, ingrese su apellido.");
                critOk = false;
            }

            if (regDescription.Length == 0)
            {
                MessageBox.Show("Por favor, ingrese su descripcion.");
                critOk = false;
            }


            if (critOk)
            {
                //regPassword = Convert.ToString(inputPasswordBox.Text);
                //regName = Convert.ToString(enterNameBox.Text);
                //regLastName = Convert.ToString(enterLastNameBox.Text);
                //regDescription = Convert.ToString(enterDescBox.Text);
                //regMail = Convert.ToString(inputMailBox.Text);


                Debug.WriteLine(regName);

                int regIdent;
                regIdent = users.Count + 1;


                NPerson newUser = new NPerson(regIdent, regName, regLastName, regPassword, regMail, regDescription, regPrivate, regPremium);
                users.Add(newUser);

                //CODIGO PARA VER QUE ESTO FUNCIONE.
                for (int i = 0; i < users.Count; i++)
                {
                    Debug.WriteLine(users[i].IDUser + users[i].Name);
                }



                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Users.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                formatter.Serialize(stream, users);
                stream.Close();

                MessageBox.Show("Se registro con exito");
                this.Close();
                main.Show();
            }
        }
        //OMITIR ESTO. 
        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        

    }
}
