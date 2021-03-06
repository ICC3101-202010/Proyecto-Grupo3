﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3Netify
{
    public partial class MainLoginForm : Form
    {
        //Heredo usuario actual desde el "challenge" de login. 
        public NPerson currentUser;
        public List<NPerson> users;
        MainMenu main;
    

        public MainLoginForm(List<NPerson> users, NPerson currentUser, MainMenu main)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            Debug.WriteLine(currentUser.IDUser);
            Debug.WriteLine(currentUser.Name);
            Debug.WriteLine(currentUser.LastName);
            Debug.WriteLine(currentUser.Email);
            Debug.WriteLine(currentUser.Password);
            Debug.WriteLine(currentUser.Premium);
            Debug.WriteLine(currentUser.Private);
            this.users = users;
            this.main = main;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeDataButton_Click(object sender, EventArgs e)
        {
            ChangeUserDataForm changeData = new ChangeUserDataForm(users, currentUser, this);
            changeData.Show();
            this.Hide();
        }

        private void FollowUsersButton_Click(object sender, EventArgs e)
        {
            FollowUsers fs = new FollowUsers(users, currentUser, this);
            fs.Show();
            this.Hide();
        }

        private void FollowArtistsButton_Click(object sender, EventArgs e)
        {
            List<Actor> actores = Gestor.ActorsLoad();

            FollowActors fa = new FollowActors(currentUser, actores, this);
            fa.Show();
            this.Hide();
        }

        private void followSingersButton_Click(object sender, EventArgs e)
        {
            List<Singer> cantantes = Gestor.SingersLoad();

            FollowSingers fs = new FollowSingers(currentUser, cantantes, this);
            fs.Show();
            this.Hide();
        }

        private void VideoMenuBotton_Click(object sender, EventArgs e)
        {
            VideoMenuForm videoMenu = new VideoMenuForm(users, currentUser, this);
            videoMenu.Show();
            this.Hide();
        }

        private void SongMenuBotton_Click(object sender, EventArgs e)
        {
            SongMenuForm songMenu = new SongMenuForm(users, currentUser, this);
            SongsController songscontroller = new SongsController(songMenu);
            songMenu.Show();
            this.Hide();
        }

        private void MainLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExtrasForm extras = new ExtrasForm(this);
            extras.Show();
            this.Hide();

        }

        private void MainLoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }
    }
}
