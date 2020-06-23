using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Entrega3Netify
{
    public partial class AlarmForm : Form
    {
        public string alarm;
        ExtrasForm extras;

        public AlarmForm(ExtrasForm extras)
        {
            this.extras = extras;
            InitializeComponent();
            for (int i = 0; i < 60; i++) 
            {
                if ((i >= 10) && (i <= 24))
                {
                    HourComboBox.Items.Add(i.ToString());
                    MinuteComboBox.Items.Add(i.ToString());
                }
                else if (i < 10)
                {
                    HourComboBox.Items.Add("0" + i.ToString());
                    MinuteComboBox.Items.Add("0" + i.ToString());
                }
                else 
                {
                    MinuteComboBox.Items.Add(i.ToString());
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            extras.Show();
        }

        private void StartAlarmButton_Click(object sender, EventArgs e)
        {
            if ((MinuteComboBox.SelectedItem == null) || (HourComboBox.SelectedItem == null))
            {
                MessageBox.Show("Porfavor elija una hora y minuto especificos.");
            }
            else
            {
                AlarmTimer.Enabled = true;
                AlarmTimer.Start();
                this.Visible = false;
                extras.Show();

            }
        }

        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            alarm = HourComboBox.SelectedItem.ToString() + ":" + MinuteComboBox.SelectedItem.ToString();
            double alarmtime = TimeSpan.Parse(alarm).TotalMinutes;
            double currentime = DateTime.Now.TimeOfDay.TotalMinutes;
            if ((0 < currentime - alarmtime)&&(currentime-alarmtime<1))
            {
                AlarmTimer.Stop();
                if (this.Visible == false)
                {
                    this.Close();
                }
                MessageBox.Show("Ya es hora!");
            }
        }
    }
}
