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
    public partial class Form2 : Form
    {
        Boolean unlk = false;
        Process process;
        Process process1;
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Terminate the application instance
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* Rebooting phon into bootloader:
             * 
             * 1. First, check if the HTC One bootloader unlock key is present if user selected HTC One from the device list.
             * 2. Throw error if it doesn't. Else, continue forward.
             * 3. Check if bootloader has alrady been unlocked using the current instance of the installer. If yes, then move to next screen.
             * 4. If not, then reboot phone into bootloader mode and wait for 10 seconds for the process to complete.
             * 
             */

            if (comboBox1.SelectedText == "HTC One" | !System.IO.File.Exists("Unlock_code.bin")) { MessageBox.Show("[HTC One] The bootloader unlock key is missing. "); }

            if (unlk == false)
            {
                label5.Visible = true;
                button2.Enabled = false;
                pictureBox3.Visible = true;
                process = new Process();
                process.StartInfo.FileName = Application.StartupPath + "/" + "adb.exe";
                process.StartInfo.Arguments = "reboot bootloader";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                timer1.Start();
            }

            else {
                Form3 f3 = new Form3();
                f3.Show();
                this.Close();
            }
  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            /* It's time to unlock the bootloader: 
             * 
             * 1. Check which device the user has selected and execute the corresponding bootloader unlock command.
             * 2. Wait for 10 seconds for bootloader to reboot, assuming user selected "Yes" in the 
             *    unlock bootloader screen without taking too much time. [Note to self: Requires code rewrite]
             * 3. Disable the previous timer pertaining to adb reboot bootloader.
             * 4. Break
             *
             */

            switch (comboBox1.SelectedText) { 
                case "Nexus 4/7/10":
                Properties.Settings.Default.defphn = "Nexus 4/7/10";
                Properties.Settings.Default.Save();
                process1 = new Process();
                process1.StartInfo.FileName = "fastboot.exe";
                process1.StartInfo.Arguments = "oem unlock";
                process1.StartInfo.CreateNoWindow = true;
                process1.Start();
                timer2.Enabled = true;
                timer1.Enabled = false; 
                break;

                case "Galaxy Nexus":
                Properties.Settings.Default.defphn = "Galaxy Nexus";
                Properties.Settings.Default.Save();
                process1 = new Process();
                 process1.StartInfo.FileName = "fastboot.exe";
                process1.StartInfo.Arguments = "oem unlock";
                process1.StartInfo.CreateNoWindow = true;
                process1.Start();
                timer2.Enabled = true;
                timer1.Enabled = false;
                break;

                case "Nexus S":
                Properties.Settings.Default.defphn = "Nexus S";
                Properties.Settings.Default.Save();
                process1 = new Process();
                process1.StartInfo.FileName = "fastboot.exe";
                process1.StartInfo.Arguments = "oem unlock";
                process1.StartInfo.CreateNoWindow = true;
                process1.Start();
                timer2.Enabled = true;
                timer1.Enabled = false;
                break;

                case "Nexus One":
                Properties.Settings.Default.defphn = "Nexus One";
                Properties.Settings.Default.Save();
                process1 = new Process();
                process1.StartInfo.FileName = "fastboot.exe";
                process1.StartInfo.Arguments = "oem unlock";
                process1.StartInfo.CreateNoWindow = true;
                process1.Start();
                timer2.Enabled = true;
                timer1.Enabled = false;
                break;

                case "HTC One":
                Properties.Settings.Default.defphn = "HTC One";
                Properties.Settings.Default.Save();
                process1 = new Process();
                process1.StartInfo.FileName = "fastboot.exe";
                process1.StartInfo.Arguments = "flash unlocktoken Unlock_code.bin";
                process1.StartInfo.CreateNoWindow = true;
                process1.Start();
                timer2.Enabled = true;
                timer1.Enabled = false;
                break;

            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // Hide the progress indicator and text
            label5.Visible = false;
            pictureBox3.Visible = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Tell user the bootloader has been unlocked 
            label5.Text = "Bootloader successfully unlocked!";
            button2.Enabled = true;
            pictureBox3.Visible = false;
            unlk = true;

            // Just in case the processes are still running in background
            try 
            
            {
                process.Kill();
                process1.Kill();
            }

            catch (Exception excp) {
                // Looks like both the processes have been terminated already 
            }
           
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Go back to root window
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Skip to next window
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }
    }
}
