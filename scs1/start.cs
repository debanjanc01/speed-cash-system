using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scs1
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileToOpen = @"F:\DesignLab\Final Project\readme.txt";
            var process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = fileToOpen
            };

            process.Start();
            process.WaitForExit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login lf = new Login(true);
            lf.Show();
            this.Hide();
        }
    }
}
