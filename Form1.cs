using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;

namespace SeniorGen
{
    public partial class MainWin : Form
    {
        TextFileWriter appBG;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MainWin_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public MainWin()
        {
            InitializeComponent();
            appBG = new TextFileWriter();
            //Next Creates dragable Top Panel. For lame border to be removed.
            DragPanel.MouseDown += new MouseEventHandler(MainWin_MouseDown);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exit button pressed to close the Application.
            /*TODO
             * Check if the project is saved
             * Close every other Window
            */
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //nothing...
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserF = new FolderBrowserDialog();
            browserF.Description = "Select a Folder for saving students data for future use!";
            browserF.ShowDialog();

            appBG.NewFile(browserF.SelectedPath.ToString());
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog browserO = new OpenFileDialog();

            browserO.InitialDirectory = "c:\\";
            browserO.Filter = "SMNW files (*.smnw)|*.smnw|All files (*.*)|*.*";
            browserO.FilterIndex = 2;
            browserO.RestoreDirectory = true;
            browserO.ShowDialog();
            appBG.LoadFile(browserO.FileName.ToString());
        }

        
    }
}
