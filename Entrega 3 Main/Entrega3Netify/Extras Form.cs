using Snake;
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
    public partial class ExtrasForm : Form
    {
        AlarmForm alarm;
        MainLoginForm mainlog;


        public ExtrasForm(MainLoginForm mainlog)
        {
            InitializeComponent();
            AlarmForm alarm = new AlarmForm(this);
            this.alarm = alarm;
            this.mainlog = mainlog;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            mainlog.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 snake = new Form1(this);
            snake.Show();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (alarm.Visible == false)
            {
                alarm.Visible = true;
            }
            else
            {
                alarm.Show();
            }
        }
    }
}
