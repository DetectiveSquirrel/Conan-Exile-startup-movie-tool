using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = "All done! DefaulGame.ini should now be edited and the startup movies show now be disabled.";
            }

            var SelectedPath = fbd.SelectedPath + "\\ConanSandbox\\Config\\DefaultGame.ini";

            ReadWriteIniFileExample.IniFileHelper.DeleteKey("/Script/MoviePlayer.MoviePlayerSettings", "-StartupMovies", System.IO.Path.GetFullPath(SelectedPath));
            ReadWriteIniFileExample.IniFileHelper.DeleteKey("/Script/MoviePlayer.MoviePlayerSettings", "+StartupMovies", System.IO.Path.GetFullPath(SelectedPath));
            ReadWriteIniFileExample.IniFileHelper.DeleteKey("/Script/MoviePlayer.MoviePlayerSettings", "+StartupMovies", System.IO.Path.GetFullPath(SelectedPath));
            ReadWriteIniFileExample.IniFileHelper.DeleteKey("/Script/MoviePlayer.MoviePlayerSettings", "+StartupMovies", System.IO.Path.GetFullPath(SelectedPath));

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
