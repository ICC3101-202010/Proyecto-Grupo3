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
    public partial class FollowSingers : Form
    {
        NPerson currentUser;
        List<Singer> singerList;
        MatrizSeguirCantantes mainMatrix;

        public FollowSingers(NPerson _currentUser, List<Singer> _singerList)
        {
            InitializeComponent();

            this.currentUser = _currentUser;
            this.singerList = _singerList;
            this.mainMatrix = new MatrizSeguirCantantes();


            followSingersView.View = View.Details;
            followSingersView.Columns.Add("ID Cantante.");
            followSingersView.Columns.Add("Nombre Cantante.");
            followSingersView.Columns.Add("Descripcion.");
            followSingersView.Columns.Add("Seguido.");

            List<bool> seguidosActual = mainMatrix.matrizSeguirCantantes[currentUser.IDUser];

            for (int i = 0; i < singerList.Count(); i++)
            {

                //Voy mostrando en ListView segun si los sigo o no. 

                if (seguidosActual[i] == true)
                {
                    var item1 = new ListViewItem(new[] { Convert.ToString(singerList[i].IDUser), singerList[i].Name + " " + singerList[i].LastName, singerList[i].Description, "Seguido" });
                    followSingersView.Items.Add(item1);
                    continue;
                }

                if (seguidosActual[i] == false)
                {
                    var item1 = new ListViewItem(new[] { Convert.ToString(singerList[i].IDUser), singerList[i].Name + " " + singerList[i].LastName, singerList[i].Description, "No Seguido" });
                    followSingersView.Items.Add(item1);
                }
            }


            if (followSingersView.Items.Count > 0)
            {
                followSingersView.MultiSelect = false;
                followSingersView.Items[0].Selected = true;
                followSingersView.Select();
            }




        }

        private void followButton_Click(object sender, EventArgs e)
        {
            String index = followSingersView.SelectedItems[0].Text;

            followSingersView.SelectedItems[0].SubItems[3].Text = "Seguido";

            //Debug.WriteLine("Seguidos:");
            //Debug.WriteLine(index);

            int followedIndex = Convert.ToInt32(index);
            mainMatrix.seguirCantante(currentUser.IDUser, followedIndex);
        }

        private void unfollowButton_Click(object sender, EventArgs e)
        {
            String index = followSingersView.SelectedItems[0].Text;
            //Debug.WriteLine("Seguidos:");
            //Debug.WriteLine(index);

            followSingersView.SelectedItems[0].SubItems[3].Text = "No Seguido";
            int followedIndex = Convert.ToInt32(index);
            mainMatrix.dejardeSeguirCantante(currentUser.IDUser, followedIndex);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void followSingersView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
