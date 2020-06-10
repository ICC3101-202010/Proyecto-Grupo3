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
    public partial class FollowActors : Form
    {

        NPerson currentUser;
        List<Actor> actorList;
        MatrizSeguirActores mainMatrix;


        public FollowActors(NPerson _currentUser, List<Actor> _actorList)
        {
            InitializeComponent();

            this.currentUser = _currentUser;
            this.actorList = _actorList;
            this.mainMatrix = new MatrizSeguirActores();


            followedActorsView.View = View.Details;
            followedActorsView.Columns.Add("ID Actor.");
            followedActorsView.Columns.Add("Nombre Actor.");
            followedActorsView.Columns.Add("Descripcion.");
            followedActorsView.Columns.Add("Seguido.");

            List<bool> seguidosActual = mainMatrix.matrizSeguirActores[currentUser.IDUser];

            for (int i = 0; i < actorList.Count(); i++)
            {

                //Voy mostrando en ListView segun si los sigo o no. 

                if (seguidosActual[i] == true)
                {
                    var item1 = new ListViewItem(new[] { Convert.ToString(actorList[i].IDUser), actorList[i].Name + " " + actorList[i].LastName, actorList[i].Description, "Seguido" });
                    followedActorsView.Items.Add(item1);
                    continue;
                }

                if (seguidosActual[i] == false)
                {
                    var item1 = new ListViewItem(new[] { Convert.ToString(actorList[i].IDUser), actorList[i].Name + " " + actorList[i].LastName, actorList[i].Description, "No Seguido" });
                    followedActorsView.Items.Add(item1);
                }
            }


            if (followedActorsView.Items.Count > 0)
            {
                followedActorsView.MultiSelect = false;
                followedActorsView.Items[0].Selected = true;
                followedActorsView.Select();
            }




        }

        private void followedActorsView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void followActor_Click(object sender, EventArgs e)
        {
            String index = followedActorsView.SelectedItems[0].Text;

            followedActorsView.SelectedItems[0].SubItems[3].Text = "Seguido";

            //Debug.WriteLine("Seguidos:");
            //Debug.WriteLine(index);

            int followedIndex = Convert.ToInt32(index);
            mainMatrix.seguirActor(currentUser.IDUser, followedIndex);
        }

        private void unfollowActor_Click(object sender, EventArgs e)
        {
            String index = followedActorsView.SelectedItems[0].Text;
            //Debug.WriteLine("Seguidos:");
            //Debug.WriteLine(index);

            followedActorsView.SelectedItems[0].SubItems[3].Text = "No Seguido";
            int followedIndex = Convert.ToInt32(index);
            mainMatrix.dejardeSeguirActor(currentUser.IDUser, followedIndex);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
