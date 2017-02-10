using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var location = Properties.Settings.Default.ConanLocation;

            if (Properties.Settings.Default.ConanLocation != "")
            {
                textBox1.Text = "Location: "+Properties.Settings.Default.ConanLocation;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }

            var SelectedPath = fbd.SelectedPath + "\\ConanSandbox\\Config\\DefaultGame.ini";
            Properties.Settings.Default.ConanLocation = SelectedPath;
            Properties.Settings.Default.Save();

            textBox1.Text += "\r\nLocation: " + Properties.Settings.Default.ConanLocation;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.ConanLocation = null;
            Properties.Settings.Default.Save();
            textBox1.Text += "\r\nLocation setting has been deleted";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ConanLocation == "")
            {
                textBox1.Text += "\r\nPlease select a location first!";
            } else {

                ReadWriteIniFileExample.IniFileHelper.DeleteKey("/Script/MoviePlayer.MoviePlayerSettings", "-StartupMovies", System.IO.Path.GetFullPath(Properties.Settings.Default.ConanLocation));
                ReadWriteIniFileExample.IniFileHelper.DeleteKey("/Script/MoviePlayer.MoviePlayerSettings", "+StartupMovies", System.IO.Path.GetFullPath(Properties.Settings.Default.ConanLocation));
                ReadWriteIniFileExample.IniFileHelper.DeleteKey("/Script/MoviePlayer.MoviePlayerSettings", "+StartupMovies", System.IO.Path.GetFullPath(Properties.Settings.Default.ConanLocation));
                ReadWriteIniFileExample.IniFileHelper.DeleteKey("/Script/MoviePlayer.MoviePlayerSettings", "+StartupMovies", System.IO.Path.GetFullPath(Properties.Settings.Default.ConanLocation));

                textBox1.Text += "\r\nDefaulGame.ini should now be edited and the startup movies show now be disabled";
            }
        }
    }
}
