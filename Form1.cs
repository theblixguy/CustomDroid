using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexusInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
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
            // Open the next screen
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

    }
}
