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
    public partial class ChangeUserDataForm : Form 
    {
        //Heredo usuario actual del login. 
        public NPerson currentUser;
        public List<NPerson> users;
        MainLoginForm mainlog;


        public ChangeUserDataForm(List<NPerson> users, NPerson currentUser, MainLoginForm mainlog)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.users = users;
            this.mainlog = mainlog;

            //Fijo los textBox para que muestren parametros actuales del usuario


            MailBox.Text = currentUser.Email;
            PasswordBox.Text = currentUser.Password;
            nameBox.Text = currentUser.Name;
            lastNameBox.Text = currentUser.LastName;
            DescBox.Text = currentUser.Description;

            //Idem con los checkbox. 

            PrivateCheck.Checked = currentUser.Private;
            PremiumCheck.Checked = currentUser.Premium;


        }

        //OMITIR ESTO.
        private void ChangeUserDataForm_Load(object sender, EventArgs e)
        {

        }

        private void MailBox_TextChanged(object sender, EventArgs e)
        {
            currentUser.Email = MailBox.Text;
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            currentUser.Password = PasswordBox.Text;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            currentUser.Name = nameBox.Text;
        }

        private void lastNameBox_TextChanged(object sender, EventArgs e)
        {
            currentUser.LastName = lastNameBox.Text;
        }

        private void DescBox_TextChanged(object sender, EventArgs e)
        {
            currentUser.Description = DescBox.Text;
        }

        private void PrivateCheck_CheckedChanged(object sender, EventArgs e)
        {
            currentUser.Private = PrivateCheck.Checked;
        }

        private void PremiumCheck_CheckedChanged(object sender, EventArgs e)
        {
            currentUser.Premium = PremiumCheck.Checked;
        }

        private void CommitChangesButton_Click(object sender, EventArgs e)
        {

            int index = currentUser.IDUser;
            for (int i = 0; i < users.Count(); i++)
            {
                int cand = users[i].IDUser;


                if (index == cand)
                {
                   
                    //Guardo los cambios en archivo User.

                    //.. primero asigno.

                    users[i].Email = currentUser.Email;
                    users[i].Password = currentUser.Password;
                    users[i].Name = currentUser.Name;
                    users[i].LastName = currentUser.LastName;
                    users[i].Description = currentUser.Description;
                    users[i].Private = currentUser.Private;
                    users[i].Premium = currentUser.Premium;

                    //.. ahora serializo. 

                    Gestor.UsersSave(users);

                    MessageBox.Show("Cambios guardados exitosamente.");
                    return; 
                }
            }
            




            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            mainlog.Show();
        }

        public void UsersSave(List<NPerson> UsersList)
        {
            throw new NotImplementedException();
        }

        public List<NPerson> UsersLoad()
        {
            throw new NotImplementedException();
        }

        private void ChangeUserDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainlog.Show();
        }
    }
}
