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
    public partial class Form3 : Form
    {
        Boolean flcr = false;
        Process process2;
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Terminate the current application instance
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)

              /* 
               * Flashing recovery:
               * 
               * 1. Get which phone was selected by user in the previous screen.
               * 2. Check if recovery has already been flashed using the current instance of the installer. If not, then move forward, else open the next screen.
               * 3. Check if the recovery files exist. If not, then throw error. Else, move forward.
               * 4. Check device name and execute the corresponding flash recovery command.
               * 5. Wait for the process to complete.
               * 
               */
        {
            string device = Properties.Settings.Default.defphn;

            if (flcr == false)
            {
                if (System.IO.File.Exists("nexus_4_twrp.img") | System.IO.File.Exists("nexus_7_twrp.img") | System.IO.File.Exists("nexus_10_twrp.img") | System.IO.File.Exists("gnexus_twrp.img") | System.IO.File.Exists("nexus_s_twrp.img") | System.IO.File.Exists("nexus_one_twrp.img") | System.IO.File.Exists("htcone_twrp.img"))
                {
                    switch (device)
                    {

                        case "Nexus 4":
                            label5.Visible = true;
                            button2.Enabled = false;
                            pictureBox3.Visible = true;
                            process2 = new Process();
                            process2.StartInfo.FileName = "fastboot.exe";
                            process2.StartInfo.Arguments = "flash recovery nexus_4_twrp.img";
                            process2.StartInfo.CreateNoWindow = true;
                            process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process2.EnableRaisingEvents = true;
                            process2.Exited += new EventHandler(myProcess_Exited);
                            process2.Start();
                            break;

                        case "Nexus 7":
                            label5.Visible = true;
                            button2.Enabled = false;
                            pictureBox3.Visible = true;
                            process2 = new Process();
                            process2.StartInfo.FileName = "fastboot.exe";
                            process2.StartInfo.Arguments = "flash recovery nexus_7_twrp.img";
                            process2.StartInfo.CreateNoWindow = true;
                            process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process2.EnableRaisingEvents = true;
                            process2.Exited += new EventHandler(myProcess_Exited);
                            process2.Start();
                            break;

                        case "Nexus 10":
                            label5.Visible = true;
                            button2.Enabled = false;
                            pictureBox3.Visible = true;
                            process2 = new Process();
                            process2.StartInfo.FileName = "fastboot.exe";
                            process2.StartInfo.Arguments = "flash recovery nexus_10_twrp.img";
                            process2.StartInfo.CreateNoWindow = true;
                            process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process2.EnableRaisingEvents = true;
                            process2.Exited += new EventHandler(myProcess_Exited);
                            process2.Start();
                            break;

                        case "Galaxy Nexus":
                            label5.Visible = true;
                            button2.Enabled = false;
                            pictureBox3.Visible = true;
                            process2 = new Process();
                            process2.StartInfo.FileName = "fastboot.exe";
                            process2.StartInfo.Arguments = "flash recovery gnexus_twrp.img";
                            process2.StartInfo.CreateNoWindow = true;
                            process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process2.EnableRaisingEvents = true;
                            process2.Exited += new EventHandler(myProcess_Exited);
                            process2.Start();
                            break;

                        case "Nexus S":
                            label5.Visible = true;
                            button2.Enabled = false;
                            pictureBox3.Visible = true;
                            process2 = new Process();
                            process2.StartInfo.FileName = "fastboot.exe";
                            process2.StartInfo.Arguments = "flash recovery nexus_s_twrp.img";
                            process2.StartInfo.CreateNoWindow = true;
                            process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process2.EnableRaisingEvents = true;
                            process2.Exited += new EventHandler(myProcess_Exited);
                            process2.Start();
                            break;

                        case "Nexus One":
                            label5.Visible = true;
                            button2.Enabled = false;
                            pictureBox3.Visible = true;
                            process2 = new Process();
                            process2.StartInfo.FileName = "fastboot.exe";
                            process2.StartInfo.Arguments = "flash recovery nexus_one_twrp.img";
                            process2.StartInfo.CreateNoWindow = true;
                            process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process2.EnableRaisingEvents = true;
                            process2.Exited += new EventHandler(myProcess_Exited);
                            process2.Start();
                            break;

                        case "HTC One":
                            label5.Visible = true;
                            button2.Enabled = false;
                            pictureBox3.Visible = true;
                            process2 = new Process();
                            process2.StartInfo.FileName = "fastboot.exe";
                            process2.StartInfo.Arguments = "flash recovery htcone_twrp.img";
                            process2.StartInfo.CreateNoWindow = true;
                            process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process2.EnableRaisingEvents = true;
                            process2.Exited += new EventHandler(myProcess_Exited);
                            process2.Start();
                            break;

                    }
                }

                else
                {
                    MessageBox.Show("The recovery files are missing. Cannot move forward", "Error");
                }
            }

            else
            {
                Form4 f4 = new Form4();
                f4.Show();
                this.Close();
            }

           
        }

        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            // Tell user the custom recovery has been flashed successfully
            button2.Enabled = true;
            label5.Text = "Custom recovery flashed!";
            pictureBox3.Visible = false;
            flcr = true;

            // Just in case the process is still running in background
            try
            
            {
                process2.Kill();
            }
           
            catch (Exception excp)
            { 
                // Looks like the process has been terminated already 
            
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
            Form4 f4 = new Form4();
            f4.Show();
            this.Close();
        }
    }
}
