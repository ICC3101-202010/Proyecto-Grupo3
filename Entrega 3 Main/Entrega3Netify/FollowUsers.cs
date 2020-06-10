using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3Netify
{
    public partial class FollowUsers : Form
    {

        NPerson currentUser; 
        List<NPerson> userList;
        MatrizSeguidores mainMatrix;

        public FollowUsers(List<NPerson> _userList, NPerson _currentUser)
        {
            InitializeComponent();
            this.mainMatrix  = new MatrizSeguidores();
            this.currentUser = _currentUser;
            this.userList = _userList;

            FollowedUsersListView.View = View.Details; 
            FollowedUsersListView.Columns.Add("ID Usuario.");
            FollowedUsersListView.Columns.Add("Nombre Usuario.");
            FollowedUsersListView.Columns.Add("Descripcion.");
            FollowedUsersListView.Columns.Add("Seguido.");

            List<bool> seguidosActual = mainMatrix.matrizSeguidores[currentUser.IDUser];

            for (int i = 0; i < userList.Count(); i++)
            {

                //Voy mostrando en ListView segun si los sigo o no. 

                if (seguidosActual[i] == true)
                {
                    var item1 = new ListViewItem(new[] { Convert.ToString(userList[i].IDUser), userList[i].Name + " " + userList[i].LastName, userList[i].Description, "Seguido" });
                    FollowedUsersListView.Items.Add(item1);
                    continue;
                }

                if (seguidosActual[i] == false)
                {
                    var item1 = new ListViewItem(new[] { Convert.ToString(userList[i].IDUser), userList[i].Name + " " + userList[i].LastName, userList[i].Description, "No Seguido" });
                    FollowedUsersListView.Items.Add(item1);
                }

            }
            

            if (FollowedUsersListView.Items.Count > 0)
            {
                FollowedUsersListView.MultiSelect = false;
                FollowedUsersListView.Items[0].Selected = true;
                FollowedUsersListView.Select();

            }

            
        }

        private void followSelected_Click(object sender, EventArgs e)
        {
            String index = FollowedUsersListView.SelectedItems[0].Text;

            FollowedUsersListView.SelectedItems[0].SubItems[3].Text = "Seguido";

            //Debug.WriteLine("Seguidos:");
            //Debug.WriteLine(index);

            int followedIndex = Convert.ToInt32(index);
            mainMatrix.seguirUsuario(currentUser.IDUser, followedIndex);






        }

        private void unfollowSelected_Click(object sender, EventArgs e)
        {
            String index = FollowedUsersListView.SelectedItems[0].Text;
            //Debug.WriteLine("Seguidos:");
            //Debug.WriteLine(index);


            FollowedUsersListView.SelectedItems[0].SubItems[3].Text = "No Seguido";


            int followedIndex = Convert.ToInt32(index);
            mainMatrix.dejardeSeguirUsuario(currentUser.IDUser, followedIndex);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }






        //IGNORAR ESTO.
        private void FollowUsers_Load(object sender, EventArgs e)
        {

        }

        private void FollowedUsersListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
