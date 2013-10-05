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
    public partial class Form5 : Form
    {
        Boolean kfl = false;
        Process process2;
        Process process3;
        public Form5()
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
               * Flashing custom kernel:
               * 
               * WIP
               * 
               */

            if (System.IO.File.Exists("kernel.zip") || System.IO.File.Exists("boot.img"))
            {

                if (kfl == false)
                {

                    // WIP
                }

                else
                {
                    //Open next window
                }
            }

            else
            {
                // MessageBox.Show("The kernel zip/img doesn't exist!", "Error");
                MessageBox.Show("Kernel flashing logic coding is incomplete. Will skip to next window");
                Form6 f6 = new Form6();
                f6.Show();
                this.Close();
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
            Form4 f4 = new Form4();
            f4.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Close();
        }
    }
}
