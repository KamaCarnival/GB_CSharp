using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace les0
{
	public partial class GameForm : Form
	{
        bool isRunning = false;
        bool isOnPause = false;
		public GameForm()
		{
			InitializeComponent();
            label1.Top = this.Height / 2;
            label1.Left = this.Width / 2;
            label1.Visible = false;
		}

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!isRunning && !isOnPause)
            {
                isRunning = true;
                isOnPause = false;
                StartToolStripMenuItem.Text = "Пауза";
                ExitToolStripMenuItem.Text = "Выход в меню";
                label1.Visible = false;
                SplashScreen.timer.Stop();
                SplashScreen.Buffer.Dispose();
                Game.Init(this);
            }
            else if (isRunning && !isOnPause)
            {
                isOnPause = true;
                StartToolStripMenuItem.Text = "Продолжить";
                ExitToolStripMenuItem.Text = "Выход в меню";
                Game.timer.Stop();
                label1.Visible = true;
            }
            else if(isRunning && isOnPause)
            {
                isOnPause = false;
                StartToolStripMenuItem.Text = "Пауза";
                ExitToolStripMenuItem.Text = "Выход в меню";
                label1.Visible = false;
                Game.timer.Start();
            }
            else
            {
                throw new Exception("что-то проглядел");
            }
            
        }


        private void recordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //myFeatureAwesomeCode
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                Application.Exit();
            }
            else
            {
                isRunning = false;
                isOnPause = false;
                label1.Visible = false;
                StartToolStripMenuItem.Text = "Старт";
                ExitToolStripMenuItem.Text = "Выход";
                Game.timer.Stop();
                Game.Buffer.Dispose();
                SplashScreen.Init(this);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
