using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sheduller
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        public static extern void LockWorkStation();

        bool on = false;
        string value = "";
        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "On";
            timer.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (everyHour.Checked)
            {
                value = "hour";
            }
            else if (everyMinute.Checked)
            {
                value = "minute";
            }
         

            if (on)
            {
                button1.Text = "On";
                on = false;

                timer.Enabled = false;
            }
            else
            {
                button1.Text = "Off";
                on = true;

                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Tick += new System.EventHandler(OnTimerEvent);
            }
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            if (value == "hour")
            {
                if (DateTime.Now.Minute == 00 && DateTime.Now.Second == 00)
                {
                    LockWorkStation();
                }
            }

            else if (value == "minute")
            {
                if (DateTime.Now.Second == 00)
                {
                    LockWorkStation();
                }
            }


            listBox1.Items.Add(DateTime.Now.ToLongTimeString() + "," + DateTime.Now.ToLongDateString());
        }
       

        private void sendMessage(string value)
        {
            string message = "Please stand up and go to the walk for 10 minites!!!";
            string caption = "Stand up time every!" + value;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                // Closes the parent form.

                this.Close();

            }
        }
    }
}
