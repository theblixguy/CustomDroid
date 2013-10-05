using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace NexusInstaller
{
    public partial class Form4 : Form
    {
        Boolean romfl = false;
        Process process2;
        Process process3;
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Terminate the current application instance
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* 
               * Flashing custom ROM:
               * 
               * 1. Check if recovery has already been flashed using the current instance of the installer. If not, then move forward, else open the next screen.
               * 2. Check if the ROM exists in the root folder. If not, then throw error. Else, move forward.
               * 4. Wipe cache and userdata partitions
               * 5. Flash the custom ROMs
               * 
               */

            if (System.IO.File.Exists("rom.zip"))
            {

                if (romfl == false)
                {

                    label5.Visible = true;
                    button2.Enabled = false;
                    pictureBox3.Visible = true;
                    process2 = new Process();
                    process2.StartInfo.FileName = "fastboot.exe";
                    process2.StartInfo.Arguments = "-w";
                    process2.StartInfo.CreateNoWindow = true;
                    process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process2.EnableRaisingEvents = true;
                    process2.Exited += new EventHandler(myProcess_Exited);
                    process2.Start();
                }

                else
                {
                   Form5 f5 = new Form5();
                   f5.Show();
                   this.Close();
                }
            }

            else
            
            {
                MessageBox.Show("The ROM file doesn't exist! Please make sure you rename the ROM's file name to 'rom.zip' and place it in the folder in which the installer is.", "Error");
            }
           
        }

        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            process3 = new Process();
            process3.StartInfo.FileName = "fastboot.exe";
            process3.StartInfo.Arguments = "update rom.zip";
            process3.StartInfo.CreateNoWindow = true;
            process3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process3.EnableRaisingEvents = true;
            process3.Exited += new EventHandler(myProcess_Exited1);
            process3.Start();
        }

        private void myProcess_Exited1(object sender, System.EventArgs e)
        {
            // Tell user the custom ROM has been flashed successfully
            button2.Enabled = true;
            label5.Text = "Custom ROM flashed!";
            pictureBox3.Visible = false;
            romfl = true;

            try
            {
                process2.Kill();
                process3.Kill();
            }
            catch (Exception excp)
            { // Looks like both the processes have been terminated already 
            }
        }

       
        private void Form2_Load(object sender, EventArgs e)
        {
            // Hide the progress indicator and text
            label5.Visible = false;
            pictureBox3.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Go back to previous window
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Skip to next window
            Form5 f5 = new Form5();
            f5.Show();
            this.Close();
        }
    }
}
