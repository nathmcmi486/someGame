using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace someGame
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        void exitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void startButtonClick(object sender, EventArgs e)
        {
            Game gameScreen = new Game(0, 0);
            Form1.changeScreen(this, gameScreen);
        }

        void startLevel2(object sender, EventArgs e)
        {
            Game gameScreen = new Game(0, 1);
            Form1.changeScreen(this, gameScreen);
        }
    }
}
