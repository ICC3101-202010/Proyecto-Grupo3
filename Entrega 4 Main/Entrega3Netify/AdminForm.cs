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
    public partial class AdminForm : Form
    {
        List<NPerson> users;
        MainMenu main;
        public AdminForm(List<NPerson> users, MainMenu main)
        {
            InitializeComponent();
            this.users = users;
            this.main = main;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            UsersListView.View = View.Details;
            UsersListView.Columns.Add("ID");
            UsersListView.Columns.Add("Nombre");
            UsersListView.Columns.Add("Apellido");
            UsersListView.Columns.Add("Email");
            UsersListView.Columns.Add("Contraseña");
            UsersListView.Columns.Add("Privado/Publico");
            UsersListView.Columns.Add("Premium/Normal");
            foreach (NPerson person in users)
            {
                UsersListView.Items.Add(new ListViewItem(new[] {person.IDUser.ToString(),person.Name,person.LastName,person.Email,person.Password,person.Private.ToString(),person.Premium.ToString() }));
            }

        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            {
                foreach (NPerson person in users)
                {
                    if (UsersListView.SelectedItems[0].Text == person.IDUser.ToString())
                    {
                        users.RemoveAt(users.IndexOf(person));
                        UsersListView.Items.Remove(UsersListView.SelectedItems[0]);
                        UsersListView.SelectedItems.Clear();
                        Gestor.UsersSave(users);
                        return;
                    }
                }
            }
        }
    }
}
